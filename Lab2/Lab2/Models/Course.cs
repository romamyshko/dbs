using System;
using System.Collections.Generic;

#nullable disable

namespace Lab2
{
    public partial class Course
    {
        public Course()
        {
            Lectures = new HashSet<Lecture>();
            Subscriptions = new HashSet<Subscription>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
