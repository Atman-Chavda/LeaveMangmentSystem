namespace LeaveMangmentSystem.API.Models.DTO
{
    public class WFHDto
    {
        public long EmpId { get; set; }
        public DateTime DateIn { get; set; }

        public DateTime DateOut { get; set; }
        public DateTime? DateInSubmit { get; set; }

        public DateTime? DateOutSubmit { get; set; }
        public string? Reason { get; set; }

        public string? Status { get; set; }

        public string? ApprovePayCode { get; set; }

        public DateTime? ApprovedOn { get; set; }

        public string? Remark { get; set; }
        public long Type { get; set; }
        public string? InIp { get; set; }

        public string? OutIp { get; set; }
        public double? Wfhcount { get; set; }
        public DateTime? CreatedDt { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? ModifyDt { get; set; }

        public long? ModifyBy { get; set; }
    }
}
