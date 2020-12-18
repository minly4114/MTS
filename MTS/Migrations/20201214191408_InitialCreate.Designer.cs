﻿// <auto-generated />
using System;
using MTS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MTS.Migrations
{
    [DbContext(typeof(PostgresContext))]
    [Migration("20201214191408_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Mts")
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("MTS.Data.Entities.Call", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("DateEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NumberOfMinutes")
                        .HasColumnType("integer");

                    b.Property<int>("PreferentialNumberOfMinutes")
                        .HasColumnType("integer");

                    b.Property<decimal>("Sum")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Calls");
                });

            modelBuilder.Entity("MTS.Data.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("MTS.Data.Entities.Cost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Locality")
                        .HasColumnType("text");

                    b.Property<decimal>("PreferentialValue")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("MTS.Data.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("MTS.Data.Entities.Call", b =>
                {
                    b.HasOne("MTS.Data.Entities.Client", "Client")
                        .WithMany("Calls")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MTS.Data.Entities.Cost", "Cost")
                        .WithMany("Calls")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Cost");
                });

            modelBuilder.Entity("MTS.Data.Entities.Payment", b =>
                {
                    b.HasOne("MTS.Data.Entities.Call", "Call")
                        .WithOne("Payment")
                        .HasForeignKey("MTS.Data.Entities.Payment", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Call");
                });

            modelBuilder.Entity("MTS.Data.Entities.Call", b =>
                {
                    b.Navigation("Payment");
                });

            modelBuilder.Entity("MTS.Data.Entities.Client", b =>
                {
                    b.Navigation("Calls");
                });

            modelBuilder.Entity("MTS.Data.Entities.Cost", b =>
                {
                    b.Navigation("Calls");
                });
#pragma warning restore 612, 618
        }
    }
}
