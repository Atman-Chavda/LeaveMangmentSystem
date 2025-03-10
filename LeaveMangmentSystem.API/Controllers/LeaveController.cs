using AutoMapper;
using LeaveMangmentSystem.API.Models.Domain;
using LeaveMangmentSystem.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveMangmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly LeaveAppDbContext context;
        private readonly IMapper mapper;

        public LeaveController(LeaveAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var leaves = await context.LeaveApplications.ToListAsync();

                var leavesDto = mapper.Map<List<LeaveApplicationDto>>(leaves);
                return Ok(leavesDto);
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
                var leave = await context.LeaveApplications.FirstOrDefaultAsync(x => x.LeaveId == id);
                if(leave == null)
                {
                    return BadRequest("Leave not found");
                }
                var showLeave = mapper.Map<LeaveApplicationDto>(leave);
                return Ok(showLeave);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> MakeLeaveRequest([FromBody] AddLeaveRequestDto addLeaveRequestDto)
        {
            try
            {
                var leave = mapper.Map<LeaveApplication>(addLeaveRequestDto);
                leave.EmpId = 1;
                leave.CreatedDt = DateTime.UtcNow;
                leave.DateApplication = DateTime.UtcNow;
                leave.LeaveStatus = "Pending";
                leave.RecordStatus = "Active";
                leave.TotalDays = (leave.DateTo - leave.DateFrom).TotalDays + 1;
                await context.LeaveApplications.AddAsync(leave);
                await context.SaveChangesAsync();
                
                return Ok("leave created successfully");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateLeave([FromRoute] long id, [FromBody] UpdateLeaveREquestDto updateDto)
        {
            try
            {
                var leave = await context.LeaveApplications.FirstOrDefaultAsync(x=>x.LeaveId==id);
                if (leave==null)
                {
                    return BadRequest("Leave not found");
                }
                if (updateDto.LeaveType.HasValue) leave.LeaveType = updateDto.LeaveType.Value;
                if (updateDto.DateFrom.HasValue) leave.DateFrom = updateDto.DateFrom.Value;
                if (updateDto.DateTo.HasValue) leave.DateTo = updateDto.DateTo.Value;
                if (!string.IsNullOrEmpty(updateDto.Reason)) leave.Reason = updateDto.Reason;

                if (leave.DateFrom != default && leave.DateTo != default)
                {
                    leave.TotalDays = (leave.DateTo - leave.DateFrom).TotalDays + 1;
                }
                leave.ModifyDt = DateTime.UtcNow;
                await context.SaveChangesAsync();
                return Ok("Leave request updated successfully.");

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet]
        [Route("checkstatus/{id:long}")]
        public async Task<IActionResult> CheckStatus([FromRoute] long id)
        {
            try
            {
                var leave = await context.LeaveApplications.FirstOrDefaultAsync(x => x.LeaveId == id);
                //also will add empId in query once cookies are done
                if (leave == null)
                {
                    return BadRequest("Leave not found");
                }
                var checkDays = leave.TotalDays;
                var checkStatus = leave.LeaveStatus;
                var checkRoStatus = leave.Rostatus;
                var checkCTOStatus = leave.Ctostatus;
                if (checkDays <= 3)
                {
                    if (checkStatus == "approve")
                    {
                        return Ok("Leave is approved");
                    }
                    else if (checkStatus == "reject")
                    {
                        return Ok("Leave is rejected");
                    }
                    else
                    {
                        return Ok("Leave approvel is pending");
                    }
                }
                else
                {
                    if (checkStatus == "approve" && checkCTOStatus == "approve" && checkRoStatus == "approve")
                    {
                        return Ok("Leave is approved");
                    }
                    if (checkStatus == "reject" || checkCTOStatus == "reject" || checkRoStatus == "reject")
                    {
                        return Ok("Leave is rejected");
                    }
                    else
                    {
                        return Ok("Leave approvel is pending");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteLeave([FromRoute] long id)
        {
            try
            {
                var leave = await context.LeaveApplications.FirstOrDefaultAsync(x => x.LeaveId == id);
                if(leave == null)
                {
                    return BadRequest("Leave not found");
                }
                context.Remove(leave);
                await context.SaveChangesAsync();
                return Ok("leave deleted");

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
