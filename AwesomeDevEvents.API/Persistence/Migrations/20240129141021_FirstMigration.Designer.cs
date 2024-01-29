﻿// <auto-generated />
using System;
using AwesomeDevEvents.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AwesomeDevEvents.API.Persistence.Migrations
{
    [DbContext(typeof(DevEventsDbContext))]
    [Migration("20240129141021_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AwesomeDevEvents.API.Entities.DevEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("End_date");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Start_date");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DevEvents");
                });

            modelBuilder.Entity("AwesomeDevEvents.API.Entities.DevEventSpeaker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DevEventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LinkedInProfile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TalkDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TalkTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DevEventId");

                    b.ToTable("DevEventsSpeaker");
                });

            modelBuilder.Entity("AwesomeDevEvents.API.Entities.DevEventSpeaker", b =>
                {
                    b.HasOne("AwesomeDevEvents.API.Entities.DevEvent", null)
                        .WithMany("Speakers")
                        .HasForeignKey("DevEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AwesomeDevEvents.API.Entities.DevEvent", b =>
                {
                    b.Navigation("Speakers");
                });
#pragma warning restore 612, 618
        }
    }
}
