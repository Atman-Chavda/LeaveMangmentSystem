namespace LeaveMangmentSystem.API.Models.DTO
{
    public class AddLeaveRequestDto
    {
        //public long LeaveId { get; set; }
        public long LeaveType { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string? Reason { get; set; }
    }
}
