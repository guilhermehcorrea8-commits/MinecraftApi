using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web_Api_29_07_Mine.Migrations
{
    /// <inheritdoc />
    public partial class AddMinecraftEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nickname",
                table: "Players",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SkinUrl",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uuid",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Mundos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Itens",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl",
                table: "Itens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Biomas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperatura = table.Column<double>(type: "float", nullable: false),
                    Chove = table.Column<bool>(type: "bit", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biomas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blocos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resistencia = table.Column<double>(type: "float", nullable: false),
                    Empilhavel = table.Column<bool>(type: "bit", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Encantamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NivelMaximo = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encantamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hostil = table.Column<bool>(type: "bit", nullable: false),
                    Vida = table.Column<int>(type: "int", nullable: false),
                    Drop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bioma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Biomas",
                columns: new[] { "Id", "Chove", "ImagemUrl", "Nome", "Temperatura" },
                values: new object[,]
                {
                    { 1, true, null, "Plains", 0.80000000000000004 },
                    { 2, false, null, "Desert", 2.0 },
                    { 3, true, null, "Forest", 0.69999999999999996 }
                });

            migrationBuilder.InsertData(
                table: "Blocos",
                columns: new[] { "Id", "Empilhavel", "ImagemUrl", "Nome", "Resistencia", "Tipo" },
                values: new object[,]
                {
                    { 1, true, null, "Diamond Block", 5.0, "Mineral" },
                    { 2, true, null, "Stone", 1.5, "Natural" }
                });

            migrationBuilder.InsertData(
                table: "Encantamentos",
                columns: new[] { "Id", "Categoria", "Descricao", "NivelMaximo", "Nome" },
                values: new object[,]
                {
                    { 1, "Sword", "Aumenta o dano da espada.", 5, "Sharpness" },
                    { 2, "Tool", "Aumenta a velocidade de mineração.", 5, "Efficiency" },
                    { 3, "Pickaxe", "Aumenta a quantidade de drops.", 3, "Fortune" }
                });

            migrationBuilder.InsertData(
                table: "Itens",
                columns: new[] { "Id", "ImagemUrl", "Nome", "Tipo" },
                values: new object[,]
                {
                    { 1, "https://minecraft.wiki/images/Diamond_Sword.png", "Diamond Sword", "Weapon" },
                    { 2, "https://minecraft.wiki/images/Diamond_Pickaxe.png", "Diamond Pickaxe", "Tool" },
                    { 3, "https://minecraft.wiki/images/Golden_Apple.png", "Golden Apple", "Food" }
                });

            migrationBuilder.InsertData(
                table: "Mobs",
                columns: new[] { "Id", "Bioma", "Drop", "Hostil", "ImagemUrl", "Nome", "Vida" },
                values: new object[,]
                {
                    { 1, "Plains", "Gunpowder", true, null, "Creeper", 20 },
                    { 2, "Forest", "Rotten Flesh", true, null, "Zombie", 20 },
                    { 3, "Plains", "Leather", false, null, "Cow", 10 }
                });

            migrationBuilder.InsertData(
                table: "Mundos",
                columns: new[] { "Id", "Bioma", "Nome" },
                values: new object[,]
                {
                    { 1, "Plains", "Survival" },
                    { 2, "Forest", "Creative" },
                    { 3, "Desert", "Hardcore" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "MundoId", "Nickname", "Nivel", "SkinUrl", "Uuid" },
                values: new object[,]
                {
                    { 1, 1, "Steve", 35, "https://crafatar.com/avatars/Steve", "uuid-steve" },
                    { 2, 2, "Alex", 18, "https://crafatar.com/avatars/Alex", "uuid-alex" }
                });

            migrationBuilder.InsertData(
                table: "Inventarios",
                columns: new[] { "ItemId", "PlayerId", "Quantidade" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 1 },
                    { 3, 2, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biomas");

            migrationBuilder.DropTable(
                name: "Blocos");

            migrationBuilder.DropTable(
                name: "Encantamentos");

            migrationBuilder.DropTable(
                name: "Mobs");

            migrationBuilder.DeleteData(
                table: "Inventarios",
                keyColumns: new[] { "ItemId", "PlayerId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Inventarios",
                keyColumns: new[] { "ItemId", "PlayerId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Inventarios",
                keyColumns: new[] { "ItemId", "PlayerId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Mundos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mundos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mundos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "SkinUrl",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ImagemUrl",
                table: "Itens");

            migrationBuilder.AlterColumn<string>(
                name: "Nickname",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Mundos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Itens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
