using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AdminController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("add-product")]
        public async Task<ActionResult<ApiResponse>> AddProducts(ProductToAddDto productModel)
        {
            var product = _mapper.Map<ProductToAddDto, Product>(productModel);
            _unitOfWork.Repository<Product>().Add(product);
            await _unitOfWork.Complete();
            return Ok(new ApiResponse(200));
        }

        [HttpPost("add-variant")]
        public async Task<ActionResult<ApiResponse>> AddVariant(VariantToAddDto variantModel)
        {
            var variant = _mapper.Map<VariantToAddDto, Variant>(variantModel);
            _unitOfWork.Repository<Variant>().Add(variant);
            await _unitOfWork.Complete();
            return Ok(new ApiResponse(200));
        }


    }
}
