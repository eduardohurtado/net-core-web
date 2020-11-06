using Microsoft.EntityFrameworkCore.Migrations;

namespace net_core_web.Migrations
{
    public partial class seedFriendTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "City", "Email", "Name" },
                values: new object[] { 1, 1, "test@test.com", "Test SQL" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
