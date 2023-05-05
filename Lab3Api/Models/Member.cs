using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3Api.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }

        
        [Required]
        [StringLength(25)]
        [DisplayName("First name")]
        public string FirstName { get; set; }


        [Required]
        [StringLength(35)]
        [DisplayName("Last name")]
        public string LastName { get; set; }


        [Required]
        [StringLength(10)]
        public string SSN { get; set; }


        [Required]
        [StringLength(12)]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }


        public virtual ICollection<Interest> Interests { get; set; }
    }
}
