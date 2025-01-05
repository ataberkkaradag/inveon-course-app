using InveonCourseAppBackend.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Infrastructure
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed Category
            
            modelBuilder.Entity<Category>().HasData(
                new Category
                {

                    Id = new Guid("aa17679c-7a07-45b0-831e-87f02faa911a"),
                    Name = "ASP.NET Core"
                },
                new Category
                {

                    Id = new Guid("83668fa1-fe5e-4e41-86a7-f61672db3013"),
                    Name = "ASP.NET MVC"
                },
                new Category
                {

                    Id = new Guid("3cd3bec7-e935-41e3-afd8-eb600f05174f"),
                    Name = "Microservices"
                },
                new Category
                {

                    Id = new Guid("c2170d5e-fdc2-476d-8afe-6303ef0795fc"),
                    Name = "Elasticsearch"
                },
                new Category
                {

                    Id = new Guid("1111a53e-1ed9-453d-a480-de46712eb863"),
                    Name = "Unity"
                }, new Category
                {

                    Id = new Guid("9e73ffb7-015c-4be2-a78b-d595d806b847"),
                    Name = "JavaScript"
                }, new Category
                {

                    Id = new Guid("0cd7de0d-d051-45e0-bb5b-8541b7391ad2"),
                    Name = "React"
                }
            );

            var roles = new List<Role>
            {
                new Role { Id = Guid.NewGuid(), Name = "Instructor", NormalizedName = "INSTRUCTOR" },
                new Role { Id = Guid.NewGuid(), Name = "Student", NormalizedName = "STUDENT" }
            };
            modelBuilder.Entity<Role>().HasData(roles);

            var hasher = new PasswordHasher<User>();

            var instructorUser = new User
            {
                Id = new Guid("008a0697-cf89-453c-8a84-0be4e576e79a"),
                UserName = "instructor",
                NormalizedUserName = "INSTRUCTOR",
                Email = "Instructor@gmail.com",
                NormalizedEmail = "INSTRUCTOR@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Instructor123*"),
                SecurityStamp = string.Empty
            };

            var normalUser = new User
            {
                Id = new Guid("ac1d06b5-1c29-4222-9270-f3e9586a3e8f"),
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "User123*"),
                SecurityStamp = string.Empty
            };


            modelBuilder.Entity<User>().HasData(instructorUser, normalUser);


            var userRoles = new List<IdentityUserRole<Guid>>
            {
                new IdentityUserRole<Guid> { UserId = instructorUser.Id, RoleId = roles[0].Id },
                new IdentityUserRole<Guid> { UserId = normalUser.Id, RoleId = roles[1].Id }
            };
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(userRoles);

            // Seed Course
            
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = new Guid("1f1e6893-171f-4a07-bc32-5bceaad2329d"),
                    Title = "Full Stack Web Geliştirme: HTML'den .NET Core'a",
                    Description = "Bu kurs, modern web geliştirme dünyasına adım atmak isteyen herkes için tasarlanmıştır. Temelden başlayarak, HTML, CSS, JavaScript, Bootstrap, ASP.NET Core ve diğer teknolojileri kullanarak gerçek dünya projeleri geliştirmeyi öğrenin.",
                    Price = 129.99m,
                    CategoryId = new Guid("9e73ffb7-015c-4be2-a78b-d595d806b847"),
                    InstructorId = new Guid("008a0697-cf89-453c-8a84-0be4e576e79a")
                },
                 new Course
                 {
                     Id = new Guid("82bc6766-d1f8-46e9-bb59-f243ec63ddf5"),
                     Title = "Unity C#; Sıfırdan İleri Seviyeye Oyun Tasarlama",
                     Description = "Heyecan verici bir dünyanın kapılarını aralıyoruz! Unity ile mobil oyun geliştirme kursu, yaratıcı düşünceyi kodla buluşturarak, özgün oyun fikirlerinizi gerçeğe dönüştürmeniz için tasarlandı. Oyun geliştirme dünyasının kapılarını açmak için siz de bu maceraya katılın! Mobil platformların büyülü dünyasında kendi izinizi bırakmak için hazır mısınız?\r\n\r\n\r\n\r\nBu eşsiz eğitimde, sizi bir mobil oyun geliştiricisi olmaya hazırlayacak adımları adım adım öğreneceksiniz.",
                     Price = 129.99m,
                     CategoryId = new Guid("1111a53e-1ed9-453d-a480-de46712eb863"),
                     InstructorId = new Guid("008a0697-cf89-453c-8a84-0be4e576e79a")
                 },
                  new Course
                  {
                      Id = new Guid("76f5c696-812e-434f-9e4a-852633a9100d"),
                      Title = ".Net Core(API/MVC) ile Observability(Trace,Log ve Metric)",
                      Description = "OpenTelemetry is an open-source project that provides a set of APIs, libraries, agents, and instrumentation to provide observability and traceability in your applications. It allows you to collect telemetry data such as traces, metrics, and logs.",
                      Price = 129.99m,
                      CategoryId = new Guid("83668fa1-fe5e-4e41-86a7-f61672db3013"),
                      InstructorId = new Guid("008a0697-cf89-453c-8a84-0be4e576e79a")
                  },
                   new Course
                   {
                       Id = new Guid("231b226d-8ae1-4fe3-b9cf-456525cfc7f7"),
                       Title = "Asp.Net Core API + Token bazlı kimlik doğrulama(JWT)",
                       Description = "Bu kursumda sıfırdan başlayarak katmanlı mimari ile asp.net core api projesi oluşturacağız. Daha sonra oluşturmuş olduğumuz proje üzerine token bazlı( json web token) kimlik doğrulama/kimlik yetkilendirme mekanizmasının nasıl inşa edileceğini hep beraber öğreneceğiz.",
                       Price = 49.99m,
                       CategoryId = new Guid("aa17679c-7a07-45b0-831e-87f02faa911a"),
                       InstructorId = new Guid("008a0697-cf89-453c-8a84-0be4e576e79a")
                   },
                    new Course
                    {
                        Id = new Guid("35bb75be-93b0-48d3-8953-f497f3ba521d"),
                        Title = "Net 8 API/WEB | NLayer/Clean Architecture | Best Practice",
                        Description = "Bu kursun amacı, katmanlı mimari veya Clean Architecture gibi yazılım mimarilerini kullanarak uygulama geliştirirken izlenmesi gereken en iyi uygulama ve teknikleri (best practices) kapsamlı bir şekilde ele almaktır. Kurs boyunca, bu mimari desenlerin temel prensiplerini, yapı taşlarını ve gerçek dünyada karşılaşabileceğiniz senaryolarda nasıl etkili bir şekilde uygulanabileceklerini detaylı olarak inceleyeceğiz. Katılımcılar, bu mimarileri kullanarak yazılım geliştirme süreçlerinde karşılaşabilecekleri zorlukları nasıl aşabileceklerini ve kaliteli, sürdürülebilir yazılımlar geliştirebilmek için hangi adımları atmaları gerektiğini öğrenecekler.Katmanlı mimari (NLayer Architecture), bir yazılım uygulamasını farklı işlevsel bileşenlere veya katmanlara ayırarak, bu bileşenlerin daha modüler, bakımı kolay ve test edilebilir hale gelmesini sağlayan bir yazılım mimarisi desenidir. Her katman, belirli bir sorumluluğa sahip olup, uygulamanın belirli bir bölümünün işlevselliğini kapsar. Bu mimari, yazılım geliştirme sürecinde karmaşıklığı yönetmek ve uygulamanın esnekliğini artırmak amacıyla kullanılır.",
                        Price = 299.99m,
                        CategoryId = new Guid("aa17679c-7a07-45b0-831e-87f02faa911a"),
                        InstructorId = new Guid("008a0697-cf89-453c-8a84-0be4e576e79a")
                    },
                     new Course
                     {
                         Id = new Guid("e951261d-8ae3-479b-8d8d-7bc7ccbfc36c"),
                         Title = "Net ile Microservices ( .Net 7 Upgrade )",
                         Description = "Microservice Mimari, günümüzde backend developer'ların bilmesi ve öğrenmesi gereken mimari yaklaşımdır.\r\n\r\nBu kursumda .Net 5 ile Microservice mimari nasıl geliştirilebileceğini öğreneceksiniz.\r\n\r\nMicroservice'ler arasında senkron ve asenkron iletişim nasıl kurulur öğreneceksiniz.\r\n\r\nMicroservice mimaride  OAuth 2.0 ve OpenID Connect protokollerinin nasıl implement edileceğiniz öğreniyor olacaksınız.\r\n\r\nMicroservice'lere ait veritabanlarında tutarlılığı sağlamak için Eventual Consistency model'inin nasıl uygulanacağını öğreneceksiniz.\r\n\r\nMicroservice'lerimizi nasıl dockerize edileceğini öğreneceksiniz.\r\n\r\nDocker Compose dosyasının nasıl oluşturulacağını öğreneceksiniz.\r\n\r\nÇeşitli veritabanlarını container olarak nasıl ayağa kaldırılacağını öğreniyor olacaksınız.\r\n\r\nKursta, udemy benzeri bir online kurs satış platformunu microservice mimari ile geliştiriyor olacağız.",
                         Price = 159.99m,
                         CategoryId = new Guid("3cd3bec7-e935-41e3-afd8-eb600f05174f"),
                         InstructorId = new Guid("008a0697-cf89-453c-8a84-0be4e576e79a")
                     },
                      new Course
                      {
                          Id = new Guid("4e0c3c93-f7d5-4d14-944c-490adac81a0f"),
                          Title = "Sıfırdan İleri Seviye React Kursu : Güncel Eğitim 2024",
                          Description = "React js ; Facebook tarafından 2013 yılında geliştirilmiş bir Javascript kütüphanesidir.\r\n\r\nŞuanda sektörde birçok kurumsal şirket tarafından sıklıkla tercih edilmektedir. React size interaktif , hızlı ve kolay bir şekilde arayüz geliştirmenize olanak sağlar.\r\n\r\nReact'ın en önemli özelliği component ve state mantığıdır. Uygulamanızı yapboz gibi küçük küçük componentlere bölerek kod tekrarını engelleyip , tekrar tekrar kullanılabilirlik sağlamış olur.\r\n\r\nBir diğer en önemli özelliklerinden bir tanesi de şudur bir state'in değeri değiştiği zaman bütün uygulama değil sadece o state'in bulunduğu component tekrar render edilmiş olur. Bu sayede yüksek performans ve kullanışlılık sunmuş olur.\r\n\r\n",
                          Price = 49.99m,
                          CategoryId = new Guid("0cd7de0d-d051-45e0-bb5b-8541b7391ad2"),
                          InstructorId = new Guid("008a0697-cf89-453c-8a84-0be4e576e79a")
                      },
                       new Course
                       {
                           Id = new Guid("c2f3ae28-5e76-477b-a220-81e18fb894c2"),
                           Title = "React JS : Uygulamalı React JS -Redux Eğitimi",
                           Description = "React (ReactJS veya React.js olarak da bilinir) kullanıcı arayüzü oluşturmaya yarayan açık kaynak kodlu bir javascript kütüphanesidir. Facebook önderliğinde bir geliştirici grubu tarafından geliştirilmekte olan React, Model-View-Controller prensibine uygun olarak oluşturulmuştur. React ile single-page olarak adlandırılan sayfalar geliştirilebileceği gibi React-Native ile mobil uygulamalar da geliştirilebilir.\r\n\r\nReact, interaktif kullanıcı arayüzü geliştirmeyi zahmetsiz hale getirir. Siz uygulamanızdaki her durum için basit sayfalar tasarlayın. React, veriniz değiştiğinde sadece doğru bileşenleri verimli bir şekilde güncellesin ve oluştursun.",
                           Price = 100.99m,
                           CategoryId = new Guid("0cd7de0d-d051-45e0-bb5b-8541b7391ad2"),
                           InstructorId = new Guid("008a0697-cf89-453c-8a84-0be4e576e79a")
                       },
                        new Course
                        {
                            Id = new Guid("50ba3fd3-b595-4705-99c0-82d90ef1853d"),
                            Title = "Asp.Net Core Üyelik Sistemi (Asp.Net Core Identity)",
                            Description = ".NET Core Identity, ASP.NET Core için bir kimlik doğrulama ve yetkilendirme çözümüdür. Identity, kullanıcıların kimlik doğrulamasını (authentication) ve yetkilendirilmesini (authorization) yönetmek için gerekli olan araçları sağlar.\r\n\r\nBizde bu kursumuzda  .Net 7 SDK ile  Asp.Net Core MVC projesi oluşturup, Identity API'nin tüm özelliklerini bu proje üzerinde adım adım gerçekleştireceğiz.",
                            Price = 49.99m,
                            CategoryId = new Guid("aa17679c-7a07-45b0-831e-87f02faa911a"),
                            InstructorId = new Guid("008a0697-cf89-453c-8a84-0be4e576e79a")
                        },
                         new Course
                         {
                             Id = new Guid("5f6894b8-4df3-4ee1-85e6-d4bf59ae6006"),
                             Title = "Elasticsearch | Net Core",
                             Description = "Elasticsearch, açık kaynaklı bir dağıtılmış arama ve analiz motorudur. Büyük miktardaki verileri hızlı bir şekilde depolama, arama, analiz etme ve gerçek zamanlı olarak keşfetme yeteneği sunar. Elasticsearch, ölçeklenebilir, yüksek performanslı ve esnek bir yapıya sahiptir.",
                             Price = 49.99m,
                             CategoryId = new Guid("c2170d5e-fdc2-476d-8afe-6303ef0795fc"),
                             InstructorId = new Guid("008a0697-cf89-453c-8a84-0be4e576e79a")
                         }
            );

        }
    }
    }
