using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cwiczenia_6.Migrations
{
    public partial class UpdateSeedAndPrescriptionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[] { 2, "Lek przeciwbólowy i przeciwgorączkowy", "Ibuprofen", "Syrop" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2022, 6, 2, 1, 2, 56, 910, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2022, 6, 2, 1, 2, 56, 910, DateTimeKind.Local).AddTicks(9778), new DateTime(2023, 3, 2, 1, 2, 56, 910, DateTimeKind.Local).AddTicks(9780) });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 2, 1, "per week", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PrescriptionMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2022, 6, 2, 0, 17, 58, 526, DateTimeKind.Local).AddTicks(895));

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2022, 6, 2, 0, 17, 58, 526, DateTimeKind.Local).AddTicks(954), new DateTime(2023, 3, 2, 0, 17, 58, 526, DateTimeKind.Local).AddTicks(956) });
        }
    }
}
