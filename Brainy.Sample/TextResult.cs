using Brainy.Core;

namespace Brainy.Sample
{
    internal class TextResult : IBrainResult
    {
        private string _text;

        public TextResult(string text)
        {
            this._text = text;
        }

        public override string ToString()
        {
            return _text;
        }
    }
}