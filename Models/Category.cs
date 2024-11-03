namespace China_Tudor_Labb2.Models
{
    public class Category
    {
        public int ID { get; set; }

        public string CategoryName { get; set; }

        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
