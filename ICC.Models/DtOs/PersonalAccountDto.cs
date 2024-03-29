﻿using System;

namespace ICC.Models.DtOs
{
    public class PersonalAccountDto
    {
        public int Id { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string AccountNum { get; set; }
        public string Address { get; set; }
        public int Square { get; set; }
        public string Residents { get; set; }
    }
}
