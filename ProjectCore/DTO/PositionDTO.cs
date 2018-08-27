using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectCore.DTO
{
    public class PositionDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
