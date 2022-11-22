using AwesomeShop.Services.Orders.Core.Events;
using System;
using System.Collections.Generic;

namespace AwesomeShop.Services.Orders.Core.Entites
{
    public class AggregateRoot : IEntityBase
    {
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        public Guid Id { get; protected set; }

        public IEnumerable<IDomainEvent> Events => _events;

        protected void AddEvent(IDomainEvent @event) => _events.Add(@event);
        

    }
}
