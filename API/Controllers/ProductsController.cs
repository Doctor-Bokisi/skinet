using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Specifications;
using API.DTOs;
using AutoMapper;
using API.Controllers.Errors;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {

        private readonly IGenericRepository<Product> _Productrepo;
        private readonly IGenericRepository<ProductBrand> _ProductBandRepo;
        private readonly IGenericRepository<ProductType> _ProductTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> Productrepo, IGenericRepository<ProductBrand> ProductBandRepo, IGenericRepository<ProductType> ProductTypeRepo, IMapper mapper)
        {
            _mapper = mapper;
            _ProductTypeRepo = ProductTypeRepo;
            _ProductBandRepo = ProductBandRepo;
            _Productrepo = Productrepo;

        }

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<ProductsToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _Productrepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductsToReturnDto>>(products));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _Productrepo.GetEntityWithSpec(spec);

            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return _mapper.Map<Product,ProductsToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var brand = await _ProductBandRepo.ListAllAsync();
            return Ok(brand);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _ProductTypeRepo.ListAllAsync());
        }
    }
}