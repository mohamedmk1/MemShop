﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MemShop.Data.Migrations
{
    public partial class UpdateDescriptinLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CustomerTypes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CustomerTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
