using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Customer;
using SolarCoffee.Services.Order;
using SolarCoffee.Web.Serialisation;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService,
            ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
            _orderService = orderService;
        }
        
        [HttpPost("/api/invoice")]
        public ActionResult GenerateNewOrder([FromBody] InvoiceModel invoice)
        {
            _logger.LogInformation("Generating invoice");
            var order = OrderMapper.SerialiseInvoiceToOrder(invoice);
            order.Customer = _customerService.GetById(invoice.CustomerId);
            _orderService.GenerateOpenOrder(order);
            return Ok();
        }

        [HttpGet("/api/order")]
        public ActionResult GetOrders()
        {
            var orders = _orderService.GetOrders();
            var orderModels = OrderMapper.SerialiseOrdersToViewModels(orders);
            return Ok(orderModels);
        }

        [HttpPatch("/api/order/complete/{id}")]
        public ActionResult MarkOrderComplete(int id)
        {
            _logger.LogInformation($"Marking order ID: {id} complete");
            _orderService.MarkFulfilled(id);
            return Ok();
        }
    }
}