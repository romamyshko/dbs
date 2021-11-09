using System;
using System.Collections.Generic;

#nullable disable

namespace Lab2
{
    public partial class Lecture
    {
        public int LectureId { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
