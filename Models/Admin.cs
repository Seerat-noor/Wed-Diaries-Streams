using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WWWW.Models
{
    [Table("RegdClients")]
    public class Admin
    {
        // class w all nescessary err messages
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }

        
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        
        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        
        [Display(Name = "Number of Guests")]
        public int Guests { get; set; }
        public decimal Budget { get; set; }

        
        public string Type { get; set; }
        public bool Catering { get; set; }
        public bool Decoration { get; set; }
        public bool Entertainment { get; set; }
        

    }
}






