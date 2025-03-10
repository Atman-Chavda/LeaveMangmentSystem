using System;
using System.Collections.Generic;

namespace LeaveMangmentSystem.API.Models.Domain;

public partial class LeaveDelegation
{
    public long DelId { get; set; }

    public long RhId { get; set; }

    public long EmpId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime? CreatedDt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? ModifyDt { get; set; }

    public long? ModifyBy { get; set; }

    public virtual Emp? CreatedByNavigation { get; set; }

    public virtual Emp Emp { get; set; } = null!;

    public virtual Emp? ModifyByNavigation { get; set; }

    public virtual Emp Rh { get; set; } = null!;
}
