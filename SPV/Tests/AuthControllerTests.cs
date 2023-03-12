using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPV.Controllers;
using SPV.Models;
using SPV.Utils;
using System;
using System.Linq;

[TestClass]
public class AuthControllerTests
{
    private readonly AppDbContext db;
    private readonly AuthController authController;
    PasswordManagement passwordManagement = new PasswordManagement();

    public AuthControllerTests()
    {
        var fixture = new InMemoryDatabaseFixture();
        db = fixture.Context;
        authController = new AuthController(db);
    }
    [TestInitialize]
    public void Initialize()
    {
    }

    [TestMethod]
    public void VeljavnaPrijava()
    {
        User user = new User
        {
            Username = "johndoe",
            Surname = "Doe",
            Name = "John",
            Email = "johndoe@example.com",
            Password = "password123",
            Created = DateTime.Now
        };
        passwordManagement.HashPasword(user);

        db.User.Add(user);
        db.SaveChanges();

        Session result = authController.Login(user);

        Assert.IsNotNull(result);
        Assert.AreEqual("", result.Error);
        Assert.AreEqual(user.Id, result.UserID);
        Assert.IsTrue(result.DateTo > DateTime.Now);
    }

    [TestMethod]
    public void NapačnoGeslo()
    {
        User user = new User
        {
            Username = "johndoe",
            Surname = "Doe",
            Name = "John",
            Email = "johndoe@example.com",
            Password = "password123",
            Created = DateTime.Now
        };
        db.User.Add(user);
        db.SaveChanges();

        User invalidUser = new User
        {
            Username = "johndoe",
            Surname = "Doe",
            Name = "John",
            Email = "johndoe@example.com",
            Password = "blablabla",
            Created = DateTime.Now
        };

        Session result = authController.Login(invalidUser);

        Assert.IsNotNull(result);
        Assert.AreEqual("Wrong password", result.Error);
    }

    [TestMethod]
    public void VeljavnaRegistracija()
    {
        User user = new User
        {
            Username = "tester",
            Surname = "tester",
            Name = "tester",
            Email = "tester@example.com",
            Password = "tester123",
            Created = DateTime.Now
        };

        Session result = authController.Register(user);

        Assert.IsNotNull(result);
        Assert.AreEqual("", result.Error);
        Assert.AreEqual(user.Username, db.User.Find(result.UserID).Username);
        Assert.IsTrue(result.DateTo > DateTime.Now);
    }

    [TestMethod]
    public void RegistracijObstoječiUporabnik()
    {
        User user = new User
        {
            Username = "johndoe",
            Surname = "Doe",
            Name = "John",
            Email = "johndoe@example.com",
            Password = "password123",
            Created = DateTime.Now
        };
        db.User.Add(user);
        db.SaveChanges();

        User existingUser = new User
        {
            Username = "johndoe",
            Surname = "Doe",
            Name = "John",
            Email = "johndoe@example.com",
            Password = "password123",
            Created = DateTime.Now
        };

        Session result = authController.Register(existingUser);

        Assert.IsNotNull(result);
        Assert.AreEqual("User already exists", result.Error);
    }
}