using Sabu.DTOs.Words;
using Sabu.Entities;

namespace Sabu.DTOs.Games
{
    public class GameStatusDto
    {
        public byte Success { get; set; }
        public byte Fail{ get; set; }
        public byte Skip { get; set; }
        public  Stack<WordForGameDto>Words { get; set; }
        public IEnumerable<int> UsedWordIds { get; set; }
        public int MaxSkipCount { get; set; }
        public int FailCount { get; set; }
    }
}
