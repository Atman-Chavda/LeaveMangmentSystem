using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LeaveMangmentSystem.API.Models.Domain;

public partial class LeaveAppDbContext : DbContext
{
    public LeaveAppDbContext()
    {
    }

    public LeaveAppDbContext(DbContextOptions<LeaveAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Balance> Balances { get; set; }

    public virtual DbSet<Emp> Emps { get; set; }

    public virtual DbSet<LeaveApplication> LeaveApplications { get; set; }

    public virtual DbSet<LeaveDelegation> LeaveDelegations { get; set; }

    public virtual DbSet<TblShiftMaster> TblShiftMasters { get; set; }

    public virtual DbSet<TblemployeeShiftMaster> TblemployeeShiftMasters { get; set; }

    public virtual DbSet<TypeLookUp> TypeLookUps { get; set; }

    public virtual DbSet<WfhOof> WfhOoves { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Balance>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Balance__7839F64DA23601CF");

            entity.ToTable("Balance");

            entity.Property(e => e.LogId).HasColumnName("logId");
            entity.Property(e => e.ClosingBalance).HasColumnName("closingBalance");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.LeavesTaken).HasColumnName("leavesTaken");
            entity.Property(e => e.ModifyDt).HasColumnType("datetime");
            entity.Property(e => e.MonthYear)
                .HasColumnType("datetime")
                .HasColumnName("monthYear");
            entity.Property(e => e.OpeningBalance).HasColumnName("openingBalance");
            entity.Property(e => e.Qut1WfhRemaining).HasColumnName("qut1_wfh_remaining");
            entity.Property(e => e.Qut1WfhTaken).HasColumnName("qut1_wfh_taken");
            entity.Property(e => e.Qut2WfhRemaining).HasColumnName("qut2_wfh_remaining");
            entity.Property(e => e.Qut2WfhTaken).HasColumnName("qut2_wfh_taken");
            entity.Property(e => e.Qut3WfhRemaining).HasColumnName("qut3_wfh_remaining");
            entity.Property(e => e.Qut3WfhTaken).HasColumnName("qut3_wfh_taken");
            entity.Property(e => e.Qut4WfhRemaining).HasColumnName("qut4_wfh_remaining");
            entity.Property(e => e.Qut4WfhTaken).HasColumnName("qut4_wfh_taken");
            entity.Property(e => e.Wfhid).HasColumnName("WFHId");

            entity.HasOne(d => d.Emp).WithMany(p => p.Balances)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Balance__empId__5FB337D6");

            entity.HasOne(d => d.Leave).WithMany(p => p.Balances)
                .HasForeignKey(d => d.LeaveId)
                .HasConstraintName("FK__Balance__LeaveId__60A75C0F");

            entity.HasOne(d => d.Wfh).WithMany(p => p.Balances)
                .HasForeignKey(d => d.Wfhid)
                .HasConstraintName("FK__Balance__WFHId__619B8048");
        });

        modelBuilder.Entity<Emp>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__emp__AFB3EC0D13B1AD0D");

            entity.ToTable("emp");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("empId");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmpAddress)
                .HasMaxLength(250)
                .HasColumnName("empAddress");
            entity.Property(e => e.EmpCode)
                .HasMaxLength(10)
                .HasColumnName("empCode");
            entity.Property(e => e.EmpDepartment)
                .HasMaxLength(50)
                .HasColumnName("empDepartment");
            entity.Property(e => e.EmpEmail)
                .HasMaxLength(100)
                .HasColumnName("empEmail");
            entity.Property(e => e.EmpName)
                .HasMaxLength(100)
                .HasColumnName("empName");
            entity.Property(e => e.EmpPhone)
                .HasMaxLength(20)
                .HasColumnName("empPhone");
            entity.Property(e => e.EmpPosition)
                .HasMaxLength(50)
                .HasColumnName("empPosition");
            entity.Property(e => e.HireDate)
                .HasColumnType("datetime")
                .HasColumnName("hireDate");
            entity.Property(e => e.ModifyDt).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
        });

        modelBuilder.Entity<LeaveApplication>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK__LeaveApp__796DB95971DC3AFA");

            entity.ToTable("LeaveApplication");

            entity.Property(e => e.ApproveOn).HasColumnType("datetime");
            entity.Property(e => e.ApprovePaycode)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ApproveRemark).HasMaxLength(200);
            entity.Property(e => e.BlpersonId).HasColumnName("BLPersonID");
            entity.Property(e => e.BlpersonName)
                .HasMaxLength(200)
                .HasColumnName("BLPersonName");
            entity.Property(e => e.CancelRemarks).HasMaxLength(250);
            entity.Property(e => e.Contactdetails).HasMaxLength(250);
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CtoactionOn)
                .HasColumnType("datetime")
                .HasColumnName("CTOActionOn");
            entity.Property(e => e.Ctostatus)
                .HasColumnType("string")
                .HasColumnName("CTOStatus");
            entity.Property(e => e.Rostatus)
                .HasColumnType("string")
                .HasColumnName("ROStatus");
            entity.Property(e => e.CtoactionPaycode)
                .HasMaxLength(100)
                .HasColumnName("CTOActionPaycode");
            entity.Property(e => e.Ctoremarks)
                .HasMaxLength(500)
                .HasColumnName("CTORemarks");
            entity.Property(e => e.DateApplication)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateFrom).HasColumnType("datetime");
            entity.Property(e => e.DateTo).HasColumnType("datetime");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.IsDelete).HasDefaultValue(false);
            entity.Property(e => e.LeaveStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Pending")
                .IsFixedLength();
            entity.Property(e => e.ModifyDt).HasColumnType("datetime");
            entity.Property(e => e.Qldtype).HasColumnName("QLDType");
            entity.Property(e => e.Reason).HasMaxLength(200);
            entity.Property(e => e.RecordStatus)
                .HasMaxLength(50)
                .HasDefaultValue("Active");
            entity.Property(e => e.RemarksbyAdmin)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.ResponsiblePerson).HasMaxLength(100);
            entity.Property(e => e.RoactionOn)
                .HasColumnType("datetime")
                .HasColumnName("ROActionOn");
            entity.Property(e => e.RoactionPaycode)
                .HasMaxLength(100)
                .HasColumnName("ROActionPaycode");
            entity.Property(e => e.Roremarks)
                .HasMaxLength(500)
                .HasColumnName("RORemarks");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.LeaveApplicationCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_LeaveApplication_CreatedBy");

            entity.HasOne(d => d.Emp).WithMany(p => p.LeaveApplicationEmps)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LeaveAppl__empId__4316F928");

            entity.HasOne(d => d.LeaveTypeNavigation).WithMany(p => p.LeaveApplicationLeaveTypeNavigations)
                .HasForeignKey(d => d.LeaveType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LeaveAppl__Leave__440B1D61");

            entity.HasOne(d => d.QldtypeNavigation).WithMany(p => p.LeaveApplicationQldtypeNavigations)
                .HasForeignKey(d => d.Qldtype)
                .HasConstraintName("FK__LeaveAppl__QLDTy__44FF419A");
        });

        modelBuilder.Entity<LeaveDelegation>(entity =>
        {
            entity.HasKey(e => e.DelId).HasName("PK__leave_de__00FBC38F4DA21928");

            entity.ToTable("leave_delegation");

            entity.Property(e => e.DelId).HasColumnName("delId");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.ModifyDt).HasColumnType("datetime");
            entity.Property(e => e.RhId).HasColumnName("rhId");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.LeaveDelegationCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_leave_delegation_CreatedBy");

            entity.HasOne(d => d.Emp).WithMany(p => p.LeaveDelegationEmps)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__leave_del__empId__5BE2A6F2");

            entity.HasOne(d => d.ModifyByNavigation).WithMany(p => p.LeaveDelegationModifyByNavigations)
                .HasForeignKey(d => d.ModifyBy)
                .HasConstraintName("FK_leave_delegation_ModifyBy");

            entity.HasOne(d => d.Rh).WithMany(p => p.LeaveDelegationRhs)
                .HasForeignKey(d => d.RhId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__leave_dele__rhId__5AEE82B9");
        });

        modelBuilder.Entity<TblShiftMaster>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__tblShift__C0A83881F6B3330D");

            entity.ToTable("tblShiftMaster");

            entity.HasIndex(e => e.Shift, "UQ__tblShift__E0BF93315A026E3D").IsUnique();

            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Endtime)
                .HasColumnType("datetime")
                .HasColumnName("ENDTIME");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Lunchdeduction).HasColumnName("LUNCHDEDUCTION");
            entity.Property(e => e.Lunchduration).HasColumnName("LUNCHDURATION");
            entity.Property(e => e.Lunchendtime)
                .HasColumnType("datetime")
                .HasColumnName("LUNCHENDTIME");
            entity.Property(e => e.Lunchtime)
                .HasColumnType("datetime")
                .HasColumnName("LUNCHTIME");
            entity.Property(e => e.ModifyDt).HasColumnType("datetime");
            entity.Property(e => e.Shift)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SHIFT");
            entity.Property(e => e.Shiftduration).HasColumnName("SHIFTDURATION");
            entity.Property(e => e.Shiftposition)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SHIFTPOSITION");
            entity.Property(e => e.Starttime)
                .HasColumnType("datetime")
                .HasColumnName("STARTTIME");
        });

        modelBuilder.Entity<TblemployeeShiftMaster>(entity =>
        {
            entity.HasKey(e => e.EmpShiftId).HasName("PK__tblemplo__183EF0056A7F984E");

            entity.ToTable("tblemployeeShiftMaster");

            entity.Property(e => e.EmpShiftId).HasColumnName("empShiftId");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.ModifyDt).HasColumnType("datetime");
            entity.Property(e => e.Shift)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SHIFT");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblemployeeShiftMasters)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblemploy__empId__5629CD9C");

            entity.HasOne(d => d.ShiftNavigation).WithMany(p => p.TblemployeeShiftMasters)
                .HasPrincipalKey(p => p.Shift)
                .HasForeignKey(d => d.Shift)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblemploy__SHIFT__571DF1D5");
        });

        modelBuilder.Entity<TypeLookUp>(entity =>
        {
            entity.HasKey(e => e.LookupId).HasName("PK__Type_Loo__6D8B9C6B13C843C6");

            entity.ToTable("Type_LookUp");

            entity.Property(e => e.LookupId).HasColumnName("LookupID");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Deleted).HasDefaultValue(false);
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LookupKey)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LookupShortName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LookupValue)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifyDt).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TypeLookUpCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Type_LookUp_CreatedBy");

            entity.HasOne(d => d.ModifyByNavigation).WithMany(p => p.TypeLookUpModifyByNavigations)
                .HasForeignKey(d => d.ModifyBy)
                .HasConstraintName("FK_Type_LookUp_ModifyBy");
        });

        modelBuilder.Entity<WfhOof>(entity =>
        {
            entity.HasKey(e => e.WfhOofid).HasName("PK__WFH_OOF__A82F155F972D0432");

            entity.ToTable("WFH_OOF");

            entity.Property(e => e.WfhOofid).HasColumnName("WFH_OOFId");
            entity.Property(e => e.ApprovePayCode).HasMaxLength(10);
            entity.Property(e => e.ApprovedOn).HasColumnType("datetime");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateIn).HasColumnType("datetime");
            entity.Property(e => e.DateInSubmit)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateOut).HasColumnType("datetime");
            entity.Property(e => e.DateOutSubmit)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.InIp).HasMaxLength(30);
            entity.Property(e => e.IsDelete).HasDefaultValue(false);
            entity.Property(e => e.ModifyDt).HasColumnType("datetime");
            entity.Property(e => e.OutIp).HasMaxLength(30);
            entity.Property(e => e.Reason).HasMaxLength(200);
            entity.Property(e => e.Remark).HasMaxLength(400);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.Wfhcount).HasColumnName("WFHCount");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.WfhOofCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_WFH_OOF_CreatedBy");

            entity.HasOne(d => d.Emp).WithMany(p => p.WfhOofEmps)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WFH_OOF__empId__4CA06362");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.WfhOoves)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WFH_OOF__Type__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
