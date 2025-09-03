namespace Bootcamp_6_10.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double? ProductPrice { get; set; }
        public int CategotyId { get; set; }
        public string? CategotyName { get; set; }
        public int? ProductQTY { get; set; }
    }
}
