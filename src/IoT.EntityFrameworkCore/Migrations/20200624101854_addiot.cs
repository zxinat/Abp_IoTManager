using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IoT.Migrations
{
    public partial class addiot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IoT_City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(maxLength: 30, nullable: false),
                    CityCode = table.Column<string>(maxLength: 30, nullable: false),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(11,2)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(11,2)", nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoT_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IoT_DeviceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeId = table.Column<string>(maxLength: 50, nullable: false),
                    TypeName = table.Column<string>(maxLength: 50, nullable: false),
                    OfflineTime = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoT_DeviceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IoT_GatewayType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeId = table.Column<string>(maxLength: 50, nullable: false),
                    TypeName = table.Column<string>(maxLength: 50, nullable: false),
                    OfflineTime = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoT_GatewayType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IoT_Severity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SeverityName = table.Column<string>(maxLength: 50, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoT_Severity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IoT_Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TagName = table.Column<string>(maxLength: 50, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoT_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IoT_Factory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FactoryName = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    CityId = table.Column<int>(maxLength: 11, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoT_Factory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoT_Factory_IoT_City_CityId",
                        column: x => x.CityId,
                        principalTable: "IoT_City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IoT_Workshop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WorkshopName = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    FactoryId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoT_Workshop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoT_Workshop_IoT_Factory_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "IoT_Factory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IoT_Gateway",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HardwareId = table.Column<string>(maxLength: 50, nullable: false),
                    GatewayName = table.Column<string>(maxLength: 50, nullable: false),
                    GatewayTypeId = table.Column<int>(nullable: false),
                    WorkshopId = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 100, nullable: true),
                    LastConnectionTime = table.Column<DateTime>(nullable: false),
                    IsOnline = table.Column<byte>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoT_Gateway", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoT_Gateway_IoT_GatewayType_GatewayTypeId",
                        column: x => x.GatewayTypeId,
                        principalTable: "IoT_GatewayType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoT_Gateway_IoT_Workshop_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "IoT_Workshop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IoT_Device",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HardwareId = table.Column<string>(maxLength: 100, nullable: false),
                    DeviceName = table.Column<string>(maxLength: 100, nullable: false),
                    GatewayId = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 100, nullable: true),
                    Mac = table.Column<string>(maxLength: 50, nullable: true),
                    DeviceTypeId = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    LastConnectionTime = table.Column<DateTime>(nullable: false),
                    PictureRoute = table.Column<string>(maxLength: 100, nullable: true),
                    Base64Image = table.Column<string>(type: "mediumtext", nullable: true),
                    IsOnline = table.Column<byte>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoT_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoT_Device_IoT_DeviceType_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "IoT_DeviceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoT_Device_IoT_Gateway_GatewayId",
                        column: x => x.GatewayId,
                        principalTable: "IoT_Gateway",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IoT_DeviceTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoT_DeviceTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoT_DeviceTag_IoT_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "IoT_Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoT_DeviceTag_IoT_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "IoT_Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IoT_Field",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FieldName = table.Column<string>(maxLength: 50, nullable: false),
                    IndexId = table.Column<string>(maxLength: 50, nullable: false),
                    DeviceId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoT_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoT_Field_IoT_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "IoT_Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IoT_OnlineTimeDaily",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceId = table.Column<int>(nullable: false),
                    OnlineTime = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoT_OnlineTimeDaily", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoT_OnlineTimeDaily_IoT_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "IoT_Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IoT_Threshold",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RuleName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    FieldId = table.Column<int>(nullable: false),
                    Operator = table.Column<string>(nullable: false),
                    ThresholdValue = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    SeverityId = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoT_Threshold", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoT_Threshold_IoT_Field_FieldId",
                        column: x => x.FieldId,
                        principalTable: "IoT_Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoT_Threshold_IoT_Severity_SeverityId",
                        column: x => x.SeverityId,
                        principalTable: "IoT_Severity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IoT_Device_DeviceTypeId",
                table: "IoT_Device",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IoT_Device_GatewayId",
                table: "IoT_Device",
                column: "GatewayId");

            migrationBuilder.CreateIndex(
                name: "IX_IoT_DeviceTag_DeviceId",
                table: "IoT_DeviceTag",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_IoT_DeviceTag_TagId",
                table: "IoT_DeviceTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_IoT_Factory_CityId",
                table: "IoT_Factory",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_IoT_Field_DeviceId",
                table: "IoT_Field",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_IoT_Gateway_GatewayTypeId",
                table: "IoT_Gateway",
                column: "GatewayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IoT_Gateway_WorkshopId",
                table: "IoT_Gateway",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_IoT_OnlineTimeDaily_DeviceId",
                table: "IoT_OnlineTimeDaily",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_IoT_Threshold_FieldId",
                table: "IoT_Threshold",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_IoT_Threshold_SeverityId",
                table: "IoT_Threshold",
                column: "SeverityId");

            migrationBuilder.CreateIndex(
                name: "IX_IoT_Workshop_FactoryId",
                table: "IoT_Workshop",
                column: "FactoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IoT_DeviceTag");

            migrationBuilder.DropTable(
                name: "IoT_OnlineTimeDaily");

            migrationBuilder.DropTable(
                name: "IoT_Threshold");

            migrationBuilder.DropTable(
                name: "IoT_Tag");

            migrationBuilder.DropTable(
                name: "IoT_Field");

            migrationBuilder.DropTable(
                name: "IoT_Severity");

            migrationBuilder.DropTable(
                name: "IoT_Device");

            migrationBuilder.DropTable(
                name: "IoT_DeviceType");

            migrationBuilder.DropTable(
                name: "IoT_Gateway");

            migrationBuilder.DropTable(
                name: "IoT_GatewayType");

            migrationBuilder.DropTable(
                name: "IoT_Workshop");

            migrationBuilder.DropTable(
                name: "IoT_Factory");

            migrationBuilder.DropTable(
                name: "IoT_City");
        }
    }
}
