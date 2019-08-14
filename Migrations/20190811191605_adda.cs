using Microsoft.EntityFrameworkCore.Migrations;

namespace Messege.Migrations
{
    public partial class adda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messagess_AspNetUsers_SenderId",
                table: "Messagess");

            migrationBuilder.DropIndex(
                name: "IX_Messagess_SenderId",
                table: "Messagess");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Messagess");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Messagess",
                newName: "Sender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sender",
                table: "Messagess",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "Messagess",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messagess_SenderId",
                table: "Messagess",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messagess_AspNetUsers_SenderId",
                table: "Messagess",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
