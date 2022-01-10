using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class PostulantConfiguration : IEntityTypeConfiguration<Postulant>
    {

        public void Configure(EntityTypeBuilder<Postulant> builder)
        {
            //Many to Many
            builder.HasMany(p => p.Offres)
            .WithMany(v => v.Postulants)
            .UsingEntity(
                j => j.ToTable("Candidature"));//Table d'association

        }
    }
}