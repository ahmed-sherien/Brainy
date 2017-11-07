using Brainy.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Brainy.Core.Help;

namespace Brainy
{
    internal class StoppingSkill : IBrainSkill
    {
        public void AssignOrders(Action<string> assign)
        {
            assign("stop");
        }

        public HelpResult HelpMe()
        {
            var orders = new OrdersCollection()
                .Add("stop", "stops brain ^_^");
            return new HelpResult(orders);
        }

        public IBrainResult Process(IBrainOrder order)
        {
            return new StoppingResult();
        }
    }
}
