namespace Sabu.Exceptions.Games
{
    public class GameNotFoundException : Exception, IBaseException 
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }
        public GameNotFoundException()
        {
            ErrorMessage = "Oyun Tapilmadi";
        }

        public GameNotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
