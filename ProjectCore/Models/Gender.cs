using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCore.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; }
    }
}
