namespace TheUnlimited_Backend_.Models
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Commission> Commissions { get; set; }
    }
}
