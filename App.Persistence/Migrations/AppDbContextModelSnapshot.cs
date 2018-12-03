﻿// <auto-generated />
using System;
using App.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("App.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<string>("GroupName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("App.Domain.Entities.PermissionUserAssociation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("SecurityRoleId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SecurityRoleId");

                    b.HasIndex("UserId");

                    b.ToTable("PermissionUserAssociations");
                });

            modelBuilder.Entity("App.Domain.Entities.SecurityRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("SecurityRoles");
                });

            modelBuilder.Entity("App.Domain.Entities.SecurityRolePermissionAssociation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("PermissionId");

                    b.Property<int?>("SecurityRoleId");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("SecurityRoleId");

                    b.ToTable("SecurityRolePermissionAssociations");
                });

            modelBuilder.Entity("App.Domain.Entities.SecurityRoleUserAssociation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("SecurityRoleId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SecurityRoleId");

                    b.HasIndex("UserId");

                    b.ToTable("SecurityRoleUserAssociations");
                });

            modelBuilder.Entity("App.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("App.Domain.Entities.PermissionUserAssociation", b =>
                {
                    b.HasOne("App.Domain.Entities.Permission", "SecurityRole")
                        .WithMany()
                        .HasForeignKey("SecurityRoleId");

                    b.HasOne("App.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("App.Domain.Entities.SecurityRolePermissionAssociation", b =>
                {
                    b.HasOne("App.Domain.Entities.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId");

                    b.HasOne("App.Domain.Entities.SecurityRole", "SecurityRole")
                        .WithMany()
                        .HasForeignKey("SecurityRoleId");
                });

            modelBuilder.Entity("App.Domain.Entities.SecurityRoleUserAssociation", b =>
                {
                    b.HasOne("App.Domain.Entities.SecurityRole", "SecurityRole")
                        .WithMany()
                        .HasForeignKey("SecurityRoleId");

                    b.HasOne("App.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
