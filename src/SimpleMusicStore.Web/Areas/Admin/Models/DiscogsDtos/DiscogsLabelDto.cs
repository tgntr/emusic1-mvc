﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMusicStore.Web.Areas.Admin.Models.DiscogsDtos
{
    public class DiscogsLabelDto
    {
        public int Id { get; set; }

        public string Profile { get; set; }

        public string Name { get; set; }

        public DiscogsImageDto[] Images { get; set; }
    }
}
