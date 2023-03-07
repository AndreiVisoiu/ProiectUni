namespace API.Models
{
    public class Context
    { 
        public String @schema { get; set; }

        public Context(String nume)
        {
            @schema = nume;
        }
    }
}
