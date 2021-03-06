// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projek_UTSAren.Data;

namespace Projek_UTSAren.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220408164305_terakhirasli")]
    partial class terakhirasli
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Projek_UTSAren.Models.Alumni", b =>
                {
                    b.Property<string>("NIM")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Jenis_kelamin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nama_alumni")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pekerjaan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RolesId")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("Tahun_angkatan")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tanggal_lahir")
                        .HasColumnType("datetime");

                    b.Property<string>("Telp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tempat_lahir")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("NIM");

                    b.HasIndex("RolesId");

                    b.ToTable("Tb_Alumni");
                });

            modelBuilder.Entity("Projek_UTSAren.Models.Event", b =>
                {
                    b.Property<string>("Id_event")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("Batas_daftar")
                        .HasColumnType("datetime");

                    b.Property<string>("Id_angkatan")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Keterangan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nama_event")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime");

                    b.Property<string>("Tempat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Waktu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_event");

                    b.HasIndex("Id_angkatan");

                    b.ToTable("Tb_Event");
                });

            modelBuilder.Entity("Projek_UTSAren.Models.Roles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tb_Roles");
                });

            modelBuilder.Entity("Projek_UTSAren.Models.Tahun", b =>
                {
                    b.Property<string>("Id_angkatan")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Nama_angkatan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tahun_angkatan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_angkatan");

                    b.ToTable("Tb_Tahun");
                });

            modelBuilder.Entity("Projek_UTSAren.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nama_Lengkap")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RolesId")
                        .HasColumnType("varchar(767)");

                    b.HasKey("Username");

                    b.HasIndex("RolesId");

                    b.ToTable("Tb_User");
                });

            modelBuilder.Entity("Projek_UTSAren.Models.Alumni", b =>
                {
                    b.HasOne("Projek_UTSAren.Models.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RolesId");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Projek_UTSAren.Models.Event", b =>
                {
                    b.HasOne("Projek_UTSAren.Models.Tahun", "Nama_angkatan")
                        .WithMany()
                        .HasForeignKey("Id_angkatan");

                    b.Navigation("Nama_angkatan");
                });

            modelBuilder.Entity("Projek_UTSAren.Models.Tahun", b =>
                {
                    b.HasOne("Projek_UTSAren.Models.Event", "Nama_event")
                        .WithMany()
                        .HasForeignKey("Id_angkatan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nama_event");
                });

            modelBuilder.Entity("Projek_UTSAren.Models.User", b =>
                {
                    b.HasOne("Projek_UTSAren.Models.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RolesId");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
