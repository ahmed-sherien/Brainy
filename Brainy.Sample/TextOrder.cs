using Brainy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brainy.Sample
{
    public class TextOrder : IBrainOrder
    {
        public string Order { get; private set; }

        public List<object> Parameters { get; private set; }

        public Dictionary<string, object> Options { get; private set; }

        public TextOrder(string order, List<string> parameters, Dictionary<string, object> options)
        {
            Order = order;
            Parameters = parameters.Cast<object>().ToList();
            Options = options;
        }
    }
}
