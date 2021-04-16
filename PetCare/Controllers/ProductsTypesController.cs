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
    [Route("api/dashboard/products-types")]
    public class ProductsTypesController : ControllerBase
    {
        private readonly ITypeProductService _typeProductService;
        private readonly IMapper _mapper;

        public ProductsTypesController(ITypeProductService serviTypeService, IMapper mapper)
        {
            _typeProductService = serviTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TypeProductResource>> GetAllTypeProducts()
        {
            var typeProducts = await _typeProductService.ListAsync();
            var resources = _mapper.Map<IEnumerable<TypeProduct>, IEnumerable<TypeProductResource>>(typeProducts);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterTypeProduct( [FromBody] SaveProductTypeResource saveTypeProductResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var serviType = _mapper.Map<SaveProductTypeResource, TypeProduct>(saveTypeProductResource);
            var result = await _typeProductService.SaveAsync(serviType);
            if (!result.Success)
                return BadRequest(result.Message);
            var resource = _mapper.Map<TypeProduct, TypeProductResource>(result.TypeProduct);
            return Ok(resource);
        }
        [HttpGet("{producttypeId}")]
        public async Task<IActionResult> GetProductTypeById(int producttypeId)
        {
            var productType = await _typeProductService.FindByIdAsync(producttypeId);
            

            var productTypeResource = _mapper.Map<TypeProduct, TypeProductResource>(productType.TypeProduct);
            return Ok(productTypeResource);
        }




    }
}