using Business;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//Attribute
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")] //get işleminde getall ismiyle çağırıcaz.
        public IActionResult GetAll()
        {
            Thread.Sleep(millisecondsTimeout:1000);
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
           
        }

        [HttpGet("getbyid")]//get işleminde parametre istiyoruz. getbyid?id=1 gibi.
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet(template:"getbycategory")]//get işleminde parametre istiyoruz. getbyid?id=1 gibi.
        public IActionResult GetAllByCategoryId(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost(template:"add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
                 
        }
        
    }
}
