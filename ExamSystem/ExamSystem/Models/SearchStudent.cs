using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamSystem.Models
{
    public class SearchStudent
    {
        public string SubjectName { get; set; }
        public string LevelName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int? MarksObtained { get; set; }
    }
}
