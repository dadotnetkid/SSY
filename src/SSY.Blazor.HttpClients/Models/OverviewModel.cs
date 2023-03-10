// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.Text.Json.Serialization;

// namespace SSY.Web.Blazor.Core.Models.Suppliers
// {


//     public class OverviewModel
//     {
//         public int TenantId { get; set; }
//         public bool IsActive { get; set; }

//         public string Name { get; set; }

//         [Required]
//         public int TypeId { get; set; }
//         public Type Type { get; set; }

//         [Required]
//         public int ColorId { get; set; }

//         [Required]
//         public string ColorCode { get; set; }

//         public string? ItemCode { get; set; }
//         public string? Pantone { get; set; }

//         public double? Weight { get; set; }

//         public int? WeightUnitId { get; set; }
        

//         public List<Assignment> Assignments { get; set; }

      
//     }

//       public class Assignment
//     {   
//         public int TenantId { get; set; }
//         public bool IsActive { get; set; }

//         public string Label { get; set; }
//         public string Value { get; set; }
//         public int OrderNumber { get; set; }

//         public List<Type> Types { get; set; }

        
//     }


//     public class Type
//     {
//          public int TenantId { get; set; }
//         public bool IsActive { get; set; }

        
//         public string Label { get; set; }
//         public string Value { get; set; }
//         public int OrderNumber { get; set; }

//         public int CategoryId { get; set; }

//     }
// }