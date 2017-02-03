using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class WorkingHour:Entity
    {
        public TimeSpan Time { get; set; }
        public IList<Doctor> Doctors { get; set; }
    }
}