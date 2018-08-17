﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProjectCore.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
