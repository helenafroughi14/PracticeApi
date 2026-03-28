using System.ComponentModel.DataAnnotations;

namespace PracticeApi.Models
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Name is required")] //name cant be empty
        [MaxLength(50, ErrorMessage ="Name cannot exceed 50 char" +
            "")] //limit length
        public string Name { get; set; } //added comemnt
    }
}
