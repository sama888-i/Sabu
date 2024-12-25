﻿using Sabu.DTOs.BannedWords;

namespace Sabu.DTOs.Words
{
    public class WordGetDto
    {
        public string Text { get; set; }
        public string LanguageCode { get; set; }
        public HashSet<string> BannedWords { get; set; }
    }
}
