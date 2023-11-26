﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ZettelKasten.ORM;

#nullable disable

namespace ZettelKasten.Migrations
{
    [DbContext(typeof(ZettelkastenContext))]
    [Migration("20231126102607_ZettelKastenDbMigration")]
    partial class ZettelKastenDbMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ZettelKasten.Models.DTO.Note", b =>
                {
                    b.Property<Guid>("Noteid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("noteid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateOnly?>("Creationdate")
                        .HasColumnType("date")
                        .HasColumnName("creationdate");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("title");

                    b.Property<Guid?>("Userid")
                        .HasColumnType("uuid")
                        .HasColumnName("userid");

                    b.HasKey("Noteid")
                        .HasName("notes_pkey");

                    b.HasIndex("Userid");

                    b.ToTable("notes", (string)null);
                });

            modelBuilder.Entity("ZettelKasten.Models.DTO.Noterelation", b =>
                {
                    b.Property<Guid>("Relationid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("relationid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid?>("Sourcenoteid")
                        .HasColumnType("uuid")
                        .HasColumnName("sourcenoteid");

                    b.Property<Guid?>("Targetnoteid")
                        .HasColumnType("uuid")
                        .HasColumnName("targetnoteid");

                    b.HasKey("Relationid")
                        .HasName("noterelations_pkey");

                    b.HasIndex("Sourcenoteid");

                    b.HasIndex("Targetnoteid");

                    b.ToTable("noterelations", (string)null);
                });

            modelBuilder.Entity("ZettelKasten.Models.DTO.Notetagrelation", b =>
                {
                    b.Property<Guid>("Relationid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("relationid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<Guid?>("Noteid")
                        .HasColumnType("uuid")
                        .HasColumnName("noteid");

                    b.Property<Guid?>("Tagid")
                        .HasColumnType("uuid")
                        .HasColumnName("tagid");

                    b.HasKey("Relationid")
                        .HasName("notetagrelations_pkey");

                    b.HasIndex("Noteid");

                    b.HasIndex("Tagid");

                    b.ToTable("notetagrelations", (string)null);
                });

            modelBuilder.Entity("ZettelKasten.Models.DTO.Tag", b =>
                {
                    b.Property<Guid>("Tagid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("tagid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Tagid")
                        .HasName("tags_pkey");

                    b.HasIndex(new[] { "Name" }, "tags_name_key")
                        .IsUnique();

                    b.ToTable("tags", (string)null);
                });

            modelBuilder.Entity("ZettelKasten.Models.DTO.User", b =>
                {
                    b.Property<Guid>("Userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("userid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("login");

                    b.Property<string>("Pass")
                        .HasColumnType("character varying")
                        .HasColumnName("pass");

                    b.HasKey("Userid")
                        .HasName("users_pkey");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ZettelKasten.Models.DTO.Note", b =>
                {
                    b.HasOne("ZettelKasten.Models.DTO.User", "User")
                        .WithMany("Notes")
                        .HasForeignKey("Userid")
                        .HasConstraintName("notes_userid_fkey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ZettelKasten.Models.DTO.Noterelation", b =>
                {
                    b.HasOne("ZettelKasten.Models.DTO.Note", "Sourcenote")
                        .WithMany("NoterelationSourcenotes")
                        .HasForeignKey("Sourcenoteid")
                        .HasConstraintName("noterelations_sourcenoteid_fkey");

                    b.HasOne("ZettelKasten.Models.DTO.Note", "Targetnote")
                        .WithMany("NoterelationTargetnotes")
                        .HasForeignKey("Targetnoteid")
                        .HasConstraintName("noterelations_targetnoteid_fkey");

                    b.Navigation("Sourcenote");

                    b.Navigation("Targetnote");
                });

            modelBuilder.Entity("ZettelKasten.Models.DTO.Notetagrelation", b =>
                {
                    b.HasOne("ZettelKasten.Models.DTO.Note", "Note")
                        .WithMany("Notetagrelations")
                        .HasForeignKey("Noteid")
                        .HasConstraintName("notetagrelations_noteid_fkey");

                    b.HasOne("ZettelKasten.Models.DTO.Tag", "Tag")
                        .WithMany("Notetagrelations")
                        .HasForeignKey("Tagid")
                        .HasConstraintName("notetagrelations_tagid_fkey");

                    b.Navigation("Note");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("ZettelKasten.Models.DTO.Note", b =>
                {
                    b.Navigation("NoterelationSourcenotes");

                    b.Navigation("NoterelationTargetnotes");

                    b.Navigation("Notetagrelations");
                });

            modelBuilder.Entity("ZettelKasten.Models.DTO.Tag", b =>
                {
                    b.Navigation("Notetagrelations");
                });

            modelBuilder.Entity("ZettelKasten.Models.DTO.User", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
