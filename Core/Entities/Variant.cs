namespace Core.Entities
{
    public enum Size
    {
        XS, S, M, L, XL
    }
    public class Variant : BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string PictureUrl { get; set; }
        public bool IsDefault { get; set; }
        public Size Size { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
    }
}
