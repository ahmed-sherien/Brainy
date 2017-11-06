using Brainy.Core;

namespace Brainy
{
    internal class StoppingResult : IBrainResult
    {
        public override string ToString()
        {
            return "Brain is stopping";
        }
    }
}