using Brainy.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Brainy.Core.Help;

namespace Brainy.Sample
{
    public class GreetingSkill : IBrainSkill
    {
        public void AssignOrders(Action<string> assign)
        {
            assign("hi");
            assign("hey");
        }

        public HelpResult HelpMe()
        {
            var orders = new OrdersCollection()
                .Add("hi", "Brainy 'hi's you back")
                .Add("hey", "Brainy 'hey's you back");
            return new HelpResult(orders);
        }

        public IBrainResult Process(IBrainOrder order)
        {
            return new TextResult($"Brainy: {order.Order}, I'm Brainy");
        }
    }
}
