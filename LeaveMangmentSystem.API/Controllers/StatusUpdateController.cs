using AutoMapper;
using LeaveMangmentSystem.API.Helper;
using LeaveMangmentSystem.API.Models.Domain;
using LeaveMangmentSystem.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveMangmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusUpdateController : ControllerBase
    {
        private readonly LeaveAppDbContext context;
        private readonly IMapper mapper;

        public StatusUpdateController(LeaveAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPatch]
        [Route("updateleavestatus/{id:long}")]
        public async Task<IActionResult> UpdateLeaveStatus([FromRoute] long id, [FromBody] UpdateLeaveStatusDto updateLeaveStatusDto)
        {
            try
            {
                var leave = await context.LeaveApplications.FirstOrDefaultAsync(x => x.LeaveId == id);
                if (leave == null)
                {
                    return BadRequest("leave not found");
                }
                leave.LeaveStatus = updateLeaveStatusDto.UpdateStatus;
                leave.ApproveRemark = updateLeaveStatusDto.Remarks;
                await context.SaveChangesAsync();
                if (updateLeaveStatusDto.UpdateStatus == "approve")
                {
                    var balance = await context.Balances.FirstOrDefaultAsync(x => x.EmpId == leave.EmpId);
                    if (balance == null)
                    {
                        balance = new Balance
                        {
                            EmpId = leave.EmpId,
                            OpeningBalance = 2,
                            LeavesTaken = 0,
                            LeaveId = leave.LeaveId,

                        };

                    }
                    balance.LeavesTaken += 1;
                    await context.Balances.AddAsync(balance);

                    await context.SaveChangesAsync();

                }
                return Ok("leave status updated");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        [Route("updatewfhstatus/{id:long}")]
        public async Task<IActionResult> UpdateWFHStatus([FromRoute] long id, [FromBody] UpdateWFHStatusDto updateWFHStatusDto)
        {
            try
            {
                var wfhTypeIds = await fetchWFHID.GetWFHTypeIdsAsync(context);
                var wfh = await context.WfhOoves
                .Where(w => w.WfhOofid == id && wfhTypeIds.Contains(w.Type))
                .FirstOrDefaultAsync();

                if(wfh==null)
                {
                    return BadRequest("WFH not found");
                }
                
                wfh.Status = updateWFHStatusDto.Status;
                wfh.Remark = updateWFHStatusDto.Remark;
                wfh.ApprovePayCode = "ae21ioa";
                wfh.ApprovedOn = DateTime.UtcNow;
                wfh.ModifyDt = DateTime.UtcNow;
                wfh.ModifyBy = 1; // fetch this from cookie
                await context.SaveChangesAsync();
                if(updateWFHStatusDto.Status=="approve")
                {
                    var balance = await context.Balances
                                 .Where(w => w.EmpId == wfh.EmpId)  
                                 .OrderByDescending(w => w.CreatedDt)  
                                 .FirstOrDefaultAsync();
                    if(balance==null)
                    {
                        balance = new Balance
                        {
                            EmpId = wfh.EmpId,
                            MonthYear = DateTime.UtcNow,
                            Wfhid = wfh.WfhOofid,
                            Qut1WfhRemaining = 5,
                            Qut1WfhTaken = 0,
                            Qut2WfhRemaining = 5,
                            Qut2WfhTaken = 0,
                            Qut3WfhRemaining = 5,
                            Qut3WfhTaken = 0,
                            Qut4WfhRemaining = 5,
                            Qut4WfhTaken = 0,
                        };
                        await context.Balances.AddAsync(balance);

                        await context.SaveChangesAsync();
                    }
                    var month = wfh.CreatedDt.Value.Month;
                    if (month >= 1 && month <= 3)
                    {
                        balance.Qut1WfhTaken += 1;
                        balance.Qut1WfhRemaining -= 1;
                    }
                    if (month >= 4 && month <= 6)
                    {
                        balance.Qut2WfhTaken += 1;
                        balance.Qut2WfhRemaining -= 1;
                    }
                    if (month >= 7 && month <= 9)
                    {
                        balance.Qut3WfhTaken += 1;
                        balance.Qut3WfhRemaining -= 1;
                    }
                    if (month >= 10 && month <= 12)
                    {
                        balance.Qut4WfhTaken += 1;
                        balance.Qut4WfhRemaining -= 1;
                    }
                    balance.CreatedDt = DateTime.UtcNow;
                    await context.SaveChangesAsync();
                    return Ok("WFH request approved");
                }
                else
                {
                    return Ok("WFH request rejected");
                }

                
            }
            catch(Exception ex) 
            { 
                return BadRequest(ex.Message); 
            }
        }
    }
}
