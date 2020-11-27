using Microsoft.EntityFrameworkCore;
using Models.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Models.Entity;
using Microsoft.Data.Sqlite;

namespace Initializer
{
    public class InitsAccount
    {
        private AMIDbContext Context { get; set; }

        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder<AMIDbContext> optionsbuilder = new DbContextOptionsBuilder<AMIDbContext>();
            Context = new AMIDbContext(optionsbuilder.Options);
        }

        [Test]
        public void InitUser()
        {
            try {
                List<Role> roles = InitializeRoles();
                roles.ForEach(x => Context.Roles.Add(x));

                List<Account> accounts = InitializeAccounts(roles);
                accounts.ForEach(x => Context.Accounts.Add(x));

                var result=   Context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private List<Role> InitializeRoles()
        {
            List<Role> roles = new List<Role>()
            {
                new Role() { RoleType = 0 },
                new Role() { RoleType = (RoleType)1},
                new Role() { RoleType = (RoleType)2 }
            };
            return roles;
        }

        private List<Account> InitializeAccounts(List<Role> roles)
        {
            List<Account> accounts =
                new List<Account>
            {
                new Account()
                {           Id=Guid.NewGuid(),
                    EmployeeID = "AMI230K-System",
                    UserName = "system",
                    Name = "system",
                    Password = "system",
                    Tel = "0900000000",
                    Email = "system@gmail.com",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Disabled = false,
                    IsApproved = true,
                    IsLocked = false,
                    Role = roles.Where(x => x.RoleType == (RoleType)0).FirstOrDefault()
                },
                new Account()
                {            Id=Guid.NewGuid(),
                    EmployeeID = "AMI230K-Admin",
                    UserName = "admin",
                    Name = "admin",
                    Password = "admin",
                    Tel = "0900000000",
                    Email = "admin@gmail.com",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Disabled = false,
                    IsApproved = true,
                    IsLocked = false,
                    Role = roles.Where(x => x.RoleType == (RoleType)1).FirstOrDefault()
                },
                new Account()
                {           Id=Guid.NewGuid(),
                    EmployeeID = "AMI230K-Guest",
                    UserName = "Guest",
                    Name = "Guest",
                    Password = "Guest",
                    Tel = "0900000000",
                    Email = "Guest@gmail.com",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Disabled = false,
                    IsApproved = true,
                    IsLocked = false,
                    Role = roles.Where(x => x.RoleType == (RoleType)2).FirstOrDefault()
                }
            };
            return accounts;
        }

    }

}
