using System;
using System.Collections.Generic;

namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// View model for open orders
    /// </summary>
    public class InvoiceModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CustomerId { get; set; }
        public List<SalesOrderItemModel> LineItems { get; set; }
    }
}