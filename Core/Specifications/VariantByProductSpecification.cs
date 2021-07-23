using Core.Entities;

namespace Core.Specifications
{
    public class VariantByProductSpecification : BaseSpecification<Variant>
    {
        public VariantByProductSpecification(int productId) : base(x => x.ProductId == productId)
        {
        }
    }
}
