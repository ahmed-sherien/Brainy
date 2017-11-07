using Brainy.Core;
using System;
using System.Linq;
using Brainy.Core.Help;

namespace Brainy.PersonalAssistant
{
    public class PersonalAssistantSkill : IBrainSkill
    {
        public void AssignOrders(Action<string> assign)
        {
            assign("introduce");
            assign("iam");
        }

        public HelpResult HelpMe()
        {
            var orders = new OrdersCollection()
                .Add("iam <name>", "introduces your name.")
                .Add("introduce <name>", "introduces friend's name.");
            return new HelpResult(orders);
        }

        public IBrainResult Process(IBrainOrder order)
        {
            switch (order.Order)
            {
                case "iam":
                case "introduce":
                    if (order.Parameters.Any())
                    {
                        return new IntroductionResult(order.Parameters.FirstOrDefault());
                    }
                    else throw new BrainException("You can't introduce me to nothing!");
                default:
                    throw new BrainException($"I forgot how to {order.Order}!");
            }
        }
    }
}
