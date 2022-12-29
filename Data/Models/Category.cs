namespace Data.Models
{
    public class Category : BaseEntity
    {
        public Category() => Products = new List<Product>();
        public virtual ICollection<Product> Products { get; set; }
    }
}
