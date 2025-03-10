using AutoMapper;
using LeaveMangmentSystem.API.Helper;
using LeaveMangmentSystem.API.Models.Domain;
using LeaveMangmentSystem.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveMangmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WFHController : ControllerBase
    {
        private readonly LeaveAppDbContext context;
        private readonly IMapper mapper;

        public WFHController(LeaveAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                //var wfhTypeIds = await fetchWFHId();

                var wfhTypeIds = await fetchWFHID.GetWFHTypeIdsAsync(context);

                //var wfhTypeIds = await context.TypeLookUps
                //.Where(t => t.LookupShortName.Contains("WFH"))
                //.Select(t => t.LookupId)
                //.ToListAsync();

                var wfhs = await context.WfhOoves
                .Where(w => wfhTypeIds.Contains(w.Type))
                .ToListAsync();


                var wfhDomain = mapper.Map<List<WFHDto>>(wfhs);

                return Ok(wfhDomain);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            try
            {
                var wfhTypeIds = await fetchWFHID.GetWFHTypeIdsAsync(context);
                var wfh = await context.WfhOoves
                .Where(w => w.WfhOofid == id && wfhTypeIds.Contains(w.Type))
                .FirstOrDefaultAsync();

                if (wfh == null)
                {
                    return NotFound("WFH does not exist");
                }
                var wfhDomain = mapper.Map<WFHDto>(wfh);
                return Ok(wfhDomain);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateWFH([FromBody] AddWFHRequestDto addWFHRequestDto)
        {
            try
            {
                var wfh = mapper.Map<WfhOof>(addWFHRequestDto);
                wfh.EmpId = 1;
                wfh.CreatedDt = DateTime.Now;
                wfh.CreatedBy = wfh.EmpId;
                wfh.Status = "panding";
                wfh.IsDelete = false;
                await context.WfhOoves.AddAsync(wfh);
                await context.SaveChangesAsync();
                //return Ok(mapper.Map<WFHDto>(wfh));
                return Ok("WFH created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateWFH([FromRoute] long id, [FromBody] UpdateWFHDto updateDto)
        {
            try
            {
                var wfhTypeIds = await fetchWFHID.GetWFHTypeIdsAsync(context);

                var wfh = await context.WfhOoves
                .Where(w => w.WfhOofid == id && wfhTypeIds.Contains(w.Type))
                .FirstOrDefaultAsync();

                if (wfh == null)
                {
                    return NotFound("WFH does not exist");
                }

                if (updateDto.DateIn != default) wfh.DateIn = updateDto.DateIn;
                if (updateDto.DateOut != default) wfh.DateOut = updateDto.DateOut;
                if (!string.IsNullOrEmpty(updateDto.Reason)) wfh.Reason = updateDto.Reason;
                if (updateDto.Type != default) wfh.Type = updateDto.Type;
                if (!string.IsNullOrEmpty(updateDto.InIp)) wfh.InIp = updateDto.InIp;
                if (!string.IsNullOrEmpty(updateDto.OutIp)) wfh.OutIp = updateDto.OutIp;

                wfh.ModifyDt = DateTime.UtcNow;
                wfh.ModifyBy = 1;

                await context.SaveChangesAsync();
                return Ok("WFH updated ");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteWFH([FromRoute] long id)
        {
            try
            {
                var wfhTypeIds = await fetchWFHID.GetWFHTypeIdsAsync(context);

                var wfh = await context.WfhOoves
                .Where(w => w.WfhOofid == id && wfhTypeIds.Contains(w.Type))
                .FirstOrDefaultAsync();

                if (wfh == null)
                {
                    return NotFound("WFH does not exist");
                }
                context.Remove(wfh);
                await context.SaveChangesAsync();
                return Ok("WFH Deleted");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
