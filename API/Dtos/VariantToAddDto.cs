namespace API.Dtos
{
    public class VariantToAddDto
    {
        public int ProductId { get; set; }
        public bool IsDefault { get; set; }
        public string PictureUrl { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
    }
}
