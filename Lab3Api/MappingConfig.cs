using AutoMapper;
using Lab3Api.Models;
using Lab3Api.Models.DTO.Interest_DTO;
using Lab3Api.Models.DTO.Link_DTO;
using Lab3Api.Models.DTO.Member_DTO;

namespace Lab3Api
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            // Mapping API - Member
            CreateMap<Member, MemberCreateDto>().ReverseMap();
            CreateMap<Member, MemberGetDto>().ReverseMap();
            CreateMap<Member, MemberUpdateDto>().ReverseMap();

            // Mapping API - Interest
            CreateMap<Interest, InterestCreateDto>().ReverseMap();
            CreateMap<Interest, InterestGetDto>().ReverseMap();
            CreateMap<Interest, InterestUpdateDto>().ReverseMap();

            // Mapping API - Link
            CreateMap<Link, LinkCreateDto>().ReverseMap();
            CreateMap<Link, LinkGetDto>().ReverseMap();
            CreateMap<Link, LinkUpdateDto>().ReverseMap();
        }
    }
}
