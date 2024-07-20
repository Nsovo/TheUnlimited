namespace TheUnlimited_Backend_.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryID { get; set; }

        public ProductCategory ProductCategory { get; set; }
        public ICollection<Commission> Commissions { get; set; }
        public ICollection<ProductSales> ProductSales { get; set; }
        public ICollection<Mandate> Mandates { get; set; }

    }
}
