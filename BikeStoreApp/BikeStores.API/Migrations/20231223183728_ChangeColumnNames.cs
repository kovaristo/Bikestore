using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeStores.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "zip_code",
                schema: "sales",
                table: "stores",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "state",
                schema: "sales",
                table: "stores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                schema: "sales",
                table: "stores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                schema: "sales",
                table: "staffs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                schema: "sales",
                table: "staffs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "zip_code",
                schema: "sales",
                table: "customers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "state",
                schema: "sales",
                table: "customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "production",
                table: "brands",
                keyColumn: "brand_id",
                keyValue: 1,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 768, DateTimeKind.Local).AddTicks(7305));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "brands",
                keyColumn: "brand_id",
                keyValue: 2,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 768, DateTimeKind.Local).AddTicks(7344));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 1,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 769, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 2,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 769, DateTimeKind.Local).AddTicks(935));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "customers",
                keyColumn: "customer_id",
                keyValue: 1,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 770, DateTimeKind.Local).AddTicks(757));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "customers",
                keyColumn: "customer_id",
                keyValue: 2,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 770, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "order_items",
                keyColumns: new[] { "item_id", "order_id" },
                keyValues: new object[] { 1, 1 },
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 770, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "order_items",
                keyColumns: new[] { "item_id", "order_id" },
                keyValues: new object[] { 2, 1 },
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 770, DateTimeKind.Local).AddTicks(8808));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "order_items",
                keyColumns: new[] { "item_id", "order_id" },
                keyValues: new object[] { 1, 2 },
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 771, DateTimeKind.Local).AddTicks(106));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "order_items",
                keyColumns: new[] { "item_id", "order_id" },
                keyValues: new object[] { 2, 2 },
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 771, DateTimeKind.Local).AddTicks(112));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "orders",
                keyColumn: "order_id",
                keyValue: 1,
                columns: new[] { "order_date", "required_date", "when_created" },
                values: new object[] { new DateTime(2021, 8, 5, 11, 30, 27, 770, DateTimeKind.Local).AddTicks(2798), new DateTime(2021, 8, 31, 11, 30, 27, 770, DateTimeKind.Local).AddTicks(2800), new DateTime(2023, 12, 23, 19, 37, 27, 770, DateTimeKind.Local).AddTicks(2788) });

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "orders",
                keyColumn: "order_id",
                keyValue: 2,
                columns: new[] { "order_date", "required_date", "shipped_date", "when_created" },
                values: new object[] { new DateTime(2021, 7, 22, 11, 30, 27, 770, DateTimeKind.Local).AddTicks(2805), new DateTime(2021, 8, 16, 11, 30, 27, 770, DateTimeKind.Local).AddTicks(2806), new DateTime(2023, 12, 21, 23, 3, 27, 770, DateTimeKind.Local).AddTicks(2807), new DateTime(2023, 12, 23, 19, 37, 27, 770, DateTimeKind.Local).AddTicks(2803) });

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 1,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 769, DateTimeKind.Local).AddTicks(3043));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 2,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 769, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 3,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 769, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 4,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 769, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 5,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 769, DateTimeKind.Local).AddTicks(3061));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 6,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 769, DateTimeKind.Local).AddTicks(3063));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 7,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 769, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 8,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 769, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 1,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 771, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 2,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 771, DateTimeKind.Local).AddTicks(4864));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 3,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 771, DateTimeKind.Local).AddTicks(4866));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 4,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 771, DateTimeKind.Local).AddTicks(4868));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 5,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 771, DateTimeKind.Local).AddTicks(4870));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 6,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 771, DateTimeKind.Local).AddTicks(4872));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "stocks",
                keyColumns: new[] { "product_id", "store_id" },
                keyValues: new object[] { 1, 1 },
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 769, DateTimeKind.Local).AddTicks(7606));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "stocks",
                keyColumns: new[] { "product_id", "store_id" },
                keyValues: new object[] { 2, 1 },
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 769, DateTimeKind.Local).AddTicks(7619));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "stocks",
                keyColumns: new[] { "product_id", "store_id" },
                keyValues: new object[] { 1, 2 },
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 769, DateTimeKind.Local).AddTicks(7621));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "stocks",
                keyColumns: new[] { "product_id", "store_id" },
                keyValues: new object[] { 2, 2 },
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 769, DateTimeKind.Local).AddTicks(7622));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "stores",
                keyColumn: "store_id",
                keyValue: 1,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 772, DateTimeKind.Local).AddTicks(4412));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "stores",
                keyColumn: "store_id",
                keyValue: 2,
                column: "when_created",
                value: new DateTime(2023, 12, 23, 19, 37, 27, 772, DateTimeKind.Local).AddTicks(4426));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "zip_code",
                schema: "sales",
                table: "stores",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "state",
                schema: "sales",
                table: "stores",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                schema: "sales",
                table: "stores",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                schema: "sales",
                table: "staffs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                schema: "sales",
                table: "staffs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "zip_code",
                schema: "sales",
                table: "customers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "state",
                schema: "sales",
                table: "customers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "production",
                table: "brands",
                keyColumn: "brand_id",
                keyValue: 1,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 327, DateTimeKind.Local).AddTicks(7343));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "brands",
                keyColumn: "brand_id",
                keyValue: 2,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 327, DateTimeKind.Local).AddTicks(7384));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 1,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 327, DateTimeKind.Local).AddTicks(9192));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 2,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 327, DateTimeKind.Local).AddTicks(9207));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "customers",
                keyColumn: "customer_id",
                keyValue: 1,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(6281));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "customers",
                keyColumn: "customer_id",
                keyValue: 2,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(6292));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "order_items",
                keyColumns: new[] { "item_id", "order_id" },
                keyValues: new object[] { 1, 1 },
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(1526));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "order_items",
                keyColumns: new[] { "item_id", "order_id" },
                keyValues: new object[] { 2, 1 },
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(1557));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "order_items",
                keyColumns: new[] { "item_id", "order_id" },
                keyValues: new object[] { 1, 2 },
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(1559));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "order_items",
                keyColumns: new[] { "item_id", "order_id" },
                keyValues: new object[] { 2, 2 },
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(1561));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "orders",
                keyColumn: "order_id",
                keyValue: 1,
                columns: new[] { "order_date", "required_date", "when_created" },
                values: new object[] { new DateTime(2021, 2, 11, 11, 12, 4, 328, DateTimeKind.Local).AddTicks(8287), new DateTime(2021, 3, 9, 11, 12, 4, 328, DateTimeKind.Local).AddTicks(8288), new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(8276) });

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "orders",
                keyColumn: "order_id",
                keyValue: 2,
                columns: new[] { "order_date", "required_date", "shipped_date", "when_created" },
                values: new object[] { new DateTime(2021, 1, 28, 11, 12, 4, 328, DateTimeKind.Local).AddTicks(8292), new DateTime(2021, 2, 22, 11, 12, 4, 328, DateTimeKind.Local).AddTicks(8293), new DateTime(2023, 6, 29, 22, 45, 4, 328, DateTimeKind.Local).AddTicks(8294), new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(8291) });

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 1,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(504));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 2,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(514));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 3,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(517));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 4,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(592));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 5,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(594));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 6,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(596));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 7,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(597));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 8,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(599));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 1,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(3959));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 2,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(3969));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 3,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(3971));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 4,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 5,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(3974));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 6,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(3976));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "stocks",
                keyColumns: new[] { "product_id", "store_id" },
                keyValues: new object[] { 1, 1 },
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(3267));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "stocks",
                keyColumns: new[] { "product_id", "store_id" },
                keyValues: new object[] { 2, 1 },
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(3277));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "stocks",
                keyColumns: new[] { "product_id", "store_id" },
                keyValues: new object[] { 1, 2 },
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(3278));

            migrationBuilder.UpdateData(
                schema: "production",
                table: "stocks",
                keyColumns: new[] { "product_id", "store_id" },
                keyValues: new object[] { 2, 2 },
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(3323));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "stores",
                keyColumn: "store_id",
                keyValue: 1,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(7059));

            migrationBuilder.UpdateData(
                schema: "sales",
                table: "stores",
                keyColumn: "store_id",
                keyValue: 2,
                column: "when_created",
                value: new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(7072));
        }
    }
}
