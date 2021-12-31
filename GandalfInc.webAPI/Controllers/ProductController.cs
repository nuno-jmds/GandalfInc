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
        public DataTableResponse GetProductsList()
        {
            Console.WriteLine("GetProductsList");

            var productsList = new List<ProductDto>();

            var sapatilhas = new ProductDto
            {
                Name = "Sapatilhas A21",
                Id = Guid.NewGuid(),
                Reference = "R21521",
                Brand = "Adidas",
                Price = "50",
                Category = "Sport",
                Quantity = "20",
                Active = true


            };
            var sapatilhas2 = new ProductDto
            {
                Name = "Sapatilhas A21",
                Id = Guid.NewGuid(),
                Reference = "R21521",
                Brand = "Adidas",
                Price = "50",
                Category = "Sport",
                Quantity = "20",
                Active = true


            };

            productsList.Add(sapatilhas);
            productsList.Add(sapatilhas2);
            productsList.Add(sapatilhas);
            productsList.Add(sapatilhas2);
            productsList.Add(sapatilhas);
            productsList.Add(sapatilhas);
            productsList.Add(sapatilhas);
            productsList.Add(sapatilhas);
            productsList.Add(sapatilhas);
            productsList.Add(sapatilhas);
            productsList.Add(sapatilhas);
            productsList.Add(sapatilhas);
            productsList.Add(sapatilhas);
            productsList.Add(sapatilhas);

            var productsTable= new DataTableResponse();

            productsTable.Data = productsList.ToArray();
            
            return productsTable;
        }

        [HttpGet]
        [Route("api/[controller]/ById")]
        public ProductDto GetProductById(Guid id) {

            Console.WriteLine(id);
        return new ProductDto
        {
            Name = "Sapatilhas A21",
            Id = Guid.NewGuid(),
            Reference = "Ref="+id,
            Brand = "Adidas",
            Price = "50",
            Category = "Sport",
            Quantity = "20",
            Active = true


        };
        }

        [HttpPost]
        public void PostNewProduct(ProductDto product)
        {
            Console.WriteLine($"PostNewProduct:\n " +
                $"{product.Name} \n " +
                $"{product.Reference} \n " +   
                $"{product.Brand} \n " +
                $"{product.Category} \n " +
                $"{product.Quantity} \n " +
                $"{product.Price} \n"+
                $"{product.Active} \n " 
                );


        }

        [HttpPut]
        public bool UpdateProduct(Guid id, ProductDto product) {

            Console.WriteLine($"UpdateProduct:\n " +
    $"{product.Name} \n " +
    $"{product.Id} \n " +
    $"{product.Reference} \n " +
    $"{product.Brand} \n " +
    $"{product.Category} \n " +
    $"{product.Quantity} \n " +
    $"{product.Price} \n" +
    $"{product.Active} \n "
    );
            return false;
        }


    }
}
