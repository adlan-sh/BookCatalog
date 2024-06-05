using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Application.Request
{
    public class AuthorCreateRequest
    {
        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        [RegularExpression("^[a-zA-Z]+$")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        [RegularExpression("^[a-zA-Z]+$")]
        public string LastName { get; set; }

        public string[] ToArray()
        {
            return new string[] { FirstName, LastName };
        }
    }
}
