using System.ComponentModel.DataAnnotations;

namespace Lab3Api.Models.DTO.Interest_DTO
{
    public class InterestUpdateDto
    {
        [Required]
        [StringLength(50)]
        public string? Title { get; set; }


        [Required]
        [StringLength(250)]
        public string? Description { get; set; }
    }
}
