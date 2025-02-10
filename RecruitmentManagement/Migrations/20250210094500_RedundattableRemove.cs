using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentManagement.Migrations
{
    /// <inheritdoc />
    public partial class RedundattableRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentStatuses");

            migrationBuilder.RenameColumn(
                name: "document_status_id",
                table: "Documents",
                newName: "document_status_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_document_status_type_id",
                table: "Documents",
                column: "document_status_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentStatusTypes_document_status_type_id",
                table: "Documents",
                column: "document_status_type_id",
                principalTable: "DocumentStatusTypes",
                principalColumn: "document_status_type_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentStatusTypes_document_status_type_id",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_document_status_type_id",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "document_status_type_id",
                table: "Documents",
                newName: "document_status_id");

            migrationBuilder.CreateTable(
                name: "DocumentStatuses",
                columns: table => new
                {
                    document_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    document_id = table.Column<int>(type: "int", nullable: false),
                    document_status_type_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentStatuses", x => x.document_status_id);
                    table.ForeignKey(
                        name: "FK_DocumentStatuses_DocumentStatusTypes_document_status_type_id",
                        column: x => x.document_status_type_id,
                        principalTable: "DocumentStatusTypes",
                        principalColumn: "document_status_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentStatuses_Documents_document_id",
                        column: x => x.document_id,
                        principalTable: "Documents",
                        principalColumn: "document_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentStatuses_document_id",
                table: "DocumentStatuses",
                column: "document_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentStatuses_document_status_type_id",
                table: "DocumentStatuses",
                column: "document_status_type_id");
        }
    }
}
