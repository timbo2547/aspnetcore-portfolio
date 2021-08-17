using Microsoft.EntityFrameworkCore.Migrations;

namespace TimPortfolioApp.Migrations
{
    public partial class AddApplicationUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "SampleItems",
                type: "text",
                nullable: true);
        }
    }
}
