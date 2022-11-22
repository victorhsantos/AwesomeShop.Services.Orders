using System;
using System.Collections.Generic;
using System.Linq;
using AwesomeShop.Services.Orders.Core.Enums;
using AwesomeShop.Services.Orders.Core.Events;
using AwesomeShop.Services.Orders.Core.ValueObjects;

namespace AwesomeShop.Services.Orders.Core.Entites
{
    public class Order : AggregateRoot
    {
        public Order(Customer customer, DeliveryAddress deliveryAddress, PaymentAddress paymentAddress, PaymentInfo paymentInfo, List<OrderItem> items)
        {
            Id = Guid.NewGuid();
            TotalPrice = items.Sum(i => i.Quantity * i.Price);
            Customer = customer;
            DeliveryAddress = deliveryAddress;
            PaymentAddress = paymentAddress;
            PaymentInfo = paymentInfo;
            Items = items;
            CreatedAt= DateTime.Now;
            Status = OrderStatus.Started;

            AddEvent(new OrderCreated(Id, TotalPrice, paymentInfo, Customer.FullName, Customer.Email));
        }

        public decimal TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public PaymentAddress PaymentAddress { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }


        public void SetAsCompleted() => Status = OrderStatus.Completed;
        public void SetAsRejected() => Status = OrderStatus.Rejected;

    }
}
