﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoading.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}

/*
 Relationships:
Teachers: A Subject can have multiple Teachers (one-to-many).
Courses: A Subject can be part of multiple Courses (one-to-many).
 */
