using System;
using Brainy.Core;

namespace Brainy
{
    internal class ExceptionResult : IBrainResult
    {
        private Exception ex;

        public ExceptionResult(Exception ex)
        {
            this.ex = ex;
        }

        public override string ToString()
        {
            return ex.Message;
        }
    }
}