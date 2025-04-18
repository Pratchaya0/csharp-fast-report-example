﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SimpleFastReport.API.Models
{
    public partial class Shift
    {
        public int ShiftId { get; set; }
        public DateTime ShiftDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int EmployeeId { get; set; }
        public int LocationId { get; set; }
        public string Status { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Location Location { get; set; }
    }
}