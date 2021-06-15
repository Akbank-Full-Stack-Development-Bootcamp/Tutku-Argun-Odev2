using DapperOrnek.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperOrnek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository productRepository;
        public ProductsController()
        {
            productRepository = new ProductRepository();
        }
        //Get All
        [HttpGet]
        [Route("Get")]
        public IList<Product> GetAll()
        {
            return productRepository.GetAll();
        }
        //Get By Id
        [HttpGet]
        [Route("Get/{id}")]
        public Product GetById(int id)
        {
            return productRepository.GetById(id);
        }

        //Insert
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.AddProduct(product);
            }
        }
        //Update 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            product.ProductId = id;
            if (ModelState.IsValid)
            {
                productRepository.Update(product);
            }
        }
        [HttpDelete]
        public void Delete(int id, [FromBody] Product product)
        {
            product.ProductId = id;
            productRepository.Delete(product);
        }
    }
}
