using ExamSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAnswerController : ControllerBase
    {
        private readonly OnlineExamContext db;


        public StudentAnswerController(OnlineExamContext context)
        {
            db = context;
        }



        [HttpGet]

        public IActionResult getAns()
        {
            try { 
            var ans = db.StudentAnswers.ToList();

            if(ans!=null)
            {
                    db.SaveChanges();
                    return Ok(ans);
            }
                else
                {
                    return Ok("Try Again"); 
                }
            }catch(Exception e)
            {
                return Ok("Ok");
            }

        }


        [HttpPost]

        public IActionResult SetRecord(List<AnsCheck> s)
        {

            //foreach(var i in s)
           // {
             //var result = (from q in db.QuestionDetails
                        //  where q.Question == s.Question
                        //  select q.Correctanswers);
            
           
                
            //}
         


              AnsCheck ans = new AnsCheck();

              
              List<AnsCheck> st = new List<AnsCheck>();

              try { 
             foreach(var result in s)
              {
                  st.Add(result);

              }
                  return Ok(st);
              }
              catch(Exception e)
              {
                  return Ok("Data Not Passed");
              }
            return Ok();
        }







    }
}
