using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCore.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
