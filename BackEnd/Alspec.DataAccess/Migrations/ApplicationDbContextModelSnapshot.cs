﻿// <auto-generated />
using Alspec.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Alspec.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Alspec.Models.Entities.Job", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Job");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Description = "Aslpec 1",
                            Title = "Job 1"
                        });
                });

            modelBuilder.Entity("Alspec.Models.Entities.SubItem", b =>
                {
                    b.Property<string>("ItemId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.HasIndex("JobId");

                    b.ToTable("SubItems");

                    b.HasData(
                        new
                        {
                            ItemId = "1",
                            Description = "Sub-Item 1  Description",
                            JobId = "1",
                            Status = "Pending",
                            Title = "Sub-Item 1"
                        },
                        new
                        {
                            ItemId = "2",
                            Description = "Sub-Item 2 Description",
                            JobId = "1",
                            Status = "Pending",
                            Title = "Sub-Item 2"
                        });
                });

            modelBuilder.Entity("Alspec.Models.Entities.SubItem", b =>
                {
                    b.HasOne("Alspec.Models.Entities.Job", "Job")
                        .WithMany("SubItems")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Alspec.Models.Entities.Job", b =>
                {
                    b.Navigation("SubItems");
                });
#pragma warning restore 612, 618
        }
    }
}
