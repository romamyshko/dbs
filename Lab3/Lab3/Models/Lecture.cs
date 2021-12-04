using System;
using System.Collections.Generic;

#nullable disable

namespace Lab3.Models
{
    public partial class Lecture
    {
        public int LectureId { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public override string ToString()
        {
            return $"Lecture Id: {LectureId}, name: {Name}, course Id: {CourseId}";
        }
    }
}
