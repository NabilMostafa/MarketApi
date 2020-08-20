using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Market.Core.Models
{
    public class Category
    {
        public Category()
        {
            Product = new Collection<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}