﻿using System.ComponentModel.DataAnnotations;

namespace SimpleMusicStore.Models
{
    public class RecordOrder
    {
        [Required]
        public int RecordId { get; set; }
        public Record Record { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}