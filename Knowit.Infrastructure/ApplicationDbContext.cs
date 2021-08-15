using Knowit.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knowit.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
       UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext()
        {
        }
        public DbSet<EventDetail> EventDetails { get; set; }

        //public DbSet<EventSummaryDto> EventSummary { get; set; }
        //public DbSet<TicketSummaryDto> TicketSummary { get; set; }
        // public DbSet<EventCategory> EventCategories { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EventDetail>(new EventDetailMap().Configure);
            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                userRole.HasOne(ur => ur.User)
                        .WithMany(u => u.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
            });

        }
    }

    public class EventDetailMap : IEntityTypeConfiguration<EventDetail>
    {
        public void Configure(EntityTypeBuilder<EventDetail> builder)
        {
            builder.ToTable("EventDetail");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.EventDate)
                   .IsRequired();

            builder.Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(200);
        }
    }
}

