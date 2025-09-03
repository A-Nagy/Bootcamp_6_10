using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp_6_10.Migrations
{
    /// <inheritdoc />
    public partial class newoneto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1) إضافة العمود (NULL مبدئيًا)
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "dbo",
                table: "Products",
                type: "int",
                nullable: true);

            // 2) إنشاء فهرس على العمود
            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "dbo",
                table: "Products",
                column: "CategoryId");

            // 3) إضافة FK "بشرط" حسب الجدول/العمود المتاحين
            // - لو dbo.Categories موجود ومفتاحه Id → أضف FK
            // - لو dbo.Categories موجود ومفتاحه CategoryID → أضف FK
            // - لو dbo.Category (مفرد) موجود بنفس الاحتمالات → أضف FK
            // - لو ولا واحد موجود → تجاهل بدون فشل (هنقدر نضيفه في ميجريشن لاحقة)
            migrationBuilder.Sql(@"
IF OBJECT_ID('dbo.Products','U') IS NOT NULL
AND COL_LENGTH('dbo.Products','CategoryId') IS NOT NULL
AND NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Products_Categories_CategoryId')
BEGIN
    -- خيار 1: dbo.Categories(Id)
    IF OBJECT_ID('dbo.Categories','U') IS NOT NULL
       AND EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Categories') AND name = 'Id')
    BEGIN
        ALTER TABLE dbo.Products WITH CHECK
        ADD CONSTRAINT FK_Products_Categories_CategoryId
            FOREIGN KEY(CategoryId) REFERENCES dbo.Categories(Id) ON DELETE CASCADE;
    END
    ELSE
    -- خيار 2: dbo.Categories(CategoryID)
    IF OBJECT_ID('dbo.Categories','U') IS NOT NULL
       AND EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Categories') AND name = 'CategoryID')
    BEGIN
        ALTER TABLE dbo.Products WITH CHECK
        ADD CONSTRAINT FK_Products_Categories_CategoryId
            FOREIGN KEY(CategoryId) REFERENCES dbo.Categories(CategoryID) ON DELETE CASCADE;
    END
    ELSE
    -- خيار 3: dbo.Category(Id)
    IF OBJECT_ID('dbo.Category','U') IS NOT NULL
       AND EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Category') AND name = 'Id')
    BEGIN
        ALTER TABLE dbo.Products WITH CHECK
        ADD CONSTRAINT FK_Products_Categories_CategoryId
            FOREIGN KEY(CategoryId) REFERENCES dbo.Category(Id) ON DELETE CASCADE;
    END
    ELSE
    -- خيار 4: dbo.Category(CategoryID)
    IF OBJECT_ID('dbo.Category','U') IS NOT NULL
       AND EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Category') AND name = 'CategoryID')
    BEGIN
        ALTER TABLE dbo.Products WITH CHECK
        ADD CONSTRAINT FK_Products_Categories_CategoryId
            FOREIGN KEY(CategoryId) REFERENCES dbo.Category(CategoryID) ON DELETE CASCADE;
    END
    -- لو ولا واحد من الخيارات متحقق: لا تعمل حاجة، وسيظل العمود بدون FK مؤقتًا.
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // إسقاط الـ FK لو كان اتضاف
            migrationBuilder.Sql(@"
IF OBJECT_ID('dbo.Products','U') IS NOT NULL
AND EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Products_Categories_CategoryId')
BEGIN
    ALTER TABLE dbo.Products DROP CONSTRAINT FK_Products_Categories_CategoryId;
END
");

            // إسقاط الفهرس
            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                schema: "dbo",
                table: "Products");

            // إسقاط العمود
            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "Products");
        }
    }
}