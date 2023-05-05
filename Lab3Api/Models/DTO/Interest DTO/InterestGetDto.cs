namespace Lab3Api.Models.DTO.Interest_DTO
{
    public class InterestGetDto
    {
        public int InterestId { get; set; }
        public int FK_MemberId { get; set; }
        public string ?Title { get; set; }
        public string ?Description { get; set; }

    }
}
