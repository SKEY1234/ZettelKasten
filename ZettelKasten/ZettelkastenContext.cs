using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ZettelKasten.Models;

namespace ZettelKasten;

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

    public virtual DbSet<Noterelation> Noterelations { get; set; }

    public virtual DbSet<Notetagrelation> Notetagrelations { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("User ID=postgres;Password=1234;Host=localhost;Port=5432;Database=zettelkasten;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.Noteid).HasName("notes_pkey");

            entity.ToTable("notes");

            entity.Property(e => e.Noteid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("noteid");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Creationdate).HasColumnName("creationdate");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Notes)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("notes_userid_fkey");
        });

        modelBuilder.Entity<Noterelation>(entity =>
        {
            entity.HasKey(e => e.Relationid).HasName("noterelations_pkey");

            entity.ToTable("noterelations");

            entity.Property(e => e.Relationid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("relationid");
            entity.Property(e => e.Sourcenoteid).HasColumnName("sourcenoteid");
            entity.Property(e => e.Targetnoteid).HasColumnName("targetnoteid");

            entity.HasOne(d => d.Sourcenote).WithMany(p => p.NoterelationSourcenotes)
                .HasForeignKey(d => d.Sourcenoteid)
                .HasConstraintName("noterelations_sourcenoteid_fkey");

            entity.HasOne(d => d.Targetnote).WithMany(p => p.NoterelationTargetnotes)
                .HasForeignKey(d => d.Targetnoteid)
                .HasConstraintName("noterelations_targetnoteid_fkey");
        });

        modelBuilder.Entity<Notetagrelation>(entity =>
        {
            entity.HasKey(e => e.Relationid).HasName("notetagrelations_pkey");

            entity.ToTable("notetagrelations");

            entity.Property(e => e.Relationid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("relationid");
            entity.Property(e => e.Noteid).HasColumnName("noteid");
            entity.Property(e => e.Tagid).HasColumnName("tagid");

            entity.HasOne(d => d.Note).WithMany(p => p.Notetagrelations)
                .HasForeignKey(d => d.Noteid)
                .HasConstraintName("notetagrelations_noteid_fkey");

            entity.HasOne(d => d.Tag).WithMany(p => p.Notetagrelations)
                .HasForeignKey(d => d.Tagid)
                .HasConstraintName("notetagrelations_tagid_fkey");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Tagid).HasName("tags_pkey");

            entity.ToTable("tags");

            entity.HasIndex(e => e.Name, "tags_name_key").IsUnique();

            entity.Property(e => e.Tagid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("tagid");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Userid)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("userid");
            entity.Property(e => e.Firstname)
                .HasColumnType("character varying")
                .HasColumnName("firstname");
            entity.Property(e => e.Lasstname)
                .HasColumnType("character varying")
                .HasColumnName("lasstname");
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
