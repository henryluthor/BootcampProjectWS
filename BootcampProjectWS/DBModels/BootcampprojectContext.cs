using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BootcampProjectWS.DBModels;

public partial class BootcampprojectContext : DbContext
{
    public BootcampprojectContext()
    {
    }

    public BootcampprojectContext(DbContextOptions<BootcampprojectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attention> Attentions { get; set; }

    public virtual DbSet<Attentionstatus> Attentionstatuses { get; set; }

    public virtual DbSet<Attentiontype> Attentiontypes { get; set; }

    public virtual DbSet<Cash> Cashes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Methodpayment> Methodpayments { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Statuscontract> Statuscontracts { get; set; }

    public virtual DbSet<Turn> Turns { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userstatus> Userstatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=LAPTOP-R601H3RA\\SQLEXPRESS;Database=bootcampproject;Trusted_Connection=true;TrustServerCertificate=true;Persist Security Info=true");
        => optionsBuilder.UseSqlServer((new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build().GetSection("DB").GetValue<string>("connection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attention>(entity =>
        {
            entity.ToTable("attention");

            entity.HasIndex(e => e.Turnid, "IX_attention_turn").IsUnique();

            entity.Property(e => e.Attentionid).HasColumnName("attentionid");
            entity.Property(e => e.Attentionstatusid).HasColumnName("attentionstatusid");
            entity.Property(e => e.Attentiontypeid).HasColumnName("attentiontypeid");
            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Turnid).HasColumnName("turnid");

            entity.HasOne(d => d.Attentionstatus).WithMany(p => p.Attentions)
                .HasForeignKey(d => d.Attentionstatusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_attention_attentionstatus");

            entity.HasOne(d => d.Attentiontype).WithMany(p => p.Attentions)
                .HasForeignKey(d => d.Attentiontypeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_attention_attentiontype");

            entity.HasOne(d => d.Client).WithMany(p => p.Attentions)
                .HasForeignKey(d => d.Clientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_attention_client");

            entity.HasOne(d => d.Turn).WithOne(p => p.Attention)
                .HasForeignKey<Attention>(d => d.Turnid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_attention_turn");
        });

        modelBuilder.Entity<Attentionstatus>(entity =>
        {
            entity.ToTable("attentionstatus");

            entity.Property(e => e.Attentionstatusid).HasColumnName("attentionstatusid");
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Attentiontype>(entity =>
        {
            entity.ToTable("attentiontype");

            entity.Property(e => e.Attentiontypeid).HasColumnName("attentiontypeid");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Cash>(entity =>
        {
            entity.ToTable("cash");

            entity.Property(e => e.Cashid).HasColumnName("cashid");
            entity.Property(e => e.Active)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("active");
            entity.Property(e => e.Cashdescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cashdescription");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("client");

            entity.HasIndex(e => e.Identification, "UQ_client").IsUnique();

            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Identification)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("identification");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Referenceaddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("referenceaddress");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.ToTable("contract");

            entity.Property(e => e.Contractid).HasColumnName("contractid");
            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Enddate)
                .HasColumnType("datetime")
                .HasColumnName("enddate");
            entity.Property(e => e.Methodpaymentid).HasColumnName("methodpaymentid");
            entity.Property(e => e.Serviceid).HasColumnName("serviceid");
            entity.Property(e => e.Startdate)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("startdate");
            entity.Property(e => e.Statuscontractid).HasColumnName("statuscontractid");

            entity.HasOne(d => d.Client).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Clientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_contract_client");

            entity.HasOne(d => d.Methodpayment).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Methodpaymentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_contract_methodpayment");

            entity.HasOne(d => d.Service).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Serviceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_contract_service");

            entity.HasOne(d => d.Statuscontract).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Statuscontractid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_contract_statuscontract");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.ToTable("device");

            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Devicename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("devicename");
            entity.Property(e => e.Serviceid).HasColumnName("serviceid");

            entity.HasOne(d => d.Service).WithMany(p => p.Devices)
                .HasForeignKey(d => d.Serviceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_device_service");
        });

        modelBuilder.Entity<Methodpayment>(entity =>
        {
            entity.ToTable("methodpayment");

            entity.Property(e => e.Methodpaymentid).HasColumnName("methodpaymentid");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("payment");

            entity.Property(e => e.Paymentid).HasColumnName("paymentid");
            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Paymentdate)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("paymentdate");

            entity.HasOne(d => d.Client).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Clientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_payment_client");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("rol");

            entity.Property(e => e.Rolid).HasColumnName("rolid");
            entity.Property(e => e.Rolname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rolname");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("service");

            entity.Property(e => e.Serviceid).HasColumnName("serviceid");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Servicedescription)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("servicedescription");
            entity.Property(e => e.Servicename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("servicename");
        });

        modelBuilder.Entity<Statuscontract>(entity =>
        {
            entity.HasKey(e => e.Statuscontractid).HasName("PK_statuscontract_1");

            entity.ToTable("statuscontract");

            entity.Property(e => e.Statuscontractid).HasColumnName("statuscontractid");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Turn>(entity =>
        {
            entity.ToTable("turn");

            entity.Property(e => e.Turnid).HasColumnName("turnid");
            entity.Property(e => e.Cashid).HasColumnName("cashid");
            entity.Property(e => e.Date)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Usergestorid).HasColumnName("usergestorid");

            entity.HasOne(d => d.Cash).WithMany(p => p.Turns)
                .HasForeignKey(d => d.Cashid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_turn_cash");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Creationdate)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("creationdate");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Rolid).HasColumnName("rolid");
            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Userapproval).HasColumnName("userapproval");
            entity.Property(e => e.Usercreate).HasColumnName("usercreate");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Rol).WithMany(p => p.Users)
                .HasForeignKey(d => d.Rolid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_rol");

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_userstatus");

            entity.HasMany(d => d.Cashes).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Usercash",
                    r => r.HasOne<Cash>().WithMany()
                        .HasForeignKey("Cashid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_usercash_cash"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_usercash_user"),
                    j =>
                    {
                        j.HasKey("Userid", "Cashid").HasName("usercash_PK");
                        j.ToTable("usercash");
                        j.IndexerProperty<int>("Userid").HasColumnName("userid");
                        j.IndexerProperty<int>("Cashid").HasColumnName("cashid");
                    });
        });

        modelBuilder.Entity<Userstatus>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("userstatus_PK");

            entity.ToTable("userstatus");

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
