using APIExpreso.Models;
using APIExpreso.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace APIExpresso.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class cProducts : ControllerBase
    {
        private readonly sProducts _sProducts;
         public cProducts(sProducts sProducts)=> _sProducts = sProducts;


        [HttpGet("get_products")]
        public async Task <List<mProductos>> GetProducts()=> await _sProducts.GetProducts();

        [HttpPost("new_product")]
        public async Task<IActionResult> Post(mProductos productos)
        {
            await _sProducts.CreateProduct(productos);

            return CreatedAtAction(nameof(GetProducts), new { id = productos.id }, productos);
        }

    }
}
