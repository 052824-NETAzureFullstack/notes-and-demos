using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hello_EF.Migrations
{
    /// <inheritdoc />
    public partial class Pet_Species : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetSpeciesID",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetSpeciesID",
                table: "Pets",
                column: "PetSpeciesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Species_PetSpeciesID",
                table: "Pets",
                column: "PetSpeciesID",
                principalTable: "Species",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Species_PetSpeciesID",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetSpeciesID",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetSpeciesID",
                table: "Pets");
        }
    }
}
