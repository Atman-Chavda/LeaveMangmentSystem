using System;
using System.Collections.Generic;

namespace LeaveMangmentSystem.API.Models.Domain;

public partial class TypeLookUp
{
    public long LookupId { get; set; }

    public string LookupKey { get; set; } = null!;

    public short LookupCode { get; set; }

    public string LookupValue { get; set; } = null!;

    public string? LookupShortName { get; set; }

    public short? DisplayOrder { get; set; }

    public string? Description { get; set; }

    public bool? Deleted { get; set; }

    public DateTime? CreatedDt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? ModifyDt { get; set; }

    public long? ModifyBy { get; set; }

    public virtual Emp? CreatedByNavigation { get; set; }

    public virtual ICollection<LeaveApplication> LeaveApplicationLeaveTypeNavigations { get; set; } = new List<LeaveApplication>();

    public virtual ICollection<LeaveApplication> LeaveApplicationQldtypeNavigations { get; set; } = new List<LeaveApplication>();

    public virtual Emp? ModifyByNavigation { get; set; }

    public virtual ICollection<WfhOof> WfhOoves { get; set; } = new List<WfhOof>();
}
