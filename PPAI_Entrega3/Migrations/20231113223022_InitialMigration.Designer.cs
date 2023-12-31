﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PPAI_Entrega3.Persistencia;

#nullable disable

namespace PPAI_Entrega3.Migrations
{
    [DbContext(typeof(IVRContexto))]
    [Migration("20231113223022_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("PPAI_Entrega3.Entidades.CambioEstado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EstadoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("FechaHoraFin")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaHoraInicio")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LlamadaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("LlamadaId");

                    b.ToTable("CambioEstado");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AudioMensajeOpciones")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MensajeOpciones")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NroOrden")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroCelular")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Estado");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Estado");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.InformacionCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DatoAValidar")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoInformacionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ValidacionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoInformacionId");

                    b.HasIndex("ValidacionId");

                    b.ToTable("InformacionCliente");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.Llamada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescripcionOperador")
                        .HasColumnType("TEXT");

                    b.Property<string>("DetalleAccionRequerida")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duracion")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EncuestaEnviada")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EstadoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ObservacionAuditor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("OpcionLlamadaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubOpcionLlamadaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("OpcionLlamadaId");

                    b.HasIndex("SubOpcionLlamadaId");

                    b.ToTable("Llamada");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.OpcionLlamada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AudioMensajeSubOpciones")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MensajeSubOpciones")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NroOrden")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("opcionLlamada");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.SubOpcionLlamada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NroOrden")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OpcionLlamadaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OpcionLlamadaId");

                    b.ToTable("SubOpcionLlamada");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.TipoInformacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TipoInformacion");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.Validacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AudioMensajeValidacion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NroOrden")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OpcionLlamadaId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SubOpcionLlamadaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoInformacionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OpcionLlamadaId");

                    b.HasIndex("SubOpcionLlamadaId");

                    b.HasIndex("TipoInformacionId");

                    b.ToTable("Validacion");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.Cancelada", b =>
                {
                    b.HasBaseType("PPAI_Entrega3.Entidades.Estado");

                    b.HasDiscriminator().HasValue("Cancelada");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.EnCurso", b =>
                {
                    b.HasBaseType("PPAI_Entrega3.Entidades.Estado");

                    b.HasDiscriminator().HasValue("EnCurso");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.Finalizada", b =>
                {
                    b.HasBaseType("PPAI_Entrega3.Entidades.Estado");

                    b.HasDiscriminator().HasValue("Finalizada");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.Iniciada", b =>
                {
                    b.HasBaseType("PPAI_Entrega3.Entidades.Estado");

                    b.HasDiscriminator().HasValue("Iniciada");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.CambioEstado", b =>
                {
                    b.HasOne("PPAI_Entrega3.Entidades.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PPAI_Entrega3.Entidades.Llamada", null)
                        .WithMany("CambiosDeEstado")
                        .HasForeignKey("LlamadaId");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.InformacionCliente", b =>
                {
                    b.HasOne("PPAI_Entrega3.Entidades.Cliente", null)
                        .WithMany("InformacionCliente")
                        .HasForeignKey("ClienteId");

                    b.HasOne("PPAI_Entrega3.Entidades.TipoInformacion", "TipoInformacion")
                        .WithMany()
                        .HasForeignKey("TipoInformacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PPAI_Entrega3.Entidades.Validacion", "Validacion")
                        .WithMany()
                        .HasForeignKey("ValidacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoInformacion");

                    b.Navigation("Validacion");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.Llamada", b =>
                {
                    b.HasOne("PPAI_Entrega3.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PPAI_Entrega3.Entidades.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PPAI_Entrega3.Entidades.OpcionLlamada", "OpcionLlamada")
                        .WithMany()
                        .HasForeignKey("OpcionLlamadaId");

                    b.HasOne("PPAI_Entrega3.Entidades.SubOpcionLlamada", "SubOpcionLlamada")
                        .WithMany()
                        .HasForeignKey("SubOpcionLlamadaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Estado");

                    b.Navigation("OpcionLlamada");

                    b.Navigation("SubOpcionLlamada");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.OpcionLlamada", b =>
                {
                    b.HasOne("PPAI_Entrega3.Entidades.Categoria", null)
                        .WithMany("Opciones")
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.SubOpcionLlamada", b =>
                {
                    b.HasOne("PPAI_Entrega3.Entidades.OpcionLlamada", null)
                        .WithMany("SubOpciones")
                        .HasForeignKey("OpcionLlamadaId");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.Validacion", b =>
                {
                    b.HasOne("PPAI_Entrega3.Entidades.OpcionLlamada", null)
                        .WithMany("Validacion")
                        .HasForeignKey("OpcionLlamadaId");

                    b.HasOne("PPAI_Entrega3.Entidades.SubOpcionLlamada", null)
                        .WithMany("Validaciones")
                        .HasForeignKey("SubOpcionLlamadaId");

                    b.HasOne("PPAI_Entrega3.Entidades.TipoInformacion", "TipoInformacion")
                        .WithMany()
                        .HasForeignKey("TipoInformacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoInformacion");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.Categoria", b =>
                {
                    b.Navigation("Opciones");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.Cliente", b =>
                {
                    b.Navigation("InformacionCliente");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.Llamada", b =>
                {
                    b.Navigation("CambiosDeEstado");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.OpcionLlamada", b =>
                {
                    b.Navigation("SubOpciones");

                    b.Navigation("Validacion");
                });

            modelBuilder.Entity("PPAI_Entrega3.Entidades.SubOpcionLlamada", b =>
                {
                    b.Navigation("Validaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
