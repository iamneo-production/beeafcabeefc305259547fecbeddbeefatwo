using System;
using System.Collections.Generic;

namespace KathakBookingSystem.Models
{
        public class Class
    {
        public int ClassID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Capacity { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}