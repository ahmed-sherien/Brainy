using System.Collections.Generic;

namespace Brainy.Core
{
    public interface ISkillSelector
    {
        void AssignSkill(string key, IBrainSkill skill);
        IBrainSkill SelectSkill(List<IBrainSkill> skills, IBrainOrder order);
    }
}