﻿using Microsoft.AspNetCore.Http;
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
    public class RegistrationController : ControllerBase
    {
        private readonly OnlineExamContext db;

        public RegistrationController(OnlineExamContext context)
        {
            db = context;
        }

        [HttpGet]

        public IActionResult Result()
        {
            var reg = db.Registrations.ToList();
            try
            {

                if (reg != null)
                {
                    return Ok(reg);
                }
                else
                {
                    return BadRequest("Record Not Found");
                }
            }
            catch (Exception e)
            {
                return Ok("Try Again");
            }
        }



        [HttpPost]

        public IActionResult Result(Registration registration)
        {
            try
            {
                if (registration == null)
                {
                    return BadRequest("Data Not Inserted");


                }
                else
                {
                    db.Registrations.Add(registration);
                    db.SaveChanges();

                    return Ok("Data Inserted");
                }
            }
            catch (Exception e)
            {
                return Ok("Email already Exist");
            }
        }


        //Login credential for user

        [HttpPost("UserLogin")]

        public IActionResult Login(UserLogin user)
        {
            var useravailable = db.Registrations.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            if(useravailable!=null)
            {
                return Ok("Success");
            }

            return Ok("Failure");
        }
    }
}
