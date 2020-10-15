using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
namespace AuthSSO.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SysAppfunctions> SysAppfunctions { get; set; }
        public virtual DbSet<SysApplications> SysApplications { get; set; }
        public virtual DbSet<SysApproles> SysApproles { get; set; }
        public virtual DbSet<SysAppusers> SysAppusers { get; set; }
        public virtual DbSet<SysBranch> SysBranch { get; set; }
        public virtual DbSet<SysBranchUsers> SysBranchUsers { get; set; }
        public virtual DbSet<SysCustomer> SysCustomer { get; set; }
        public virtual DbSet<SysGroupUser> SysGroupUser { get; set; }
        public virtual DbSet<SysRolewithfunctions> SysRolewithfunctions { get; set; }
        public virtual DbSet<SysUserandroles> SysUserandroles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                // Get configuration for dynamic connection string in ef
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                      .AddJsonFile($"appsettings.{envName}.json", optional: false)
                    .Build();


                optionsBuilder.UseLoggerFactory(LoggerFactory.Create(options => options.AddConsole()));
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("Default"), x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysAppfunctions>(entity =>
            {
                entity.HasKey(e => e.Functionid)
                    .HasName("pk_sys_appfunctions");

                entity.ToTable("sys_appfunctions", "bvquany");

                entity.Property(e => e.Functionid)
                    .HasColumnName("functionid")
                    .HasMaxLength(36);

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Customerid)
                    .HasColumnName("customerid")
                    .HasMaxLength(36);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(512);

                entity.Property(e => e.Functionname)
                    .HasColumnName("functionname")
                    .HasMaxLength(256);

                entity.Property(e => e.Functype)
                    .HasColumnName("functype")
                    .HasMaxLength(4)
                    .HasDefaultValueSql("'FUNC'::character varying");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasColumnType("numeric(1,0)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Isdelete)
                    .HasColumnName("isdelete")
                    .HasColumnType("numeric(1,0)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Itemlevel)
                    .HasColumnName("itemlevel")
                    .HasColumnType("numeric(1,0)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lastdatemodify).HasColumnName("lastdatemodify");

                entity.Property(e => e.Moduleid)
                    .HasColumnName("moduleid")
                    .HasMaxLength(256);

                entity.Property(e => e.Parentid)
                    .HasColumnName("parentid")
                    .HasMaxLength(32)
                    .HasDefaultValueSql("NULL::character varying");

                entity.HasOne(d => d.SysApplications)
                    .WithMany(p => p.SysAppfunctions)
                    .HasForeignKey(d => new { d.Moduleid, d.Customerid })
                    .HasConstraintName("fk_sys_appfunctions1");
            });

            modelBuilder.Entity<SysApplications>(entity =>
            {
                entity.HasKey(e => new { e.Moduleid, e.Customerid })
                    .HasName("pk_sys_applications");

                entity.ToTable("sys_applications", "bvquany");

                entity.Property(e => e.Moduleid)
                    .HasColumnName("moduleid")
                    .HasMaxLength(36);

                entity.Property(e => e.Customerid)
                    .HasColumnName("customerid")
                    .HasMaxLength(36);

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Currentversion)
                    .HasColumnName("currentversion")
                    .HasMaxLength(20);

                entity.Property(e => e.FileVersion)
                    .HasColumnName("file_version")
                    .HasMaxLength(20);

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasColumnType("numeric(1,0)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Isdelete)
                    .HasColumnName("isdelete")
                    .HasColumnType("numeric(1,0)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Modulecode)
                    .IsRequired()
                    .HasColumnName("modulecode")
                    .HasMaxLength(256);

                entity.Property(e => e.Modulename)
                    .IsRequired()
                    .HasColumnName("modulename")
                    .HasMaxLength(128);

                entity.Property(e => e.ParentModule)
                    .HasColumnName("parent_module")
                    .HasMaxLength(36);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SysApplications)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sys_applications1");
            });

            modelBuilder.Entity<SysApproles>(entity =>
            {
                entity.HasKey(e => e.Roleid)
                    .HasName("pk_sys_approles");

                entity.ToTable("sys_approles", "bvquany");

                entity.Property(e => e.Roleid)
                    .HasColumnName("roleid")
                    .HasMaxLength(36);

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Createuser)
                    .HasColumnName("createuser")
                    .HasMaxLength(36);

                entity.Property(e => e.Customerid)
                    .HasColumnName("customerid")
                    .HasMaxLength(36);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256);

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasColumnType("numeric(1,0)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Isdelete)
                    .HasColumnName("isdelete")
                    .HasColumnType("numeric(1,0)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Moduleid)
                    .HasColumnName("moduleid")
                    .HasMaxLength(256);

                entity.Property(e => e.Rolename)
                    .IsRequired()
                    .HasColumnName("rolename")
                    .HasMaxLength(100);

                entity.Property(e => e.Updateddate).HasColumnName("updateddate");

                entity.Property(e => e.Updateduser)
                    .HasColumnName("updateduser")
                    .HasMaxLength(36);

                entity.HasOne(d => d.CreateuserNavigation)
                    .WithMany(p => p.SysApproles)
                    .HasForeignKey(d => d.Createuser)
                    .HasConstraintName("fk_sys_approles3");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SysApproles)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("fk_sys_approles1");

                entity.HasOne(d => d.SysApplications)
                    .WithMany(p => p.SysApproles)
                    .HasForeignKey(d => new { d.Moduleid, d.Customerid })
                    .HasConstraintName("fk_sys_approles2");
            });

            modelBuilder.Entity<SysAppusers>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("pk_sys_appusers");

                entity.ToTable("sys_appusers", "bvquany");

                entity.HasIndex(e => e.Id)
                    .HasName("uk_sys_appusers2")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("uk_sys_appusers1")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(36);

                entity.Property(e => e.PatientId)
                    .HasColumnName("patient_id")
                    .HasMaxLength(8);

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Createduser)
                    .HasColumnName("createduser")
                    .HasMaxLength(36)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Customerid)
                    .HasColumnName("customerid")
                    .HasMaxLength(36);

                entity.Property(e => e.Defaultbranchid)
                    .HasColumnName("defaultbranchid")
                    .HasMaxLength(36);

                entity.Property(e => e.Deleteddate).HasColumnName("deleteddate");

                entity.Property(e => e.Deleteduser)
                    .HasColumnName("deleteduser")
                    .HasMaxLength(36);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasMaxLength(256);

                entity.Property(e => e.Groupid)
                    .HasColumnName("groupid")
                    .HasColumnType("numeric(1,0)")
                    .HasDefaultValueSql("2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasColumnType("numeric(1,0)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Isdelete)
                    .HasColumnName("isdelete")
                    .HasColumnType("numeric(1,0)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Islocked)
                    .HasColumnName("islocked")
                    .HasColumnType("numeric(1,0)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lastlogindate).HasColumnName("lastlogindate");

                entity.Property(e => e.Lastupdateddate).HasColumnName("lastupdateddate");

                entity.Property(e => e.Lastupdateduser)
                    .HasColumnName("lastupdateduser")
                    .HasMaxLength(36);

                entity.Property(e => e.Lockeddate).HasColumnName("lockeddate");

                entity.Property(e => e.Passwd)
                    .IsRequired()
                    .HasColumnName("passwd")
                    .HasMaxLength(256);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20);

                entity.Property(e => e.Requirechangepassword)
                    .HasColumnName("requirechangepassword")
                    .HasColumnType("numeric(1,0)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SysAppusers)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("fk_sys_appusers1");

                entity.HasOne(d => d.Defaultbranch)
                    .WithMany(p => p.SysAppusers)
                    .HasForeignKey(d => d.Defaultbranchid)
                    .HasConstraintName("fk_sys_appusers3");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.SysAppusers)
                    .HasForeignKey(d => d.Groupid)
                    .HasConstraintName("fk_sys_appusers2");

                // entity.HasMany(d => d.SysApproles).WithOne(i => i.)

            });

            modelBuilder.Entity<SysBranch>(entity =>
            {
                entity.HasKey(e => e.Branchid)
                    .HasName("pk_sys_branch");

                entity.ToTable("sys_branch", "bvquany");

                entity.Property(e => e.Branchid)
                    .HasColumnName("branchid")
                    .HasMaxLength(36);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(512);

                entity.Property(e => e.Branchname)
                    .IsRequired()
                    .HasColumnName("branchname")
                    .HasMaxLength(100);

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Createduser)
                    .HasColumnName("createduser")
                    .HasColumnType("numeric");

                entity.Property(e => e.Customerid)
                    .HasColumnName("customerid")
                    .HasMaxLength(36);

                entity.Property(e => e.Deleteddate).HasColumnName("deleteddate");

                entity.Property(e => e.Districtid)
                    .HasColumnName("districtid")
                    .HasMaxLength(5);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasColumnType("numeric(1,0)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Isdelete)
                    .HasColumnName("isdelete")
                    .HasColumnType("numeric(1,0)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20);

                entity.Property(e => e.Provinceid)
                    .HasColumnName("provinceid")
                    .HasMaxLength(3);

                entity.Property(e => e.Updateddate).HasColumnName("updateddate");

                entity.Property(e => e.Updateduser)
                    .HasColumnName("updateduser")
                    .HasColumnType("numeric");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SysBranch)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("fk_sys_branch1");
            });

            modelBuilder.Entity<SysBranchUsers>(entity =>
            {
                entity.HasKey(e => new { e.Branchid, e.Userid })
                    .HasName("pk_sys_branch_users");

                entity.ToTable("sys_branch_users", "bvquany");

                entity.Property(e => e.Branchid)
                    .HasColumnName("branchid")
                    .HasMaxLength(36);

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(36);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.SysBranchUsers)
                    .HasForeignKey(d => d.Branchid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sys_branch_users1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SysBranchUsers)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sys_branch_users2");
            });

            modelBuilder.Entity<SysCustomer>(entity =>
            {
                entity.HasKey(e => e.Customerid)
                    .HasName("pk_sys_customer");

                entity.ToTable("sys_customer", "bvquany");

                entity.Property(e => e.Customerid)
                    .HasColumnName("customerid")
                    .HasMaxLength(36);

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Createduser)
                    .HasColumnName("createduser")
                    .HasColumnType("numeric");

                entity.Property(e => e.Customercode)
                    .HasColumnName("customercode")
                    .HasMaxLength(10);

                entity.Property(e => e.Customername)
                    .IsRequired()
                    .HasColumnName("customername")
                    .HasMaxLength(100);

                entity.Property(e => e.Diachi)
                    .HasColumnName("diachi")
                    .HasMaxLength(256);

                entity.Property(e => e.Dienthoai)
                    .HasColumnName("dienthoai")
                    .HasMaxLength(20);

                entity.Property(e => e.Districtid)
                    .HasColumnName("districtid")
                    .HasMaxLength(5);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(20);

                entity.Property(e => e.Provinceid)
                    .HasColumnName("provinceid")
                    .HasMaxLength(3);

                entity.Property(e => e.Syt)
                    .HasColumnName("syt")
                    .HasMaxLength(100);

                entity.Property(e => e.Updateddate).HasColumnName("updateddate");

                entity.Property(e => e.Updateduser)
                    .HasColumnName("updateduser")
                    .HasColumnType("numeric");
            });

            modelBuilder.Entity<SysGroupUser>(entity =>
            {
                entity.HasKey(e => e.Groupid)
                    .HasName("pk_sys_group_user");

                entity.ToTable("sys_group_user", "bvquany");

                entity.Property(e => e.Groupid)
                    .HasColumnName("groupid")
                    .HasColumnType("numeric");

                entity.Property(e => e.Groupname)
                    .HasColumnName("groupname")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SysRolewithfunctions>(entity =>
            {
                entity.HasKey(e => new { e.Roleid, e.Functionid })
                    .HasName("pk_rolewithfunctions");

                entity.ToTable("sys_rolewithfunctions", "bvquany");

                entity.Property(e => e.Roleid)
                    .HasColumnName("roleid")
                    .HasMaxLength(36);

                entity.Property(e => e.Functionid)
                    .HasColumnName("functionid")
                    .HasMaxLength(36);

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.SysRolewithfunctions)
                    .HasForeignKey(d => d.Functionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rolewithfunction_2");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SysRolewithfunctions)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rolewithfunction_1");
            });

            modelBuilder.Entity<SysUserandroles>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.Roleid })
                    .HasName("pk_sys_userandroles");

                entity.ToTable("sys_userandroles", "bvquany");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(36);

                entity.Property(e => e.Roleid)
                    .HasColumnName("roleid")
                    .HasMaxLength(36);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SysUserandroles)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sys_userandroles_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SysUserandroles)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sys_userandroles_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
