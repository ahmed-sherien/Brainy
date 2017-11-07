using System.Collections.Generic;

namespace Brainy.Core.Help
{
    public class HelpResult : IBrainResult
    {
        public OrdersCollection Orders { get; private set; }
        public HelpResult(OrdersCollection orders)
        {
            Orders = orders;
        }

        public bool Contains(string order)
        {
            return Orders.Contains(order);
        }

        public override string ToString()
        {
            return Orders.ToString();
        }
    }
}