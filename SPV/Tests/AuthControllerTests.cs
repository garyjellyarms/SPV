using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPV.Controllers;
using SPV.Models;
using SPV.Utils;
using System;

namespace SPV.Tests.Controllers
{
    [TestClass]
    public class AuthControllerTests
    {
        private readonly AppDbContext _context;
        private readonly AuthController authController;
        PasswordManagement passwordManagement = new PasswordManagement();

        public AuthControllerTests()
        {
            var fixture = new InMemoryDatabaseFixture();
            _context = fixture.Context;
            authController = new AuthController(_context);
        }
        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void Login_WithValidCredentials_ReturnsSession()
        {
            User user = new User { Email = "test@example.com", Password = "password123" };
            _context.User.Add(user);
         
            Session session = authController.Login(user);

            Assert.IsNotNull(session);
            Assert.AreEqual(session.UserID, 0);
        }

        [TestMethod]
        public void Login_WithInvalidUser_ReturnsError()
        {
            User user = new User { Email = "invalid@example.com", Password = "password123" };

            _context.User.Add(user);
            Session session = authController.Login(user);

            Assert.IsNotNull(session);
            Assert.AreEqual(session.Error, "Wrong body parameters");
        }

        [TestMethod]
        public void Register_WithNewUser_ReturnsSession()
        {
            _context.User.Add(new User { Email = "test@example.com", Password = "password123" });

            User user = new User { Email = "newuser@example.com", Password = "password123",Username="MyUsername", Name="MyName", Surname="Surname", Created=DateTime.Now };

            passwordManagement.HashPasword(user);
            Session session = authController.Register(user);

            Assert.IsNotNull(session);
            Assert.IsNotNull(session.UserID);
        }

        [TestMethod]
        public void Register_WithExistingUser_ReturnsError()
        {
            User user = new User { Email = "test@example.com", Password = "password123" };

            Session session = authController.Register(user);

            Assert.IsNotNull(session);
            Assert.AreEqual(session.Error, "User already exists");
        }
    }
}