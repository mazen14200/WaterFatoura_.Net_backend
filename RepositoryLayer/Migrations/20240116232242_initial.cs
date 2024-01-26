using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Default_Slice_Values",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Condition = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Water_Price = table.Column<float>(type: "real", maxLength: 7, nullable: false),
                    Sanitation_price = table.Column<float>(type: "real", maxLength: 7, nullable: false),
                    Reasons = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Default_Slice_Values", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Invoices",
                columns: table => new
                {
                    NO_Invoice = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    year = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    FK_Real_Estate_Types_id = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    FK_Subscription_No_sp_id = table.Column<int>(type: "int", nullable: false),
                    FK_Subscription_No_sp_Date = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FK_Subscriber_No = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    From = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    To = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Previous_Consumption_Amount = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Current_Consumption_Amount = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Amount_Consumption_Amount = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Service_Free = table.Column<float>(type: "real", maxLength: 11, nullable: false),
                    Tax_Rate = table.Column<float>(type: "real", maxLength: 11, nullable: false),
                    Is_There_Sanitation = table.Column<bool>(type: "bit", nullable: false),
                    Consumption_Value = table.Column<float>(type: "real", maxLength: 11, nullable: false),
                    Wastewater_Consumption_Value = table.Column<float>(type: "real", maxLength: 11, nullable: false),
                    Total_Invoice = table.Column<float>(type: "real", maxLength: 11, nullable: false),
                    Tax_Value = table.Column<float>(type: "real", maxLength: 11, nullable: false),
                    Total_Bill = table.Column<float>(type: "real", maxLength: 11, nullable: false),
                    Reasons = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Invoices", x => x.NO_Invoice);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Real_Estate_Types",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Reasons = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Real_Estate_Types", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Subscriber_File",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Reasons = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Subscriber_File", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Subscription_File",
                columns: table => new
                {
                    NO_Subscription = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    FK_Subscriber_No = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FK_Real_Estate_Types_id = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Unit_No = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Is_There_Sanitation = table.Column<bool>(type: "bit", nullable: false),
                    Last_Reading_Meter = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Reasons = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Subscription_File", x => x.NO_Subscription);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Default_Slice_Values");

            migrationBuilder.DropTable(
                name: "Tbl_Invoices");

            migrationBuilder.DropTable(
                name: "Tbl_Real_Estate_Types");

            migrationBuilder.DropTable(
                name: "Tbl_Subscriber_File");

            migrationBuilder.DropTable(
                name: "Tbl_Subscription_File");
        }
    }
}
