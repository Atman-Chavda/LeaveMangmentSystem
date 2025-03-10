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
    public class CheckBalanceController : ControllerBase
    {
        private readonly LeaveAppDbContext context;
        private readonly IMapper mapper;

        public CheckBalanceController(LeaveAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("emp/{id:long}")]
        public async Task<IActionResult> CheckBalanceEmp([FromRoute] long id)
        {
            try
            {
                var balances = await context.Balances
                .Where(b => b.EmpId == id)
                .OrderByDescending(b => b.MonthYear) 
                .ToListAsync();
                if (balances == null || balances.Count == 0)
                {
                    return NotFound("No balance records found for this employee.");
                }
                return Ok(mapper.Map<List<BalanceDto>>(balances));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> CheckBalanceAdmin()
        {
            try
            {
                var balances = await context.Balances.OrderByDescending(b => b.MonthYear).ToListAsync();
                if(balances == null)
                {
                    return BadRequest("No balance record found");
                }
                return Ok(mapper.Map<List<BalanceDto>>(balances));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
