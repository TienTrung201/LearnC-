using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFWebApp.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                });
                migrationBuilder.InsertData(
                    table : "Articles",
                    columns: new[] {"Title","Created","Content"},
                    values:new object[] {
                        "Bài viet 1",new DateTime(2015,2,3),"Noi dung 1"
                    }
                );
                migrationBuilder.InsertData(
                    table : "Articles",
                    columns: new[] {"Title","Created","Content"},
                    values:new object[] {
                        "Bài viet 2",new DateTime(2015,2,3),"Noi dung 2"
                    }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
