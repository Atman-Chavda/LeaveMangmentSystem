using System;
using System.Collections.Generic;

namespace LeaveMangmentSystem.API.Models.Domain;

public partial class TblemployeeShiftMaster
{
    public long EmpShiftId { get; set; }

    public long EmpId { get; set; }

    public string Shift { get; set; } = null!;

    public DateTime? CreatedDt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? ModifyDt { get; set; }

    public long? ModifyBy { get; set; }

    public virtual Emp Emp { get; set; } = null!;

    public virtual TblShiftMaster ShiftNavigation { get; set; } = null!;
}
