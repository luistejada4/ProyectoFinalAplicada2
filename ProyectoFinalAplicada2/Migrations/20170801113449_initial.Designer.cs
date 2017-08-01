using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProyectoFinalAplicada2.Models;

namespace ProyectoFinalAplicada2.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20170801113449_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyectoFinalAplicada2.Models.Boleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventoId");

                    b.Property<DateTime>("Fecha");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Boletas");
                });

            modelBuilder.Entity("ProyectoFinalAplicada2.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("Fecha");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("ProyectoFinalAplicada2.Models.Boleta", b =>
                {
                    b.HasOne("ProyectoFinalAplicada2.Models.Evento", "Evento")
                        .WithMany("Boletas")
                        .HasForeignKey("EventoId");
                });
        }
    }
}
