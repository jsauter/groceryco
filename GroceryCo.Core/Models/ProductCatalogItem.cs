namespace GroceryCo.Core.Models
{
    public class ProductCatalogItem : ItemBase
    {
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
    }
}