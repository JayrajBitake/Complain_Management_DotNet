namespace FinalProject.Models
{
    public class Complain
    {
        public string Category{ get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int Id { get ; set; }
        public List<Complain> Complaininfo { get; set; }



    }
}
