using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3Api.Models
{
    public class Link
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinkId { get; set; }


        [Required]
        [DisplayName("Url")]
        public string LinkUrl { get; set; }


        [ForeignKey("Interests")]
        public int FK_InterestId { get; set; }
        public virtual Interest Interests { get; set; }
    }
}
