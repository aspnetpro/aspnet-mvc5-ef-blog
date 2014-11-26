using AspNetMvcBlog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AspNetMvcBlog.Data.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Categories");
            HasKey(x => x.Id);

            Property(x => x.Permalink)
                .HasMaxLength(70)
                .IsVariableLength()
                .IsRequired();

            Property(x => x.Name)
                .HasMaxLength(70)
                .IsVariableLength()
                .IsRequired();

            HasMany(x => x.Posts)
                .WithOptional(x => x.Category);
        }
    }
}