using Brainy.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brainy.Sample
{
    public class GreetingSkill : IBrainSkill
    {
        public void AssignOrders(Action<string> assign)
        {
            assign("hi");
            assign("hey");
        }

        public IBrainResult Process(IBrainOrder order)
        {
            return new TextResult($"Brainy: {order.Order}, I'm Brainy");
        }
    }
}
