﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORT;

namespace ORT.Migrations
{
    [DbContext(typeof(Model))]
    [Migration("20190623150633_xx2")]
    partial class xx2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ORT.AlergiayEnfermedad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.Property<string>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("AlergiasyEnfermedades");
                });

            modelBuilder.Entity("ORT.AyEdeHistoriaClinica", b =>
                {
                    b.Property<int>("HistoriaClinicaId");

                    b.Property<int>("AlergiayEnfermedadId");

                    b.HasKey("HistoriaClinicaId", "AlergiayEnfermedadId");

                    b.HasIndex("AlergiayEnfermedadId");

                    b.ToTable("AyEdeHistoriasClinicas");
                });

            modelBuilder.Entity("ORT.HistoriaClinica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaInicio");

                    b.Property<string>("GrupoSanguineo");

                    b.Property<string>("Observaciones");

                    b.Property<int>("PacienteId");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId")
                        .IsUnique();

                    b.ToTable("HistoriasClinicas");
                });

            modelBuilder.Entity("ORT.LineaReceta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadRecetado");

                    b.Property<int>("MedicamentoId");

                    b.Property<int>("RecetaId");

                    b.HasKey("Id");

                    b.HasIndex("RecetaId");

                    b.ToTable("LineasRecetas");
                });

            modelBuilder.Entity("ORT.Receta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("VisitaId");

                    b.HasKey("Id");

                    b.HasIndex("VisitaId")
                        .IsUnique();

                    b.ToTable("Recetas");
                });

            modelBuilder.Entity("ORT.Visita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Diagnostico");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("HistoriaClinicaId");

                    b.Property<int>("MedicoId");

                    b.Property<int>("PartidaMedicamentoId");

                    b.Property<string>("Sintomas");

                    b.HasKey("Id");

                    b.HasIndex("HistoriaClinicaId");

                    b.ToTable("Visitas");
                });

            modelBuilder.Entity("ORT.AyEdeHistoriaClinica", b =>
                {
                    b.HasOne("ORT.AlergiayEnfermedad", "AlergiayEnfermedad")
                        .WithMany()
                        .HasForeignKey("AlergiayEnfermedadId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ORT.HistoriaClinica", "HistoriaClinica")
                        .WithMany()
                        .HasForeignKey("HistoriaClinicaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ORT.LineaReceta", b =>
                {
                    b.HasOne("ORT.Receta", "Receta")
                        .WithMany("LineaRecetas")
                        .HasForeignKey("RecetaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ORT.Receta", b =>
                {
                    b.HasOne("ORT.Visita", "Visita")
                        .WithOne("Receta")
                        .HasForeignKey("ORT.Receta", "VisitaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ORT.Visita", b =>
                {
                    b.HasOne("ORT.HistoriaClinica", "HistoriaClinica")
                        .WithMany("Visitas")
                        .HasForeignKey("HistoriaClinicaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
