﻿using System;

namespace MyNotes.Models
{
    public class Note
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string Date { get; set; }
    }
}
