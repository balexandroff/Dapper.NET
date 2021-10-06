using Dapper.NET.Domain.Entities;
using Dapper.NET.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

public class StocksIdentityDbContext : IdentityDbContext
{
    public StocksIdentityDbContext(DbContextOptions<StocksIdentityDbContext> options)
            : base(options)
    {
    }

    //public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
    //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
    //public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
    //public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
    //public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
    //public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
    //public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<AspNetRoleClaims>(entity =>
        //{
        //    entity.HasIndex(e => e.RoleId);

        //    entity.Property(e => e.RoleId).IsRequired();

        //    entity.HasOne(d => d.Role)
        //        .WithMany(p => p.AspNetRoleClaims)
        //        .HasForeignKey(d => d.RoleId);
        //});

        //modelBuilder.Entity<AspNetRoles>(entity =>
        //{
        //    entity.HasIndex(e => e.NormalizedName)
        //        .HasName("RoleNameIndex")
        //        .IsUnique()
        //        .HasFilter("([NormalizedName] IS NOT NULL)");

        //    entity.Property(e => e.Name).HasMaxLength(256);

        //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
        //});

        //modelBuilder.Entity<AspNetUserClaims>(entity =>
        //{
        //    entity.HasIndex(e => e.UserId);

        //    entity.Property(e => e.UserId).IsRequired();

        //    entity.HasOne(d => d.User)
        //        .WithMany(p => p.AspNetUserClaims)
        //        .HasForeignKey(d => d.UserId);
        //});

        //modelBuilder.Entity<AspNetUserLogins>(entity =>
        //{
        //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

        //    entity.HasIndex(e => e.UserId);

        //    entity.Property(e => e.UserId).IsRequired();

        //    entity.HasOne(d => d.User)
        //        .WithMany(p => p.AspNetUserLogins)
        //        .HasForeignKey(d => d.UserId);
        //});

        //modelBuilder.Entity<AspNetUserRoles>(entity =>
        //{
        //    entity.HasKey(e => new { e.UserId, e.RoleId });

        //    entity.HasIndex(e => e.RoleId);

        //    entity.HasOne(d => d.Role)
        //        .WithMany(p => p.AspNetUserRoles)
        //        .HasForeignKey(d => d.RoleId);

        //    entity.HasOne(d => d.User)
        //        .WithMany(p => p.AspNetUserRoles)
        //        .HasForeignKey(d => d.UserId);
        //});

        //modelBuilder.Entity<AspNetUserTokens>(entity =>
        //{
        //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

        //    entity.HasOne(d => d.User)
        //        .WithMany(p => p.AspNetUserTokens)
        //        .HasForeignKey(d => d.UserId);
        //});

        //modelBuilder.Entity<AspNetUsers>(entity =>
        //{
        //    entity.HasIndex(e => e.NormalizedEmail)
        //        .HasName("EmailIndex");

        //    entity.HasIndex(e => e.NormalizedUserName)
        //        .HasName("UserNameIndex")
        //        .IsUnique()
        //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

        //    entity.Property(e => e.Email).HasMaxLength(256);

        //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

        //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

        //    entity.Property(e => e.UserName).HasMaxLength(256);
        //});

        modelBuilder.IdentitySeed();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
