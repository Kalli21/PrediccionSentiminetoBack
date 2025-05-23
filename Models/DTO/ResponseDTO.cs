﻿namespace PrediccionSentiminetoBack.Models.DTO
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; } = true;
        public object? Result { get; set; }
        public string? DisplayMessage { get; set; }
        public List<string>? ErrorMessages { get; set; }
        public object? FiltroInfo { get; set; }
    }
}
