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

        private readonly DummyDataOld _dummyDataOld;

        private readonly DummyDataNew _dummyDataNew;


        public ProductsController(DummyDataNew dummyDataNew)
        {
           // _dummyDataOld = DummyDataOld.Instance;

            _dummyDataNew = dummyDataNew;
        }

        [HttpGet]
        public List<ProductModel> Get()
        {

            return _dummyDataNew.Products;
        }

        [HttpGet("{id}")]
        public ProductModel Get( int id)
        {
            var data = _dummyDataNew.Products.FirstOrDefault(c => c.Id == id);
            return data;
        }

        [HttpPost]
        public void Post([FromBody] ProductModel product)
        {
            _dummyDataNew.Products.Add(product);
        }




    }
}
