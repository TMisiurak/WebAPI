using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCore.Models
{
    public class Gender
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
