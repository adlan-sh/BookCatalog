using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Application.Request
{
    public class BookCreateRequest
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public string[] ToArray()
        {
            return new string[] { Title, Description };
        }
    }
}
