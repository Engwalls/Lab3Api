using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lab3Api.Models.DTO.Link_DTO
{
    public class LinkUpdateDto
    {
        [Required]
        [DisplayName("Url")]
        public string LinkUrl { get; set; }
    }
}
