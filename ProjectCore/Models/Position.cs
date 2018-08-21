﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ProjectCore.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required, Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
