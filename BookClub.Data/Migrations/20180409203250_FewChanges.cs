using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookClub.Data.Migrations
{
    public partial class FewChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Publishers");

            migrationBuilder.RenameColumn(
                name: "PrintDate",
                table: "Publishers",
                newName: "PublishDate");

            migrationBuilder.AlterColumn<long>(
                name: "ISBN",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "Publishers",
                newName: "PrintDate");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Publishers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ISBN",
                table: "Books",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
