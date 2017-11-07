using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brainy.Core.Help
{
    public class HelpMeSkill : IBrainSkill
    {
        private IBrain _brain;
        public HelpMeSkill(IBrain brain)
        {
            _brain = brain;
        }
        public void AssignOrders(Action<string> assign)
        {
            assign("helpme");
        }

        public HelpResult HelpMe()
        {
            var orders = new OrdersCollection();
            orders.Add("helpme", "prints this info!");
            orders.Add("helpme skills", "prints help for all known skills.");
            orders.Add("helpme <skill>", "prints help for a specific skill.");
            return new HelpResult(orders);
        }

        public IBrainResult Process(IBrainOrder order)
        {
            if (!order.Parameters.Any()) return HelpMe();
            var inquiry = order.Parameters.FirstOrDefault();
            if (inquiry == "skills") return new HelpResult(new OrdersCollection(new Dictionary<string, string>(_brain.Skills.Select(s => s.HelpMe()).SelectMany(h => h.Orders))));
            var skill = _brain.Skills.FirstOrDefault(s => s.HelpMe().Contains(inquiry));
            if (skill == null) throw new BrainException($"I don't know anything about {inquiry}!");
            return skill.HelpMe();
        }
    }
}
