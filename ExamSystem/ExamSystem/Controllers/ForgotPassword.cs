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
    public class ForgotPassword : ControllerBase
    {
        private readonly OnlineExamContext db;


        public ForgotPassword(OnlineExamContext context)
        {
            db = context;
        }



        [HttpGet]
        [Route("Registration/{Email}")]

        public IActionResult getpass(string Email)

        {
            
            
                var data = db.Registrations.Where(d => d.Email == Email);
            try
            {
                if (data == null)
                {
                    return BadRequest($"report {Email} not found !");

                }
               
                else 
                {
                    return Ok(data);
                }
                

            }catch(Exception e)
            {
                return Ok("Email not found");
            }
        }


        [HttpPut]
        [Route("passedit/{Email}")]
        public IActionResult EditPassbymail(string Email, [FromBody] Registration resetPass)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Registration oresetpass = db.Registrations.Find(Email);
                    oresetpass.Password = resetPass.Password;

                    db.SaveChanges();
                    return Ok("Record Edited");
                }
                return BadRequest("Something went Wrong");

            }catch(Exception e)
            {
                return Ok();
            }
        }











    }
}
