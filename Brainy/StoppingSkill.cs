using Brainy.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Brainy.Core.Help;
using System.Linq;

namespace Brainy
{
    internal class StoppingSkill : IBrainSkill
    {
        private OrdersCollection _orders;
        public StoppingSkill()
        {
            _orders = new OrdersCollection
            {
                { "stop", "stops brain ^_^" }
            };
        }
        public void AssignOrders(Action<string> assign)
        {
            assign("stop");
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
            return new StoppingResult();
        }
    }
}
