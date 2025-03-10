using System;
using System.Collections.Generic;

namespace LeaveMangmentSystem.API.Models.Domain;

public partial class Balance
{
    public long LogId { get; set; }

    public long EmpId { get; set; }

    public DateTime MonthYear { get; set; }

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

    public virtual Emp Emp { get; set; } = null!;

    public virtual LeaveApplication? Leave { get; set; }

    public virtual WfhOof? Wfh { get; set; }
}
