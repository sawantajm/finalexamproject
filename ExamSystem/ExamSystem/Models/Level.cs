﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ExamSystem.Models
{
    public partial class Level
    {
        public Level()
        {
            QuestionDetails = new HashSet<QuestionDetail>();
            Subjects = new HashSet<Subject>();
        }

        public int LevelId { get; set; }
        public string LevelName { get; set; }

        public virtual ICollection<QuestionDetail> QuestionDetails { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
