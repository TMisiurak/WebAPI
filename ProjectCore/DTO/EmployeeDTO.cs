using System;
using System.ComponentModel.DataAnnotations;
using ProjectCore.Models;

namespace ProjectCore
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "GenderId is required")]
        public int GenderId { get; set; }

        [Required(ErrorMessage = "PositionId is required")]
        public int PositionId { get; set; }

        public Position Position { get; set; }
    }
}