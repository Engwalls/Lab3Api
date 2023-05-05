using System.ComponentModel.DataAnnotations;

namespace Lab3Api.Models.DTO.Interest_DTO
{
    public class InterestCreateDto
    {
        public int FK_MemberId { get; set; }


        [Required]
        [StringLength(50)]
        public string ?Title { get; set; }


        [Required]
        [StringLength(250)]
        public string ?Description { get; set; }
    }
}
