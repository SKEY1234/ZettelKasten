using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ZettelKasten.Models.DTO;

namespace ZettelKasten.ORM;

public partial class ZettelkastenContext : DbContext
{
    public ZettelkastenContext()
    {
    }

    public ZettelkastenContext(DbContextOptions<ZettelkastenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<NoteRelation> NoteRelations { get; set; }

    public virtual DbSet<NoteTagRelation> NoteTagRelations { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("User ID=postgres;Password=1234;Host=localhost;Port=5432;Database=zettelkasten;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.NoteId).HasName("notes_pkey");

            entity.ToTable("notes");

            entity.Property(e => e.NoteId)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("noteid");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedOn).HasColumnName("createdon");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Notes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("notes_userid_fkey");
        });

        modelBuilder.Entity<NoteRelation>(entity =>
        {
            entity.HasKey(e => e.RelationId).HasName("noterelations_pkey");

            entity.ToTable("noterelations");

            entity.Property(e => e.RelationId)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("relationid");
            entity.Property(e => e.SourceNoteId).HasColumnName("sourcenoteid");
            entity.Property(e => e.TargetNoteId).HasColumnName("targetnoteid");

            entity.HasOne(d => d.SourceNote).WithMany(p => p.NoteRelationSourceNotes)
                .HasForeignKey(d => d.SourceNoteId)
                .HasConstraintName("noterelations_sourcenoteid_fkey");

            entity.HasOne(d => d.TargetNote).WithMany(p => p.NoteRelationTargetNotes)
                .HasForeignKey(d => d.TargetNoteId)
                .HasConstraintName("noterelations_targetnoteid_fkey");
        });

        modelBuilder.Entity<NoteTagRelation>(entity =>
        {
            entity.HasKey(e => e.RelationId).HasName("notetagrelations_pkey");

            entity.ToTable("notetagrelations");

            entity.Property(e => e.RelationId)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("relationid");
            entity.Property(e => e.NoteId).HasColumnName("noteid");
            entity.Property(e => e.TagId).HasColumnName("tagid");

            entity.HasOne(d => d.Note).WithMany(p => p.NoteTagRelations)
                .HasForeignKey(d => d.NoteId)
                .HasConstraintName("notetagrelations_noteid_fkey");

            entity.HasOne(d => d.Tag).WithMany(p => p.NoteTagRelations)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("notetagrelations_tagid_fkey");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("tags_pkey");

            entity.ToTable("tags");

            entity.HasIndex(e => e.Name, "tags_name_key").IsUnique();

            entity.Property(e => e.TagId)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("tagid");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("userid");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Pass)
                .HasColumnType("character varying")
                .HasColumnName("pass");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
