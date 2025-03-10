using System;
using System.Collections.Generic;

namespace LeaveMangmentSystem.API.Models.Domain;

public partial class Emp
{
    public long EmpId { get; set; }

    public string EmpCode { get; set; } = null!;

    public string EmpName { get; set; } = null!;

    public string EmpEmail { get; set; } = null!;

    public string? EmpPhone { get; set; }

    public string? EmpAddress { get; set; }

    public string? EmpDepartment { get; set; }

    public string? EmpPosition { get; set; }

    public DateTime? HireDate { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedDt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? ModifyDt { get; set; }

    public long? ModifyBy { get; set; }

    public virtual ICollection<Balance> Balances { get; set; } = new List<Balance>();

    public virtual ICollection<LeaveApplication> LeaveApplicationCreatedByNavigations { get; set; } = new List<LeaveApplication>();

    public virtual ICollection<LeaveApplication> LeaveApplicationEmps { get; set; } = new List<LeaveApplication>();

    public virtual ICollection<LeaveDelegation> LeaveDelegationCreatedByNavigations { get; set; } = new List<LeaveDelegation>();

    public virtual ICollection<LeaveDelegation> LeaveDelegationEmps { get; set; } = new List<LeaveDelegation>();

    public virtual ICollection<LeaveDelegation> LeaveDelegationModifyByNavigations { get; set; } = new List<LeaveDelegation>();

    public virtual ICollection<LeaveDelegation> LeaveDelegationRhs { get; set; } = new List<LeaveDelegation>();

    public virtual ICollection<TblemployeeShiftMaster> TblemployeeShiftMasters { get; set; } = new List<TblemployeeShiftMaster>();

    public virtual ICollection<TypeLookUp> TypeLookUpCreatedByNavigations { get; set; } = new List<TypeLookUp>();

    public virtual ICollection<TypeLookUp> TypeLookUpModifyByNavigations { get; set; } = new List<TypeLookUp>();

    public virtual ICollection<WfhOof> WfhOofCreatedByNavigations { get; set; } = new List<WfhOof>();

    public virtual ICollection<WfhOof> WfhOofEmps { get; set; } = new List<WfhOof>();
}
