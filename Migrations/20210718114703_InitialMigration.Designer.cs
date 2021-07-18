﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using covidAPI.Implementation;

namespace covidAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210718114703_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("covidAPI.Models.CovidCase", b =>
                {
                    b.Property<int>("intId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("dtmLastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("dtmObservationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("intConfirmed")
                        .HasColumnType("integer");

                    b.Property<int>("intDeaths")
                        .HasColumnType("integer");

                    b.Property<int>("intRecovered")
                        .HasColumnType("integer");

                    b.Property<string>("strCountry")
                        .HasColumnType("text");

                    b.Property<string>("strProvince")
                        .HasColumnType("text");

                    b.HasKey("intId");

                    b.ToTable("covid_observation");
                });
#pragma warning restore 612, 618
        }
    }
}
