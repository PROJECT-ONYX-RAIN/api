    using ONYX.RAIN.Domain.Catalog;

    namespace ONYX.RAIN.Domain.Orders
    {
        public class OrderItem
        {
            public int Id { get; set; }
            public required Item Item { get; set; }
            public int Quantity {get; set; }
            public decimal Price => Item.Price * Quantity;
        }
        
    }
