using System.ComponentModel.DataAnnotations;

namespace ManagerRecords.Model
{
    public class RedordeDTO
    {
        [Required(ErrorMessage = "Please enter a user name")]
        [MinLength(5)]
        public string? UserName { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter a record")]
        public Double Number { get; set; }
    }
}
