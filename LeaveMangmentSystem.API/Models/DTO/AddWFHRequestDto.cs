namespace LeaveMangmentSystem.API.Models.DTO
{
    public class AddWFHRequestDto
    {
        
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public string? Reason { get; set; }
        public long Type { get; set; }  // WFH type ID
        public string? InIp { get; set; }
        public string? OutIp { get; set; }
    }
}
