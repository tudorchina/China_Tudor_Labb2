using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace China_Tudor_Labb2.Models
{
    public class Book
    {
        public int ID { get; set; }
        
        [Display(Name = "Book Title")]
        public string Title { get; set; }
        

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int? PublisherID { get; set; }

        public Publisher? Publisher { get; set; }

        public int? AuthorsID { get; set; }  // Cheie străină
        public Authors? Authors { get; set; }  // Proprietate de navigare


    } //navigation property 
}

