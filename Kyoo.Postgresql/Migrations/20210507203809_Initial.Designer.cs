﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Kyoo.Models;
using Kyoo.Postgresql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Kyoo.Postgresql.Migrations
{
    [DbContext(typeof(PostgresContext))]
    [Migration("20210507203809_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresEnum(null, "item_type", new[] { "show", "movie", "collection" })
                .HasPostgresEnum(null, "status", new[] { "finished", "airing", "planned", "unknown" })
                .HasPostgresEnum(null, "stream_type", new[] { "unknown", "video", "audio", "subtitle", "attachment" })
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Kyoo.Models.Collection", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Overview")
                        .HasColumnType("text");

                    b.Property<string>("Poster")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("Kyoo.Models.Episode", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AbsoluteNumber")
                        .HasColumnType("integer");

                    b.Property<int>("EpisodeNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Overview")
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Runtime")
                        .HasColumnType("integer");

                    b.Property<int?>("SeasonID")
                        .HasColumnType("integer");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("integer");

                    b.Property<int>("ShowID")
                        .HasColumnType("integer");

                    b.Property<string>("Thumb")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("SeasonID");

                    b.HasIndex("ShowID", "SeasonNumber", "EpisodeNumber", "AbsoluteNumber")
                        .IsUnique();

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("Kyoo.Models.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Kyoo.Models.Library", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string[]>("Paths")
                        .HasColumnType("text[]");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("Kyoo.Models.Link<Kyoo.Models.Collection, Kyoo.Models.Show>", b =>
                {
                    b.Property<int>("FirstID")
                        .HasColumnType("integer");

                    b.Property<int>("SecondID")
                        .HasColumnType("integer");

                    b.HasKey("FirstID", "SecondID");

                    b.HasIndex("SecondID");

                    b.ToTable("Link<Collection, Show>");
                });

            modelBuilder.Entity("Kyoo.Models.Link<Kyoo.Models.Library, Kyoo.Models.Collection>", b =>
                {
                    b.Property<int>("FirstID")
                        .HasColumnType("integer");

                    b.Property<int>("SecondID")
                        .HasColumnType("integer");

                    b.HasKey("FirstID", "SecondID");

                    b.HasIndex("SecondID");

                    b.ToTable("Link<Library, Collection>");
                });

            modelBuilder.Entity("Kyoo.Models.Link<Kyoo.Models.Library, Kyoo.Models.Provider>", b =>
                {
                    b.Property<int>("FirstID")
                        .HasColumnType("integer");

                    b.Property<int>("SecondID")
                        .HasColumnType("integer");

                    b.HasKey("FirstID", "SecondID");

                    b.HasIndex("SecondID");

                    b.ToTable("Link<Library, Provider>");
                });

            modelBuilder.Entity("Kyoo.Models.Link<Kyoo.Models.Library, Kyoo.Models.Show>", b =>
                {
                    b.Property<int>("FirstID")
                        .HasColumnType("integer");

                    b.Property<int>("SecondID")
                        .HasColumnType("integer");

                    b.HasKey("FirstID", "SecondID");

                    b.HasIndex("SecondID");

                    b.ToTable("Link<Library, Show>");
                });

            modelBuilder.Entity("Kyoo.Models.Link<Kyoo.Models.Show, Kyoo.Models.Genre>", b =>
                {
                    b.Property<int>("FirstID")
                        .HasColumnType("integer");

                    b.Property<int>("SecondID")
                        .HasColumnType("integer");

                    b.HasKey("FirstID", "SecondID");

                    b.HasIndex("SecondID");

                    b.ToTable("Link<Show, Genre>");
                });

            modelBuilder.Entity("Kyoo.Models.Link<Kyoo.Models.User, Kyoo.Models.Show>", b =>
                {
                    b.Property<int>("FirstID")
                        .HasColumnType("integer");

                    b.Property<int>("SecondID")
                        .HasColumnType("integer");

                    b.HasKey("FirstID", "SecondID");

                    b.HasIndex("SecondID");

                    b.ToTable("Link<User, Show>");
                });

            modelBuilder.Entity("Kyoo.Models.MetadataID", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DataID")
                        .HasColumnType("text");

                    b.Property<int?>("EpisodeID")
                        .HasColumnType("integer");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<int?>("PeopleID")
                        .HasColumnType("integer");

                    b.Property<int>("ProviderID")
                        .HasColumnType("integer");

                    b.Property<int?>("SeasonID")
                        .HasColumnType("integer");

                    b.Property<int?>("ShowID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("EpisodeID");

                    b.HasIndex("PeopleID");

                    b.HasIndex("ProviderID");

                    b.HasIndex("SeasonID");

                    b.HasIndex("ShowID");

                    b.ToTable("MetadataIds");
                });

            modelBuilder.Entity("Kyoo.Models.People", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Poster")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("People");
                });

            modelBuilder.Entity("Kyoo.Models.PeopleRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("PeopleID")
                        .HasColumnType("integer");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<int>("ShowID")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("PeopleID");

                    b.HasIndex("ShowID");

                    b.ToTable("PeopleRoles");
                });

            modelBuilder.Entity("Kyoo.Models.Provider", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<string>("LogoExtension")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("Kyoo.Models.Season", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Overview")
                        .HasColumnType("text");

                    b.Property<string>("Poster")
                        .HasColumnType("text");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("integer");

                    b.Property<int>("ShowID")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int?>("Year")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ShowID", "SeasonNumber")
                        .IsUnique();

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("Kyoo.Models.Show", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string[]>("Aliases")
                        .HasColumnType("text[]");

                    b.Property<string>("Backdrop")
                        .HasColumnType("text");

                    b.Property<int?>("EndYear")
                        .HasColumnType("integer");

                    b.Property<bool>("IsMovie")
                        .HasColumnType("boolean");

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<string>("Overview")
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<string>("Poster")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("StartYear")
                        .HasColumnType("integer");

                    b.Property<Status?>("Status")
                        .HasColumnType("status");

                    b.Property<int?>("StudioID")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("TrailerUrl")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.HasIndex("StudioID");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("Kyoo.Models.Studio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("Kyoo.Models.Track", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Codec")
                        .HasColumnType("text");

                    b.Property<int>("EpisodeID")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsExternal")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsForced")
                        .HasColumnType("boolean");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("TrackIndex")
                        .HasColumnType("integer");

                    b.Property<StreamType>("Type")
                        .HasColumnType("stream_type");

                    b.HasKey("ID");

                    b.HasIndex("EpisodeID", "Type", "Language", "TrackIndex", "IsForced")
                        .IsUnique();

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("Kyoo.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<Dictionary<string, string>>("ExtraData")
                        .HasColumnType("jsonb");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string[]>("Permissions")
                        .HasColumnType("text[]");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Kyoo.Models.WatchedEpisode", b =>
                {
                    b.Property<int>("FirstID")
                        .HasColumnType("integer");

                    b.Property<int>("SecondID")
                        .HasColumnType("integer");

                    b.Property<int>("WatchedPercentage")
                        .HasColumnType("integer");

                    b.HasKey("FirstID", "SecondID");

                    b.HasIndex("SecondID");

                    b.ToTable("WatchedEpisodes");
                });

            modelBuilder.Entity("Kyoo.Models.Episode", b =>
                {
                    b.HasOne("Kyoo.Models.Season", "Season")
                        .WithMany("Episodes")
                        .HasForeignKey("SeasonID");

                    b.HasOne("Kyoo.Models.Show", "Show")
                        .WithMany("Episodes")
                        .HasForeignKey("ShowID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");

                    b.Navigation("Show");
                });

            modelBuilder.Entity("Kyoo.Models.Link<Kyoo.Models.Collection, Kyoo.Models.Show>", b =>
                {
                    b.HasOne("Kyoo.Models.Collection", "First")
                        .WithMany("ShowLinks")
                        .HasForeignKey("FirstID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kyoo.Models.Show", "Second")
                        .WithMany("CollectionLinks")
                        .HasForeignKey("SecondID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("First");

                    b.Navigation("Second");
                });

            modelBuilder.Entity("Kyoo.Models.Link<Kyoo.Models.Library, Kyoo.Models.Collection>", b =>
                {
                    b.HasOne("Kyoo.Models.Library", "First")
                        .WithMany("CollectionLinks")
                        .HasForeignKey("FirstID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kyoo.Models.Collection", "Second")
                        .WithMany("LibraryLinks")
                        .HasForeignKey("SecondID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("First");

                    b.Navigation("Second");
                });

            modelBuilder.Entity("Kyoo.Models.Link<Kyoo.Models.Library, Kyoo.Models.Provider>", b =>
                {
                    b.HasOne("Kyoo.Models.Library", "First")
                        .WithMany("ProviderLinks")
                        .HasForeignKey("FirstID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kyoo.Models.Provider", "Second")
                        .WithMany("LibraryLinks")
                        .HasForeignKey("SecondID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("First");

                    b.Navigation("Second");
                });

            modelBuilder.Entity("Kyoo.Models.Link<Kyoo.Models.Library, Kyoo.Models.Show>", b =>
                {
                    b.HasOne("Kyoo.Models.Library", "First")
                        .WithMany("ShowLinks")
                        .HasForeignKey("FirstID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kyoo.Models.Show", "Second")
                        .WithMany("LibraryLinks")
                        .HasForeignKey("SecondID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("First");

                    b.Navigation("Second");
                });

            modelBuilder.Entity("Kyoo.Models.Link<Kyoo.Models.Show, Kyoo.Models.Genre>", b =>
                {
                    b.HasOne("Kyoo.Models.Show", "First")
                        .WithMany("GenreLinks")
                        .HasForeignKey("FirstID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kyoo.Models.Genre", "Second")
                        .WithMany("ShowLinks")
                        .HasForeignKey("SecondID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("First");

                    b.Navigation("Second");
                });

            modelBuilder.Entity("Kyoo.Models.Link<Kyoo.Models.User, Kyoo.Models.Show>", b =>
                {
                    b.HasOne("Kyoo.Models.User", "First")
                        .WithMany("ShowLinks")
                        .HasForeignKey("FirstID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kyoo.Models.Show", "Second")
                        .WithMany()
                        .HasForeignKey("SecondID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("First");

                    b.Navigation("Second");
                });

            modelBuilder.Entity("Kyoo.Models.MetadataID", b =>
                {
                    b.HasOne("Kyoo.Models.Episode", "Episode")
                        .WithMany("ExternalIDs")
                        .HasForeignKey("EpisodeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kyoo.Models.People", "People")
                        .WithMany("ExternalIDs")
                        .HasForeignKey("PeopleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kyoo.Models.Provider", "Provider")
                        .WithMany("MetadataLinks")
                        .HasForeignKey("ProviderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kyoo.Models.Season", "Season")
                        .WithMany("ExternalIDs")
                        .HasForeignKey("SeasonID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kyoo.Models.Show", "Show")
                        .WithMany("ExternalIDs")
                        .HasForeignKey("ShowID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Episode");

                    b.Navigation("People");

                    b.Navigation("Provider");

                    b.Navigation("Season");

                    b.Navigation("Show");
                });

            modelBuilder.Entity("Kyoo.Models.PeopleRole", b =>
                {
                    b.HasOne("Kyoo.Models.People", "People")
                        .WithMany("Roles")
                        .HasForeignKey("PeopleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kyoo.Models.Show", "Show")
                        .WithMany("People")
                        .HasForeignKey("ShowID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("People");

                    b.Navigation("Show");
                });

            modelBuilder.Entity("Kyoo.Models.Season", b =>
                {
                    b.HasOne("Kyoo.Models.Show", "Show")
                        .WithMany("Seasons")
                        .HasForeignKey("ShowID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");
                });

            modelBuilder.Entity("Kyoo.Models.Show", b =>
                {
                    b.HasOne("Kyoo.Models.Studio", "Studio")
                        .WithMany("Shows")
                        .HasForeignKey("StudioID");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("Kyoo.Models.Track", b =>
                {
                    b.HasOne("Kyoo.Models.Episode", "Episode")
                        .WithMany("Tracks")
                        .HasForeignKey("EpisodeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Episode");
                });

            modelBuilder.Entity("Kyoo.Models.WatchedEpisode", b =>
                {
                    b.HasOne("Kyoo.Models.User", "First")
                        .WithMany("CurrentlyWatching")
                        .HasForeignKey("FirstID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kyoo.Models.Episode", "Second")
                        .WithMany()
                        .HasForeignKey("SecondID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("First");

                    b.Navigation("Second");
                });

            modelBuilder.Entity("Kyoo.Models.Collection", b =>
                {
                    b.Navigation("LibraryLinks");

                    b.Navigation("ShowLinks");
                });

            modelBuilder.Entity("Kyoo.Models.Episode", b =>
                {
                    b.Navigation("ExternalIDs");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Kyoo.Models.Genre", b =>
                {
                    b.Navigation("ShowLinks");
                });

            modelBuilder.Entity("Kyoo.Models.Library", b =>
                {
                    b.Navigation("CollectionLinks");

                    b.Navigation("ProviderLinks");

                    b.Navigation("ShowLinks");
                });

            modelBuilder.Entity("Kyoo.Models.People", b =>
                {
                    b.Navigation("ExternalIDs");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Kyoo.Models.Provider", b =>
                {
                    b.Navigation("LibraryLinks");

                    b.Navigation("MetadataLinks");
                });

            modelBuilder.Entity("Kyoo.Models.Season", b =>
                {
                    b.Navigation("Episodes");

                    b.Navigation("ExternalIDs");
                });

            modelBuilder.Entity("Kyoo.Models.Show", b =>
                {
                    b.Navigation("CollectionLinks");

                    b.Navigation("Episodes");

                    b.Navigation("ExternalIDs");

                    b.Navigation("GenreLinks");

                    b.Navigation("LibraryLinks");

                    b.Navigation("People");

                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("Kyoo.Models.Studio", b =>
                {
                    b.Navigation("Shows");
                });

            modelBuilder.Entity("Kyoo.Models.User", b =>
                {
                    b.Navigation("CurrentlyWatching");

                    b.Navigation("ShowLinks");
                });
#pragma warning restore 612, 618
        }
    }
}