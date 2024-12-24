﻿using Sabu.DTOs.BannedWords;

namespace Sabu.DTOs.Words
{
    public class WordGetDto
    {
        public string Text { get; set; }
        public string LanguageCode { get; set; }
        public List<BannedWordCreateDto> BannedWords { get; set; }
    }
}