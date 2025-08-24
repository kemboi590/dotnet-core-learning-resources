﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoading.Entities
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchLocation { get; set; }
        public string? BranchPhoneNumber { get; set; }
        public string? BranchEmail { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}

/*
 Relationships:
Students: A Branch can have multiple Students (one-to-many).
Teachers: A Branch can have multiple Teachers (one-to-many).
 */