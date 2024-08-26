namespace WinForms.Service
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0M;
        public string? Code { get; set; } = string.Empty;
    }

    public static class CartManager
    {

    }
}
