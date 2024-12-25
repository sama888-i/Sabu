using Sabu.DTOs.BannedWords;

namespace Sabu.DTOs.Words
{
    public class WordCreateDto
    { 
        public string Text { get; set; }
        public string LanguageCode { get; set; }
        public HashSet<string> BannedWords { get; set; }
    }
}
