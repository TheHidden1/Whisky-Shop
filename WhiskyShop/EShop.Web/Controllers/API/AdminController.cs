using WhiskyShop.Domain.Domain;
using WhiskyShop.Domain.DTO;
using WhiskyShop.Domain.Identity;
using WhiskyShop.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public AdminController (IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("[action]")]
        public List<Order> GetAllOrders()
        {
            return this._orderService.GetAllOrders();
        }
        [HttpPost("[action]")]
        public Order GetDetails(BaseEntity id)
        {
            return this._orderService.GetDetailsForOrder(id);
        }

        [HttpPost("[action]")]
        public bool ImportAllProducts(List<Product> model)
        {
           

            foreach (var item in model)
            {
                

                
                    var product = new Product
                    {
                        ProductName = item.ProductName,
                        ProductDescription = item.ProductDescription,
                        ProductImage = item.ProductImage,
                        Price = item.Price
                    };

                    

               
            }
            return true;
        }

    }
}
