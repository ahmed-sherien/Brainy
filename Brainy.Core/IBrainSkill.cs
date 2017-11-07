using Brainy.Core.Help;
using System;

namespace Brainy.Core
{
    public interface IBrainSkill
    {
        IBrainResult Process(IBrainOrder order);
        void AssignOrders(Action<string> assign);
        HelpResult HelpMe();
    }
}
