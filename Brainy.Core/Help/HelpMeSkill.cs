using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brainy.Core.Help
{
    public class HelpMeSkill : IBrainSkill
    {
        private IBrain _brain;
        private Dictionary<string, IBrainSkill> _skills;
        private OrdersCollection _orders;
        public HelpMeSkill(IBrain brain)
        {
            _brain = brain;
            _skills = new Dictionary<string, IBrainSkill>();
            _orders = new OrdersCollection();
            _orders.Add("helpme", "prints this info!");
            _orders.Add("helpme allskills", "prints help for all known skills.");
            _orders.Add("helpme <skill>", "prints help for a specific skill.");
        }

        public void AddSkillHelp(string order, IBrainSkill skill)
        {
            _skills.Add(order, skill);
        }
        public void AssignOrders(Action<string> assign)
        {
            assign("helpme");
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
            if (!order.Parameters.Any()) return HelpMe();
            var inquiry = order.Parameters.FirstOrDefault().ToString();
            if (inquiry == "allskills") return new HelpResult(new OrdersCollection(new Dictionary<string, string>(_brain.Skills.Select(s => s.HelpMe()).SelectMany(h => h.Orders))));
            if (!_skills.ContainsKey(inquiry)) throw new BrainException($"I don't know anything about \"{inquiry}\"!");
            var skill = _skills[inquiry];
            return skill.HelpMe(inquiry);
        }
    }
}
