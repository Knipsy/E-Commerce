using API.Dtos;
using AutoMapper;
using Core.Entities;
using System.Collections.Generic;

namespace API.Helpers
{
    public class VariantResolver : IValueResolver<Product, ProductToReturnDto, List<VariantToReturnDto>>
    {
        public List<VariantToReturnDto> Resolve(Product source, ProductToReturnDto destination, List<VariantToReturnDto> destMember,
            ResolutionContext context)
        {
            if (source.Variants == null) return null;
            var result = new List<VariantToReturnDto>();
            foreach (var variant in source.Variants)
            {
                result.Add(new VariantToReturnDto
                {
                    Color = variant.Color,
                    IsDefault = variant.IsDefault,
                    PictureUrl = variant.PictureUrl,
                    Quantity = variant.Quantity,
                    Size = (int)variant.Size
                });
            }
            return result;
        }
    }
}
