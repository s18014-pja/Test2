using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test2.Migrations
{
    public partial class AddedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Doctors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Doctors",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Doctors",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "idDoctor",
                table: "Doctors",
                newName: "IdDoctor");

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    IdPatient1 = table.Column<int>(nullable: true),
                    IdDoctor1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_IdDoctor1",
                        column: x => x.IdDoctor1,
                        principalTable: "Doctors",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_IdPatient1",
                        column: x => x.IdPatient1,
                        principalTable: "Patients",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdDoctor1",
                table: "Prescriptions",
                column: "IdDoctor1");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdPatient1",
                table: "Prescriptions",
                column: "IdPatient1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Doctors",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Doctors",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Doctors",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "IdDoctor",
                table: "Doctors",
                newName: "idDoctor");
        }
    }
}
