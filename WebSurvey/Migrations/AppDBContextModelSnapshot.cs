﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSurvey.Data;

namespace WebSurvey.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebSurvey.Data.Models.Answer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("WebSurvey.Data.Models.AnswerQuestion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnswerID")
                        .HasColumnType("int");

                    b.Property<int?>("OptionID")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AnswerID");

                    b.HasIndex("OptionID");

                    b.HasIndex("QuestionID");

                    b.ToTable("AnswersQuestions");
                });

            modelBuilder.Entity("WebSurvey.Data.Models.Option", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("WebSurvey.Data.Models.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("WebSurvey.Data.Models.AnswerQuestion", b =>
                {
                    b.HasOne("WebSurvey.Data.Models.Answer", "Answer")
                        .WithMany("AnswerQuestions")
                        .HasForeignKey("AnswerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebSurvey.Data.Models.Option", "Option")
                        .WithMany("Answers")
                        .HasForeignKey("OptionID");

                    b.HasOne("WebSurvey.Data.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Answer");

                    b.Navigation("Option");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("WebSurvey.Data.Models.Option", b =>
                {
                    b.HasOne("WebSurvey.Data.Models.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("WebSurvey.Data.Models.Answer", b =>
                {
                    b.Navigation("AnswerQuestions");
                });

            modelBuilder.Entity("WebSurvey.Data.Models.Option", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("WebSurvey.Data.Models.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Options");
                });
#pragma warning restore 612, 618
        }
    }
}
