using Newtonsoft.Json;

namespace SSY.Blazor.HttpClients.Models.Shopify;

public class CustomCollectionImageModel
{
    /// <summary>
    /// An image attached to a shop's theme returned as Base64-encoded binary data.
    /// </summary>
    public string Attachment { get; set; }

    /// <summary>
    /// Source URL that specifies the location of the image.
    /// </summary>
    public string Src { get; set; }

    /// <summary>
    /// Alternative text that describes the collection image.
    /// </summary>
    public string Alt { get; set; }

    /// <summary>
    /// The date the image was created.
    /// </summary>
    public DateTimeOffset? Created_At { get; set; }

    /// <summary>
    /// Width of the image in pixels.
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    /// Height of the image in pixels.
    /// </summary>
    public int? Height { get; set; }
}