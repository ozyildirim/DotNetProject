﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // -> Attribute
    public class ProductsController : ControllerBase
    {
        //Loose coupled
        //naming convention
        //IoC Container -- inversion of controller
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger -> hazır dökümantasyonu olan, hazır API
            //Dependecy chain
            var result = _productService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        //[HttpGet("getbyname")]
        //public IActionResult GetByName(String name)
        //{
        //    var result = _productService.GetByName(name);
        //    if(result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

         
    }
}
