using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GenderId { get; set; }

        [Required]
        public int PositionId { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Position Position { get; set; }
    }
}
