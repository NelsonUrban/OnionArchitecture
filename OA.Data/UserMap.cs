using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace OA.Data
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entitiBuilder)
        {
            entitiBuilder.HasKey(t => t.Id);
            entitiBuilder.Property(t => t.Email).IsRequired();
            entitiBuilder.Property(t => t.Password).IsRequired();
            entitiBuilder.Property(t => t.UserName).IsRequired();
            entitiBuilder.HasOne(t => t.UserProfile)
                         .WithOne(x => x.User)
                         .HasForeignKey<UserProfile>(x => x.Id);
        }

    }
}
