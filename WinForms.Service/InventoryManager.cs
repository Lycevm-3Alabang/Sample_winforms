namespace WinForms.Service
{
    public static class InventoryManager
    {
        static ICollection<Item>? _items;

        public static ICollection<Item> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = [];
                }

                return _items;
            }
        }


    }

    public class Item
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0M;
        public string? Code { get; set; } = string.Empty;
    }
}
