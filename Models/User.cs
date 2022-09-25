namespace Roadmap.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserGroup { get; set; }
        public string EmployeeType { get; set; }
        public string Level { get; set; }
        public string Reviewer { get; set; }
        public bool Active { get; set; }
        
        public User()
        {

        }
    }
}
