using System.ComponentModel.DataAnnotations;

namespace WWWW.Models
{
    public class Client
    {
        // clients class w all nescessary err messages
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]

        public string FullName { get; set; }
        
        

        [Required(ErrorMessage = "Phone Number is required.")]
        [Range(1, int.MaxValue, ErrorMessage = " Phone number must be valid")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Event Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Number of Guests is required.")]
        [Range(1, int.MaxValue, ErrorMessage = " Guests must be at least 1.")]
        [Display(Name = "Number of Guests")]
        public int Guests { get; set; }
        [Required(ErrorMessage = "Deal type is required.")]
        public string Type { get; set; }
        public bool Catering { get; set; }
        public bool Decoration { get; set; }
        public bool Entertainment { get; set; }
    }
}






