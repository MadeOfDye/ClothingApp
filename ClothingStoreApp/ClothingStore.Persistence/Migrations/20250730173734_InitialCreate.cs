using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothingStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hot = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastChance = table.Column<bool>(type: "bit", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Collection = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    CareGuide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialDistribution = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Letter = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    SizeType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Dress_Bust = table.Column<float>(type: "real", nullable: true),
                    Dress_Waist = table.Column<float>(type: "real", nullable: true),
                    Dress_Hip = table.Column<float>(type: "real", nullable: true),
                    Hat_Circumference = table.Column<float>(type: "real", nullable: true),
                    Pant_Waist = table.Column<float>(type: "real", nullable: true),
                    Pant_Inseam = table.Column<float>(type: "real", nullable: true),
                    Pant_PantLegCircumference = table.Column<float>(type: "real", nullable: true),
                    Shirt_Length = table.Column<float>(type: "real", nullable: true),
                    Shirt_ShoulderWidth = table.Column<float>(type: "real", nullable: true),
                    Shirt_ChestWidth = table.Column<float>(type: "real", nullable: true),
                    Shirt_SleeveLength = table.Column<float>(type: "real", nullable: true),
                    SleeveCircumference = table.Column<float>(type: "real", nullable: true),
                    NeckCircumference = table.Column<float>(type: "real", nullable: true),
                    Shoe_Length = table.Column<float>(type: "real", nullable: true),
                    Shoe_Width = table.Column<float>(type: "real", nullable: true),
                    Shoe_HeelHight = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Dislikes = table.Column<int>(type: "int", nullable: false),
                    IsFlagged = table.Column<bool>(type: "bit", nullable: false),
                    TimesEdited = table.Column<int>(type: "int", nullable: false),
                    LastEdited = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ReviewId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Items_Reviews",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Reviews_ReviewId1",
                        column: x => x.ReviewId1,
                        principalTable: "Reviews",
                        principalColumn: "ReviewId");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ordinal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Items_Tags",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    VariantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColorHex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorRed = table.Column<byte>(type: "tinyint", nullable: false),
                    ColorGreen = table.Column<byte>(type: "tinyint", nullable: false),
                    ColorBlue = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.VariantId);
                    table.ForeignKey(
                        name: "FK_Items_Variants",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset(0)", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Users_ShoppingCarts",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableLocations",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VariantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableLocations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_AvailableLocations_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Variants_AvailableLocations",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "VariantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VariantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadedAt = table.Column<DateTimeOffset>(type: "datetimeoffset(0)", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Variants_Photos",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "VariantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoppingCartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShoppingCarts",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StocksByLocations",
                columns: table => new
                {
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationBySizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_StockByLocation_AvailableLocations",
                        column: x => x.LocationBySizeId,
                        principalTable: "AvailableLocations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StocksByLocation",
                columns: table => new
                {
                    StockByLocationStockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocksByLocation", x => x.StockByLocationStockId);
                    table.ForeignKey(
                        name: "FK_StocksByLocation_StocksByLocations_StockByLocationStockId",
                        column: x => x.StockByLocationStockId,
                        principalTable: "StocksByLocations",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "ItemId", "Name", "Ordinal" },
                values: new object[,]
                {
                    { new Guid("05cb9e09-af51-4fe0-9964-031ebb88fa14"), new Guid("00000000-0000-0000-0000-000000000000"), "Boots", 16 },
                    { new Guid("0a415d2d-24fa-43af-a491-dc207c5c13bd"), new Guid("00000000-0000-0000-0000-000000000000"), "Dress_Shoes", 5 },
                    { new Guid("0eaa402d-8656-4aa0-9faa-b390b9cd6ecb"), new Guid("00000000-0000-0000-0000-000000000000"), "Dress", 2 },
                    { new Guid("110594f3-7f59-406d-91b0-6143f3cc258b"), new Guid("00000000-0000-0000-0000-000000000000"), "Tennis_shoes", 7 },
                    { new Guid("1214d400-80d7-400a-a095-e0feefa3f9eb"), new Guid("00000000-0000-0000-0000-000000000000"), "Jackets", 17 },
                    { new Guid("14ffc92b-de97-4fde-bdbc-bb8d71c5a18b"), new Guid("00000000-0000-0000-0000-000000000000"), "Colognes", 25 },
                    { new Guid("15ce4012-9ed3-4bbe-af24-81ef3f1ccaa3"), new Guid("00000000-0000-0000-0000-000000000000"), "Cardigans", 15 },
                    { new Guid("1f4a2d98-0cd7-4be1-b70a-99c166bd67b8"), new Guid("00000000-0000-0000-0000-000000000000"), "Coats", 20 },
                    { new Guid("22f60eb0-8016-4652-a1be-fa062731ba50"), new Guid("00000000-0000-0000-0000-000000000000"), "Overshirts", 22 },
                    { new Guid("2d800a18-f6c7-4171-b236-95cb1b82a66b"), new Guid("00000000-0000-0000-0000-000000000000"), "Skirt", 3 },
                    { new Guid("327c812f-d81d-41eb-93e4-f71b0d20c5e5"), new Guid("00000000-0000-0000-0000-000000000000"), "Sweatshirt", 24 },
                    { new Guid("35362f06-4cad-413d-b2b5-7b2027a6869b"), new Guid("00000000-0000-0000-0000-000000000000"), "Perfumes", 26 },
                    { new Guid("456d936e-5c44-4589-929d-5836ecb64abe"), new Guid("00000000-0000-0000-0000-000000000000"), "Poncho", 4 },
                    { new Guid("46f7c272-c285-4b93-a058-b6d86de1246d"), new Guid("00000000-0000-0000-0000-000000000000"), "Caps", 11 },
                    { new Guid("4c3ca4e4-f273-401b-9420-128ef1d5c516"), new Guid("00000000-0000-0000-0000-000000000000"), "Jeans", 14 },
                    { new Guid("58f3f330-f4b7-498f-bdec-9ba1bcca0673"), new Guid("00000000-0000-0000-0000-000000000000"), "Sneakers", 6 },
                    { new Guid("5d145f1d-54eb-42a9-8194-7e986867000c"), new Guid("00000000-0000-0000-0000-000000000000"), "Polo_Shirts", 18 },
                    { new Guid("63adcb97-a096-4c7b-bf24-03ce1d5547e8"), new Guid("00000000-0000-0000-0000-000000000000"), "Hats", 12 },
                    { new Guid("79ca5945-a5cf-47a6-8626-f78a997861b6"), new Guid("00000000-0000-0000-0000-000000000000"), "Accessories", 27 },
                    { new Guid("843873fc-605a-48ae-9139-1edd7a5f7e8f"), new Guid("00000000-0000-0000-0000-000000000000"), "Pants", 19 },
                    { new Guid("99e2db19-fa0c-4ea8-ab1c-f7cee1dcf6dd"), new Guid("00000000-0000-0000-0000-000000000000"), "Hoodies", 23 },
                    { new Guid("ae47258a-791d-4cd0-a71a-ec932d1d82e9"), new Guid("00000000-0000-0000-0000-000000000000"), "Dress_Shirt", 9 },
                    { new Guid("d8fcfa38-cf74-4ab6-a7f1-8ad6de12fb7e"), new Guid("00000000-0000-0000-0000-000000000000"), "Blazers", 21 },
                    { new Guid("da98d9fe-62e2-43db-98d7-60e6529bb59c"), new Guid("00000000-0000-0000-0000-000000000000"), "Shirt", 1 },
                    { new Guid("e1a86080-ed96-4d55-b354-b2022f2713af"), new Guid("00000000-0000-0000-0000-000000000000"), "V_necks", 8 },
                    { new Guid("f6aaeda0-fef3-4a4e-8f55-9f5191261b7a"), new Guid("00000000-0000-0000-0000-000000000000"), "Sweater", 0 },
                    { new Guid("f7b4865c-ffa2-426a-a5df-1b0392aaefba"), new Guid("00000000-0000-0000-0000-000000000000"), "Blouse", 10 },
                    { new Guid("feace32b-c410-410c-bc0a-df2e3e40453b"), new Guid("00000000-0000-0000-0000-000000000000"), "Shorts", 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableLocations_SizeId",
                table: "AvailableLocations",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableLocations_VariantId",
                table: "AvailableLocations",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ItemId",
                table: "CartItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ShoppingCartId",
                table: "CartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_VariantId",
                table: "Photos",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ItemId",
                table: "Reviews",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewId1",
                table: "Reviews",
                column: "ReviewId1");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StocksByLocations_LocationBySizeId",
                table: "StocksByLocations",
                column: "LocationBySizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ItemId",
                table: "Tags",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ItemId",
                table: "Variants",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "StocksByLocation");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "StocksByLocations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AvailableLocations");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
