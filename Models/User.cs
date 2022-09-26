namespace Roadmap.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Reviewer { get; set; } // will probably get removed
        public bool Active { get; set; }
        
        public User()
        {

        }
    }
}
