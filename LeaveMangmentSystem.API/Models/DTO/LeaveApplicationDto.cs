namespace LeaveMangmentSystem.API.Models.DTO
{
    public class LeaveApplicationDto
    {
        public long EmpId { get; set; }
        public DateTime? DateApplication { get; set; }

        public long LeaveType { get; set; }

        public double? TotalDays { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public bool? FromFirstHalf { get; set; }

        public bool? FromSecondHalf { get; set; }

        public string? Reason { get; set; }

        public string? ApprovePaycode { get; set; }

        public DateTime? ApproveOn { get; set; }

        public string? LeaveStatus { get; set; }

        public string? ApproveRemark { get; set; }

        public string? RecordStatus { get; set; }

        public string? Contactdetails { get; set; }

        public string? ResponsiblePerson { get; set; }

        public string? CancelRemarks { get; set; }
        public string? RemarksbyAdmin { get; set; }
    }
}
