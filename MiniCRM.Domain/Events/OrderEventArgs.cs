using MiniCRM.Domain.Models;
using System;

namespace MiniCRM.Domain.Events
{
    public class OrderEventArgs : EventArgs
    {
        public OrderEventArgs(Order order)
        {
            Order = order ?? throw new ArgumentNullException(nameof(order));
        }

        public Order Order { get; private set; }
    }
}
