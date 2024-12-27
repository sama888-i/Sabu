namespace Sabu.Exceptions.Languages
{
    public class LanguageNotFoundException:Exception , IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }
        public LanguageNotFoundException()
        {
        ErrorMessage = "Dil movcuddur";
        }

        public LanguageNotFoundException(string message) : base(message)
        {
             ErrorMessage = message;
        }


    }  
}
