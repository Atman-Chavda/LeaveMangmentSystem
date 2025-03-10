namespace LeaveMangmentSystem.API.Models.DTO
{
    public class BalanceDto
    {
        public long? LeaveId { get; set; }

        public double? OpeningBalance { get; set; }

        public double? ClosingBalance { get; set; }

        public double? LeavesTaken { get; set; }

        public double? Credit { get; set; }

        public long? Wfhid { get; set; }

        public double? Qut1WfhTaken { get; set; }

        public double? Qut1WfhRemaining { get; set; }

        public double? Qut2WfhTaken { get; set; }

        public double? Qut2WfhRemaining { get; set; }

        public double? Qut3WfhTaken { get; set; }

        public double? Qut3WfhRemaining { get; set; }

        public double? Qut4WfhTaken { get; set; }

        public double? Qut4WfhRemaining { get; set; }

        public DateTime? CreatedDt { get; set; }

        public DateTime? ModifyDt { get; set; }
    }
}
