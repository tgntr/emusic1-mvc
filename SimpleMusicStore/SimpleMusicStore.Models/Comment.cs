﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleMusicStore.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        public SimpleUser User { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.UtcNow;
    }
}