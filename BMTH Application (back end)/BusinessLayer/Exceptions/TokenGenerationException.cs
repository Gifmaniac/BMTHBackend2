namespace BusinessLayer.Exceptions
{
    public class TokenGenerationException : Exception
    {
        public TokenGenerationException(string message) : base(message) { }
        public TokenGenerationException(string message, Exception inner) : base(message, inner) { }
    }
}

