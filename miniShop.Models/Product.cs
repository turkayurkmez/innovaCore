using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Models
{
   public class Product : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanını doldurunuz")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int? StockCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        public double? Discount { get; set; } = 0;


        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
    }
}
