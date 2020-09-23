﻿using Forum.Doman.PublicUsers.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Forum.Domain.PublicUsers.Models.ModelConstants.Common;

namespace Forum.Infrastructure.PublicUsers.Configurations
{
    public class PublicUserConfiguration : IEntityTypeConfiguration<PublicUser>
    {
        public void Configure(EntityTypeBuilder<PublicUser> builder)
        {
             builder
                .HasKey(pu => pu.Id);

            builder
                .Property(pu => pu.UserName)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                  .Property(pu => pu.Email)
                  .IsRequired()
                  .HasMaxLength(MaxEmailLength);

            builder
                .HasMany(pu => pu.Posts)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("posts");

            builder
               .HasMany(pu => pu.Comments)
               .WithOne()
               .Metadata
               .PrincipalToDependent
               .SetField("comments");
        }
    }
}
