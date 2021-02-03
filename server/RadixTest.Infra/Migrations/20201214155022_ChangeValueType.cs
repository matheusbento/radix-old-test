using Microsoft.EntityFrameworkCore.Migrations;

namespace RadixTest.Infra.Migrations
{
    public partial class ChangeValueType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Event",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Value",
                table: "Event",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
