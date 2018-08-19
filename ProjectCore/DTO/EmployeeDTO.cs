using System.ComponentModel.DataAnnotations;

namespace ProjectCore
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is requred")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is requred")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "GenderId is requred")]
        public int GenderId { get; set; }

        [Required(ErrorMessage = "PositionId is requred")]
        public int PositionId { get; set; }
    }
}