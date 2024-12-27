namespace Sabu.DTOs.Games
{
    public class GameResultDto
    {
        public int? Score { get; set; }
        public int? SuccessAnswer { get; set; }
        public int? WrongAnswer { get; set; }
        public string LanguageCode { get; set; }
    }
}
