﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleMusicStore.Data.Models
{
    public class Video
    {
        public int Id { get; set; }
        
        [Required]
        public string Url { get; set; }

        [Required]
        public int RecordId { get; set; }
        public Record Record { get; set; }
    }
}
