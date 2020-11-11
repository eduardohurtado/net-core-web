using Microsoft.EntityFrameworkCore.Migrations;

namespace net_core_web.Migrations
{
    public partial class PhotoRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "photoRoute",
                table: "Friends",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photoRoute",
                table: "Friends");
        }
    }
}
