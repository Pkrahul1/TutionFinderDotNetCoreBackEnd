using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddedStudentTeacherTution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Skills = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tutions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: false),
                    CreaterId = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutions", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Tutions",
                columns: new[] { "Id", "City", "CreaterId", "Description", "Status" },
                values: new object[,]
                {
                    { 1, "chapra", "rahull.ks16@gmail.com", "I can teach from class 5 to 10 , All Subjects.", true },
                    { 2, "Patna", "pkrahul.ks16@gmail.com", "I can teach from class 5 to 10 , All Subjects.", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Tutions");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    EmailID = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "EmailID", "Name" },
                values: new object[] { 1, "Chapra", "mary@pragimtech.com", "Mary" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "EmailID", "Name" },
                values: new object[] { 2, "Patna", "dary@pragimtech.com", "Darry" });
        }
    }
}
