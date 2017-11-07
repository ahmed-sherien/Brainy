using System.Collections.Generic;
using Brainy.Core;

namespace Brainy
{
    internal class SkillSelector : ISkillSelector
    {
        private Dictionary<string, IBrainSkill> skillsDictionary;
        public SkillSelector()
        {
            skillsDictionary = new Dictionary<string, IBrainSkill>();
        }

        public void AssignSkill(string key, IBrainSkill skill)
        {
            skillsDictionary.Add(key, skill);
        }

        public IBrainSkill SelectSkill(List<IBrainSkill> skills, IBrainOrder order)
        {
            var key = order.Order;
            if (!skillsDictionary.ContainsKey(key)) throw new BrainException($"I don't know how to \"{key}\"!");
            return skillsDictionary[key];
        }
    }
}