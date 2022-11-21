using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediCare2._0.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alternative",
                columns: table => new
                {
                    alternativeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alternativeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternative", x => x.alternativeID);
                });

            migrationBuilder.CreateTable(
                name: "Contraindiction",
                columns: table => new
                {
                    contraindicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contraindicationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contraindiction", x => x.contraindicationID);
                });

            migrationBuilder.CreateTable(
                name: "DrugAdmin",
                columns: table => new
                {
                    drugAdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adminType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugAdmin", x => x.drugAdminID);
                });

            migrationBuilder.CreateTable(
                name: "Phase",
                columns: table => new
                {
                    phaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phaseStage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phaseDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phase", x => x.phaseID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    regionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    regionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.regionID);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    scheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    scheduleNumber = table.Column<int>(type: "int", nullable: false),
                    scheduleDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.scheduleID);
                });

            migrationBuilder.CreateTable(
                name: "SideEffect",
                columns: table => new
                {
                    sideEffectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sideEffectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sideEffectDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    sideEffectDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideEffect", x => x.sideEffectID);
                });

            migrationBuilder.CreateTable(
                name: "Symptom",
                columns: table => new
                {
                    symptomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    symptomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    symptomDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    symptomDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptom", x => x.symptomID);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    companyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    companyEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    companyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyCount = table.Column<int>(type: "int", nullable: false),
                    regionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.companyID);
                    table.ForeignKey(
                        name: "FK_Company_Region_regionID",
                        column: x => x.regionID,
                        principalTable: "Region",
                        principalColumn: "regionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drug",
                columns: table => new
                {
                    drugID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    drugName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dosage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dateFirstManufactured = table.Column<DateTime>(type: "datetime2", nullable: false),
                    drugAdminID = table.Column<int>(type: "int", nullable: false),
                    sideEffectID = table.Column<int>(type: "int", nullable: false),
                    symptomID = table.Column<int>(type: "int", nullable: false),
                    companyID = table.Column<int>(type: "int", nullable: false),
                    phaseID = table.Column<int>(type: "int", nullable: false),
                    alternativeID = table.Column<int>(type: "int", nullable: false),
                    contraindicationID = table.Column<int>(type: "int", nullable: false),
                    scheduleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drug", x => x.drugID);
                    table.ForeignKey(
                        name: "FK_Drug_Alternative_alternativeID",
                        column: x => x.alternativeID,
                        principalTable: "Alternative",
                        principalColumn: "alternativeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drug_Company_companyID",
                        column: x => x.companyID,
                        principalTable: "Company",
                        principalColumn: "companyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drug_Contraindiction_contraindicationID",
                        column: x => x.contraindicationID,
                        principalTable: "Contraindiction",
                        principalColumn: "contraindicationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drug_DrugAdmin_drugAdminID",
                        column: x => x.drugAdminID,
                        principalTable: "DrugAdmin",
                        principalColumn: "drugAdminID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drug_Phase_phaseID",
                        column: x => x.phaseID,
                        principalTable: "Phase",
                        principalColumn: "phaseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drug_Schedule_scheduleID",
                        column: x => x.scheduleID,
                        principalTable: "Schedule",
                        principalColumn: "scheduleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drug_SideEffect_sideEffectID",
                        column: x => x.sideEffectID,
                        principalTable: "SideEffect",
                        principalColumn: "sideEffectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drug_Symptom_symptomID",
                        column: x => x.symptomID,
                        principalTable: "Symptom",
                        principalColumn: "symptomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_regionID",
                table: "Company",
                column: "regionID");

            migrationBuilder.CreateIndex(
                name: "IX_Drug_alternativeID",
                table: "Drug",
                column: "alternativeID");

            migrationBuilder.CreateIndex(
                name: "IX_Drug_companyID",
                table: "Drug",
                column: "companyID");

            migrationBuilder.CreateIndex(
                name: "IX_Drug_contraindicationID",
                table: "Drug",
                column: "contraindicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Drug_drugAdminID",
                table: "Drug",
                column: "drugAdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Drug_phaseID",
                table: "Drug",
                column: "phaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Drug_scheduleID",
                table: "Drug",
                column: "scheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_Drug_sideEffectID",
                table: "Drug",
                column: "sideEffectID");

            migrationBuilder.CreateIndex(
                name: "IX_Drug_symptomID",
                table: "Drug",
                column: "symptomID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drug");

            migrationBuilder.DropTable(
                name: "Alternative");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Contraindiction");

            migrationBuilder.DropTable(
                name: "DrugAdmin");

            migrationBuilder.DropTable(
                name: "Phase");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "SideEffect");

            migrationBuilder.DropTable(
                name: "Symptom");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
