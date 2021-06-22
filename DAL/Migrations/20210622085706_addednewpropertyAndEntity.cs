using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addednewpropertyAndEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Tutions",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tutions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "AppliedBy",
                table: "Tutions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedTo",
                table: "Tutions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    To = table.Column<string>(nullable: false),
                    From = table.Column<string>(nullable: false),
                    Msg = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Tutions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Not Applied");

            migrationBuilder.UpdateData(
                table: "Tutions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Not Applied");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropColumn(
                name: "AppliedBy",
                table: "Tutions");

            migrationBuilder.DropColumn(
                name: "ApprovedTo",
                table: "Tutions");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Tutions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tutions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Tutions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tutions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: true);
        }
    }
}
