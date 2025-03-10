using LeaveMangmentSystem.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace LeaveMangmentSystem.API.Helper
{
    public class fetchWFHID
    {

        public static async Task<List<long>> GetWFHTypeIdsAsync(LeaveAppDbContext context)
        {
            return await context.TypeLookUps
                .Where(t => t.LookupShortName.Contains("WFH"))
                .Select(t => t.LookupId)
                .ToListAsync();
        }
    }
}
