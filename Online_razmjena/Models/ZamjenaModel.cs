﻿using Online_razmjena.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Models
{
    public class ZamjenaModel
    {
        
        public int ZamjenaId { get; set; }
        
        public string Nacin { get; set; }

    }
}
