using System;

namespace AwesomeShop.Services.Orders.Core.ValueObjects
{
    public class PaymentAddress
    {
        public PaymentAddress(string street, string number, string city, string state, string postalCode, string country)
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is DeliveryAddress address &&
                   Street == address.Street &&
                   Number == address.Number &&
                   City == address.City &&
                   State == address.State &&
                   PostalCode == address.PostalCode &&
                   Country == address.Country;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, Number, City, State, PostalCode, Country);
        }
    }
}
