using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cars.Migrations
{
    /// <inheritdoc />
    public partial class AddingFuels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fuels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxRPM = table.Column<int>(type: "int", nullable: false),
                    HorsePower = table.Column<int>(type: "int", nullable: false),
                    FuelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engines_Fuels_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Fuels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearOfManufacture = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarEngines",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarEngines", x => new { x.CarId, x.EngineId });
                    table.ForeignKey(
                        name: "FK_CarEngines_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarEngines_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxSpeed = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    EngineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Models_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ModelEngines",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelEngines", x => new { x.ModelId, x.EngineId });
                    table.ForeignKey(
                        name: "FK_ModelEngines_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelEngines_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "EngineId", "Name", "YearOfManufacture" },
                values: new object[,]
                {
                    { 1, null, "BMW", 2006 },
                    { 2, null, "Audi", 2015 },
                    { 3, null, "Toyota", 2020 }
                });

            migrationBuilder.InsertData(
                table: "Fuels",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Diesel" },
                    { 2, "Petrol" },
                    { 3, "Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "FuelId", "HorsePower", "MaxRPM", "Name" },
                values: new object[,]
                {
                    { 1, 1, 122, 90, "BMW N45B16" },
                    { 2, 2, 150, 110, "Audi 2.0 TDI" },
                    { 3, 3, 122, 72, "Toyota 1.8 VVT-i Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CarId", "EngineId", "Length", "MaxSpeed", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, 1, null, 4200.0, 210.0, "116i", 1280.0 },
                    { 2, 2, null, 4700.0, 250.0, "A4", 1420.0 },
                    { 3, 3, null, 4350.0, 180.0, "Corolla", 1340.0 }
                });

            migrationBuilder.InsertData(
                table: "CarEngines",
                columns: new[] { "CarId", "EngineId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "ModelEngines",
                columns: new[] { "EngineId", "ModelId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarEngines_EngineId",
                table: "CarEngines",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineId",
                table: "Cars",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Engines_FuelId",
                table: "Engines",
                column: "FuelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelEngines_EngineId",
                table: "ModelEngines",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_CarId",
                table: "Models",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_EngineId",
                table: "Models",
                column: "EngineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarEngines");

            migrationBuilder.DropTable(
                name: "ModelEngines");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Fuels");
        }
    }
}
