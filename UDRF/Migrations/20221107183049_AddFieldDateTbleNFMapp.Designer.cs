﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UDRF.Data;

#nullable disable

namespace UDRF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221107183049_AddFieldDateTbleNFMapp")]
    partial class AddFieldDateTbleNFMapp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.APImapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("NFId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ServiceApi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("NFId");

                    b.ToTable("APImapping", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.BcNode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("BcNodeId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Group")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumberOfSecondBcNodes")
                        .HasColumnType("int");

                    b.Property<Guid>("PlaceId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ready")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("TopBcNodeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("BcNodeId");

                    b.HasIndex("PlaceId");

                    b.ToTable("BcNode", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.BcNodeContent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BcNodeId")
                        .HasColumnType("char(36)");

                    b.Property<float>("Bitrate")
                        .HasColumnType("float");

                    b.Property<Guid>("ContentId")
                        .HasColumnType("char(36)");

                    b.Property<float>("Size")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BcNodeId");

                    b.HasIndex("ContentId");

                    b.ToTable("BcNodeContent", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.Content", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ServicesId")
                        .HasColumnType("char(36)");

                    b.Property<string>("SourceLocation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ServicesId");

                    b.ToTable("Content", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.ContentServices", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("RealTime")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("ContentServices", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.IDinNRF", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("IDinNRF", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.InterfaceBcNode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BcNodeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("InterfaceId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("BcNodeId");

                    b.HasIndex("InterfaceId");

                    b.ToTable("InterfaceBcNode", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.InterfaceBcNodesCoreBcNode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BcNodeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("InterfBcNodeCoreId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("BcNodeId");

                    b.HasIndex("InterfBcNodeCoreId");

                    b.ToTable("InterfaceBcNodesCoreBcNode", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.Interfaces", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Interfaces", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.InterfBcNodeCore", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("InterfBcNodeCore", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.NFmapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Available")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("NFmapping", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.Place", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Place", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.RepeatSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("TimeSchduleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TimeSchduleId");

                    b.ToTable("RepeatSchedule", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.TimeSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BcNodeContentId")
                        .HasColumnType("char(36)");

                    b.Property<int>("DurationSec")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("BcNodeContentId");

                    b.ToTable("TimeSchedule", (string)null);
                });

            modelBuilder.Entity("UDRF.Models.Token", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Token", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UDRF.Models.APImapping", b =>
                {
                    b.HasOne("UDRF.Models.NFmapping", "NF")
                        .WithMany("Apis")
                        .HasForeignKey("NFId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NF");
                });

            modelBuilder.Entity("UDRF.Models.BcNode", b =>
                {
                    b.HasOne("UDRF.Models.BcNode", null)
                        .WithMany("SecondaryBcNodes")
                        .HasForeignKey("BcNodeId");

                    b.HasOne("UDRF.Models.Place", "Place")
                        .WithMany("BcNodes")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("UDRF.Models.BcNodeContent", b =>
                {
                    b.HasOne("UDRF.Models.BcNode", "Bcnode")
                        .WithMany("BcNodeContents")
                        .HasForeignKey("BcNodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UDRF.Models.Content", "Content")
                        .WithMany("BcNodeContents")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bcnode");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("UDRF.Models.Content", b =>
                {
                    b.HasOne("UDRF.Models.ContentServices", "Services")
                        .WithMany("Contents")
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Services");
                });

            modelBuilder.Entity("UDRF.Models.InterfaceBcNode", b =>
                {
                    b.HasOne("UDRF.Models.BcNode", "BcNode")
                        .WithMany("InterfaceBcNodes")
                        .HasForeignKey("BcNodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UDRF.Models.Interfaces", "Interfaces")
                        .WithMany("InterfaceBcNodes")
                        .HasForeignKey("InterfaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BcNode");

                    b.Navigation("Interfaces");
                });

            modelBuilder.Entity("UDRF.Models.InterfaceBcNodesCoreBcNode", b =>
                {
                    b.HasOne("UDRF.Models.BcNode", "BcNode")
                        .WithMany("InterfaceBcNodesCoreBcNodes")
                        .HasForeignKey("BcNodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UDRF.Models.InterfBcNodeCore", "InterfBcNodeCore")
                        .WithMany("InterfaceBcNodesCoreBcNode")
                        .HasForeignKey("InterfBcNodeCoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BcNode");

                    b.Navigation("InterfBcNodeCore");
                });

            modelBuilder.Entity("UDRF.Models.RepeatSchedule", b =>
                {
                    b.HasOne("UDRF.Models.TimeSchedule", "TimeSchedule")
                        .WithMany("RepeatSchedule")
                        .HasForeignKey("TimeSchduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TimeSchedule");
                });

            modelBuilder.Entity("UDRF.Models.TimeSchedule", b =>
                {
                    b.HasOne("UDRF.Models.BcNodeContent", "BcNodeContent")
                        .WithMany("TimeSchedules")
                        .HasForeignKey("BcNodeContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BcNodeContent");
                });

            modelBuilder.Entity("UDRF.Models.BcNode", b =>
                {
                    b.Navigation("BcNodeContents");

                    b.Navigation("InterfaceBcNodes");

                    b.Navigation("InterfaceBcNodesCoreBcNodes");

                    b.Navigation("SecondaryBcNodes");
                });

            modelBuilder.Entity("UDRF.Models.BcNodeContent", b =>
                {
                    b.Navigation("TimeSchedules");
                });

            modelBuilder.Entity("UDRF.Models.Content", b =>
                {
                    b.Navigation("BcNodeContents");
                });

            modelBuilder.Entity("UDRF.Models.ContentServices", b =>
                {
                    b.Navigation("Contents");
                });

            modelBuilder.Entity("UDRF.Models.Interfaces", b =>
                {
                    b.Navigation("InterfaceBcNodes");
                });

            modelBuilder.Entity("UDRF.Models.InterfBcNodeCore", b =>
                {
                    b.Navigation("InterfaceBcNodesCoreBcNode");
                });

            modelBuilder.Entity("UDRF.Models.NFmapping", b =>
                {
                    b.Navigation("Apis");
                });

            modelBuilder.Entity("UDRF.Models.Place", b =>
                {
                    b.Navigation("BcNodes");
                });

            modelBuilder.Entity("UDRF.Models.TimeSchedule", b =>
                {
                    b.Navigation("RepeatSchedule");
                });
#pragma warning restore 612, 618
        }
    }
}
