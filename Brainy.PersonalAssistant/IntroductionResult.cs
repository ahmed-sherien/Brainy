using Brainy.Core;

namespace Brainy.PersonalAssistant
{
    internal class IntroductionResult : IBrainResult
    {
        private string _greet;

        public IntroductionResult(string name)
        {
            this._greet = $"Hi {name}, I'm Brainy";
        }

        public override string ToString()
        {
            return _greet;
        }
    }
}