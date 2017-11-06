using Brainy.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brainy
{
    internal class StoppingSkill : IBrainSkill
    {
        public void AssignOrders(Action<string> assign)
        {
            assign("stop");
        }

        public IBrainResult Process(IBrainOrder order)
        {
            return new StoppingResult();
        }
    }
}
