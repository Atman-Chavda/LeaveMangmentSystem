using System;
using System.Collections.Generic;

namespace LeaveMangmentSystem.API.Models.Domain;

public partial class WfhOof
{
    public long WfhOofid { get; set; }

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

    public int? MainReasonType { get; set; }

    public double? Wfhcount { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime? CreatedDt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? ModifyDt { get; set; }

    public long? ModifyBy { get; set; }

    public virtual ICollection<Balance> Balances { get; set; } = new List<Balance>();

    public virtual Emp? CreatedByNavigation { get; set; }

    public virtual Emp Emp { get; set; } = null!;

    public virtual TypeLookUp TypeNavigation { get; set; } = null!;
}
