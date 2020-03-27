using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PersonelTakip.Migrations
{
    public partial class hesaplamalarDuzeltildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hesaplamalar",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Baslik = table.Column<string>(maxLength: 100, nullable: true),
                    OzetGoster = table.Column<bool>(nullable: false),
                    SaymaLimiti = table.Column<int>(nullable: false),
                    UyariLimiti = table.Column<int>(nullable: false),
                    Disabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hesaplamalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Secenekler",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Deger = table.Column<string>(maxLength: 3, nullable: true),
                    Aciklama = table.Column<string>(maxLength: 256, nullable: true),
                    Renk = table.Column<string>(maxLength: 50, nullable: true),
                    Disabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secenekler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unvanlar",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UnvanAdi = table.Column<string>(maxLength: 100, nullable: true),
                    Disabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unvanlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HesaplamaSecenekleri",
                columns: table => new
                {
                    SecenekId = table.Column<long>(nullable: false),
                    HesaplamaId = table.Column<long>(nullable: false),
                    Katsayi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HesaplamaSecenekleri", x => new { x.HesaplamaId, x.SecenekId });
                    table.ForeignKey(
                        name: "FK_HesaplamaSecenekleri_Hesaplamalar_HesaplamaId",
                        column: x => x.HesaplamaId,
                        principalTable: "Hesaplamalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HesaplamaSecenekleri_Secenekler_SecenekId",
                        column: x => x.SecenekId,
                        principalTable: "Secenekler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HesaplamaUnvanlari",
                columns: table => new
                {
                    HesaplamaId = table.Column<long>(nullable: false),
                    UnvanId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HesaplamaUnvanlari", x => new { x.HesaplamaId, x.UnvanId });
                    table.ForeignKey(
                        name: "FK_HesaplamaUnvanlari_Hesaplamalar_HesaplamaId",
                        column: x => x.HesaplamaId,
                        principalTable: "Hesaplamalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HesaplamaUnvanlari_Unvanlar_UnvanId",
                        column: x => x.UnvanId,
                        principalTable: "Unvanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AdSoyad = table.Column<string>(maxLength: 100, nullable: true),
                    TcNo = table.Column<string>(maxLength: 11, nullable: true),
                    DogumTarihi = table.Column<DateTime>(nullable: false),
                    GorevId = table.Column<long>(nullable: false),
                    Telefon = table.Column<string>(maxLength: 20, nullable: true),
                    KanGrubu = table.Column<string>(maxLength: 10, nullable: true),
                    Adres = table.Column<string>(maxLength: 256, nullable: true),
                    SicilNo = table.Column<string>(maxLength: 7, nullable: true),
                    IseBaslamaTarihi = table.Column<DateTime>(nullable: false),
                    IstenAyrilmaTarihi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personeller_Unvanlar_GorevId",
                        column: x => x.GorevId,
                        principalTable: "Unvanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Puantajlar",
                columns: table => new
                {
                    PersonelId = table.Column<long>(nullable: false),
                    Tarih = table.Column<DateTime>(nullable: false),
                    SecenekId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puantajlar", x => new { x.PersonelId, x.Tarih });
                    table.ForeignKey(
                        name: "FK_Puantajlar_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Puantajlar_Secenekler_SecenekId",
                        column: x => x.SecenekId,
                        principalTable: "Secenekler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hesaplamalar",
                columns: new[] { "Id", "Baslik", "Disabled", "OzetGoster", "SaymaLimiti", "UyariLimiti" },
                values: new object[,]
                {
                    { 1L, "Çalışma Günü", false, false, 0, 0 },
                    { 21L, "Resmi Tatil Mesai", false, true, 0, 0 },
                    { 20L, "İdari İzin", false, true, 0, 0 },
                    { 19L, "Vizite", false, true, 0, 0 },
                    { 18L, "Saat Mesai", false, true, 0, 0 },
                    { 17L, "Gece Çalışma", false, true, 0, 0 },
                    { 15L, "Yol Gün", false, true, 0, 0 },
                    { 14L, "Yemek Gün", false, true, 0, 0 },
                    { 13L, "Sigorta Gün", false, true, 30, 0 },
                    { 12L, "Devamsızlık", false, false, 0, 0 },
                    { 16L, "Sorumluluk Gün", false, true, 0, 0 },
                    { 10L, "Ödenmeyecek Rapor", false, false, 0, 0 },
                    { 11L, "Ücretsiz İzin", false, false, 0, 0 },
                    { 3L, "Resmi Tatil", false, true, 0, 0 },
                    { 4L, "Yıllık İzin", false, false, 0, 0 },
                    { 5L, "Ödenecek Rapor", false, false, 0, 0 },
                    { 2L, "Hafta Tatili", false, false, 0, 0 },
                    { 7L, "Ölüm İzni", false, false, 0, 0 },
                    { 8L, "Evlilik İzni", false, false, 0, 0 },
                    { 9L, "Vardiya İzni", false, false, 0, 0 },
                    { 6L, "Doğum İzni", false, false, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Secenekler",
                columns: new[] { "Id", "Aciklama", "Deger", "Disabled", "Renk" },
                values: new object[,]
                {
                    { 11L, "Ödenecek Rapor", "R+", false, "blue" },
                    { 19L, "Resmi Tatil Çalışma", "Rc", false, "tan" },
                    { 18L, "Vardiya İzni", "Vi", false, "lavenderblush" },
                    { 17L, "Ölüm İzni", "Öi", false, "floralwhite" },
                    { 16L, "Evlilik İzni", "Ei", false, "hotpink" },
                    { 15L, "Doğum İzni", "Di", false, "lavender" },
                    { 14L, "Resmi Tatil", "Rt", false, "thistle" },
                    { 13L, "Vizite", "V", false, "slateblue" },
                    { 12L, "Ödenmeyecek Rapor", "R-", false, "skyblue" },
                    { 10L, "Ücretsiz İzin", "Üi", false, "white" },
                    { 6L, "Hafta Tatili", "Ht", false, "limegreen" },
                    { 8L, "Yıllık İzin", "Yi", false, "aquamarine" },
                    { 7L, "Devamsızlık", "D", false, "lightcyan" },
                    { 5L, "Gece Çalışması", "Gx", false, "palegoldenrod" },
                    { 4L, "Üç Saatlik Mesai", "X3", false, "papayawhip" },
                    { 3L, "İki Saatlik Mesai", "X2", false, "darkorange" },
                    { 2L, "Bir Saatlik Mesai", "X1", false, "lightsalmon" },
                    { 1L, "Normal Çalışma", "X", false, "indianred" },
                    { -1L, "Boş Değer", "", false, "white" },
                    { 9L, "İdari İzin", "İi", false, "white" }
                });

            migrationBuilder.InsertData(
                table: "Unvanlar",
                columns: new[] { "Id", "Disabled", "UnvanAdi" },
                values: new object[,]
                {
                    { 12L, false, "Ağaç Dalı Ekibi" },
                    { 11L, false, "Otobüs Şoförü" },
                    { 10L, false, "Şoför" },
                    { 9L, false, "Vasıflı" },
                    { 8L, false, "İlaçlama Görevlisi" },
                    { 7L, false, "Operatör" },
                    { 3L, false, "Bölge Şefi" },
                    { 5L, false, "Araç Bakım Sorumlusu" },
                    { 4L, false, "Puantör" },
                    { 2L, false, "İlaçlama Yetkilisi" },
                    { 1L, false, "Yönetici Amir" },
                    { 13L, false, "Yükleyici İşçi" },
                    { 6L, false, "Halkla İlişkiler Görevlisi" },
                    { 14L, false, "Genel Amaçlı İşçi" }
                });

            migrationBuilder.InsertData(
                table: "HesaplamaSecenekleri",
                columns: new[] { "HesaplamaId", "SecenekId", "Katsayi" },
                values: new object[,]
                {
                    { 1L, 1L, 1 },
                    { 13L, 8L, 1 },
                    { 13L, 9L, 1 },
                    { 20L, 9L, 1 },
                    { 11L, 10L, 1 },
                    { 5L, 11L, 1 },
                    { 13L, 11L, 1 },
                    { 10L, 12L, 1 },
                    { 13L, 13L, 1 },
                    { 19L, 13L, 1 },
                    { 3L, 14L, 1 },
                    { 13L, 14L, 1 },
                    { 6L, 15L, 1 },
                    { 4L, 8L, 1 },
                    { 13L, 15L, 1 },
                    { 13L, 16L, 1 },
                    { 7L, 17L, 1 },
                    { 13L, 17L, 1 },
                    { 9L, 18L, 1 },
                    { 13L, 18L, 1 },
                    { 1L, 19L, 1 },
                    { 13L, 19L, 1 },
                    { 14L, 19L, 1 },
                    { 15L, 19L, 1 },
                    { 16L, 19L, 1 },
                    { 17L, 19L, 1 },
                    { 21L, 19L, 1 },
                    { 8L, 16L, 1 },
                    { 12L, 7L, 1 },
                    { 13L, 6L, 1 },
                    { 15L, 3L, 1 },
                    { 15L, 1L, 1 },
                    { 16L, 1L, 1 },
                    { 1L, 2L, 1 },
                    { 13L, 2L, 1 },
                    { 14L, 2L, 1 },
                    { 15L, 2L, 1 },
                    { 16L, 2L, 1 },
                    { 18L, 2L, 1 },
                    { 1L, 3L, 1 },
                    { 13L, 3L, 1 },
                    { 14L, 3L, 1 },
                    { 2L, 6L, 1 },
                    { 14L, 1L, 1 },
                    { 16L, 3L, 1 },
                    { 1L, 4L, 1 },
                    { 13L, 4L, 1 },
                    { 14L, 4L, 1 },
                    { 15L, 4L, 1 },
                    { 16L, 4L, 1 },
                    { 18L, 4L, 3 },
                    { 1L, 5L, 1 },
                    { 13L, 5L, 1 },
                    { 14L, 5L, 1 },
                    { 15L, 5L, 1 },
                    { 16L, 5L, 1 },
                    { 17L, 5L, 1 },
                    { 18L, 3L, 2 },
                    { 13L, 1L, 1 }
                });

            migrationBuilder.InsertData(
                table: "HesaplamaUnvanlari",
                columns: new[] { "HesaplamaId", "UnvanId" },
                values: new object[,]
                {
                    { 16L, 10L },
                    { 16L, 7L },
                    { 16L, 11L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HesaplamaSecenekleri_SecenekId",
                table: "HesaplamaSecenekleri",
                column: "SecenekId");

            migrationBuilder.CreateIndex(
                name: "IX_HesaplamaUnvanlari_UnvanId",
                table: "HesaplamaUnvanlari",
                column: "UnvanId");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_GorevId",
                table: "Personeller",
                column: "GorevId");

            migrationBuilder.CreateIndex(
                name: "IX_Puantajlar_SecenekId",
                table: "Puantajlar",
                column: "SecenekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "HesaplamaSecenekleri");

            migrationBuilder.DropTable(
                name: "HesaplamaUnvanlari");

            migrationBuilder.DropTable(
                name: "Puantajlar");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Hesaplamalar");

            migrationBuilder.DropTable(
                name: "Personeller");

            migrationBuilder.DropTable(
                name: "Secenekler");

            migrationBuilder.DropTable(
                name: "Unvanlar");
        }
    }
}
