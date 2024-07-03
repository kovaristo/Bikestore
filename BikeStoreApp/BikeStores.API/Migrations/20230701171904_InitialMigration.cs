using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BikeStores.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "production");

            migrationBuilder.EnsureSchema(
                name: "sales");

            migrationBuilder.CreateTable(
                name: "brands",
                schema: "production",
                columns: table => new
                {
                    brand_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    when_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    when_modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "production",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    when_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    when_modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "sales",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    state = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    zip_code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    when_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    when_modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                schema: "sales",
                columns: table => new
                {
                    store_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    state = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    zip_code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    when_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    when_modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.store_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "production",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    brand_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    model_year = table.Column<short>(type: "smallint", nullable: false),
                    list_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    when_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    when_modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Products_Brands",
                        column: x => x.brand_id,
                        principalSchema: "production",
                        principalTable: "brands",
                        principalColumn: "brand_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories",
                        column: x => x.category_id,
                        principalSchema: "production",
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "staffs",
                schema: "sales",
                columns: table => new
                {
                    staff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    active = table.Column<byte>(type: "tinyint", nullable: false),
                    store_id = table.Column<int>(type: "int", nullable: false),
                    manager_id = table.Column<int>(type: "int", nullable: true),
                    when_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    when_modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffs", x => x.staff_id);
                    table.ForeignKey(
                        name: "FK_Staffs_Manager",
                        column: x => x.manager_id,
                        principalSchema: "sales",
                        principalTable: "staffs",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staffs_Stores",
                        column: x => x.store_id,
                        principalSchema: "sales",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                schema: "production",
                columns: table => new
                {
                    store_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    when_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    when_modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => new { x.store_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_Stocks_Products",
                        column: x => x.product_id,
                        principalSchema: "production",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_Stores",
                        column: x => x.store_id,
                        principalSchema: "sales",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "sales",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_id = table.Column<int>(type: "int", nullable: false),
                    staff_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    order_status = table.Column<byte>(type: "tinyint", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    required_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    shipped_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    when_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    when_modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Customers_Orders",
                        column: x => x.customer_id,
                        principalSchema: "sales",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Stores",
                        column: x => x.store_id,
                        principalSchema: "sales",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staffs_Orders",
                        column: x => x.staff_id,
                        principalSchema: "sales",
                        principalTable: "staffs",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                schema: "sales",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    list_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    when_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    when_modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => new { x.order_id, x.item_id });
                    table.ForeignKey(
                        name: "FK_Orders_OrderItems",
                        column: x => x.order_id,
                        principalSchema: "sales",
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_OrderItems",
                        column: x => x.product_id,
                        principalSchema: "production",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "production",
                table: "brands",
                columns: new[] { "brand_id", "created_by", "modified_by", "brand_name", "when_created", "when_modified" },
                values: new object[,]
                {
                    { 1, "system", null, "Kross", new DateTime(2023, 7, 1, 19, 19, 4, 327, DateTimeKind.Local).AddTicks(7343), null },
                    { 2, "system", null, "Romet", new DateTime(2023, 7, 1, 19, 19, 4, 327, DateTimeKind.Local).AddTicks(7384), null }
                });

            migrationBuilder.InsertData(
                schema: "production",
                table: "categories",
                columns: new[] { "category_id", "created_by", "modified_by", "category_name", "when_created", "when_modified" },
                values: new object[,]
                {
                    { 1, "system", null, "Trekking bicycles", new DateTime(2023, 7, 1, 19, 19, 4, 327, DateTimeKind.Local).AddTicks(9192), null },
                    { 2, "system", null, "Universal bicycles", new DateTime(2023, 7, 1, 19, 19, 4, 327, DateTimeKind.Local).AddTicks(9207), null }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "customers",
                columns: new[] { "customer_id", "city", "created_by", "email", "first_name", "last_name", "modified_by", "phone", "state", "street", "when_created", "when_modified", "zip_code" },
                values: new object[,]
                {
                    { 1, "Radom", "system", "jan.nowak@gmail.com", "Jan", "Nowak", null, "+48555666777", "Mazowieckie", "Cisowa 7/23", new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(6281), null, "26611" },
                    { 2, "Kielce", "system", "adam.kowalski@gmail.com", "Adam", "Kowalski", null, "+48555999444", "Świetokrzyskie", "Galenowa 13/2", new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(6292), null, "25705" }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "stores",
                columns: new[] { "store_id", "city", "created_by", "email", "modified_by", "store_name", "phone", "state", "street", "when_created", "when_modified", "zip_code" },
                values: new object[,]
                {
                    { 1, "Radom", "system", "radom@bikestores.org", null, "Sklep w Radomiu", "+48654234200", "Mazowieckie", "Wiejska 14", new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(7059), null, "26606" },
                    { 2, "Kielce", "system", "kielce@bikestores.org", null, "Sklep w Kielcach", "+22456543200", "Swietokrzyskie", "Kwarcowa 12/4", new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(7072), null, "25741" }
                });

            migrationBuilder.InsertData(
                schema: "production",
                table: "products",
                columns: new[] { "product_id", "brand_id", "category_id", "created_by", "list_price", "model_year", "modified_by", "product_name", "when_created", "when_modified" },
                values: new object[,]
                {
                    { 1, 1, 1, "system", 123m, (short)2020, null, "Kross Adventure 1", new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(504), null },
                    { 2, 1, 1, "system", 79m, (short)2021, null, "Kross Hardcore 2", new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(514), null },
                    { 3, 1, 2, "system", 37m, (short)2023, null, "Kross Family 2", new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(517), null },
                    { 4, 1, 2, "system", 62m, (short)2022, null, "Kross Common 1", new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(592), null },
                    { 5, 2, 1, "system", 231m, (short)2021, null, "Romet Gazela 2", new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(594), null },
                    { 6, 2, 1, "system", 193m, (short)2022, null, "Romet Alicia 3", new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(596), null },
                    { 7, 2, 2, "system", 56m, (short)2022, null, "Romet Universal 1", new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(597), null },
                    { 8, 2, 2, "system", 63m, (short)2023, null, "Romel Universal 2", new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(599), null }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "staffs",
                columns: new[] { "staff_id", "active", "created_by", "email", "first_name", "last_name", "manager_id", "modified_by", "phone", "store_id", "when_created", "when_modified" },
                values: new object[,]
                {
                    { 1, (byte)1, "system", "adam.manager@radom.bikestores.org", "Adam", "Manager", null, null, "+48654234201", 1, new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(3959), null },
                    { 4, (byte)1, "system", "janina.manager@kielce.bikestores.org", "Janina", "Manager", null, null, "+48654234201", 1, new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(3973), null },
                    { 2, (byte)1, "system", "anna.pracownik@radom.bikestores.org", "Anna", "Pracownik", 1, null, "+48654234202", 2, new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(3969), null },
                    { 5, (byte)1, "system", "julian.pracownik@kielce.bikestores.org", "Julian", "Pracownik", 4, null, "+48654234202", 2, new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(3974), null }
                });

            migrationBuilder.InsertData(
                schema: "production",
                table: "stocks",
                columns: new[] { "product_id", "store_id", "created_by", "modified_by", "quantity", "when_created", "when_modified" },
                values: new object[,]
                {
                    { 1, 1, "system", null, 13, new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(3267), null },
                    { 2, 1, "system", null, 17, new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(3277), null },
                    { 1, 2, "system", null, 23, new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(3278), null },
                    { 2, 2, "system", null, 7, new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(3323), null }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "orders",
                columns: new[] { "order_id", "created_by", "customer_id", "modified_by", "order_date", "order_status", "required_date", "shipped_date", "staff_id", "store_id", "when_created", "when_modified" },
                values: new object[,]
                {
                    { 1, "system", 1, null, new DateTime(2021, 2, 11, 11, 12, 4, 328, DateTimeKind.Local).AddTicks(8287), (byte)0, new DateTime(2021, 3, 9, 11, 12, 4, 328, DateTimeKind.Local).AddTicks(8288), null, 2, 1, new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(8276), null },
                    { 2, "system", 2, null, new DateTime(2021, 1, 28, 11, 12, 4, 328, DateTimeKind.Local).AddTicks(8292), (byte)5, new DateTime(2021, 2, 22, 11, 12, 4, 328, DateTimeKind.Local).AddTicks(8293), new DateTime(2023, 6, 29, 22, 45, 4, 328, DateTimeKind.Local).AddTicks(8294), 2, 1, new DateTime(2023, 7, 1, 19, 19, 4, 328, DateTimeKind.Local).AddTicks(8291), null }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "staffs",
                columns: new[] { "staff_id", "active", "created_by", "email", "first_name", "last_name", "manager_id", "modified_by", "phone", "store_id", "when_created", "when_modified" },
                values: new object[,]
                {
                    { 3, (byte)1, "system", "krzysztof.pracownik@radom.bikestores.org", "Krzysztof", "Pracownik", 2, null, "+48654234201", 2, new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(3971), null },
                    { 6, (byte)1, "system", "krzysztof.pracownik.radom@bikestores.org", "Krzysztof", "Pracownik", 5, null, "+48654234201", 2, new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(3976), null }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "order_items",
                columns: new[] { "item_id", "order_id", "created_by", "discount", "list_price", "modified_by", "product_id", "quantity", "when_created", "when_modified" },
                values: new object[,]
                {
                    { 1, 1, "system", 10m, 123m, null, 1, 1, new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(1526), null },
                    { 2, 1, "system", 5m, 35m, null, 3, 2, new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(1557), null },
                    { 1, 2, "system", 2m, 33m, null, 3, 3, new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(1559), null },
                    { 2, 2, "system", 17m, 223m, null, 5, 5, new DateTime(2023, 7, 1, 19, 19, 4, 329, DateTimeKind.Local).AddTicks(1561), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_items_product_id",
                schema: "sales",
                table: "order_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customer_id",
                schema: "sales",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_staff_id",
                schema: "sales",
                table: "orders",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_store_id",
                schema: "sales",
                table: "orders",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_brand_id",
                schema: "production",
                table: "products",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                schema: "production",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_staffs_manager_id",
                schema: "sales",
                table: "staffs",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_staffs_store_id",
                schema: "sales",
                table: "staffs",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_product_id",
                schema: "production",
                table: "stocks",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_items",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "stocks",
                schema: "production");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "products",
                schema: "production");

            migrationBuilder.DropTable(
                name: "customers",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "staffs",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "brands",
                schema: "production");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "production");

            migrationBuilder.DropTable(
                name: "stores",
                schema: "sales");
        }
    }
}
