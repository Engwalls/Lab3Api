using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lab3Api.Models.DTO.Member_DTO
{
    public class MemberUpdateDto
    {
        [Required]
        [StringLength(25)]
        [DisplayName("First name")]
        public string FirstName { get; set; }


        [Required]
        [StringLength(35)]
        [DisplayName("Last name")]
        public string LastName { get; set; }


        [Required]
        [StringLength(12)]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
    }
}
