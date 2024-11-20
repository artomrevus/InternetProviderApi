using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternetProvider.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__City__031491A82FEEEE5D", x => x.city_id);
                });

            migrationBuilder.CreateTable(
                name: "ClientStatus",
                columns: table => new
                {
                    client_status_id = table.Column<int>(type: "int", nullable: false),
                    client_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ClientSt__B82E681503D75972", x => x.client_status_id);
                });

            migrationBuilder.CreateTable(
                name: "ConnectionTariff",
                columns: table => new
                {
                    connection_tariff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Connecti__7986F62E2962E692", x => x.connection_tariff_id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePosition",
                columns: table => new
                {
                    employee_position_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_position = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__A6A1257C60EFC98A", x => x.employee_position_id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStatus",
                columns: table => new
                {
                    employee_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__EDD287846018B3E6", x => x.employee_status_id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentType",
                columns: table => new
                {
                    equipment_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipment_type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Equipmen__D8B1EC05651C9D4A", x => x.equipment_type_id);
                });

            migrationBuilder.CreateTable(
                name: "InternetConnectionRequestStatus",
                columns: table => new
                {
                    internet_connection_request_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    internet_connection_request_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Internet__9CA7A241DFC511C2", x => x.internet_connection_request_status_id);
                });

            migrationBuilder.CreateTable(
                name: "InternetTariffStatus",
                columns: table => new
                {
                    internet_tariff_status_id = table.Column<int>(type: "int", nullable: false),
                    internet_tariff_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Internet__A427AF2A349ABD7A", x => x.internet_tariff_status_id);
                });

            migrationBuilder.CreateTable(
                name: "LocationType",
                columns: table => new
                {
                    location_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location_type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__535FD89A63DBD566", x => x.location_type_id);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    office_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Office__2A196375878F0F99", x => x.office_id);
                    table.ForeignKey(
                        name: "fk_city_Office",
                        column: x => x.city_id,
                        principalTable: "City",
                        principalColumn: "city_id");
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    street_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    street = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Street__665BB66B8FD12D0B", x => x.street_id);
                    table.ForeignKey(
                        name: "fk_city_Street",
                        column: x => x.city_id,
                        principalTable: "City",
                        principalColumn: "city_id");
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    equipment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipment_type_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Equipmen__197068AF7EC45C10", x => x.equipment_id);
                    table.ForeignKey(
                        name: "fk_equipment_type",
                        column: x => x.equipment_type_id,
                        principalTable: "EquipmentType",
                        principalColumn: "equipment_type_id");
                });

            migrationBuilder.CreateTable(
                name: "InternetTariff",
                columns: table => new
                {
                    internet_tariff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    internet_tariff_status_id = table.Column<int>(type: "int", nullable: false),
                    location_type_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    internet_speed_mbits = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Internet__5DA1086BBE8656A4", x => x.internet_tariff_id);
                    table.ForeignKey(
                        name: "fk_location_type_",
                        column: x => x.location_type_id,
                        principalTable: "LocationType",
                        principalColumn: "location_type_id");
                    table.ForeignKey(
                        name: "fk_tariff_status",
                        column: x => x.internet_tariff_status_id,
                        principalTable: "InternetTariffStatus",
                        principalColumn: "internet_tariff_status_id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_position_id = table.Column<int>(type: "int", nullable: false),
                    employee_status_id = table.Column<int>(type: "int", nullable: false),
                    office_id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__C52E0BA81274DB0B", x => x.employee_id);
                    table.ForeignKey(
                        name: "fk_employee_position",
                        column: x => x.employee_position_id,
                        principalTable: "EmployeePosition",
                        principalColumn: "employee_position_id");
                    table.ForeignKey(
                        name: "fk_employee_status",
                        column: x => x.employee_status_id,
                        principalTable: "EmployeeStatus",
                        principalColumn: "employee_status_id");
                    table.ForeignKey(
                        name: "fk_office",
                        column: x => x.office_id,
                        principalTable: "Office",
                        principalColumn: "office_id");
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    house_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street_id = table.Column<int>(type: "int", nullable: false),
                    house_number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__House__E24626419289811A", x => x.house_id);
                    table.ForeignKey(
                        name: "fk_street",
                        column: x => x.street_id,
                        principalTable: "Street",
                        principalColumn: "street_id");
                });

            migrationBuilder.CreateTable(
                name: "OfficeEquipment",
                columns: table => new
                {
                    office_equipment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    office_id = table.Column<int>(type: "int", nullable: false),
                    equipment_id = table.Column<int>(type: "int", nullable: false),
                    office_equipment_amount = table.Column<int>(type: "int", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OfficeEq__05F556A58424C729", x => x.office_equipment_id);
                    table.ForeignKey(
                        name: "fk_equipment",
                        column: x => x.equipment_id,
                        principalTable: "Equipment",
                        principalColumn: "equipment_id");
                    table.ForeignKey(
                        name: "fk_office_",
                        column: x => x.office_id,
                        principalTable: "Office",
                        principalColumn: "office_id");
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    location_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location_type_id = table.Column<int>(type: "int", nullable: false),
                    house_id = table.Column<int>(type: "int", nullable: false),
                    apartment_number = table.Column<int>(type: "int", nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__771831EA1718521C", x => x.location_id);
                    table.ForeignKey(
                        name: "fk_house",
                        column: x => x.house_id,
                        principalTable: "House",
                        principalColumn: "house_id");
                    table.ForeignKey(
                        name: "fk_location_type",
                        column: x => x.location_type_id,
                        principalTable: "LocationType",
                        principalColumn: "location_type_id");
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_status_id = table.Column<int>(type: "int", nullable: false),
                    location_id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    registration_date = table.Column<DateOnly>(type: "date", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Client__BF21A424B23CB230", x => x.client_id);
                    table.ForeignKey(
                        name: "fk_client_status",
                        column: x => x.client_status_id,
                        principalTable: "ClientStatus",
                        principalColumn: "client_status_id");
                    table.ForeignKey(
                        name: "fk_location",
                        column: x => x.location_id,
                        principalTable: "Location",
                        principalColumn: "location_id");
                });

            migrationBuilder.CreateTable(
                name: "InternetConnectionRequest",
                columns: table => new
                {
                    internet_connection_request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    internet_tariff_id = table.Column<int>(type: "int", nullable: false),
                    internet_connection_request_status_id = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    request_date = table.Column<DateOnly>(type: "date", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Internet__AB3061E5B1D47AEA", x => x.internet_connection_request_id);
                    table.ForeignKey(
                        name: "fk_client",
                        column: x => x.client_id,
                        principalTable: "Client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_internet_tariff",
                        column: x => x.internet_tariff_id,
                        principalTable: "InternetTariff",
                        principalColumn: "internet_tariff_id");
                    table.ForeignKey(
                        name: "fk_request_status",
                        column: x => x.internet_connection_request_status_id,
                        principalTable: "InternetConnectionRequestStatus",
                        principalColumn: "internet_connection_request_status_id");
                });

            migrationBuilder.CreateTable(
                name: "Connection_",
                columns: table => new
                {
                    connection_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    internet_connection_request_id = table.Column<int>(type: "int", nullable: true),
                    connection_tariff_id = table.Column<int>(type: "int", nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    total_price = table.Column<decimal>(type: "money", nullable: false),
                    connection_date = table.Column<DateOnly>(type: "date", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Connecti__E4AA4DD0066B8AC9", x => x.connection_id);
                    table.ForeignKey(
                        name: "fk_connection_tariff",
                        column: x => x.connection_tariff_id,
                        principalTable: "ConnectionTariff",
                        principalColumn: "connection_tariff_id");
                    table.ForeignKey(
                        name: "fk_employee",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "fk_internet_connection_request",
                        column: x => x.internet_connection_request_id,
                        principalTable: "InternetConnectionRequest",
                        principalColumn: "internet_connection_request_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConnectionEquipment",
                columns: table => new
                {
                    connection_equipment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    connection_id = table.Column<int>(type: "int", nullable: false),
                    office_equipment_id = table.Column<int>(type: "int", nullable: false),
                    connection_equipment_amount = table.Column<int>(type: "int", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Connecti__F31B608BE8AC5CC2", x => x.connection_equipment_id);
                    table.ForeignKey(
                        name: "fk_connection",
                        column: x => x.connection_id,
                        principalTable: "Connection_",
                        principalColumn: "connection_id");
                    table.ForeignKey(
                        name: "fk_office_equipment",
                        column: x => x.office_equipment_id,
                        principalTable: "OfficeEquipment",
                        principalColumn: "office_equipment_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_client_status_id",
                table: "Client",
                column: "client_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Client_location_id",
                table: "Client",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Client__A1936A6BA1C1D8C0",
                table: "Client",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Client__AB6E6164CB8757C8",
                table: "Client",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Connection__connection_date_IDX",
                table: "Connection_",
                column: "connection_date");

            migrationBuilder.CreateIndex(
                name: "IX_Connection__connection_tariff_id",
                table: "Connection_",
                column: "connection_tariff_id");

            migrationBuilder.CreateIndex(
                name: "IX_Connection__employee_id",
                table: "Connection_",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_InternetConnectionRequestId",
                table: "Connection_",
                column: "internet_connection_request_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Connecti__AB3061E48A55B137",
                table: "Connection_",
                column: "internet_connection_request_id",
                unique: true,
                filter: "[internet_connection_request_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionEquipment_Connection_Id",
                table: "ConnectionEquipment",
                column: "connection_id");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionEquipment_OfficeEquipmentId",
                table: "ConnectionEquipment",
                column: "office_equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_employee_position_id",
                table: "Employee",
                column: "employee_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_employee_status_id",
                table: "Employee",
                column: "employee_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_office_id",
                table: "Employee",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__A1936A6B3F12F04C",
                table: "Employee",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__AB6E616404CDF810",
                table: "Employee",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_equipment_type_id",
                table: "Equipment",
                column: "equipment_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_House_street_id",
                table: "House",
                column: "street_id");

            migrationBuilder.CreateIndex(
                name: "InternetConnectionRequest_request_date_IDX",
                table: "InternetConnectionRequest",
                column: "request_date");

            migrationBuilder.CreateIndex(
                name: "IX_InternetConnectionRequest_client_id",
                table: "InternetConnectionRequest",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_InternetConnectionRequest_internet_connection_request_status_id",
                table: "InternetConnectionRequest",
                column: "internet_connection_request_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_InternetConnectionRequest_internet_tariff_id",
                table: "InternetConnectionRequest",
                column: "internet_tariff_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Internet__FD291E4145F9AB4B",
                table: "InternetConnectionRequest",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InternetTariff_internet_tariff_status_id",
                table: "InternetTariff",
                column: "internet_tariff_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_InternetTariff_location_type_id",
                table: "InternetTariff",
                column: "location_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Location_house_id",
                table: "Location",
                column: "house_id");

            migrationBuilder.CreateIndex(
                name: "IX_Location_location_type_id",
                table: "Location",
                column: "location_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Office_city_id",
                table: "Office",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Office__A1936A6B595321FB",
                table: "Office",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Office__AB6E616424395FF7",
                table: "Office",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfficeEquipment_EquipmentId",
                table: "OfficeEquipment",
                column: "equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeEquipment_office_id",
                table: "OfficeEquipment",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "OfficeEquipment_office_equipment_amount_IDX",
                table: "OfficeEquipment",
                column: "office_equipment_amount");

            migrationBuilder.CreateIndex(
                name: "IX_Street_city_id",
                table: "Street",
                column: "city_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConnectionEquipment");

            migrationBuilder.DropTable(
                name: "Connection_");

            migrationBuilder.DropTable(
                name: "OfficeEquipment");

            migrationBuilder.DropTable(
                name: "ConnectionTariff");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "InternetConnectionRequest");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "EmployeePosition");

            migrationBuilder.DropTable(
                name: "EmployeeStatus");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "InternetTariff");

            migrationBuilder.DropTable(
                name: "InternetConnectionRequestStatus");

            migrationBuilder.DropTable(
                name: "EquipmentType");

            migrationBuilder.DropTable(
                name: "ClientStatus");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "InternetTariffStatus");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "LocationType");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
