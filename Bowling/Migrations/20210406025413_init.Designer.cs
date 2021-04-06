﻿// <auto-generated />
using System;
using Bowling.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bowling.Migrations
{
    [DbContext(typeof(BowlingLeagueContext))]
    [Migration("20210406025413_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Bowling.Models.Bowler", b =>
                {
                    b.Property<long>("BowlerId")
                        .HasColumnType("int")
                        .HasColumnName("BowlerID");

                    b.Property<string>("BowlerAddress")
                        .HasColumnType("nvarchar (50)");

                    b.Property<string>("BowlerCity")
                        .HasColumnType("nvarchar (50)");

                    b.Property<string>("BowlerFirstName")
                        .HasColumnType("nvarchar (50)");

                    b.Property<string>("BowlerLastName")
                        .HasColumnType("nvarchar (50)");

                    b.Property<string>("BowlerMiddleInit")
                        .HasColumnType("nvarchar (1)");

                    b.Property<string>("BowlerPhoneNumber")
                        .HasColumnType("nvarchar (14)");

                    b.Property<string>("BowlerState")
                        .HasColumnType("nvarchar (2)");

                    b.Property<string>("BowlerZip")
                        .HasColumnType("nvarchar (10)");

                    b.Property<long?>("TeamId")
                        .HasColumnType("int")
                        .HasColumnName("TeamID");

                    b.HasKey("BowlerId");

                    b.HasIndex(new[] { "BowlerLastName" }, "BowlerLastName");

                    b.HasIndex(new[] { "TeamId" }, "BowlersTeamID");

                    b.ToTable("Bowlers");
                });

            modelBuilder.Entity("Bowling.Models.BowlerScore", b =>
                {
                    b.Property<long>("MatchId")
                        .HasColumnType("int")
                        .HasColumnName("MatchID");

                    b.Property<long>("GameNumber")
                        .HasColumnType("smallint");

                    b.Property<long>("BowlerId")
                        .HasColumnType("int")
                        .HasColumnName("BowlerID");

                    b.Property<long?>("HandiCapScore")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("0");

                    b.Property<long?>("RawScore")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("0");

                    b.Property<byte[]>("WonGame")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.HasKey("MatchId", "GameNumber", "BowlerId");

                    b.HasIndex(new[] { "BowlerId" }, "BowlerID");

                    b.HasIndex(new[] { "MatchId", "GameNumber" }, "MatchGamesBowlerScores");

                    b.ToTable("Bowler_Scores");
                });

            modelBuilder.Entity("Bowling.Models.MatchGame", b =>
                {
                    b.Property<long>("MatchId")
                        .HasColumnType("int")
                        .HasColumnName("MatchID");

                    b.Property<long>("GameNumber")
                        .HasColumnType("smallint");

                    b.Property<long?>("WinningTeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("WinningTeamID")
                        .HasDefaultValueSql("0");

                    b.HasKey("MatchId", "GameNumber");

                    b.HasIndex(new[] { "WinningTeamId" }, "Team1ID");

                    b.HasIndex(new[] { "MatchId" }, "TourneyMatchesMatchGames");

                    b.ToTable("Match_Games");
                });

            modelBuilder.Entity("Bowling.Models.Team", b =>
                {
                    b.Property<long>("TeamId")
                        .HasColumnType("int")
                        .HasColumnName("TeamID");

                    b.Property<long?>("CaptainId")
                        .HasColumnType("int")
                        .HasColumnName("CaptainID");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar (50)");

                    b.HasKey("TeamId");

                    b.HasIndex(new[] { "TeamId" }, "TeamID")
                        .IsUnique();

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Bowling.Models.Tournament", b =>
                {
                    b.Property<long>("TourneyId")
                        .HasColumnType("int")
                        .HasColumnName("TourneyID");

                    b.Property<byte[]>("TourneyDate")
                        .HasColumnType("date");

                    b.Property<string>("TourneyLocation")
                        .HasColumnType("nvarchar (50)");

                    b.HasKey("TourneyId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Bowling.Models.TourneyMatch", b =>
                {
                    b.Property<long>("MatchId")
                        .HasColumnType("int")
                        .HasColumnName("MatchID");

                    b.Property<long?>("EvenLaneTeamId")
                        .HasColumnType("int")
                        .HasColumnName("EvenLaneTeamID")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Lanes")
                        .HasColumnType("nvarchar (5)");

                    b.Property<long?>("OddLaneTeamId")
                        .HasColumnType("int")
                        .HasColumnName("OddLaneTeamID")
                        .HasDefaultValueSql("0");

                    b.Property<long?>("TourneyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TourneyID")
                        .HasDefaultValueSql("0");

                    b.HasKey("MatchId");

                    b.HasIndex(new[] { "OddLaneTeamId" }, "TourneyMatchesOdd");

                    b.HasIndex(new[] { "TourneyId" }, "TourneyMatchesTourneyID");

                    b.HasIndex(new[] { "EvenLaneTeamId" }, "Tourney_MatchesEven");

                    b.ToTable("Tourney_Matches");
                });

            modelBuilder.Entity("Bowling.Models.ZtblBowlerRating", b =>
                {
                    b.Property<string>("BowlerRating")
                        .HasColumnType("nvarchar (15)");

                    b.Property<long?>("BowlerHighAvg")
                        .HasColumnType("smallint");

                    b.Property<long?>("BowlerLowAvg")
                        .HasColumnType("smallint");

                    b.HasKey("BowlerRating");

                    b.ToTable("ztblBowlerRatings");
                });

            modelBuilder.Entity("Bowling.Models.ZtblSkipLabel", b =>
                {
                    b.Property<long>("LabelCount")
                        .HasColumnType("int");

                    b.HasKey("LabelCount");

                    b.ToTable("ztblSkipLabels");
                });

            modelBuilder.Entity("Bowling.Models.ZtblWeek", b =>
                {
                    b.Property<byte[]>("WeekStart")
                        .HasColumnType("date");

                    b.Property<byte[]>("WeekEnd")
                        .HasColumnType("date");

                    b.HasKey("WeekStart");

                    b.ToTable("ztblWeeks");
                });

            modelBuilder.Entity("Bowling.Models.Bowler", b =>
                {
                    b.HasOne("Bowling.Models.Team", "Team")
                        .WithMany("Bowlers")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Bowling.Models.BowlerScore", b =>
                {
                    b.HasOne("Bowling.Models.Bowler", "Bowler")
                        .WithMany("BowlerScores")
                        .HasForeignKey("BowlerId")
                        .IsRequired();

                    b.Navigation("Bowler");
                });

            modelBuilder.Entity("Bowling.Models.MatchGame", b =>
                {
                    b.HasOne("Bowling.Models.TourneyMatch", "Match")
                        .WithMany("MatchGames")
                        .HasForeignKey("MatchId")
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Bowling.Models.TourneyMatch", b =>
                {
                    b.HasOne("Bowling.Models.Team", "EvenLaneTeam")
                        .WithMany("TourneyMatchEvenLaneTeams")
                        .HasForeignKey("EvenLaneTeamId");

                    b.HasOne("Bowling.Models.Team", "OddLaneTeam")
                        .WithMany("TourneyMatchOddLaneTeams")
                        .HasForeignKey("OddLaneTeamId");

                    b.HasOne("Bowling.Models.Tournament", "Tourney")
                        .WithMany("TourneyMatches")
                        .HasForeignKey("TourneyId");

                    b.Navigation("EvenLaneTeam");

                    b.Navigation("OddLaneTeam");

                    b.Navigation("Tourney");
                });

            modelBuilder.Entity("Bowling.Models.Bowler", b =>
                {
                    b.Navigation("BowlerScores");
                });

            modelBuilder.Entity("Bowling.Models.Team", b =>
                {
                    b.Navigation("Bowlers");

                    b.Navigation("TourneyMatchEvenLaneTeams");

                    b.Navigation("TourneyMatchOddLaneTeams");
                });

            modelBuilder.Entity("Bowling.Models.Tournament", b =>
                {
                    b.Navigation("TourneyMatches");
                });

            modelBuilder.Entity("Bowling.Models.TourneyMatch", b =>
                {
                    b.Navigation("MatchGames");
                });
#pragma warning restore 612, 618
        }
    }
}
