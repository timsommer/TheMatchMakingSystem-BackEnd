﻿using FoosballAPI.Data;
using FoosballAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class DBInitializer
    {
        public static void Initialize(ApiContext context)
        {
            context.Database.EnsureCreated();

            // Look for any user.
            if (context.Roles.Any())
            {
                return;   // DB has been seeded
            }

            context.Roles.AddRange(
              new Role { Name = "User" },
              new Role { Name = "Admin" });
            context.SaveChanges();

            context.Users.AddRange(
                new User { Username = "test", Password = "test", FirstName = "Test", LastName = "Test", Email = "test.test@thomasmore.be", Address = "Doelenstraat 46", Dob = new DateTime(1989, 11, 19), RoleID = 1, Town = "Geel"});
            context.SaveChanges();
        }
    }
}