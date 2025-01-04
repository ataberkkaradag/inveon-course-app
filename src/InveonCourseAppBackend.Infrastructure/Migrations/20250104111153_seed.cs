using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InveonCourseAppBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourses_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseOrder",
                columns: table => new
                {
                    CoursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOrder", x => new { x.CoursesId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_CourseOrder_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2b5ecd24-6895-41fb-a0a2-f18f5a3e1af3"), null, "Instructor", "INSTRUCTOR" },
                    { new Guid("50ecf675-1a19-4bf1-b7d9-9bce04411c2d"), null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("008a0697-cf89-453c-8a84-0be4e576e79a"), 0, "0bb8d66d-4581-41f6-b17f-1e4beb6077c4", "Instructor@gmail.com", true, false, null, "INSTRUCTOR@GMAIL.COM", "INSTRUCTOR", "AQAAAAIAAYagAAAAEIeDUTmooPP1wO5H2O3OCT3NW4RgQpIKVSapJSqZO0nYBkdvAV3xuN/j666abhAgYQ==", null, false, "", false, "instructor" },
                    { new Guid("ac1d06b5-1c29-4222-9270-f3e9586a3e8f"), 0, "af79cf87-6d24-48ce-8864-cea75cbcc73a", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER", "AQAAAAIAAYagAAAAEEDS+WhtGt7OrqVlcH0VC8l4omIkQJmInVFnCSCzRBrnUmZvvP6yqRAVf0A/jA+qqA==", null, false, "", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0cd7de0d-d051-45e0-bb5b-8541b7391ad2"), "React" },
                    { new Guid("1111a53e-1ed9-453d-a480-de46712eb863"), "Unity" },
                    { new Guid("3cd3bec7-e935-41e3-afd8-eb600f05174f"), "Microservices" },
                    { new Guid("83668fa1-fe5e-4e41-86a7-f61672db3013"), "ASP.NET MVC" },
                    { new Guid("9e73ffb7-015c-4be2-a78b-d595d806b847"), "JavaScript" },
                    { new Guid("aa17679c-7a07-45b0-831e-87f02faa911a"), "ASP.NET Core" },
                    { new Guid("c2170d5e-fdc2-476d-8afe-6303ef0795fc"), "Elasticsearch" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2b5ecd24-6895-41fb-a0a2-f18f5a3e1af3"), new Guid("008a0697-cf89-453c-8a84-0be4e576e79a") },
                    { new Guid("50ecf675-1a19-4bf1-b7d9-9bce04411c2d"), new Guid("ac1d06b5-1c29-4222-9270-f3e9586a3e8f") }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("1f1e6893-171f-4a07-bc32-5bceaad2329d"), new Guid("9e73ffb7-015c-4be2-a78b-d595d806b847"), "Bu kurs, modern web geliştirme dünyasına adım atmak isteyen herkes için tasarlanmıştır. Temelden başlayarak, HTML, CSS, JavaScript, Bootstrap, ASP.NET Core ve diğer teknolojileri kullanarak gerçek dünya projeleri geliştirmeyi öğrenin.", new Guid("008a0697-cf89-453c-8a84-0be4e576e79a"), 129.99m, "Full Stack Web Geliştirme: HTML'den .NET Core'a" },
                    { new Guid("231b226d-8ae1-4fe3-b9cf-456525cfc7f7"), new Guid("aa17679c-7a07-45b0-831e-87f02faa911a"), "A comprehensive course on C# programming.", new Guid("008a0697-cf89-453c-8a84-0be4e576e79a"), 49.99m, "Learn C#" },
                    { new Guid("35bb75be-93b0-48d3-8953-f497f3ba521d"), new Guid("aa17679c-7a07-45b0-831e-87f02faa911a"), "Bu kursun amacı, katmanlı mimari veya Clean Architecture gibi yazılım mimarilerini kullanarak uygulama geliştirirken izlenmesi gereken en iyi uygulama ve teknikleri (best practices) kapsamlı bir şekilde ele almaktır. Kurs boyunca, bu mimari desenlerin temel prensiplerini, yapı taşlarını ve gerçek dünyada karşılaşabileceğiniz senaryolarda nasıl etkili bir şekilde uygulanabileceklerini detaylı olarak inceleyeceğiz. Katılımcılar, bu mimarileri kullanarak yazılım geliştirme süreçlerinde karşılaşabilecekleri zorlukları nasıl aşabileceklerini ve kaliteli, sürdürülebilir yazılımlar geliştirebilmek için hangi adımları atmaları gerektiğini öğrenecekler.Katmanlı mimari (NLayer Architecture), bir yazılım uygulamasını farklı işlevsel bileşenlere veya katmanlara ayırarak, bu bileşenlerin daha modüler, bakımı kolay ve test edilebilir hale gelmesini sağlayan bir yazılım mimarisi desenidir. Her katman, belirli bir sorumluluğa sahip olup, uygulamanın belirli bir bölümünün işlevselliğini kapsar. Bu mimari, yazılım geliştirme sürecinde karmaşıklığı yönetmek ve uygulamanın esnekliğini artırmak amacıyla kullanılır.", new Guid("008a0697-cf89-453c-8a84-0be4e576e79a"), 299.99m, "Net 8 API/WEB | NLayer/Clean Architecture | Best Practice" },
                    { new Guid("4e0c3c93-f7d5-4d14-944c-490adac81a0f"), new Guid("0cd7de0d-d051-45e0-bb5b-8541b7391ad2"), "React js ; Facebook tarafından 2013 yılında geliştirilmiş bir Javascript kütüphanesidir.\r\n\r\nŞuanda sektörde birçok kurumsal şirket tarafından sıklıkla tercih edilmektedir. React size interaktif , hızlı ve kolay bir şekilde arayüz geliştirmenize olanak sağlar.\r\n\r\nReact'ın en önemli özelliği component ve state mantığıdır. Uygulamanızı yapboz gibi küçük küçük componentlere bölerek kod tekrarını engelleyip , tekrar tekrar kullanılabilirlik sağlamış olur.\r\n\r\nBir diğer en önemli özelliklerinden bir tanesi de şudur bir state'in değeri değiştiği zaman bütün uygulama değil sadece o state'in bulunduğu component tekrar render edilmiş olur. Bu sayede yüksek performans ve kullanışlılık sunmuş olur.\r\n\r\n", new Guid("008a0697-cf89-453c-8a84-0be4e576e79a"), 49.99m, "Sıfırdan İleri Seviye React Kursu : Güncel Eğitim 2024" },
                    { new Guid("50ba3fd3-b595-4705-99c0-82d90ef1853d"), new Guid("aa17679c-7a07-45b0-831e-87f02faa911a"), ".NET Core Identity, ASP.NET Core için bir kimlik doğrulama ve yetkilendirme çözümüdür. Identity, kullanıcıların kimlik doğrulamasını (authentication) ve yetkilendirilmesini (authorization) yönetmek için gerekli olan araçları sağlar.\r\n\r\nBizde bu kursumuzda  .Net 7 SDK ile  Asp.Net Core MVC projesi oluşturup, Identity API'nin tüm özelliklerini bu proje üzerinde adım adım gerçekleştireceğiz.", new Guid("008a0697-cf89-453c-8a84-0be4e576e79a"), 49.99m, "Asp.Net Core Üyelik Sistemi (Asp.Net Core Identity)" },
                    { new Guid("5f6894b8-4df3-4ee1-85e6-d4bf59ae6006"), new Guid("c2170d5e-fdc2-476d-8afe-6303ef0795fc"), "Elasticsearch, açık kaynaklı bir dağıtılmış arama ve analiz motorudur. Büyük miktardaki verileri hızlı bir şekilde depolama, arama, analiz etme ve gerçek zamanlı olarak keşfetme yeteneği sunar. Elasticsearch, ölçeklenebilir, yüksek performanslı ve esnek bir yapıya sahiptir.", new Guid("008a0697-cf89-453c-8a84-0be4e576e79a"), 49.99m, "Elasticsearch | Net Core" },
                    { new Guid("76f5c696-812e-434f-9e4a-852633a9100d"), new Guid("83668fa1-fe5e-4e41-86a7-f61672db3013"), "A comprehensive course on C# programming.", new Guid("008a0697-cf89-453c-8a84-0be4e576e79a"), 129.99m, ".Net Core(API/MVC) ile Observability(Trace,Log ve Metric)" },
                    { new Guid("82bc6766-d1f8-46e9-bb59-f243ec63ddf5"), new Guid("1111a53e-1ed9-453d-a480-de46712eb863"), "Heyecan verici bir dünyanın kapılarını aralıyoruz! Unity ile mobil oyun geliştirme kursu, yaratıcı düşünceyi kodla buluşturarak, özgün oyun fikirlerinizi gerçeğe dönüştürmeniz için tasarlandı. Oyun geliştirme dünyasının kapılarını açmak için siz de bu maceraya katılın! Mobil platformların büyülü dünyasında kendi izinizi bırakmak için hazır mısınız?\r\n\r\n\r\n\r\nBu eşsiz eğitimde, sizi bir mobil oyun geliştiricisi olmaya hazırlayacak adımları adım adım öğreneceksiniz.", new Guid("008a0697-cf89-453c-8a84-0be4e576e79a"), 129.99m, "Unity C#; Sıfırdan İleri Seviyeye Oyun Tasarlama" },
                    { new Guid("c2f3ae28-5e76-477b-a220-81e18fb894c2"), new Guid("0cd7de0d-d051-45e0-bb5b-8541b7391ad2"), "React (ReactJS veya React.js olarak da bilinir) kullanıcı arayüzü oluşturmaya yarayan açık kaynak kodlu bir javascript kütüphanesidir. Facebook önderliğinde bir geliştirici grubu tarafından geliştirilmekte olan React, Model-View-Controller prensibine uygun olarak oluşturulmuştur. React ile single-page olarak adlandırılan sayfalar geliştirilebileceği gibi React-Native ile mobil uygulamalar da geliştirilebilir.\r\n\r\nReact, interaktif kullanıcı arayüzü geliştirmeyi zahmetsiz hale getirir. Siz uygulamanızdaki her durum için basit sayfalar tasarlayın. React, veriniz değiştiğinde sadece doğru bileşenleri verimli bir şekilde güncellesin ve oluştursun.", new Guid("008a0697-cf89-453c-8a84-0be4e576e79a"), 100.99m, "React JS : Uygulamalı React JS -Redux Eğitimi" },
                    { new Guid("e951261d-8ae3-479b-8d8d-7bc7ccbfc36c"), new Guid("3cd3bec7-e935-41e3-afd8-eb600f05174f"), "Microservice Mimari, günümüzde backend developer'ların bilmesi ve öğrenmesi gereken mimari yaklaşımdır.\r\n\r\nBu kursumda .Net 5 ile Microservice mimari nasıl geliştirilebileceğini öğreneceksiniz.\r\n\r\nMicroservice'ler arasında senkron ve asenkron iletişim nasıl kurulur öğreneceksiniz.\r\n\r\nMicroservice mimaride  OAuth 2.0 ve OpenID Connect protokollerinin nasıl implement edileceğiniz öğreniyor olacaksınız.\r\n\r\nMicroservice'lere ait veritabanlarında tutarlılığı sağlamak için Eventual Consistency model'inin nasıl uygulanacağını öğreneceksiniz.\r\n\r\nMicroservice'lerimizi nasıl dockerize edileceğini öğreneceksiniz.\r\n\r\nDocker Compose dosyasının nasıl oluşturulacağını öğreneceksiniz.\r\n\r\nÇeşitli veritabanlarını container olarak nasıl ayağa kaldırılacağını öğreniyor olacaksınız.\r\n\r\nKursta, udemy benzeri bir online kurs satış platformunu microservice mimari ile geliştiriyor olacağız.", new Guid("008a0697-cf89-453c-8a84-0be4e576e79a"), 159.99m, "Net ile Microservices ( .Net 7 Upgrade )" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOrder_OrdersId",
                table: "CourseOrder",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId",
                unique: true,
                filter: "[PaymentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");
        }

        /// <inheritdoc />
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
                name: "CourseOrder");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
