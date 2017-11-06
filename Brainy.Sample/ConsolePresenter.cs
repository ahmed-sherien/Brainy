using Brainy.Core;
using System;

namespace Brainy.Sample
{
    public class ConsolePresenter : IBrainPresenter
    {
        public void Present(IBrainResult result)
        {
            Console.WriteLine(result.ToString());
        }
    }
}