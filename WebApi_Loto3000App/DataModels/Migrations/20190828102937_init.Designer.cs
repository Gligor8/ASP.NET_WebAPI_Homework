﻿// <auto-generated />
using System;
using DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataModels.Migrations
{
    [DbContext(typeof(LottoAppDbContext))]
    [Migration("20190828102937_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataModels.SessionDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("DataModels.TicketDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Numbers");

                    b.Property<int>("Session");

                    b.Property<int?>("SessionDboId");

                    b.Property<int?>("UserDboId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SessionDboId");

                    b.HasIndex("UserDboId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("DataModels.UserDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<int>("Session");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, Address = "Partizanska 33", FirstName = "Bob", IsAdmin = true, LastName = "Bobsky", Password = "(?\\?-??3#>L?q", Session = 0, UserName = "bob007" }
                    );
                });

            modelBuilder.Entity("DataModels.WinnerDbo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Prize");

                    b.HasKey("Id");

                    b.ToTable("Winners");
                });

            modelBuilder.Entity("DataModels.TicketDbo", b =>
                {
                    b.HasOne("DataModels.SessionDbo")
                        .WithMany("Tickets")
                        .HasForeignKey("SessionDboId");

                    b.HasOne("DataModels.UserDbo")
                        .WithMany("Numbers")
                        .HasForeignKey("UserDboId");
                });
#pragma warning restore 612, 618
        }
    }
}
