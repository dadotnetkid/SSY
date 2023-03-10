namespace SSY.Blazor.HttpClients.Models.Shopify;

public class ShopifyProductModel
{
    public long Id { get; set; }
    /// <summary>
    /// The name of the product. In a shop's catalog, clicking on a product's title takes you to that product's page.
    /// On a product's page, the product's title typically appears in a large font.
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// The description of the product, complete with HTML formatting.
    /// </summary>
    public string BodyHtml { get; set; }

    /// <summary>
    /// The date and time when the product was created. The API returns this value in ISO 8601 format.
    /// </summary>
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time when the product was last modified. The API returns this value in ISO 8601 format.
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// The date and time when the product was published. The API returns this value in ISO 8601 format. 
    /// Set to NULL to unpublish a product
    /// </summary>
    public DateTimeOffset? PublishedAt { get; set; }

    /// <summary>
    /// The name of the vendor of the product.
    /// </summary>
    public string Vendor { get; set; }

    /// <summary>
    /// A categorization that a product can be tagged with, commonly used for filtering and searching.
    /// </summary>
    public string ProductType { get; set; }

    /// <summary>
    /// A human-friendly unique string for the Product automatically generated from its title.
    /// They are used by the Liquid templating language to refer to objects.
    /// </summary>
    public string Handle { get; set; }

    /// <summary>
    /// The suffix of the liquid template being used.
    /// By default, the original template is called product.liquid, without any suffix.
    /// Any additional templates will be: product.suffix.liquid.
    /// </summary>
    public string TemplateSuffix { get; set; }

    /// <summary>
    /// The sales channels in which the product is visible.
    /// </summary>
    public string PublishedScope { get; set; }

    /// <summary>
    /// A categorization that a product can be tagged with, commonly used for filtering and searching.
    /// Each comma-separated tag has a character limit of 255.
    /// </summary>
    public string Tags { get; set; }

    /// <summary>
    /// The status of the product
    /// </summary>
    public string Status { get; set; }


    /// <summary>
    /// A list of variant objects, each one representing a slightly different version of the product.
    /// For example, if a product comes in different sizes and colors, each size and color permutation (such as "small black", "medium black", "large blue"), would be a variant.
    /// To reorder variants, update the product with the variants in the desired order.The position attribute on the variant will be ignored.
    /// </summary>
    public IEnumerable<ProductVariant> Variants { get; set; }
}
public class ProductVariant
{
    /// <summary>
    /// The unique numeric identifier for the product.
    /// </summary>
    public long? ProductId { get; set; }

    /// <summary>
    /// The title of the product variant.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// A unique identifier for the product in the shop.
    /// </summary>
    public string SKU { get; set; }

    /// <summary>
    /// The order of the product variant in the list of product variants. 1 is the first position.
    /// </summary>
    public int? Position { get; set; }

    /// <summary>
    /// The weight of the product variant in grams.
    /// </summary>
    public long? Grams { get; set; }

    /// <summary>
    /// Specifies whether or not customers are allowed to place an order for a product variant when it's out of stock. Known values are 'deny' and 'continue'.
    /// </summary>
    public string InventoryPolicy { get; set; }

    /// <summary>
    /// Service that is doing the fulfillment. Can be 'manual' or any custom string.
    /// </summary>
    public string FulfillmentService { get; set; }

    /// <summary>
    /// The unique identifier for the inventory item, which is used in the Inventory API to query for inventory information.
    /// </summary>
    public long? InventoryItemId { get; set; }

    /// <summary>
    /// Specifies whether or not Shopify tracks the number of items in stock for this product variant. Known values are 'blank' and 'shopify'.
    /// </summary>
    public string InventoryManagement { get; set; }

    /// <summary>
    /// The price of the product variant.
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// The competitors prices for the same item.
    /// </summary>
    public decimal? CompareAtPrice { get; set; }

    /// <summary>
    /// Custom properties that a shop owner can use to define product variants.
    /// </summary>
    public string Option1 { get; set; }

    /// <summary>
    /// Custom properties that a shop owner can use to define product variants.
    /// </summary>
    public string Option2 { get; set; }

    /// <summary>
    /// Custom properties that a shop owner can use to define product variants.
    /// </summary>
    public string Option3 { get; set; }


    /// <summary>
    /// Specifies whether or not a tax is charged when the product variant is sold.
    /// </summary>
    public bool? Taxable { get; set; }

    /// <summary>
    /// Specifies a tax code which is used for Avalara tax integrations
    /// </summary>
    public string TaxCode { get; set; }

    /// <summary>
    /// Specifies whether or not a customer needs to provide a shipping address when placing an order for this product variant.
    /// </summary>
    public bool? RequiresShipping { get; set; }

    /// <summary>
    /// The barcode, UPC or ISBN number for the product.
    /// </summary>
    public string Barcode { get; set; }

    /// <summary>
    /// The number of items in stock for this product variant.
    /// NOTE: After 2018-07-01, this field will be read-only in the Shopify API. Use the `InventoryLevelService` instead.
    /// </summary>
    public long? InventoryQuantity { get; set; }

    /// <summary>
    /// The unique numeric identifier for one of the product's images.
    /// </summary>
    public long? ImageId { get; set; }

    /// <summary>
    /// The weight of the product variant in the unit system specified with weight_unit.
    /// </summary>
    public decimal? Weight { get; set; }

    /// <summary>
    /// The unit system that the product variant's weight is measure in. The weight_unit can be either "g", "kg, "oz", or "lb".
    /// </summary>
    public string WeightUnit { get; set; }

}