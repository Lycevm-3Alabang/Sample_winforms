namespace WinForms.Service
{
    public static class InventoryManager
    {
        static ICollection<Product>? _items;

        public static IEnumerable<Product>? GetProducts()
        {
            if (_items == null) _items = [];
            return _items;
        }

        public static void AddProduct(Product item)
        {
            _items ??= [];
            _items.Add(item);
        }


    }
}
