using System.Collections.Generic;

namespace Brainy.Core
{
    public interface IBrainOrder
    {
        string Order { get; }
        List<string> Parameters { get; }
        Dictionary<string, object> Options { get; }
    }
}