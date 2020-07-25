using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Features] ([Name]) VALUES ('Feature_1')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Features] ([Name]) VALUES ('Feature_2')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Features] ([Name]) VALUES ('Feature_3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Features WHERE Features IN ('Feature_1','Feature_2','Feature_3')");
        }
    }
}
