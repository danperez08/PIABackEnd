﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PIABackEnd;

#nullable disable

namespace PIABackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230516042648_Citas_Paciente")]
    partial class Citas_Paciente
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PIABackEnd.Entidades.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("PIABackEnd.Entidades.Cita_Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CitaId")
                        .HasColumnType("int");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CitaId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Cita_Pacientes");
                });

            modelBuilder.Entity("PIABackEnd.Entidades.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("PIABackEnd.Entidades.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("PIABackEnd.Entidades.Cita", b =>
                {
                    b.HasOne("PIABackEnd.Entidades.Doctor", "Doctor")
                        .WithMany("citas")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIABackEnd.Entidades.Paciente", "Paciente")
                        .WithMany("citas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("PIABackEnd.Entidades.Cita_Paciente", b =>
                {
                    b.HasOne("PIABackEnd.Entidades.Cita", "Cita")
                        .WithMany("cita_pacientes")
                        .HasForeignKey("CitaId");

                    b.HasOne("PIABackEnd.Entidades.Paciente", "Paciente")
                        .WithMany("cita_pacientes")
                        .HasForeignKey("PacienteId");

                    b.Navigation("Cita");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("PIABackEnd.Entidades.Cita", b =>
                {
                    b.Navigation("cita_pacientes");
                });

            modelBuilder.Entity("PIABackEnd.Entidades.Doctor", b =>
                {
                    b.Navigation("citas");
                });

            modelBuilder.Entity("PIABackEnd.Entidades.Paciente", b =>
                {
                    b.Navigation("cita_pacientes");

                    b.Navigation("citas");
                });
#pragma warning restore 612, 618
        }
    }
}
