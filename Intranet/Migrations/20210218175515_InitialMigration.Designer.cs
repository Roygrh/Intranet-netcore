﻿// <auto-generated />
using System;
using Intranet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Intranet.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210218175515_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Intranet.Models.IT_AUTORIZACION", b =>
                {
                    b.Property<decimal>("AUTORIZACION_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(6,0)")
                        .HasColumnName("AUTORIZACION_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DESCRIPCION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FECHA_CREACION")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_EDICION")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_INGRESA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_MODIFICA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_RETORNO_PROG")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_SALIDA_PROG")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_ULTIMO_ESTADO")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("FILE")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("HORA_RETORNO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HORA_RETORNO_SEGURIDAD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HORA_SALIDA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HORA_SALIDA_SEGURIDAD")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("ID_AREA_FUNCIONAL")
                        .HasColumnType("numeric(6,0)");

                    b.Property<decimal>("ID_ESTADO")
                        .HasColumnType("numeric(6,0)");

                    b.Property<decimal>("ID_MOTIVO")
                        .HasColumnType("numeric(6,0)");

                    b.Property<decimal?>("ID_TIPO_USUARIO")
                        .HasColumnType("numeric(6,0)");

                    b.Property<string>("NOMBRE_ARCHIVO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RETORNO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TIPO_CONTENIDO_FILE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USUARIO_AUTORIZA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USUARIO_CREA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USUARIO_EDITA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("USUARIO_INGRESA")
                        .HasColumnType("numeric(4,0)");

                    b.Property<decimal?>("USUARIO_MODIFICA")
                        .HasColumnType("numeric(4,0)");

                    b.HasKey("AUTORIZACION_ID");

                    b.HasIndex("ID_ESTADO");

                    b.HasIndex("ID_MOTIVO");

                    b.ToTable("IT_AUTORIZACION");
                });

            modelBuilder.Entity("Intranet.Models.IT_AUTORIZACION_AUDITORIA", b =>
                {
                    b.Property<decimal>("AUTORIZACION_AUDITORIA_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(6,0)")
                        .HasColumnName("AUTORIZACION_AUDITORIA_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AUTORIZACION_ID")
                        .HasColumnType("numeric(6,0)");

                    b.Property<string>("DESCRIPCION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FECHA_CREACION")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_EDICION")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_INGRESA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_MODIFICA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_MOVIMIENTO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_RETORNO_PROG")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_SALIDA_PROG")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_ULTIMO_ESTADO")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("FILE")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("HORA_RETORNO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HORA_RETORNO_SEGURIDAD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HORA_SALIDA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HORA_SALIDA_SEGURIDAD")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("ID_AREA_FUNCIONAL")
                        .HasColumnType("numeric(6,0)");

                    b.Property<decimal>("ID_ESTADO")
                        .HasColumnType("numeric(6,0)");

                    b.Property<decimal>("ID_MOTIVO")
                        .HasColumnType("numeric(6,0)");

                    b.Property<decimal?>("ID_TIPO_USUARIO")
                        .HasColumnType("numeric(6,0)");

                    b.Property<string>("NOMBRE_ARCHIVO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RETORNO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TIPO_CONTENIDO_FILE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TIPO_MOVIMIENTO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USUARIO_AUTORIZA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USUARIO_CREA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USUARIO_EDITA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("USUARIO_INGRESA")
                        .HasColumnType("numeric(4,0)");

                    b.Property<decimal?>("USUARIO_MODIFICA")
                        .HasColumnType("numeric(4,0)");

                    b.HasKey("AUTORIZACION_AUDITORIA_ID");

                    b.HasIndex("AUTORIZACION_ID");

                    b.ToTable("IT_AUTORIZACION_AUDITORIA");
                });

            modelBuilder.Entity("Intranet.Models.IT_AUTORIZACION_MOVIMIENTOS", b =>
                {
                    b.Property<decimal>("MOVIMIENTO_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(6,0)")
                        .HasColumnName("MOVIMIENTO_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FECHA_CREACION")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_INGRESA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_MODIFICA")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("ID_AREA_FUNCIONAL")
                        .HasColumnType("numeric(6,0)");

                    b.Property<decimal>("ID_AUTORIZACION")
                        .HasColumnType("numeric(6,0)");

                    b.Property<decimal>("ID_ESTADO")
                        .HasColumnType("numeric(6,0)");

                    b.Property<decimal>("ID_MOTIVO")
                        .HasColumnType("numeric(6,0)");

                    b.Property<decimal?>("ID_TIPO_USUARIO")
                        .HasColumnType("numeric(6,0)");

                    b.Property<string>("ID_USUARIO_AUTORIZA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USUARIO_CREA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("USUARIO_INGRESA")
                        .HasColumnType("numeric(4,0)");

                    b.Property<decimal?>("USUARIO_MODIFICA")
                        .HasColumnType("numeric(4,0)");

                    b.HasKey("MOVIMIENTO_ID");

                    b.HasIndex("ID_AUTORIZACION");

                    b.ToTable("IT_AUTORIZACION_MOVIMIENTOS");
                });

            modelBuilder.Entity("Intranet.Models.IT_CONTENIDO_GENERAL", b =>
                {
                    b.Property<decimal>("CONTENIDO_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(6,0)")
                        .HasColumnName("CONTENIDO_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DESCRIPCION_CONTENIDO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FECHA_CREACION")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_EDICION")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_INGRESA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_MODIFICA")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("FILE")
                        .HasColumnType("varbinary(max)");

                    b.Property<decimal?>("ID_AREA_FUNCIONAL")
                        .HasColumnType("numeric(6,0)");

                    b.Property<string>("NOMBRE_ARCHIVO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NOMBRE_CONTENIDO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TIPO_CONTENIDO_FILE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TIPO_CONTENIDO_ID")
                        .HasColumnType("numeric(6,0)");

                    b.Property<string>("UBICACION_ARCHIVO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USUARIO_CREA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USUARIO_EDITA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("USUARIO_INGRESA")
                        .HasColumnType("numeric(4,0)");

                    b.Property<decimal?>("USUARIO_MODIFICA")
                        .HasColumnType("numeric(4,0)");

                    b.HasKey("CONTENIDO_ID");

                    b.HasIndex("TIPO_CONTENIDO_ID");

                    b.ToTable("IT_CONTENIDO_GENERAL");
                });

            modelBuilder.Entity("Intranet.Models.IT_CONTENIDO_GENERAL_AUDITORIA", b =>
                {
                    b.Property<decimal>("CONTENIDO_GENERAL_AUDITORIA_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(6,0)")
                        .HasColumnName("CONTENIDO_GENERAL_AUDITORIA_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("CONTENIDO_ID")
                        .HasColumnType("numeric(6,0)");

                    b.Property<string>("DESCRIPCION_CONTENIDO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FECHA_CREACION")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_EDICION")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_INGRESA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_MODIFICA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_MOVIMIENTO")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("FILE")
                        .HasColumnType("varbinary(max)");

                    b.Property<decimal?>("ID_AREA_FUNCIONAL")
                        .HasColumnType("numeric(6,0)");

                    b.Property<decimal?>("ID_TIPO_CONTENIDO")
                        .HasColumnType("numeric(6,0)");

                    b.Property<string>("NOMBRE_ARCHIVO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NOMBRE_CONTENIDO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TIPO_CONTENIDO_FILE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TIPO_MOVIMIENTO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UBICACION_ARCHIVO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USUARIO_CREA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USUARIO_EDITA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("USUARIO_INGRESA")
                        .HasColumnType("numeric(4,0)");

                    b.Property<decimal?>("USUARIO_MODIFICA")
                        .HasColumnType("numeric(4,0)");

                    b.HasKey("CONTENIDO_GENERAL_AUDITORIA_ID");

                    b.HasIndex("CONTENIDO_ID");

                    b.ToTable("IT_CONTENIDO_GENERAL_AUDITORIA");
                });

            modelBuilder.Entity("Intranet.Models.IT_ESTADO_AUTORIZACION", b =>
                {
                    b.Property<decimal>("ESTADO_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(6,0)")
                        .HasColumnName("ESTADO_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FECHA_INGRESA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_MODIFICA")
                        .HasColumnType("datetime2");

                    b.Property<string>("NOMBRE_ESTADO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("USUARIO_INGRESA")
                        .HasColumnType("numeric(4,0)");

                    b.Property<decimal?>("USUARIO_MODIFICA")
                        .HasColumnType("numeric(4,0)");

                    b.HasKey("ESTADO_ID");

                    b.ToTable("IT_ESTADO_AUTORIZACION");
                });

            modelBuilder.Entity("Intranet.Models.IT_MOTIVO_AUTORIZACION", b =>
                {
                    b.Property<decimal>("MOTIVO_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(6,0)")
                        .HasColumnName("MOTIVO_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FECHA_INGRESA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_MODIFICA")
                        .HasColumnType("datetime2");

                    b.Property<string>("NOMBRE_MOTIVO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("USUARIO_INGRESA")
                        .HasColumnType("numeric(4,0)");

                    b.Property<decimal?>("USUARIO_MODIFICA")
                        .HasColumnType("numeric(4,0)");

                    b.HasKey("MOTIVO_ID");

                    b.ToTable("IT_MOTIVO_AUTORIZACION");
                });

            modelBuilder.Entity("Intranet.Models.IT_TIPO_CONTENIDO", b =>
                {
                    b.Property<decimal>("TIPO_CONTENIDO_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(6,0)")
                        .HasColumnName("TIPO_CONTENIDO_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FECHA_INGRESA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FECHA_MODIFICA")
                        .HasColumnType("datetime2");

                    b.Property<string>("NOMBRE_TIPO_CONTENIDO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("USUARIO_INGRESA")
                        .HasColumnType("numeric(4,0)");

                    b.Property<decimal?>("USUARIO_MODIFICA")
                        .HasColumnType("numeric(4,0)");

                    b.HasKey("TIPO_CONTENIDO_ID");

                    b.ToTable("IT_TIPO_CONTENIDO");
                });

            modelBuilder.Entity("Intranet.Models.IT_AUTORIZACION", b =>
                {
                    b.HasOne("Intranet.Models.IT_ESTADO_AUTORIZACION", "IT_ESTADO_AUTORIZACION")
                        .WithMany()
                        .HasForeignKey("ID_ESTADO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Intranet.Models.IT_MOTIVO_AUTORIZACION", "IT_MOTIVO_AUTORIZACION")
                        .WithMany()
                        .HasForeignKey("ID_MOTIVO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IT_ESTADO_AUTORIZACION");

                    b.Navigation("IT_MOTIVO_AUTORIZACION");
                });

            modelBuilder.Entity("Intranet.Models.IT_AUTORIZACION_AUDITORIA", b =>
                {
                    b.HasOne("Intranet.Models.IT_AUTORIZACION", "IT_AUTORIZACION")
                        .WithMany()
                        .HasForeignKey("AUTORIZACION_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IT_AUTORIZACION");
                });

            modelBuilder.Entity("Intranet.Models.IT_AUTORIZACION_MOVIMIENTOS", b =>
                {
                    b.HasOne("Intranet.Models.IT_AUTORIZACION", "IT_AUTORIZACION")
                        .WithMany()
                        .HasForeignKey("ID_AUTORIZACION")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IT_AUTORIZACION");
                });

            modelBuilder.Entity("Intranet.Models.IT_CONTENIDO_GENERAL", b =>
                {
                    b.HasOne("Intranet.Models.IT_TIPO_CONTENIDO", "IT_TIPO_CONTENIDO")
                        .WithMany()
                        .HasForeignKey("TIPO_CONTENIDO_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IT_TIPO_CONTENIDO");
                });

            modelBuilder.Entity("Intranet.Models.IT_CONTENIDO_GENERAL_AUDITORIA", b =>
                {
                    b.HasOne("Intranet.Models.IT_CONTENIDO_GENERAL", "IT_CONTENIDO_GENERAL")
                        .WithMany()
                        .HasForeignKey("CONTENIDO_ID");

                    b.Navigation("IT_CONTENIDO_GENERAL");
                });
#pragma warning restore 612, 618
        }
    }
}
