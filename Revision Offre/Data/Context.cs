using Data.Configurations;
using Domain;
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
        
        public DbSet<Offre> Offre { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ExamenOffreDB;Integrated Security=true; MultipleActiveResultSets=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Faire appel aux classes de configuration que nous venons de créer(1ère méthode) 
            new PostulantConfiguration().Configure(modelBuilder.Entity<Postulant>());


            //Faire appel aux classes de configuration que nous venons de créer(2eme méthode) 
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());


            //Configurer toute propriété qui commence par Id comme clé primaire.
            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //            .SelectMany(t => t.GetProperties())
            //            .Where(p => p.ClrType == typeof(int) && p.Name.StartsWith("Id")))
            //{
            //    property.SetMaxLength(30);
            //}

            ////TPH
            //modelBuilder.Entity<Product>()
            //            .HasDiscriminator<int>("IsBiological")
            //            .HasValue<Biological>(1)
            //            .HasValue<Chemical>(2)
            //            .HasValue<Product>(0);

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

            //Methode2:
            modelBuilder.Entity<Entreprise>().OwnsOne(typeof(Adresse), "AdresseEntreprise");

            ////Configurer le nom de toutes les tables
            //foreach (var entity in modelBuilder.Model.GetEntityTypes())
            //{
            //   if (entity.Name != "Address") { modelBuilder.Entity(entity.Name).ToTable("Table" + entity.Name); }
            //   }


            ////Configurer les propriétés nommées Key comme clé primaire
            //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties())
            //            .Where(p => p.Name.StartsWith("Id")))
            //{
            //    property.IsPrimaryKey();

            //}



        }
    }
}