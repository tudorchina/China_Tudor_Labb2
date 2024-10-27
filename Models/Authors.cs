namespace China_Tudor_Labb2.Models
{
    public class Authors
    {
        public int ID { get; set; }
        public string FirstName { get; set; } public string LastName { get; set; }


        public ICollection<Book>? Books { get; set; }
    }
}
