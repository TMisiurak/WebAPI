using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required, Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required, Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public Gender Gender { get; set; }

        public Position Position { get; set; }
    }
}
