using Brainy.Core;
using System;
using System.Linq;

namespace Brainy.PersonalAssistant
{
    public class PersonalAssistantSkill : IBrainSkill
    {
        public void AssignOrders(Action<string> assign)
        {
            assign("introduce");
        }

        public IBrainResult Process(IBrainOrder order)
        {
            switch (order.Order)
            {
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
