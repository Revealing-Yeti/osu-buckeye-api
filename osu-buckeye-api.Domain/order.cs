using System;
using System.Collections.Generic;
using System.Linq;

namespace osu_buckeye_api.Domain.Orders;

public class Order
{
    public int Id { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    public DateTime CreatedDate { get; set; }
    public decimal TotalPrice => Items.Sum(i => i.Price);
}

public class OrderItem
{
    public int Id { get; set; }
    public Item Item { get; set; }
    public int Quantity { get; set; }
    public decimal Price => Item.Price * Quantity;
}