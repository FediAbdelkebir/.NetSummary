using Data.Configurations;
using Domain;
using Domaine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
   public class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public Context()
        {
            //Database.EnsureCreated();
        }
        
        public DbSet<Equipe> Equipe { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ExamenBIDB;Integrated Security=true; MultipleActiveResultSets=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Faire appel aux classes de configuration que nous venons de créer(1ère méthode) 
            new ContratConfiguration().Configure(modelBuilder.Entity<Contrat>());


            //Faire appel aux classes de configuration que nous venons de créer(2eme méthode) 
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());


            //Configurer toute les propriétés de type string et dont le nom commence par “Name”
            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //            .SelectMany(t => t.GetProperties())
            //            .Where(p => p.ClrType == typeof(string) && p.Name.StartsWith("Name")))
            //{
            //    property.SetColumnName("MyName");
            //}

            //TPH
            modelBuilder.Entity<Membre>()
                        .HasDiscriminator<string>("Type")
                        .HasValue<Entraineur>("E")
                        .HasValue<Joueur>("J")
                        .HasValue<Membre>("M");

            ////TPT
            //modelBuilder.Entity<Biological>().ToTable("Biologicals");
            //modelBuilder.Entity<Chemical>().ToTable("Chemicals");



            ////Configurer le type d’entité détenu Address
            ////Methode1:
            //modelBuilder.Entity<Chemical>().OwnsOne(c => c.MyAddress, myadd =>
            //{
            //    myadd.Property(a => a.StreetAddress).HasColumnName("MyStreet").HasMaxLength(50); ;
            //    myadd.Property(a => a.City).HasColumnName("MyCity").IsRequired();
            //});

            ////Methode2:
            //modelBuilder.Entity<Chemical>().OwnsOne(typeof(Address), "MyAddress");

            ////Configurer le nom de toutes les tables
            //foreach (var entity in modelBuilder.Model.GetEntityTypes())
            //{
            //   if (entity.Name != "Address") { modelBuilder.Entity(entity.Name).ToTable("Table" + entity.Name); }
            //   }


            ////Configurer les propriétés nommées Key comme clé primaire
            //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties())
            //            .Where(p => p.Name == "CIN"))
            //{
            //    property.IsPrimaryKey();

            //}



        }
    }
}