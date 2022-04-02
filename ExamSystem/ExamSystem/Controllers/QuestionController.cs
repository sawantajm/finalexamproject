using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamSystem.Models;
namespace ExamSystem.Controllers
{
    [Route("api/AddQuestion")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly OnlineExamContext db;

        public QuestionController(OnlineExamContext context)
        {
            db = context;
        }


        [HttpGet]

        public IActionResult GetQuestion()
        {
            var que = db.QuestionDetails.ToList();

            if(que==null)
            {
                return Ok("Try again");
            }
            else
            {

                return Ok(que);
            }
        }






        [HttpPost]
        [Route("AddRoute")]
        public  IActionResult GetQuestion(QuestionDetail question)
        {

            if (question == null)
            {
                return BadRequest("Data Not Inserted");


            }
            else
            {
                db.QuestionDetails.Add(question);
                db.SaveChanges();

                return Ok("Data Inserted");
            }











        }

       



    }
}
