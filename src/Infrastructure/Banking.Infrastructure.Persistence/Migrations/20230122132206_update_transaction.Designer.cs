﻿// <auto-generated />
using System;
using Banking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Banking.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(BankingContext))]
    [Migration("20230122132206_update_transaction")]
    partial class updatetransaction
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Banking.Infrastructure.Persistence.Entities.Account", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("IBAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Banking.Infrastructure.Persistence.Entities.Transaction", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DestinationAccountID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SourceAccountID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DestinationAccountID");

                    b.HasIndex("SourceAccountID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Banking.Infrastructure.Persistence.Entities.Transaction", b =>
                {
                    b.HasOne("Banking.Infrastructure.Persistence.Entities.Account", "DestinationAccount")
                        .WithMany("TransactionsIn")
                        .HasForeignKey("DestinationAccountID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Banking.Infrastructure.Persistence.Entities.Account", "SourceAccount")
                        .WithMany("TransactionsOut")
                        .HasForeignKey("SourceAccountID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("DestinationAccount");

                    b.Navigation("SourceAccount");
                });

            modelBuilder.Entity("Banking.Infrastructure.Persistence.Entities.Account", b =>
                {
                    b.Navigation("TransactionsIn");

                    b.Navigation("TransactionsOut");
                });
#pragma warning restore 612, 618
        }
    }
}
