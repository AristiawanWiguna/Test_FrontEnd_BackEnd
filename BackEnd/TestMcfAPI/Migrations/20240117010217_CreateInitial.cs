using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMcfAPI.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ms_storage_location",
                columns: table => new
                {
                    location_id = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    location_name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ms_storage_location", x => x.location_id);
                });

            migrationBuilder.CreateTable(
                name: "tr_bpkb",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    agreement_number = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    bpkb_no = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    branch_id = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    bpkb_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    faktur_no = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    faktur_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    location_id = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    police_no = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    bpkb_date_in = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_updated_by = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    last_updated_on = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_bpkb", x => x.ID);
                    table.ForeignKey(
                        name : "FK_tr_bpkb", 
                        column : x => x.location_id,
                        principalTable : "ms_storage_location",
                        principalColumn : "location_id",
                        onDelete : ReferentialAction.Cascade
                        );
                });


            migrationBuilder.CreateTable(
                name: "ms_user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ms_user", x => x.user_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tr_bpkb");
            migrationBuilder.DropTable(
                name: "ms_storage_location");
            migrationBuilder.DropTable(
                name: "ms_user");
        }
    }
}
