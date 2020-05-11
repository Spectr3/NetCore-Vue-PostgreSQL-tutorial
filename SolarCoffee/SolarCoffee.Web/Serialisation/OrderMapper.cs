using System;
using System.Collections.Generic;
using System.Linq;
using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Serialisation
{
    /// <summary>
    /// Handles mapping order data models to and from related view models
    /// </summary>
    public class OrderMapper
    {
        /// <summary>
        /// Maps an InvoiceModel to a salesorder data model
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public static SalesOrder SerialiseInvoiceToOrder(InvoiceModel invoice)
        {
            var salesOrderItems = invoice.LineItems
                .Select(item => new SalesOrderItem
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Product = ProductMapper.SerialiseProductModel(item.Product)
                })
                .ToList();
            return new SalesOrder
            {
                SalesOrderItems = salesOrderItems,
                UpdatedOn = DateTime.UtcNow,
                CreatedOn = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Maps a collection of salesorders to ordermodels
        /// </summary>
        /// <returns></returns>
        public static List<OrderModel> SerialiseOrdersToViewModels(IEnumerable<SalesOrder> orders)
        {
            return orders.Select(order => new OrderModel
            {
                Id = order.Id,
                CreatedOn = order.CreatedOn,
                UpdatedOn = order.UpdatedOn,
                SalesOrderItems = SerialiseSalesOrderItems(order.SalesOrderItems),
                Customer = CustomerMapper.SerialiseCustomer(order.Customer),
                IsPaid = order.IsPaid
            }).ToList();
        }

        /// <summary>
        /// Maps a collection of SalesOrderItems to SalesOrderItemModels
        /// </summary>
        /// <param name="orderItems"></param>
        /// <returns></returns>
        public static List<SalesOrderItemModel> SerialiseSalesOrderItems(IEnumerable<SalesOrderItem> orderItems)
        {
            return orderItems.Select(item => new SalesOrderItemModel
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Product = ProductMapper.SerialiseProductModel(item.Product)
            }).ToList();
        }
    }
}