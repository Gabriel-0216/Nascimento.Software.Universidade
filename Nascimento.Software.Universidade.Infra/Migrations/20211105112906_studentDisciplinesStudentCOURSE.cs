using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nascimento.Software.Universidade.Infra.Migrations
{
    public partial class studentDisciplinesStudentCOURSE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentDisciplinesId",
                table: "Disciplines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ra = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentDisciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDisciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentDisciplines_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_StudentDisciplinesId",
                table: "Disciplines",
                column: "StudentDisciplinesId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentId",
                table: "StudentCourse",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDisciplines_StudentId",
                table: "StudentDisciplines",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_StudentDisciplines_StudentDisciplinesId",
                table: "Disciplines",
                column: "StudentDisciplinesId",
                principalTable: "StudentDisciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_StudentDisciplines_StudentDisciplinesId",
                table: "Disciplines");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "StudentDisciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_StudentDisciplinesId",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "StudentDisciplinesId",
                table: "Disciplines");
        }
    }
}
