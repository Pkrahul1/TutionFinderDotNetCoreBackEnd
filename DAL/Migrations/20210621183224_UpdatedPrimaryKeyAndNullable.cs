using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdatedPrimaryKeyAndNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "Teachers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Teachers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Teachers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Students",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Email");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Email",
                keyValue: "pkrahul.ks16@gmail.com",
                columns: new[] { "ConfirmPassword", "Password" },
                values: new object[] { "12345678", "12345678" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Email",
                keyValue: "rahull.ks16@gmail.com",
                columns: new[] { "ConfirmPassword", "Password" },
                values: new object[] { "12345678", "12345678" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Email",
                keyValue: "pchristy@gmail.com",
                columns: new[] { "ConfirmPassword", "Password" },
                values: new object[] { "12345678", "12345678" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Email",
                keyValue: "rahulll.ks18@gmail.com",
                columns: new[] { "ConfirmPassword", "Password" },
                values: new object[] { "12345678", "12345678" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Email",
                keyValue: "pkrahul.ks16@gmail.com");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Email",
                keyValue: "rahull.ks16@gmail.com");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Email",
                keyValue: "pchristy@gmail.com");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Email",
                keyValue: "rahulll.ks18@gmail.com");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Teachers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Students",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "City", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Chapra", "pkrahul.ks16@gmail.com", "Mary" },
                    { 2, "Patna", "rahull.ks16@gmail.com", "Darry" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "About", "City", "Email", "Gender", "Name", "Skills" },
                values: new object[,]
                {
                    { 1, "I can teach from class 5 to 10 , All Subjects.", "Patna", "rahulll.ks18@gmail.com", 0, "David", "MATH, ENGLISH,SCIENCE" },
                    { 2, "I can teach from class 8 to 10 , All Subjects.", "Chapra", "pchristy@gmail.com", 1, "Christy Pearly", "MATH, ENGLISH,SCIENCE" }
                });
        }
    }
}
