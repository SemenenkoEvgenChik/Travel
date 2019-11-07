using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace TravelAgency.DAL.Helpers
{
    class TravelAgencyInitializer : CreateDatabaseIfNotExists<TravelAgencyContext>
    {
        const string pathCountry = @"C:\Users\Евгений\Desktop\TravelAgency\TravelAgency\TravelAgency.DAL\Countries.txt";
        const string pathCity = @"C:\Users\Евгений\Desktop\TravelAgency\TravelAgency\TravelAgency.DAL\Cities.txt";
        protected override void Seed(TravelAgencyContext context)
        {
            var countries = new List<Countries>();
            using (StreamReader sr = new StreamReader(pathCountry, Encoding.Default))
            {
                string[] masCountry;
                while (!sr.EndOfStream)
                {
                    masCountry = sr.ReadLine().Split('/');
                    var country = new Countries { Key = masCountry[1], NameOfCountry = masCountry[0] };
                    countries.Add(country);
                }
            }
            countries.ForEach(c => context.Countries.Add(c));
            context.SaveChanges();

            var cities = new List<City>();
            using (StreamReader sr = new StreamReader(pathCity, Encoding.Default))
            {
                string[] masCity;
                while (!sr.EndOfStream)
                {
                    masCity = sr.ReadLine().Split('/');
                    var city = new City { KeyCountry = masCity[0], NameOfCity = masCity[1] };
                    cities.Add(city);
                }
            }
            cities.ForEach(c => context.Cities.Add(c));
            context.SaveChanges();

            var typeOftour = new List<TypeOfTour> {
                new TypeOfTour { Description="Стандарт" },
                new TypeOfTour { Description ="Горящий" }
            };
            typeOftour.ForEach(type => context.TypeOfTours.Add(type));
            context.SaveChanges();

            var typeOfRest = new List<TypeOfRest>
            {
                new TypeOfRest { Description="Отдых" },
                new TypeOfRest { Description="Шопинг" },
                new TypeOfRest { Description="Экскурсия" }
            };
            typeOfRest.ForEach(type => context.TypeOfRests.Add(type));
            context.SaveChanges();

            var tripStatus = new List<TripStatus>
            {
                new TripStatus{ Status="Зарегистрирован"},
                new TripStatus{ Status="Оплачено"},
                new TripStatus{ Status="Отменен"}
            };
            tripStatus.ForEach(status => context.TripStatuses.Add(status));
            context.SaveChanges();

            var statusClient = new List<StatusClient> {
                new StatusClient{ Status ="Активен"},
                new StatusClient{ Status ="Заблокирован"}
            };
            statusClient.ForEach(status => context.StatusClients.Add(status));
            context.SaveChanges();

            var meansOfTransport = new List<MeansOfTransport> {
                new MeansOfTransport{ TypeOfTransport="Самолет"},
                new MeansOfTransport{ TypeOfTransport="Поезд"},
                new MeansOfTransport{ TypeOfTransport="Автобус"},
            };
            meansOfTransport.ForEach(transport => context.MeansOfTransports.Add(transport));
            context.SaveChanges();

            var food = new List<Food> {
                new Food{ TypeOfFood="без питания" },
                new Food{ TypeOfFood="завтраки" },
                new Food{ TypeOfFood="полупансион (завтрак + ужин)" },
                new Food{ TypeOfFood="полный пансион (завтрак, обед, ужин)" },
                new Food{ TypeOfFood="всё включено (полный пансион, включая алкогольные напитки)" },
            };
            food.ForEach(f => context.Foods.Add(f));
            context.SaveChanges();

            var role = new List<IdentityRole>
            {
                new IdentityRole { Name="admin" },
                new IdentityRole { Name="manager" },
                new IdentityRole { Name="client" },

            };
            role.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            var adminUser = new ApplicationUser
            {
                UserName = "Admin@gmail.com",
                Email = "Admin@gmail.com",
                PasswordHash = new PasswordHasher().HashPassword("Admin123"),
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            context.Users.Add(adminUser);
            context.SaveChanges();

            var managerUser = new ApplicationUser
            {
                UserName = "manager@gmail.com",
                Email = "manager@gmail.com",
                PasswordHash = new PasswordHasher().HashPassword("Manager123"),
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            context.Users.Add(managerUser);
            context.SaveChanges();

            var adminRole = role.Where(r => r.Name == "admin").FirstOrDefault();
            var managerRole = role.Where(r => r.Name == "manager").FirstOrDefault();

            var admin = new IdentityUserRole
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            };

            var manager = new IdentityUserRole
            {
                UserId = managerUser.Id,
                RoleId = managerRole.Id
            };

            int col = context.Database.ExecuteSqlCommand($"INSERT INTO AspNetUserRoles (UserId,RoleId) VALUES ('{admin.UserId}','{admin.RoleId}')");
            int col2 = context.Database.ExecuteSqlCommand($"INSERT INTO AspNetUserRoles (UserId,RoleId) VALUES ('{manager.UserId}','{manager.RoleId}')");

            context.SaveChanges();
        }
    }
}