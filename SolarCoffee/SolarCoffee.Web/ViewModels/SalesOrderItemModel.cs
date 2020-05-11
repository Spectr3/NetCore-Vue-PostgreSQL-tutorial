namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// View model for sales order items
    /// </summary>
    public class SalesOrderItemModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductModel Product { get; set; }
    }
}