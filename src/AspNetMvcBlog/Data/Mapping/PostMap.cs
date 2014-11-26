using AspNetMvcBlog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AspNetMvcBlog.Data.Mapping
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            ToTable("Posts");
            HasKey(x => x.Id);

            Property(x => x.Permalink)
                .HasMaxLength(100)
                .IsVariableLength()
                .IsRequired();

            Property(x => x.Title)
                .HasMaxLength(70)
                .IsVariableLength()
                .IsRequired();

            Property(x => x.Summary)
                .HasMaxLength(500)
                .IsVariableLength()
                .IsRequired();

            Property(x => x.Content)
                .IsMaxLength()
                .IsVariableLength()
                .IsOptional();

            Property(x => x.Tags)
                .HasMaxLength(150)
                .IsVariableLength()
                .IsOptional();
        }
    }
}