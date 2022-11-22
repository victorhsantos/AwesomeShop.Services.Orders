using System;

namespace AwesomeShop.Services.Orders.Core.Entites
{
    public class OrderItem : IEntityBase
    {
        public OrderItem(Guid id, Guid productId, int quantity, decimal price)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
