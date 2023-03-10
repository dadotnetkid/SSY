using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using SSY.Authors;
using SSY.Books;
using SSY.Permissions;

namespace SSY.Inventory.Books;

public class BookAppService :
      CrudAppService<
          Book, //The Book entity
          InfluencerDto, //Used to show books
          Guid, //Primary key of the book entity
          PagedAndSortedResultRequestDto, //Used for paging/sorting
          CreateUpdateBookDto>, //Used to create/update a book
      IBookAppService //implement the IBookAppService
{

    private readonly IAuthorRepository _authorRepository;

    public BookAppService(IAuthorRepository authorRepository,
        IRepository<Book, Guid> repository)
        : base(repository)
    {
        _authorRepository = authorRepository;
        GetPolicyName = SSYPermissions.Books.Default;
        GetListPolicyName = SSYPermissions.Books.Default;
        CreatePolicyName = SSYPermissions.Books.Create;
        UpdatePolicyName = SSYPermissions.Books.Edit;
        DeletePolicyName = SSYPermissions.Books.Delete;
    }

    protected override Task<IQueryable<Book>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
    {
        return base.CreateFilteredQueryAsync(input);
    }

    //public override async Task<InfluencerDto> GetAsync(Guid id)
    //{
    //    //Get the IQueryable<Book> from the repository
    //    var queryable = await Repository.GetQueryableAsync();

    //    //Prepare a query to join books and authors
    //    var query = from book in queryable
    //                join author in await _authorRepository.GetQueryableAsync() on book.AuthorId equals author.Id
    //                where book.Id == id
    //                select new { book, author };

    //    //Execute the query and get the book with author
    //    var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
    //    if (queryResult == null)
    //    {
    //        throw new EntityNotFoundException(typeof(Book), id);
    //    }

    //    var bookDto = ObjectMapper.Map<Book, InfluencerDto>(queryResult.book);
    //    bookDto.AuthorName = queryResult.author.Name;
    //    return bookDto;
    //}

    public override async Task<PagedResultDto<InfluencerDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        //Get the IQueryable<Book> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join books and authors
        var query = from book in queryable
                    join author in await _authorRepository.GetQueryableAsync() on book.AuthorId equals author.Id
                    select new { book, author };

        //Paging
        query = query
            .OrderBy(NormalizeSorting(input.Sorting))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        //Execute the query and get a list
        var queryResult = await AsyncExecuter.ToListAsync(query);

        //Convert the query result to a list of InfluencerDto objects
        var bookDtos = queryResult.Select(x =>
        {
            var bookDto = ObjectMapper.Map<Book, InfluencerDto>(x.book);
            return bookDto;
        }).ToList();

        //Get the total count with another query
        var totalCount = await Repository.GetCountAsync();

        return new PagedResultDto<InfluencerDto>(
            totalCount,
        bookDtos
        );
    }

    public async Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync()
    {
        var authors = await _authorRepository.GetListAsync();

        return new ListResultDto<AuthorLookupDto>(
            ObjectMapper.Map<List<Author>, List<AuthorLookupDto>>(authors)
        );
    }

    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty())
        {
            return $"book.{nameof(Book.Name)}";
        }

        if (sorting.Contains("authorName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "authorName",
                "author.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        return $"book.{sorting}";
    }
}