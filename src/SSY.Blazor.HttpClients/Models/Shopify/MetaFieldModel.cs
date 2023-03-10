namespace SSY.Blazor.HttpClients.Models.Shopify;

public class MetaFieldModel
{
    /// <summary>
    /// The date and time when the metafield was created.
    /// </summary>
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time when the metafield was last updated.
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// Identifier for the metafield (maximum of 30 characters).
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Information to be stored as metadata. Must be either a string or an int.
    /// </summary>
    public object Value { get; set; }

    /// <summary>
    /// The metafield's information type. See https://shopify.dev/apps/metafields/definitions/types for a full list of types.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Container for a set of metadata. Namespaces help distinguish between metadata you created and metadata created by another individual with a similar namespace (maximum of 20 characters).
    /// </summary>
    public string Namespace { get; set; }

    /// <summary>
    /// Additional information about the metafield.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The Id of the Shopify Resource that the metafield is associated with. This value could be the id of things like product, order, variant, collection.
    /// </summary>
    public long? OwnerId { get; set; }

    /// <summary>
    /// The name of the Shopify Resource that the metafield is associated with. This could be things like product, order, variant, collection.
    /// </summary>
    public string OwnerResource { get; set; }
}