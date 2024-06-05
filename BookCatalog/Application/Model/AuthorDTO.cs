namespace BookCatalog.Application.Model
{
    public class AuthorDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public AuthorDTO(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
