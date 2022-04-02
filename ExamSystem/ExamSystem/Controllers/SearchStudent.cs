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
    public class SearchStudentController : ControllerBase
    {
        private readonly OnlineExamContext db;
        public SearchStudentController(OnlineExamContext context)
        {
            db = context;
        }

        [HttpPost]

        public IActionResult searchstudent(SearchStudent student)
        {
            try
            {
                var search = from u in db.Registrations
                             join r in db.ReportDetails on u.UserId equals r.UserId
                             join l in db.Levels on r.LevelId equals l.LevelId
                             join s
                             in db.Subjects on r.SubjectId equals s.SubjectId
                             where u.City == student.City && u.State == student.State && r.MarksObtained == student.MarksObtained 
                             && s.SubjectName == student.SubjectName && l.LevelName==student.LevelName
                             select new { Name = u.Fullname, Email = u.Email,
                                 mobile_No = u.MobileNo, city = u.City, state = u.State };
                return Ok(search);

            }
            catch (Exception e)
            {
                return Ok("Try Again");
            }
        }

        [HttpGet]
        public IActionResult getdata()
        {
            var repo = from u in db.Registrations
                       join r in db.ReportDetails on u.UserId equals r.UserId
                       join l in db.Levels on r.LevelId equals l.LevelId
                       join s
                       in db.Subjects on r.SubjectId equals s.SubjectId
                       select new { subjectname = s.SubjectName, state = u.State, city = u.City, marks = r.MarksObtained,Level=l.LevelName };
            return Ok(repo);
        }
    }
}
