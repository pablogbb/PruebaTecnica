﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnica.Core.ProjectAggregate;

namespace PruebaTecnica.Infrastructure.Data.Config;
public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
  public void Configure(EntityTypeBuilder<Project> builder)
  {
    builder.Property(p => p.Name)
        .HasMaxLength(100)
        .IsRequired();

    builder.Property(p => p.Priority)
      .HasConversion(
          p => p.Value,
          p => PriorityStatus.FromValue(p));
  }
}
