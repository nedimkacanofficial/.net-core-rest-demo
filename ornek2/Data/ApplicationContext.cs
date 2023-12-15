using ornek2.Models;

namespace ornek2.Data
{
    public static class ApplicationContext
    {
        public static List<Product> Products { get; set; }
        static ApplicationContext()
        {
            Products = new List<Product>()
            {
                new Product { Id = 1, Name = "Kalem", Description = "Kırmızı Kalem", Price = 100 },
                new Product { Id = 2, Name = "Silgi", Description = "Büyük Silgi", Price = 200 },
                new Product { Id = 3, Name = "Defter", Description = "Kareli Defter", Price = 300 }
            };
        }
    }
}
