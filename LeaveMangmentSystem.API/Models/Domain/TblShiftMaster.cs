using System;
using System.Collections.Generic;

namespace LeaveMangmentSystem.API.Models.Domain;

public partial class TblShiftMaster
{
    public long ShiftId { get; set; }

    public string Shift { get; set; } = null!;

    public DateTime Starttime { get; set; }

    public DateTime Endtime { get; set; }

    public DateTime? Lunchtime { get; set; }

    public int? Lunchduration { get; set; }

    public DateTime? Lunchendtime { get; set; }

    public int? Lunchdeduction { get; set; }

    public string? Shiftposition { get; set; }

    public double? Shiftduration { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? ModifyDt { get; set; }

    public long? ModifyBy { get; set; }

    public virtual ICollection<TblemployeeShiftMaster> TblemployeeShiftMasters { get; set; } = new List<TblemployeeShiftMaster>();
}
