using System;
using System.ComponentModel.DataAnnotations;

namespace SSY.Blazor.HttpClients.Data.CollectionsAndProducts.Product
{
    public class Product
    {
        // Currently consists of the following values:
        // Greige
        // Fabric
        // Trims and Accessories
        // Packaging
        // Others
        // Fields to be displayed will be based on the selected Category.
        // Error message for the required field should be displayed here if the user leaves it as empty.
        // Sample error message: This field is required.
        // Dropdown
        [Required(ErrorMessage = "The Category is required.")]
        public int CategoryId { get; set; }

        // This should be database data
        // Create EF Configuration for the default values
        public List<Category> Categories
        {
            get
            {
                return new()
                {
                    new() { Id = 1, OrderNumber = 1, Name = "Greige" },
                    new() { Id = 2, OrderNumber = 2, Name = "Fabric" },
                    new() { Id = 3, OrderNumber = 3, Name = "Trims and Accessories" },
                    new() { Id = 4, OrderNumber = 4, Name = "Packaging" },
                    new() { Id = 5, OrderNumber = 99, Name = "Others" },
                };
            }
        }

        // Not editable.
        // Auto-generated based on the following fields:
        // Supplier Code
        // Excess
        // Category
        // Color
        // Unique Number
        // Sample displayed value once saved: YTI-PH-CEB-01_E_G_Black_001
        // ReadOnly
        [Required(ErrorMessage = "The Material Name is required.")]
        public string MaterialName { get { return ""; } }


        // Required.
        // Currently consists of the following values:
        // Greige Activewear
        // Greige Jersey
        // Greige Windbreaker
        // Greige Mesh
        // List should be in ascending order by name.
        // No default value for this field.	
        // List is being pulled out from the Settings (will be done of Phase 2. For the meantime, list values are added from the backend).
        // Error message for the required field should be displayed here if the user leaves it as empty.
        // Sample error message: This field is required.
        // Dropdown
        [Required(ErrorMessage = "The Material Type is required.")]
        public MaterialType MaterialType { get; set; }

        // This should be database data
        // Create EF Configuration for the default values
        public List<MaterialType> MaterialTypes
        {
            get
            {
                return new()
                {
                    new() { Id = 1, OrderNumber = 1, Name = "Greige Activewear", CategoryId = 1 },
                    new() { Id = 2, OrderNumber = 2, Name = "Greige Jersey", CategoryId = 1 },
                    new() { Id = 3, OrderNumber = 3, Name = "Greige Mesh", CategoryId = 1 },
                    new() { Id = 4, OrderNumber = 4, Name = "Greige Windbreaker", CategoryId = 1 },

                    new() { Id = 11, OrderNumber = 1, Name = "Activewear", CategoryId = 2 },
                    new() { Id = 12, OrderNumber = 2, Name = "Jersey", CategoryId = 2 },
                    new() { Id = 13, OrderNumber = 3, Name = "Knitwear", CategoryId = 2 },
                    new() { Id = 14, OrderNumber = 4, Name = "Mesh", CategoryId = 2 },
                    new() { Id = 15, OrderNumber = 5, Name = "Sweats", CategoryId = 2 },
                    new() { Id = 16, OrderNumber = 6, Name = "Windbreaker", CategoryId = 2 },
                };
            }
        }
        // Required.
        // Currently consists of the following values:
        // White
        // Yellow
        // Orange
        // Red
        // Pink
        // Purple
        // Blue
        // Green
        // Beige
        // Brown
        // Grey
        // Black
        // List should be in ascending order by name.
        // No default value for this field.
        // List is being pulled out from the Settings > Inventory > Color Type module.
        // Error message for the required field should be displayed here if the user leaves it as empty.
        // Sample error message: This field is required.
        [Required]
        public int ColorId { get; set; }
        public List<Color> Colors
        {
            get
            {
                return new()
                {
                    new() { Id = 1, OrderNumber = 12, Name = "White" },
                    new() { Id = 2, OrderNumber = 11, Name = "Yellow" },
                    new() { Id = 3, OrderNumber = 7, Name = "Orange" },
                    new() { Id = 4, OrderNumber = 10, Name = "Red" },
                    new() { Id = 5, OrderNumber = 8, Name = "Pink" },
                    new() { Id = 6, OrderNumber = 9, Name = "Purple" },
                    new() { Id = 7, OrderNumber = 2, Name = "Blue" },
                    new() { Id = 8, OrderNumber = 5, Name = "Green" },
                    new() { Id = 9, OrderNumber = 1, Name = "Beige" },
                    new() { Id = 10, OrderNumber = 4, Name = "Brown" },
                    new() { Id = 11, OrderNumber = 6, Name = "Grey" },
                    new() { Id = 12, OrderNumber = 3, Name = "Black" },
                };
            }
        }

