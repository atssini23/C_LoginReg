using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using YourNamespace.Models;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        public IActionResult Index(User user) 
        {
            System.Console.WriteLine(User);
            if (ModelState.IsValid)
            { 
               DbConnector.Execute($"INSERT INTO Users (FirstName, LastName, Email, Password, CreatedAt, UpdatedAt) VALUES ('{user.FirstName}','{user.LastName}','{user.Email}','{user.Password}', NOW(), NOW())");
                return View("Result");
            } else{
               
                return View("Index");
            }
        }
        [HttpPost]
        [Route("/login")]
        public IActionResult Login(User user)
        {
            List<Dictionary<string, object>> dbuser = DbConnector.Query($"SELECT * FROM Users WHERE Email = '{user.Email}'");
            System.Console.WriteLine(dbuser);
            return View("Result");
        }


    }
}
