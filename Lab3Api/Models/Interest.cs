using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3Api.Models
{
    public class Interest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterestId { get; set; }


        [Required]
        [StringLength(50)]
        public string ?Title { get; set;}


        [Required]
        [StringLength(250)]
        public string ?Description { get; set;}


        [ForeignKey("Members")]
        public int FK_MemberId { get; set; }
        public virtual Member Members { get; set; }


        public virtual ICollection<Link> Links { get; set; }
    }
}
