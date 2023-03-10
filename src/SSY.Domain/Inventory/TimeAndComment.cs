

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSY.Inventory
{
    /// <summary>
    /// Time and Comment NEED REFACTOR
    /// </summary>
    /// <typeparam name="Guid"></typeparam>
    public class TimeAndComment : FullAuditedAggregateRoot<Guid>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }

        public string NameOfCommentor { get; set; }
        public string Assignedto { get; set; }
        public string Comment { get; set; }
        public string CommentDate { get; set; }
        public string TimeDate { get; set; }
        public string TimeComment { get; set; }

        // Default constructor use by Entity Framework Core don't remove.
        public TimeAndComment()
        {
        }

        public TimeAndComment(string nameofcommentor, string assignedTo, string comment,
                                string commentDate, string timeDate, string timeComment)
        {
            NameOfCommentor = nameofcommentor;
            Assignedto = assignedTo;
            Comment = comment;
            CommentDate = commentDate;
            TimeDate = timeDate;
            TimeComment = timeComment;
        }
    }
}
