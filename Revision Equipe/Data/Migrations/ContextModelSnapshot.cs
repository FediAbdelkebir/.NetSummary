﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Equipe", b =>
                {
                    b.Property<int>("EquipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdresseLocal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomEquipe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipeId");

                    b.ToTable("Equipe");
                });

            modelBuilder.Entity("Domaine.Contrat", b =>
                {
                    b.Property<DateTime>("DateContrat")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipeFk")
                        .HasColumnType("int");

                    b.Property<int>("MembreFk")
                        .HasColumnType("int");

                    b.Property<int>("DureeMois")
                        .HasColumnType("int");

                    b.Property<int>("Identifiant")
                        .HasColumnType("int");

                    b.Property<double>("Salaire")
                        .HasColumnType("float");

                    b.HasKey("DateContrat", "EquipeFk", "MembreFk");

                    b.HasIndex("EquipeFk");

                    b.HasIndex("MembreFk");

                    b.ToTable("Contrat");
                });

            modelBuilder.Entity("Domaine.Membre", b =>
                {
                    b.Property<int>("Identifiant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateNaisssance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identifiant");

                    b.ToTable("Membre");

                    b.HasDiscriminator<string>("Type").HasValue("M");
                });

            modelBuilder.Entity("Domaine.Trophee", b =>
                {
                    b.Property<int>("TropheeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTrophee")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipeFK")
                        .HasColumnType("int");

                    b.Property<int?>("EquipeId")
                        .HasColumnType("int");

                    b.Property<double>("Recompense")
                        .HasColumnType("float");

                    b.Property<string>("TypeTrophee")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TropheeId");

                    b.HasIndex("EquipeId");

                    b.ToTable("Trophee");
                });

            modelBuilder.Entity("Domaine.Entraineur", b =>
                {
                    b.HasBaseType("Domaine.Membre");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("E");
                });

            modelBuilder.Entity("Domaine.Joueur", b =>
                {
                    b.HasBaseType("Domaine.Membre");

                    b.Property<string>("Poste")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("J");
                });

            modelBuilder.Entity("Domaine.Contrat", b =>
                {
                    b.HasOne("Domain.Equipe", "Equipe")
                        .WithMany("Contrats")
                        .HasForeignKey("EquipeFk")
                        .IsRequired();

                    b.HasOne("Domaine.Membre", "Membre")
                        .WithMany("Contrats")
                        .HasForeignKey("MembreFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");

                    b.Navigation("Membre");
                });

            modelBuilder.Entity("Domaine.Trophee", b =>
                {
                    b.HasOne("Domain.Equipe", "Equipe")
                        .WithMany("Trophees")
                        .HasForeignKey("EquipeId");

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("Domain.Equipe", b =>
                {
                    b.Navigation("Contrats");

                    b.Navigation("Trophees");
                });

            modelBuilder.Entity("Domaine.Membre", b =>
                {
                    b.Navigation("Contrats");
                });
#pragma warning restore 612, 618
        }
    }
}