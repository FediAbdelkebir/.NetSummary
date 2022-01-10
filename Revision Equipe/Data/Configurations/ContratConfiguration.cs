using Domaine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class ContratConfiguration : IEntityTypeConfiguration<Contrat>
    {
        public void Configure(EntityTypeBuilder<Contrat> builder)
        {
            builder.HasKey(f => new
            {
                f.DateContrat,
                f.EquipeFk,
                f.MembreFk
            });

            builder.HasOne(f => f.Equipe)
            .WithMany(c => c.Contrats)
            .HasForeignKey(f => f.EquipeFk).OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(f => f.Membre)
           .WithMany(p => p.Contrats)
           .HasForeignKey(f => f.MembreFk);
        }
    }
}
