﻿// <auto-generated />
using System;
using Agro.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Agro.DataAccess.Migrations
{
    [DbContext(typeof(AgroDbContext))]
    [Migration("20230528230406_Change_Silo")]
    partial class Change_Silo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Agro.DataAccess.Entities.AnimalGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("AnimalGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 0,
                            Name = "-"
                        });
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.ArchiveMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("ArchiveMessages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 0,
                            Message = "OK"
                        },
                        new
                        {
                            Id = 2,
                            Code = 1,
                            Message = ">T"
                        },
                        new
                        {
                            Id = 3,
                            Code = 2,
                            Message = ">A>T"
                        },
                        new
                        {
                            Id = 4,
                            Code = 3,
                            Message = ">T OK"
                        },
                        new
                        {
                            Id = 5,
                            Code = 4,
                            Message = ">T FAIL"
                        },
                        new
                        {
                            Id = 6,
                            Code = 5,
                            Message = ">A>T OK"
                        },
                        new
                        {
                            Id = 7,
                            Code = 6,
                            Message = ">A>T FAIL"
                        });
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Areas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 0,
                            Name = "-"
                        });
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.Balance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.Property<float>("EmptyTolerance")
                        .HasColumnType("real");

                    b.Property<DateTime>("LastChange")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxDosingTime")
                        .HasColumnType("int");

                    b.Property<float>("MaxWeight")
                        .HasColumnType("real");

                    b.Property<float>("MinWeight")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.Property<float>("WeighTolerance")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Balances");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.DosingTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BatchCount")
                        .HasColumnType("int");

                    b.Property<float>("BatchSize")
                        .HasColumnType("real");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Comment")
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("InProcessBatchCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<int>("ManufNr")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ProductRecipeId")
                        .HasColumnType("int");

                    b.Property<int>("ReadyBatchCount")
                        .HasColumnType("int");

                    b.Property<int?>("SiloOneId")
                        .HasColumnType("int");

                    b.Property<int?>("SiloTwoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskMessageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductRecipeId");

                    b.HasIndex("SiloOneId");

                    b.HasIndex("SiloTwoId");

                    b.HasIndex("TaskMessageId");

                    b.ToTable("DosingTasks");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.DosingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("DosingTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 1,
                            Name = "ручное"
                        },
                        new
                        {
                            Id = 2,
                            Code = 2,
                            Name = "жидкое"
                        },
                        new
                        {
                            Id = 3,
                            Code = 3,
                            Name = "автоматическое"
                        });
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("DryMixTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastChange")
                        .HasColumnType("datetime2");

                    b.Property<float>("MaxBatchSize")
                        .HasColumnType("real");

                    b.Property<float>("MinBatchSize")
                        .HasColumnType("real");

                    b.Property<int>("MixTime")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("AnimalGroupId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.ProductRecipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastChange")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductRecipes");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.RecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DosingPriority")
                        .HasColumnType("int");

                    b.Property<int>("ProductRecipeId")
                        .HasColumnType("int");

                    b.Property<float>("ResourceContent")
                        .HasColumnType("real");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductRecipeId");

                    b.HasIndex("ResourceId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Activity")
                        .HasColumnType("real");

                    b.Property<float>("AlertTolerance")
                        .HasColumnType("real");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<float>("Density")
                        .HasColumnType("real");

                    b.Property<int>("DosingTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastChange")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.Property<float>("RejectTolerance")
                        .HasColumnType("real");

                    b.Property<int?>("ResourceTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(32)");

                    b.Property<float>("TechTolerance")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("DosingTypeId");

                    b.HasIndex("ResourceTypeId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.ResourceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("ResourceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 1,
                            Name = "минеральное"
                        });
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.Silo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("DefaultBalanceId")
                        .HasColumnType("int");

                    b.Property<float>("FreeFall")
                        .HasColumnType("real");

                    b.Property<DateTime>("LastChange")
                        .HasColumnType("datetime2");

                    b.Property<float>("MaxCapacity")
                        .HasColumnType("real");

                    b.Property<float>("MaxComponentSize")
                        .HasColumnType("real");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int?>("PreviousResourceId")
                        .HasColumnType("int");

                    b.Property<float>("RealStock")
                        .HasColumnType("real");

                    b.Property<int?>("ResourceId")
                        .HasColumnType("int");

                    b.Property<int>("SiloTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("DefaultBalanceId");

                    b.HasIndex("PreviousResourceId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("SiloTypeId");

                    b.ToTable("Silos");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.SiloType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("SiloTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 1,
                            Name = "дозаторный"
                        });
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.TaskMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("TaskMessages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 0,
                            Message = "-"
                        },
                        new
                        {
                            Id = 2,
                            Code = 1,
                            Message = "ожидает"
                        },
                        new
                        {
                            Id = 3,
                            Code = 2,
                            Message = "выполняется"
                        },
                        new
                        {
                            Id = 4,
                            Code = 3,
                            Message = "выполнено"
                        },
                        new
                        {
                            Id = 5,
                            Code = 4,
                            Message = "остановлено"
                        });
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Администратор",
                            PasswordHash = "$2a$11$uBkk6kvhgypwdGBF4Dz94uF0Yv7UtCs5mkVinjo1UGB.0o4tEcxDy",
                            UserName = "admin",
                            UserRoleId = 1
                        });
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Администратор"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Оператор"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Технолог"
                        });
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.Balance", b =>
                {
                    b.HasOne("Agro.DataAccess.Entities.Area", "Area")
                        .WithMany("Balances")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.DosingTask", b =>
                {
                    b.HasOne("Agro.DataAccess.Entities.ProductRecipe", "ProductRecipe")
                        .WithMany()
                        .HasForeignKey("ProductRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agro.DataAccess.Entities.Silo", "SiloOne")
                        .WithMany()
                        .HasForeignKey("SiloOneId");

                    b.HasOne("Agro.DataAccess.Entities.Silo", "SiloTwo")
                        .WithMany()
                        .HasForeignKey("SiloTwoId");

                    b.HasOne("Agro.DataAccess.Entities.TaskMessage", "TaskMessage")
                        .WithMany()
                        .HasForeignKey("TaskMessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductRecipe");

                    b.Navigation("SiloOne");

                    b.Navigation("SiloTwo");

                    b.Navigation("TaskMessage");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.Product", b =>
                {
                    b.HasOne("Agro.DataAccess.Entities.AnimalGroup", "AnimalGroup")
                        .WithMany()
                        .HasForeignKey("AnimalGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnimalGroup");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.ProductRecipe", b =>
                {
                    b.HasOne("Agro.DataAccess.Entities.Product", "Product")
                        .WithMany("ProductRecipes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.RecipeIngredient", b =>
                {
                    b.HasOne("Agro.DataAccess.Entities.ProductRecipe", "ProductRecipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("ProductRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agro.DataAccess.Entities.Resource", "Resource")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductRecipe");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.Resource", b =>
                {
                    b.HasOne("Agro.DataAccess.Entities.DosingType", "DosingType")
                        .WithMany("Resources")
                        .HasForeignKey("DosingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agro.DataAccess.Entities.ResourceType", "ResourceType")
                        .WithMany("Resources")
                        .HasForeignKey("ResourceTypeId");

                    b.Navigation("DosingType");

                    b.Navigation("ResourceType");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.Silo", b =>
                {
                    b.HasOne("Agro.DataAccess.Entities.Area", "Area")
                        .WithMany("Silos")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agro.DataAccess.Entities.Balance", "DefaultBalance")
                        .WithMany("Silos")
                        .HasForeignKey("DefaultBalanceId");

                    b.HasOne("Agro.DataAccess.Entities.Resource", "PreviousResource")
                        .WithMany()
                        .HasForeignKey("PreviousResourceId");

                    b.HasOne("Agro.DataAccess.Entities.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId");

                    b.HasOne("Agro.DataAccess.Entities.SiloType", "SiloType")
                        .WithMany("Silos")
                        .HasForeignKey("SiloTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("DefaultBalance");

                    b.Navigation("PreviousResource");

                    b.Navigation("Resource");

                    b.Navigation("SiloType");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.User", b =>
                {
                    b.HasOne("Agro.DataAccess.Entities.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.Area", b =>
                {
                    b.Navigation("Balances");

                    b.Navigation("Silos");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.Balance", b =>
                {
                    b.Navigation("Silos");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.DosingType", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.Product", b =>
                {
                    b.Navigation("ProductRecipes");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.ProductRecipe", b =>
                {
                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.Resource", b =>
                {
                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.ResourceType", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.SiloType", b =>
                {
                    b.Navigation("Silos");
                });

            modelBuilder.Entity("Agro.DataAccess.Entities.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
