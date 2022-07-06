using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PropDatabaseCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    clientId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    companyName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lsPricing = table.Column<int>(type: "integer", nullable: false),
                    esPricing = table.Column<int>(type: "integer", nullable: false),
                    rtPricing = table.Column<int>(type: "integer", nullable: false),
                    tcPricing = table.Column<int>(type: "integer", nullable: false),
                    lnpPricing = table.Column<int>(type: "integer", nullable: false),
                    csPricing = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.clientId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ordernumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Clientfilenumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    userId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ordernumber);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userFirst = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    userLast = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    companyName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    userType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    additionalContacts = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    userNotes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    clientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                    table.ForeignKey(
                        name: "FK_Users_Clients_clientId",
                        column: x => x.clientId,
                        principalTable: "Clients",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    filenumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductType = table.Column<int>(type: "integer", nullable: false),
                    OrderStatus = table.Column<int>(type: "integer", nullable: false),
                    orderNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.filenumber);
                    table.ForeignKey(
                        name: "FK_Products_Orders_orderNumber",
                        column: x => x.orderNumber,
                        principalTable: "Orders",
                        principalColumn: "ordernumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CSSearches",
                columns: table => new
                {
                    csnumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerEmail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BuyerEmail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    productId = table.Column<int>(type: "integer", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Zip = table.Column<string>(type: "text", nullable: false),
                    County = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Parcel = table.Column<string>(type: "text", nullable: false),
                    Refinance = table.Column<bool>(type: "boolean", nullable: false),
                    Vacant = table.Column<bool>(type: "boolean", nullable: false),
                    Commercial = table.Column<bool>(type: "boolean", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NeedByDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Rush = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalComments = table.Column<string>(type: "text", nullable: true),
                    OwnerName = table.Column<string>(type: "text", nullable: false),
                    BuyerName = table.Column<string>(type: "text", nullable: true),
                    AddressTwo = table.Column<string>(type: "text", nullable: true),
                    LegalDescription = table.Column<string>(type: "text", nullable: true),
                    AdditionalContactEmail = table.Column<string>(type: "text", nullable: true),
                    Clientfilenumber = table.Column<string>(type: "text", nullable: true),
                    AssignedResearcher = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSSearches", x => x.csnumber);
                    table.ForeignKey(
                        name: "FK_CSSearches_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "filenumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstoppelSearches",
                columns: table => new
                {
                    estoppelnumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productId = table.Column<int>(type: "integer", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Zip = table.Column<string>(type: "text", nullable: false),
                    County = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Parcel = table.Column<string>(type: "text", nullable: false),
                    Refinance = table.Column<bool>(type: "boolean", nullable: false),
                    Vacant = table.Column<bool>(type: "boolean", nullable: false),
                    Commercial = table.Column<bool>(type: "boolean", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NeedByDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Rush = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalComments = table.Column<string>(type: "text", nullable: true),
                    OwnerName = table.Column<string>(type: "text", nullable: false),
                    BuyerName = table.Column<string>(type: "text", nullable: true),
                    AddressTwo = table.Column<string>(type: "text", nullable: true),
                    LegalDescription = table.Column<string>(type: "text", nullable: true),
                    AdditionalContactEmail = table.Column<string>(type: "text", nullable: true),
                    Clientfilenumber = table.Column<string>(type: "text", nullable: true),
                    AssignedResearcher = table.Column<int>(type: "integer", nullable: true),
                    OwnerEmail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoppelSearches", x => x.estoppelnumber);
                    table.ForeignKey(
                        name: "FK_EstoppelSearches_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "filenumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LienSearches",
                columns: table => new
                {
                    liensearchnumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<bool>(type: "boolean", nullable: false),
                    Permit = table.Column<bool>(type: "boolean", nullable: false),
                    Tax = table.Column<bool>(type: "boolean", nullable: false),
                    Utility = table.Column<bool>(type: "boolean", nullable: false),
                    SpecialAssessments = table.Column<bool>(type: "boolean", nullable: false),
                    productId = table.Column<int>(type: "integer", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Zip = table.Column<string>(type: "text", nullable: false),
                    County = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Parcel = table.Column<string>(type: "text", nullable: false),
                    Refinance = table.Column<bool>(type: "boolean", nullable: false),
                    Vacant = table.Column<bool>(type: "boolean", nullable: false),
                    Commercial = table.Column<bool>(type: "boolean", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NeedByDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Rush = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalComments = table.Column<string>(type: "text", nullable: true),
                    OwnerName = table.Column<string>(type: "text", nullable: false),
                    BuyerName = table.Column<string>(type: "text", nullable: true),
                    AddressTwo = table.Column<string>(type: "text", nullable: true),
                    LegalDescription = table.Column<string>(type: "text", nullable: true),
                    AdditionalContactEmail = table.Column<string>(type: "text", nullable: true),
                    Clientfilenumber = table.Column<string>(type: "text", nullable: true),
                    AssignedResearcher = table.Column<int>(type: "integer", nullable: true),
                    OwnerEmail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LienSearches", x => x.liensearchnumber);
                    table.ForeignKey(
                        name: "FK_LienSearches_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "filenumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RTSearches",
                columns: table => new
                {
                    rtnumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerEmail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BuyerEmail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    productId = table.Column<int>(type: "integer", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Zip = table.Column<string>(type: "text", nullable: false),
                    County = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Parcel = table.Column<string>(type: "text", nullable: false),
                    Refinance = table.Column<bool>(type: "boolean", nullable: false),
                    Vacant = table.Column<bool>(type: "boolean", nullable: false),
                    Commercial = table.Column<bool>(type: "boolean", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NeedByDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Rush = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalComments = table.Column<string>(type: "text", nullable: true),
                    OwnerName = table.Column<string>(type: "text", nullable: false),
                    BuyerName = table.Column<string>(type: "text", nullable: true),
                    AddressTwo = table.Column<string>(type: "text", nullable: true),
                    LegalDescription = table.Column<string>(type: "text", nullable: true),
                    AdditionalContactEmail = table.Column<string>(type: "text", nullable: true),
                    Clientfilenumber = table.Column<string>(type: "text", nullable: true),
                    AssignedResearcher = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RTSearches", x => x.rtnumber);
                    table.ForeignKey(
                        name: "FK_RTSearches_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "filenumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxSearches",
                columns: table => new
                {
                    taxnumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productId = table.Column<int>(type: "integer", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Zip = table.Column<string>(type: "text", nullable: false),
                    County = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Parcel = table.Column<string>(type: "text", nullable: false),
                    Refinance = table.Column<bool>(type: "boolean", nullable: false),
                    Vacant = table.Column<bool>(type: "boolean", nullable: false),
                    Commercial = table.Column<bool>(type: "boolean", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NeedByDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Rush = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalComments = table.Column<string>(type: "text", nullable: true),
                    OwnerName = table.Column<string>(type: "text", nullable: false),
                    BuyerName = table.Column<string>(type: "text", nullable: true),
                    AddressTwo = table.Column<string>(type: "text", nullable: true),
                    LegalDescription = table.Column<string>(type: "text", nullable: true),
                    AdditionalContactEmail = table.Column<string>(type: "text", nullable: true),
                    Clientfilenumber = table.Column<string>(type: "text", nullable: true),
                    AssignedResearcher = table.Column<int>(type: "integer", nullable: true),
                    OwnerEmail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxSearches", x => x.taxnumber);
                    table.ForeignKey(
                        name: "FK_TaxSearches_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "filenumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CSSearches_productId",
                table: "CSSearches",
                column: "productId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstoppelSearches_productId",
                table: "EstoppelSearches",
                column: "productId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LienSearches_productId",
                table: "LienSearches",
                column: "productId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_orderNumber",
                table: "Products",
                column: "orderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_RTSearches_productId",
                table: "RTSearches",
                column: "productId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxSearches_productId",
                table: "TaxSearches",
                column: "productId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_clientId",
                table: "Users",
                column: "clientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CSSearches");

            migrationBuilder.DropTable(
                name: "EstoppelSearches");

            migrationBuilder.DropTable(
                name: "LienSearches");

            migrationBuilder.DropTable(
                name: "RTSearches");

            migrationBuilder.DropTable(
                name: "TaxSearches");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