        // Required.
        // Accepts alphanumeric and special characters.
        // Maximum allowed characters are up to 200 only.
        // System should not accept the succeeding characters if the user reaches the maximum length of characters.
        // Error message for the required field should be displayed here if the user leaves it as empty.
        // Sample error message: This field is required.
        [Required]
        [Range(1, 200)]
        public string ColorCodeOEM { get; set; }

        // Optional.
        // Accepts alphanumeric and special characters.
        // Maximum allowed characters are up to 200 only.
        // System should not accept the succeeding characters if the user reaches the maximum length of characters.
        [Range(0, 200)]
        public string ItemCode { get; set; }

        // Optional.
        // Should be mapped with Hex & RGB # (Equivalent to Hex and RGB #).
        // Sample value: 
        // Accepts alphanumeric and special characters.
        // Maximum allowed characters are up to 200 only.
        // System should not accept the succeeding characters if the user reaches the maximum length of characters.
        [Range(0, 200)]
        public string PantoneNumberTCXCode { get; set; }

        // Required.
        // Currently consists of the following values:
        // Activewear section
        // Leggings
        // Biker Shorts
        // Shorts
        // Bra
        // Fitted Tank
        // Loose Tank
        // Tshirt
        // Hoodie
        // Sweatshirt
        // Jogger
        // Sweatshorts
        // Windbreaker Jacket
        // Windbreaker Running Shorts
        // Jumpsuit
        // Sweats:
        // Hoodie
        // Sweatshirt
        // Jogger
        // Sweatshorts
        // Sweat Cardigan
        // Jersey:
        // Jersey Loose Tank
        // Jersey Tshirt
        // Jersey Jumpsuit
        // Windbreaker:
        // Windbreaker Jacket
        // Windbreaker Running Shorts
        // Windbreaker Pants
        // Mesh:
        // Mesh Loose Tank
        // Mesh Tshirt
        // Knitwear section
        // Lounge Pants
        // Lounge Shirt
        // Lounge Tank
        // Lounge Bra
        // Lounge Dress
        // Lounge Skirt
        // Lounge Shorts
        // Cardigan
        // Sweater
        // Beanie
        // Scarf
        // Values should be displayed in alphabetical order per section.
        // Displayed values will be based on the selected Material Type field.
        // eg: If material type == Mesh, product assignment values should be Mesh Loose Tank, and Mesh Tshirt.
        // List is being pulled out from the Settings > Design > Product Options module.
        // Error message for the required field should be displayed here if the user leaves it as empty.
        // Sample error message: This field is required.
        // Checkbox
        [Required]
        public int AssignmentId { get; set; }
        public List<Assignment> Assignments
        {
            get
            {
                return new()
                {
                    // Activewear section
                    new() { Id = 1, OrderNumber = 1, Name = "Leggings", MaterialTypeId = new int[] {1,11} },
                    new() { Id = 2, OrderNumber = 2, Name = "Biker Shorts", MaterialTypeId = new int[] {1,11} },
                    new() { Id = 3, OrderNumber = 3, Name = "Shorts", MaterialTypeId =  new int[] {1,11} },
                    new() { Id = 4, OrderNumber = 4, Name = "Bra", MaterialTypeId = new int[] {1,11} },
                    new() { Id = 5, OrderNumber = 5, Name = "Fitted Tank", MaterialTypeId = new int[] {1,11} },
                    new() { Id = 6, OrderNumber = 6, Name = "Loose Tank", MaterialTypeId = new int[] {1,11} },
                    new() { Id = 7, OrderNumber = 7, Name = "Tshirt", MaterialTypeId = new int[] {1,11} },
                    new() { Id = 8, OrderNumber = 8, Name = "Sweatshirt", MaterialTypeId =  new int[] {1,11} },
                    new() { Id = 9, OrderNumber = 9, Name = "Jogger", MaterialTypeId =  new int[] {1,11} },
                    new() { Id = 10, OrderNumber = 10, Name = "Sweatshorts", MaterialTypeId =  new int[] {1,11} },
                    new() { Id = 11, OrderNumber = 11, Name = "Windbreaker Jacket", MaterialTypeId =  new int[] {1,11} },
                    new() { Id = 12, OrderNumber = 12, Name = "Windbreaker Running Shorts", MaterialTypeId =  new int[] {1,11} },
                    new() { Id = 13, OrderNumber = 13, Name = "Jumpsuit", MaterialTypeId =  new int[] {1,11} },
                    // Sweats:
                    new() { Id = 14, OrderNumber = 1, Name = "Hoodie", MaterialTypeId =  new int[] {15} },
                    new() { Id = 15, OrderNumber = 2, Name = "Sweatshirt", MaterialTypeId = new int[] {15} },
                    new() { Id = 16, OrderNumber = 3, Name = "Jogger", MaterialTypeId = new int[] {15} },
                    new() { Id = 17, OrderNumber = 4, Name = "Sweatshorts", MaterialTypeId = new int[] {15} },
                    new() { Id = 18, OrderNumber = 5, Name = " Sweat Cardigan", MaterialTypeId = new int[] {15} },
                    // Jersey:
                    new() { Id = 19, OrderNumber = 1, Name = "Jersey Loose Tank", MaterialTypeId = new int[] {2,12} },
                    new() { Id = 20, OrderNumber = 2, Name = "Jersey Tshirt", MaterialTypeId = new int[]{2,12} },
                    new() { Id = 21, OrderNumber = 3, Name = "Jersey Jumpsuit", MaterialTypeId = new int[]{2,12} },
                    // Windbreaker:
                    new() { Id = 22, OrderNumber = 1, Name = "Windbreaker Jacket", MaterialTypeId = new int[] {4,16} },
                    new() { Id = 23, OrderNumber = 2, Name = "Windbreaker Running Shorts", MaterialTypeId = new int[] {4,16} },
                    new() { Id = 24, OrderNumber = 3, Name = "JWindbreaker Pants", MaterialTypeId = new int[] {4,16} },
                    // Mesh:
                    new() { Id = 25, OrderNumber = 1, Name = "Mesh Loose Tank", MaterialTypeId = new int[] {3,14} },
                    new() { Id = 26, OrderNumber = 2, Name = "Mesh Tshirt", MaterialTypeId = new int[] {3,14} },
                    // Knitwear section
                    new() { Id = 27, OrderNumber = 1, Name = "Lounge Pants", MaterialTypeId = new int[] {13} },
                    new() { Id = 28, OrderNumber = 2, Name = "Lounge Shirt", MaterialTypeId = new int[] {13} },
                    new() { Id = 29, OrderNumber = 3, Name = "Lounge Tank", MaterialTypeId = new int[] {13} },
                    new() { Id = 30, OrderNumber = 4, Name = "Lounge Bra", MaterialTypeId = new int[] {13} },
                    new() { Id = 31, OrderNumber = 5, Name = "Lounge Dress", MaterialTypeId = new int[] {13} },
                    new() { Id = 32, OrderNumber = 6, Name = "Lounge Skirt", MaterialTypeId = new int[] {13} },
                    new() { Id = 33, OrderNumber = 7, Name = "Lounge Shorts", MaterialTypeId = new int[] {13} },
                    new() { Id = 34, OrderNumber = 8, Name = "Cardigan", MaterialTypeId = new int[] {13} },
                    new() { Id = 35, OrderNumber = 9, Name = "Sweater", MaterialTypeId = new int[] {13} },
                    new() { Id = 36, OrderNumber = 10, Name = "Beanie", MaterialTypeId = new int[] {13} },
                    new() { Id = 37, OrderNumber = 11, Name = "Scarf", MaterialTypeId = new int[] {13} },
                };
            }
        }

    }
}