namespace Sabu.Exceptions.Words
{
    public class WordTextException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
        public WordTextException()
        {
            ErrorMessage = "Bu soz artiq var";
        }

        public WordTextException(string message) : base(message)
        {
            ErrorMessage = message;
        }

       
    }
}
