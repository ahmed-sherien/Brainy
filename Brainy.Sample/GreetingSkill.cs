using Brainy.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Brainy.Core.Help;
using System.Linq;

namespace Brainy.Sample
{
    public class GreetingSkill : IBrainSkill
    {
        private OrdersCollection _orders;
        public GreetingSkill()
        {
            _orders = new OrdersCollection
            {
                { "hi", "Brainy 'hi's you back" },
                { "hey", "Brainy 'hey's you back" }
            };
        }
        public void AssignOrders(Action<string> assign)
        {
            assign("hi");
            assign("hey");
        }

        public HelpResult HelpMe()
        {
            return new HelpResult(_orders);
        }

        public HelpResult HelpMe(string order)
        {
            return new HelpResult(new OrdersCollection(_orders.Where(o => o.Key.Contains(order))));
        }

        public IBrainResult Process(IBrainOrder order)
        {
            return new TextResult($"Brainy: {order.Order}, I'm Brainy");
        }
    }
}
