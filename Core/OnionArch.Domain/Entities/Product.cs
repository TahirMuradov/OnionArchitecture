using OnionArch.Domain.Entities.Common;

namespace OnionArch.Domain.Entities
{
   public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
