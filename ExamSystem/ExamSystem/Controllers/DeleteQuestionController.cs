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
    public class DeleteQuestionController : ControllerBase
    {
        private readonly OnlineExamContext db;

        public DeleteQuestionController(OnlineExamContext context)
        {
            db = context;
        }

        [HttpGet]

        public IActionResult GetData()
        {
            try
            {
                var que = (from q in db.QuestionDetails
                           join
                            l in db.Levels on
                            q.LevelId equals l.LevelId
                           join s in db.Subjects on q.SubjectId equals
                           s.SubjectId
                           select new
                           {
                               Level = l.LevelName,
                               Subject = s.SubjectName,
                               Question = q.Question,
                               option1 = q.Option1,
                               option2 = q.Option2,
                               option3 = q.Option3,
                               option4 = q.Option4,
                               correctanswers = q.Correctanswers,
                               QuestionId = q.QuestionId

                           });
                return Ok(que);
            }
            catch (Exception e)
            {
                return Ok("Try Again");
            }


        }


        //delete Record

        [HttpDelete("{question_id}")]

        public IActionResult DeleteData(int question_id)
        {
            try
            {

                var que = db.QuestionDetails.Find(question_id);

                if (que != null)
                {
                    db.QuestionDetails.Remove(que);
                    db.SaveChanges();
                    return Ok("record Deleted");
                }
                else
                {
                    return BadRequest("Record Not Found");
                }
            }
            catch (Exception e)
            {
                return Ok("try again");
            }
        }

    }
}
