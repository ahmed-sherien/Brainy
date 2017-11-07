using System;

namespace Brainy.Core
{
    [Serializable]
    public class BrainException : Exception
    {
        public BrainException() : base($"Brainy: Unknown Error!")
        {
        }

        public BrainException(string message) : base($"Brainy: {message}")
        {
        }

        public BrainException(string message, Exception innerException) : base($"Brainy: {message}", innerException)
        {
        }
    }
}