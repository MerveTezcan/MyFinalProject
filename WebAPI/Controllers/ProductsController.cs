using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //attribute : class ile ilgili bilgi verme ve imzalama yöntemi
    public class ProductsController : ControllerBase
    {
        //Loosely coupled

        //IoC Container(Inversion of Control)
        IProductService _productService;
        
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]//veri tabanındaki verileri çektik
        public IActionResult GetAll()
        {

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }

           return BadRequest(result); 
        }

            [HttpGet("getbyid")]
            public IActionResult GetById(int id)
            {
                var result = _productService.GetById(id);
                if (result.Success)
                {
                return Ok(result.Data);
                }
                return BadRequest(result);
            }
       
        [HttpPost("add")]//veri tabanına veri girdik
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)//result.Succes==true ile aynı anlama gelir.
            {
                return Ok(result);

            }
            return BadRequest(result);
        }



    }
}
