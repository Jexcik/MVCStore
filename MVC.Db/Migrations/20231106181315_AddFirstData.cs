using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Cost", "Description", "ImagePath", "Name", "ReleaseYear" },
                values: new object[,]
                {
                    { new Guid("42d35f2e-6b68-4572-a21e-cc7455bdbcdf"), "Баста", 3000m, "TheBest Production", "/images/Баста.jpg", "Моя Игра", 2006 },
                    { new Guid("529e84d9-49c7-4d0a-b9cb-049f83c43cd9"), "GUF", 2000m, "Legendary Album", "/images/ЕЩЁ.jpg", "Ещё", 2016 },
                    { new Guid("952ca27f-6918-4840-af4f-2da84a09b388"), "Скриптонит", 1850m, "Дебютный альбом", "/images/Скриптонит.jpg", "Дом с нормальными явлениями", 2015 },
                    { new Guid("a8f5fd0f-d612-4deb-84a3-c670e1b99c9a"), "Oxxxymiron", 3150m, "Второй студийный альбом российского рэпера Oxxxymiron", "/images/Горгород.jpg", "ГОРГОРОД", 2015 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("42d35f2e-6b68-4572-a21e-cc7455bdbcdf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("529e84d9-49c7-4d0a-b9cb-049f83c43cd9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("952ca27f-6918-4840-af4f-2da84a09b388"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a8f5fd0f-d612-4deb-84a3-c670e1b99c9a"));
        }
    }
}
