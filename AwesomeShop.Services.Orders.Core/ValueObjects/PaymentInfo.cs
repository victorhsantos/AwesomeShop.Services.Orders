using System;

namespace AwesomeShop.Services.Orders.Core.ValueObjects
{
    public class PaymentInfo
    {
        public PaymentInfo(string cardName, string fullName, string expiration, string cvv)
        {
            CardName = cardName;
            FullName = fullName;
            Expiration = expiration;
            Cvv = cvv;
        }

        public string CardName { get; private set; }
        public string FullName { get; private set; }
        public string Expiration { get; private set; }
        public string Cvv { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is PaymentInfo info &&
                   CardName == info.CardName &&
                   FullName == info.FullName &&
                   Expiration == info.Expiration &&
                   Cvv == info.Cvv;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CardName, FullName, Expiration, Cvv);
        }
    }
}
