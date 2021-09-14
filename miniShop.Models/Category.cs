using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Models
{
    public class Category : IEntity
    {

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        public int Id { get ; set ; }
    }
}
