using System.Collections.Generic;
using System.Linq;

namespace ONYX.RAIN.Domain.Orders
{    
    public class Order
    {
        public int Id { get; set; }
        public required List<OrderItem> Items { get; set; }
        public DateTime CreatedDate {get; set; }
        public decimal TotalPrice => Items.Sum(i => i.Price);
    }


}