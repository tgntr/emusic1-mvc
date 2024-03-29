﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleMusicStore.Data.Models
{
    public class Label
    {
        public int Id { get; set; }

        [Required]
        public int DiscogsId { get; set; }

        [Required]
        public string Name { get; set; }

        [Url]
        public string ImageUrl { get; set; } = @"https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/12in-Vinyl-LP-Record-Angle.jpg/330px-12in-Vinyl-LP-Record-Angle.jpg";

        public string Description { get; set; }

        public List<Record> Records { get; set; } = new List<Record>();

        public List<LabelUser> Followers { get; set; } = new List<LabelUser>();

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
