﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateArtist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Songs_SongId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_SongId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Artists");

            migrationBuilder.CreateTable(
                name: "ArtistSong",
                columns: table => new
                {
                    ArtistsId = table.Column<int>(type: "int", nullable: false),
                    SongsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSong", x => new { x.ArtistsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_ArtistSong_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSong_SongsId",
                table: "ArtistSong",
                column: "SongsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistSong");

            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artists_SongId",
                table: "Artists",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Songs_SongId",
                table: "Artists",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id");
        }
    }
}
