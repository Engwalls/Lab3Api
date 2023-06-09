﻿// <auto-generated />
using Lab3Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab3Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230503193740_firsttry")]
    partial class firsttry
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab3Api.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("FK_MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InterestId");

                    b.HasIndex("FK_MemberId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("Lab3Api.Models.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkId"));

                    b.Property<int>("FK_InterestId")
                        .HasColumnType("int");

                    b.Property<string>("LinkUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LinkId");

                    b.HasIndex("FK_InterestId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Lab3Api.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Lab3Api.Models.Interest", b =>
                {
                    b.HasOne("Lab3Api.Models.Member", "Members")
                        .WithMany("Interests")
                        .HasForeignKey("FK_MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Members");
                });

            modelBuilder.Entity("Lab3Api.Models.Link", b =>
                {
                    b.HasOne("Lab3Api.Models.Interest", "Interests")
                        .WithMany("Links")
                        .HasForeignKey("FK_InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interests");
                });

            modelBuilder.Entity("Lab3Api.Models.Interest", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("Lab3Api.Models.Member", b =>
                {
                    b.Navigation("Interests");
                });
#pragma warning restore 612, 618
        }
    }
}
