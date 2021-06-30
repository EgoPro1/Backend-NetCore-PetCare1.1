using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Models;
using PetCare.Domain.Services;
using PetCare.Extensions;
using PetCare.Resources;
using PetCare.Resources.Save;

namespace PetCare.Controllers
{
    [Authorize]
    [Route("api/business/{businessId}/providers/{providerId}/typeproduts/{typeproductId}/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _product;
        private readonly IMapper _mapper;

        public ProductsController(IProductService product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterByTypeProductId(int typeproductId, [FromBody] SaveProductResource saveProductResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var entity = _mapper.Map<SaveProductResource, Product>(saveProductResource);
            var result = await _product.SaveByTypeProductIdAsync(typeproductId, entity);
            if (!result.Success)
                return BadRequest(result.Message);

            var Resource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(Resource);
        }


        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllProductByTypeProductId(int providerId,int typeproductId)
        {
            var products = await _product.ListByTypeProductIdAsync(providerId,typeproductId);
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var productDB = await _product.FindById(productId);


            var productResource = _mapper.Map<Product, ProductResource>(productDB.Product);
            return Ok(productResource);
        }


    }
}