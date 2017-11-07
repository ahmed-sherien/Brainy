using Brainy.Core;
using System;
using System.Linq;
using Brainy.Core.Help;

namespace Brainy.PersonalAssistant
{
    public class PersonalAssistantSkill : IBrainSkill
    {
        private OrdersCollection _orders;
        public PersonalAssistantSkill()
        {
            _orders = new OrdersCollection
            {
                { "iam <name>", "introduces your name." },
                { "introduce <name>", "introduces friend's name." }
            };
        }
        public void AssignOrders(Action<string> assign)
        {
            assign("introduce");
            assign("iam");
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
            switch (order.Order)
            {
                case "iam":
                case "introduce":
                    if (order.Parameters.Any())
                    {
                        return new IntroductionResult(order.Parameters.FirstOrDefault().ToString());
                    }
                    else throw new BrainException("You can't introduce me to nothing!");
                default:
                    throw new BrainException($"I forgot how to {order.Order}!");
            }
        }
    }
}
