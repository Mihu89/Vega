using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedExample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Makes] ([Name]) VALUES ('Make_1')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Makes] ([Name]) VALUES ('Make_2')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Makes] ([Name]) VALUES ('Make_3')");

            migrationBuilder.Sql("INSERT INTO [dbo].[Models] ([Name], [MakeId]) VALUES ('Make_1-Model_A', (SELECT ID FROM Makes WHERE Name ='Make_1'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[Models] ([Name], [MakeId]) VALUES ('Make_1-Model_B', (SELECT ID FROM Makes WHERE Name ='Make_1'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[Models] ([Name], [MakeId]) VALUES ('Make_1-Model_C', (SELECT ID FROM Makes WHERE Name ='Make_1'))");

            migrationBuilder.Sql("INSERT INTO [dbo].[Models] ([Name], [MakeId]) VALUES ('Make_2-Model_A', (SELECT ID FROM Makes WHERE Name ='Make_2'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[Models] ([Name], [MakeId]) VALUES ('Make_2-Model_B', (SELECT ID FROM Makes WHERE Name ='Make_2'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[Models] ([Name], [MakeId]) VALUES ('Make_2-Model_C', (SELECT ID FROM Makes WHERE Name ='Make_2'))");

            migrationBuilder.Sql("INSERT INTO [dbo].[Models] ([Name], [MakeId]) VALUES ('Make_3-Model_A', (SELECT ID FROM Makes WHERE Name ='Make_3'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[Models] ([Name], [MakeId]) VALUES ('Make_3-Model_B', (SELECT ID FROM Makes WHERE Name ='Make_3'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[Models] ([Name], [MakeId]) VALUES ('Make_3-Model_C', (SELECT ID FROM Makes WHERE Name ='Make_3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN ('Make_1','Make_2','Make_3')");
            migrationBuilder.Sql("DELETE FROM Models WHERE Name IN ('Make_1-Model_A', 'Make_1-Model_B', 'Make_1-Model_C', 'Make_2-Model_A', 'Make_2-Model_B', 'Make_2-Model_C', 'Make_3-Model_A', 'Make_3-Model_B', 'Make_3-Model_C')");
        }
    }
}
