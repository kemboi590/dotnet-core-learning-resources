using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBranchProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Branches",
                newName: "BranchPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Branches",
                newName: "BranchEmail");

            migrationBuilder.AddColumn<string>(
                name: "BranchLocation",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchLocation",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "BranchPhoneNumber",
                table: "Branches",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "BranchEmail",
                table: "Branches",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
