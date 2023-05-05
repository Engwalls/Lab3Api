using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lab3Api.Models.DTO.Link_DTO
{
    public class LinkCreateDto
    {
        public int FK_InterestId { get; set; }


        [Required]
        [DisplayName("Url")]
        public string LinkUrl { get; set; }
    }
}
