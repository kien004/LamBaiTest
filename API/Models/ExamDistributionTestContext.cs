using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class ExamDistributionTestContext : DbContext
{
    public ExamDistributionTestContext()
    {
    }

    public ExamDistributionTestContext(DbContextOptions<ExamDistributionTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepartmentFacility> DepartmentFacilities { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<Major> Majors { get; set; }

    public virtual DbSet<MajorFacility> MajorFacilities { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffMajorFacility> StaffMajorFacilities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-77H263D\\SQLEXPRESS;Database=exam_distribution_test;Integrated Security=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departme__3213E83FD98417F6");

            entity.ToTable("department");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<DepartmentFacility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departme__3213E83FEBFE1280");

            entity.ToTable("department_facility");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.IdDepartment).HasColumnName("id_department");
            entity.Property(e => e.IdFacility).HasColumnName("id_facility");
            entity.Property(e => e.IdStaff).HasColumnName("id_staff");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.DepartmentFacilities)
                .HasForeignKey(d => d.IdDepartment)
                 .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__departmen__id_de__3C69FB99");

            entity.HasOne(d => d.IdFacilityNavigation).WithMany(p => p.DepartmentFacilities)
                .HasForeignKey(d => d.IdFacility)
                 .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__departmen__id_fa__3D5E1FD2");

            entity.HasOne(d => d.IdStaffNavigation).WithMany(p => p.DepartmentFacilities)
                .HasForeignKey(d => d.IdStaff)
                 .OnDelete(DeleteBehavior.Cascade) // Xóa các phụ thuộc
                .HasConstraintName("FK__departmen__id_st__3E52440B");
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__facility__3213E83F3ADA88C0");

            entity.ToTable("facility");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Major>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__major__3213E83F48363524");

            entity.ToTable("major");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<MajorFacility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__major_fa__3213E83FE7DAAD5E");

            entity.ToTable("major_facility");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.IdDepartmentFacility).HasColumnName("id_department_facility");
            entity.Property(e => e.IdMajor).HasColumnName("id_major");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdDepartmentFacilityNavigation).WithMany(p => p.MajorFacilities)
                .HasForeignKey(d => d.IdDepartmentFacility)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__major_fac__id_de__4316F928");

            entity.HasOne(d => d.IdMajorNavigation).WithMany(p => p.MajorFacilities)
                .HasForeignKey(d => d.IdMajor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__major_fac__id_ma__440B1D61");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__staff__3213E83F38FBCCC8");

            entity.ToTable("staff");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccountFe)
                .HasMaxLength(255)
                .HasColumnName("account_fe");
            entity.Property(e => e.AccountFpt)
                .HasMaxLength(255)
                .HasColumnName("account_fpt");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.StaffCode)
                .HasMaxLength(255)
                .HasColumnName("staff_code");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<StaffMajorFacility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__staff_ma__3213E83FB67F2852");

            entity.ToTable("staff_major_facility");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.IdMajorFacility).HasColumnName("id_major_facility");
            entity.Property(e => e.IdStaff).HasColumnName("id_staff");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdMajorFacilityNavigation).WithMany(p => p.StaffMajorFacilities)
                .HasForeignKey(d => d.IdMajorFacility)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__staff_maj__id_ma__46E78A0C");

            entity.HasOne(d => d.IdStaffNavigation).WithMany(p => p.StaffMajorFacilities)
                .HasForeignKey(d => d.IdStaff)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__staff_maj__id_st__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
