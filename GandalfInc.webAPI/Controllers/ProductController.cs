using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GandalfInc.webAPI.DTO;


namespace GandalfInc.webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        [HttpGet]
        public void GetProductsList()
        {
            Console.WriteLine("GetProductsList");


        }

        [HttpPost]
        public void PostNewProduct(ProductDto product)
        {
            Console.WriteLine($"PostNewProduct {product.Nome}");


        }


    }
}
