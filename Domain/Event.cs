﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Working_with_events_api.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Description { get; set; }
        public string Spiker { get; set; }
    }
}
