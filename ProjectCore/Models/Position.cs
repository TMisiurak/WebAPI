using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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

        public ICollection<Employee> Employees { get; set; }
    }
}
