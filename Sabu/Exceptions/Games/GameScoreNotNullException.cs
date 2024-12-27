namespace Sabu.Exceptions.Games
{
    public class GameScoreNotNullException:Exception,IBaseException 
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
        public GameScoreNotNullException()
        {
            ErrorMessage = "Oyun tamamlanib";
        }

        public GameScoreNotNullException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
