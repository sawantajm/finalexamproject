using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamSystem.Models;
namespace ExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly OnlineExamContext db;

        public AdminController(OnlineExamContext context)
        {
            db = context;
        }


        //Admin Login 

        [HttpPost("AdminLogin")]
        public IActionResult Admin(AdminLogin user)
        {

            var u = db.AdminLogins.Where(t => t.Email == user.Email && t.Password == user.Password).FirstOrDefault();
            if (u != null)
            {

                return Ok("Login Succesfully");
            }
            else
            {
                return Unauthorized("Invalid");
            }

     }
        
}
}
