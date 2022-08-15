//# nullable disable
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dotNET6_Dapper.Models
{
    public class Stock
    {
        [Required]
        public string Symbol { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        //[Required]
        //public string Name { get; set; } = string.Empty;
        //[Required]
        //public string Description { get; set; } = string.Empty;
        //public decimal Price { get; set; }
        //public bool IsAvailable { get; set; }
        //[Required]
        //public int CategoryId { get; set; }

        //[JsonIgnore]
        //#nullable enable
        //public virtual Category? Category { get; set; } //the ? means nullable
    }
}
