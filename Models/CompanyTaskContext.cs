using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFWD2.Models;

public partial class CompanyTaskContext : DbContext
{
    public CompanyTaskContext()
    {
    }

    public CompanyTaskContext(DbContextOptions<CompanyTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CourseView> CourseViews { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeDeptView> EmployeeDeptViews { get; set; }

    public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }

    public virtual DbSet<EmployeeView> EmployeeViews { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectDeptView> ProjectDeptViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=CompanyTask;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CourseView");

            entity.Property(e => e.CrsId).HasColumnName("Crs_Id");
            entity.Property(e => e.CrsName)
                .HasMaxLength(50)
                .HasColumnName("Crs_Name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Dnumber).HasName("PK__Departme__3361AE3816F60017");

            entity.Property(e => e.Dnumber)
                .ValueGeneratedNever()
                .HasColumnName("DNumber");
            entity.Property(e => e.Dname)
                .HasMaxLength(50)
                .HasColumnName("DName");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC079F2605A9");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.DepartmentNumberNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentNumber)
                .HasConstraintName("FK__Employees__Depar__398D8EEE");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.InverseSupervisor)
                .HasForeignKey(d => d.SupervisorId)
                .HasConstraintName("FK__Employees__Super__3A81B327");
        });

        modelBuilder.Entity<EmployeeDeptView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EmployeeDeptView");

            entity.Property(e => e.DepartmentName).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<EmployeeProject>(entity =>
        {
            entity.HasKey(e => new { e.Eid, e.Pnum }).HasName("PK__Employee__24643652C06C895B");

            entity.ToTable("Employee_Projects");

            entity.Property(e => e.Eid).HasColumnName("EId");
            entity.Property(e => e.Pnum).HasColumnName("PNum");

            entity.HasOne(d => d.EidNavigation).WithMany(p => p.EmployeeProjects)
                .HasForeignKey(d => d.Eid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EProjects_Employees");

            entity.HasOne(d => d.PnumNavigation).WithMany(p => p.EmployeeProjects)
                .HasForeignKey(d => d.Pnum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EProjects_Projects");
        });

        modelBuilder.Entity<EmployeeView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EmployeeView");

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Pnumber).HasName("PK__Projects__DDE0878D2781686D");

            entity.Property(e => e.Pnumber)
                .ValueGeneratedNever()
                .HasColumnName("PNumber");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Pname)
                .HasMaxLength(50)
                .HasColumnName("PName");

            entity.HasOne(d => d.DeptNumNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.DeptNum)
                .HasConstraintName("FK_Projects_Departments");
        });

        modelBuilder.Entity<ProjectDeptView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ProjectDeptView");

            entity.Property(e => e.DepartmentName).HasMaxLength(50);
            entity.Property(e => e.Pname)
                .HasMaxLength(50)
                .HasColumnName("PName");
            entity.Property(e => e.Pnumber).HasColumnName("PNumber");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
