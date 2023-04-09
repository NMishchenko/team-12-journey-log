using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JourneyLog.DAL.Migrations
{
    public partial class FixEntityNamings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelNotes_PlaceTravelLogs_PlaceTravelLogId",
                table: "TravelNotes");

            migrationBuilder.DropTable(
                name: "PlaceTravelLogs");

            migrationBuilder.DropTable(
                name: "TravelPhotos");

            migrationBuilder.RenameColumn(
                name: "PlaceTravelLogId",
                table: "TravelNotes",
                newName: "TravelLogPlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelNotes_PlaceTravelLogId",
                table: "TravelNotes",
                newName: "IX_TravelNotes_TravelLogPlaceId");

            migrationBuilder.CreateTable(
                name: "NotePhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelNoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotePhotos_TravelNotes_TravelNoteId",
                        column: x => x.TravelNoteId,
                        principalTable: "TravelNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelLogPlaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitingOrder = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelLogPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelLogPlaces_TravelLogs_TravelLogId",
                        column: x => x.TravelLogId,
                        principalTable: "TravelLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotePhotos_TravelNoteId",
                table: "NotePhotos",
                column: "TravelNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelLogPlaces_TravelLogId",
                table: "TravelLogPlaces",
                column: "TravelLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelNotes_TravelLogPlaces_TravelLogPlaceId",
                table: "TravelNotes",
                column: "TravelLogPlaceId",
                principalTable: "TravelLogPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelNotes_TravelLogPlaces_TravelLogPlaceId",
                table: "TravelNotes");

            migrationBuilder.DropTable(
                name: "NotePhotos");

            migrationBuilder.DropTable(
                name: "TravelLogPlaces");

            migrationBuilder.RenameColumn(
                name: "TravelLogPlaceId",
                table: "TravelNotes",
                newName: "PlaceTravelLogId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelNotes_TravelLogPlaceId",
                table: "TravelNotes",
                newName: "IX_TravelNotes_PlaceTravelLogId");

            migrationBuilder.CreateTable(
                name: "PlaceTravelLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PlaceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlannedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitingOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceTravelLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceTravelLogs_TravelLogs_TravelLogId",
                        column: x => x.TravelLogId,
                        principalTable: "TravelLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelNoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelPhotos_TravelNotes_TravelNoteId",
                        column: x => x.TravelNoteId,
                        principalTable: "TravelNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaceTravelLogs_TravelLogId",
                table: "PlaceTravelLogs",
                column: "TravelLogId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPhotos_TravelNoteId",
                table: "TravelPhotos",
                column: "TravelNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelNotes_PlaceTravelLogs_PlaceTravelLogId",
                table: "TravelNotes",
                column: "PlaceTravelLogId",
                principalTable: "PlaceTravelLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
