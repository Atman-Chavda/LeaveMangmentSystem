using System;
using System.Collections.Generic;

namespace LeaveMangmentSystem.API.Models.Domain;

public partial class LeaveApplication
{
    public long LeaveId { get; set; }

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

    public bool? IsDelete { get; set; }

    public string? RemarksbyAdmin { get; set; }

    public long? Qldtype { get; set; }

    public long? BlpersonId { get; set; }

    public DateTime? EventDate { get; set; }

    public string? BlpersonName { get; set; }

    public string? Rostatus { get; set; }
    public DateTime? RoactionOn { get; set; }

    public string? Roremarks { get; set; }

    public string? RoactionPaycode { get; set; }
    public string? Ctostatus { get; set; }

    public DateTime? CtoactionOn { get; set; }

    public string? Ctoremarks { get; set; }

    public string? CtoactionPaycode { get; set; }

    public DateTime? CreatedDt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? ModifyDt { get; set; }

    public long? ModifyBy { get; set; }

    public virtual ICollection<Balance> Balances { get; set; } = new List<Balance>();

    public virtual Emp? CreatedByNavigation { get; set; }

    public virtual Emp Emp { get; set; } = null!;

    public virtual TypeLookUp LeaveTypeNavigation { get; set; } = null!;

    public virtual TypeLookUp? QldtypeNavigation { get; set; }
}
