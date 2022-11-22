using AwesomeShop.Services.Orders.Core.Entites;
using AwesomeShop.Services.Orders.Core.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AwesomeShop.Services.Orders.Application.Commands
{
    public class AddOrder : IRequest<Guid>
    {
        public CustomerInputModel Customer { get; set; }
        public List<OrderItemInputModel> Items { get; set; }
        public DeliveryAddressInputModel DeliveryAddress { get; set; }
        public PaymentAddressInputModel PaymentAddress { get; set; }
        public PaymentInfoInputModel PaymentInfo { get; set; }

        public Order ToEntity() => new Order(
            new Customer(Customer.Id, Customer.FullName, Customer.Email),
            new DeliveryAddress(DeliveryAddress.Street, DeliveryAddress.Number, DeliveryAddress.City, DeliveryAddress.State, DeliveryAddress.PostalCode, DeliveryAddress.Country),
            new PaymentAddress(PaymentAddress.Street, PaymentAddress.Number, PaymentAddress.City, PaymentAddress.State, PaymentAddress.PostalCode, PaymentAddress.Country),
            new PaymentInfo(PaymentInfo.CardName, PaymentInfo.FullName, PaymentInfo.Expiration, PaymentInfo.Cvv),
            Items.Select(i => new OrderItem(i.ProductId, i.Quantity, i.Price)).ToList());

    }

    public class CustomerInputModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }

    public class OrderItemInputModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }

    public class DeliveryAddressInputModel
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class PaymentAddressInputModel
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class PaymentInfoInputModel
    {
        public string CardName { get; set; }
        public string FullName { get; set; }
        public string Expiration { get; set; }
        public string Cvv { get; set; }
    }
}
