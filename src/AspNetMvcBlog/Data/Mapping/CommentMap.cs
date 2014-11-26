using AspNetMvcBlog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AspNetMvcBlog.Data.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            ToTable("PostsComments");
            HasKey(x => x.Id);

            Property(x => x.Author)
                .HasMaxLength(100)
                .IsVariableLength()
                .IsRequired();

            Property(x => x.Email)
                .HasMaxLength(100)
                .IsVariableLength()
                .IsRequired();

            Property(x => x.Content)
                .IsMaxLength()
                .IsVariableLength()
                .IsOptional();

            HasRequired(x => x.Post)
                .WithMany(x => x.Comments);
        }
    }
}