using System;
using System.Collections.Generic;

#nullable disable

namespace ExamSystem.Models
{
    public partial class StudentAnswer
    {
        public int? Userid { get; set; }
        public int? Subjectid { get; set; }
        public int? Levelid { get; set; }
        public string StudentResponse { get; set; }
        public string Question { get; set; }

        public virtual Level Level { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Registration User { get; set; }
    }
}
