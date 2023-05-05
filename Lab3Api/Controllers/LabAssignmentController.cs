using AutoMapper;
using Lab3Api.Data;
using Lab3Api.Models;
using Lab3Api.Models.DTO.Interest_DTO;
using Lab3Api.Models.DTO.Link_DTO;
using Lab3Api.Models.DTO.Member_DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabAssignmentController : Controller
    {
        public readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        public LabAssignmentController(IMapper mapper, ApplicationDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }


        //-----------------------------------------------------------------------
        // Uppgift 1
        [HttpPost("Add member")]
        public async Task<ActionResult<MemberCreateDto>> Post([FromBody] MemberCreateDto member)
        {
            var person = mapper.Map<Member>(member);
            await context.Members.AddAsync(person);
            await context.SaveChangesAsync();
            return Ok(member);
        }
        [HttpGet("api/ Get all members")]
        public async Task<ActionResult<IEnumerable<MemberGetDto>>> Get()
        {
            IEnumerable<Member> membersList = await context.Members.ToListAsync();
            var membersDto = mapper.Map<List<MemberGetDto>>(membersList);
            return Ok(membersDto);
        }


        //-----------------------------------------------------------------------
        // Uppgift 2
        [HttpPost("Add interest to member")]
        public async Task<ActionResult<InterestCreateDto>> Post([FromBody] InterestCreateDto newInterest)
        {
            var hobby = mapper.Map<Interest>(newInterest);
            await context.Interests.AddAsync(hobby);
            await context.SaveChangesAsync();
            return Ok(newInterest);
        }



        //-----------------------------------------------------------------------
        // Uppgift 3
        [HttpGet("{memberId}/Get all interests that are connected to the person")]
        public async Task<ActionResult<List<InterestGetDto>>> GetInterests(int memberId)
        {
            var interests = await context.Interests
                .Where(i => i.FK_MemberId == memberId)
                .Select(i => new InterestGetDto
                {
                    InterestId = i.InterestId,
                    Title = i.Title,
                    Description = i.Description,
                    FK_MemberId = i.FK_MemberId
                })
                .ToListAsync();

            if (interests.Count == 0)
            {
                return NotFound();
            }

            return Ok(interests);
        }



        //-----------------------------------------------------------------------
        // Uppgift 4
        [HttpPost("Add a link to an existing interest")]
        public async Task<ActionResult<LinkCreateDto>> Post([FromBody] LinkCreateDto newLinkDto)
        {
            var link = mapper.Map<Link>(newLinkDto);
            await context.Links.AddAsync(link);
            await context.SaveChangesAsync();
            return Ok(newLinkDto);
        }

        [HttpGet("{id}/ Get all links that are connected to the person")]
        public async Task<ActionResult<List<LinkGetDto>>> GetLinks(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var links = await (from l in context.Links
                               join i in context.Interests on l.FK_InterestId equals i.InterestId
                               where i.FK_MemberId == id
                               select l.LinkUrl).ToListAsync();
            return Ok(links);

        }


        //-----------------------------------------------------------------------
        // Uppgift 5
        [HttpPost("{memberId}/interests/{interestId}/Add new links to a specifik person and the specifik interest")]
        public async Task<IActionResult> AddLink(int memberId, int interestId, [FromBody] string linkUrl)
        {
            var interest = await context.Interests.FindAsync(interestId);

            if (interest == null || interest.FK_MemberId != memberId)
            {
                return NotFound();
            }

            var link = new Link
            {
                FK_InterestId = interest.InterestId,
                LinkUrl = linkUrl
            };

            context.Links.Add(link);
            await context.SaveChangesAsync();

            return Ok();
        }



        //-----------------------------------------------------------------------
        // Alternativ kod till uppgift 5
        //[HttpPost("{MemberID}/ Add new links to a specifik person and the specifik interest")]
        //public async Task<IActionResult> AddLink(int MemberID, string addUrl, int InterestID)
        //{
        //    var interest = await context.Interests.FirstOrDefaultAsync(i => i.FK_MemberId == MemberID && i.InterestId == InterestID);

        //    if (interest == null || MemberID == 0)
        //    {
        //        return NotFound();
        //    }

        //    var createLink = new Link
        //    {
        //        FK_InterestId = interest.InterestId,
        //        LinkUrl = addUrl,
        //    };

        //    await context.Links.AddAsync(createLink);
        //    await context.SaveChangesAsync();
        //    return Ok();
        //}

    }
}
