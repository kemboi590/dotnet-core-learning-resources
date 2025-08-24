using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAnnotation.Migrations
{
    /// <inheritdoc />
    public partial class manymanyrel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Courses_CoursesId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentsId",
                table: "CourseStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent");

            migrationBuilder.RenameTable(
                name: "CourseStudent",
                newName: "StudentCourses");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_StudentsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                columns: new[] { "CoursesId", "StudentsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CoursesId",
                table: "StudentCourses",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentsId",
                table: "StudentCourses",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CoursesId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentsId",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                newName: "CourseStudent");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_StudentsId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_StudentsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent",
                columns: new[] { "CoursesId", "StudentsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Courses_CoursesId",
                table: "CourseStudent",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentsId",
                table: "CourseStudent",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
