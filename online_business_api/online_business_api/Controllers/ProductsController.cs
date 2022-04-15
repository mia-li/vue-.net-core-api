using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using online_business_api.Models;
using Microsoft.AspNetCore.Cors;

namespace online_business_api.Controllers
{
    [EnableCors("any")]
    [Route("api/[controller]/[action]")] 
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public List<Products> GetProducts()
        {
            List<Products> productList = Products.GetProductList();
            return productList;
        }
        public Products GetProductById(int id)
        {
            Products product = Products.GetProductById(id);
            return product;
        }
        public string AddCart(int productId, int count)
        {
            int rows = ShoppingCart.AddCart(productId, count);
            return rows.ToString();
        }
        public string AddCart1(int id)
        {
            return id.ToString();
        }
    }
}
