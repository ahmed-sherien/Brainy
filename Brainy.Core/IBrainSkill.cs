using System;
using System.Collections.Generic;
using System.Text;

namespace Brainy.Core
{
    public interface IBrainSkill
    {
        IBrainResult Process(IBrainOrder order);
        void AssignOrders(Action<string> assign);
    }
}
