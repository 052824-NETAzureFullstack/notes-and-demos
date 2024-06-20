using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hello_EF.Migrations
{
    /// <inheritdoc />
    public partial class Intitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuteness = table.Column<int>(type: "int", nullable: true),
                    PetSpeciesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pets_Species_PetSpeciesID",
                        column: x => x.PetSpeciesID,
                        principalTable: "Species",
                        principalColumn: "ID");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetSpeciesID",
                table: "Pets",
                column: "PetSpeciesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnerPet");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
