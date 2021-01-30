using FirstApplication.Data;
using FirstApplication.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FirstApplication.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //private readonly List<ProductModel> _data = new List<ProductModel>();
        //private readonly DummyDataOld _dummyDataOld;

        private readonly IDatabase _database;

        public ProductsController(IDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        public List<ProductModel> Get()
        {
            return _database.Products.ToList();
        }

        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            var data = _database.Products.FirstOrDefault(c => c.Id == id);
            return data;
        }

        [HttpPost]
        public void Post([FromBody] ProductModel product)
        {
            _database.Products.Add(product);
        }
    }
}