﻿// <auto-generated />
using System;
using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lifequest.Migrations
{
    [DbContext(typeof(LifequestDbContext))]
    [Migration("20230617113029_FixedCostsAddExpense")]
    partial class FixedCostsAddExpense
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Lifequest.Src.Infrastructure.Db.Tables.BankHistoryTable", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("id");

                    b.Property<uint>("BankId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("bank_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at");

                    b.Property<int>("DifferencesAmount")
                        .HasColumnType("int")
                        .HasColumnName("differences_amount");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)")
                        .HasColumnName("status");

                    b.Property<uint>("TotalAmountSnapshot")
                        .HasColumnType("int unsigned")
                        .HasColumnName("total_amount_snapshot");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("bank_histories");
                });

            modelBuilder.Entity("Lifequest.Src.Infrastructure.Db.Tables.BankTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<uint?>("AccountNumber")
                        .HasColumnType("int unsigned")
                        .HasColumnName("account_number");

                    b.Property<string>("BranchName")
                        .HasColumnType("VARCHAR(16)")
                        .HasColumnName("branch_name");

                    b.Property<ushort?>("BranchNumber")
                        .HasColumnType("smallint unsigned")
                        .HasColumnName("branch_number");

                    b.Property<string>("Code")
                        .HasColumnType("longtext")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at");

                    b.Property<uint>("FamilyId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("family_id");

                    b.Property<uint>("FamilymemberId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("family_member_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<uint>("TotalAmount")
                        .HasColumnType("int unsigned")
                        .HasColumnName("total_amount");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("banks");
                });

            modelBuilder.Entity("Lifequest.Src.Infrastructure.Db.Tables.FamilyMembersTable", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at");

                    b.Property<uint>("FamilyId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("family_id");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_owner");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)")
                        .HasColumnName("position");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<uint>("UserId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("family_members");
                });

            modelBuilder.Entity("Lifequest.Src.Infrastructure.Db.Tables.FamilyTable", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("families");
                });

            modelBuilder.Entity("Lifequest.Src.Infrastructure.Db.Tables.FixedCostTable", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at");

                    b.Property<uint>("Expose")
                        .HasColumnType("int unsigned")
                        .HasColumnName("expense");

                    b.Property<uint>("FamilyId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("family_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(128)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("fixed_costs");
                });

            modelBuilder.Entity("Lifequest.Src.Infrastructure.Db.Tables.ScheduleTable", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<uint>("CreatedUserId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("created_user_id");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("end_date_time");

                    b.Property<uint>("FamilyId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("family_id");

                    b.Property<bool>("IsAllDayFlag")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_all_day_flag");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("start_date_time");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("schedules");
                });

            modelBuilder.Entity("Lifequest.Src.Infrastructure.Db.Tables.TaskTable", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("id");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)")
                        .HasColumnName("category");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at");

                    b.Property<uint>("FamilyMemberId")
                        .HasColumnType("int unsigned")
                        .HasColumnName("family_member_id");

                    b.Property<bool>("IsCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_completed");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(128)")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("tasks");
                });

            modelBuilder.Entity("Lifequest.Src.Infrastructure.Db.Tables.UserTable", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("id");

                    b.Property<sbyte>("Age")
                        .HasColumnType("tinyint")
                        .HasColumnName("age");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("birthday");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("email");

                    b.Property<bool>("Gender")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)")
                        .HasColumnName("name");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
