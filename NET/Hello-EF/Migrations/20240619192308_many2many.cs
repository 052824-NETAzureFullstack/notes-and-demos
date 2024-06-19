using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hello_EF.Migrations
{
    /// <inheritdoc />
    public partial class many2many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Owners_OwnerID",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_OwnerID",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Pets");

            migrationBuilder.CreateTable(
                name: "OwnerPet",
                columns: table => new
                {
                    OwnedPetID = table.Column<int>(type: "int", nullable: false),
                    PetOwnersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerPet", x => new { x.OwnedPetID, x.PetOwnersID });
                    table.ForeignKey(
                        name: "FK_OwnerPet_Owners_PetOwnersID",
                        column: x => x.PetOwnersID,
                        principalTable: "Owners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerPet_Pets_OwnedPetID",
                        column: x => x.OwnedPetID,
                        principalTable: "Pets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnerPet_PetOwnersID",
                table: "OwnerPet",
                column: "PetOwnersID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnerPet");

            migrationBuilder.AddColumn<int>(
                name: "OwnerID",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_OwnerID",
                table: "Pets",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Owners_OwnerID",
                table: "Pets",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID");
        }
    }
}
