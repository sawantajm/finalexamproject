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
    public class UserReportController : ControllerBase
    {
        public readonly OnlineExamContext db;

        public UserReportController(OnlineExamContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult GetReport()

        {
            return Ok(db.ReportDetails.ToList());
        }


        [HttpGet("userid")]

        public IActionResult GetReport(int userid)
        {
            try
            {
                var report = (from r in db.ReportDetails
                              join
                               l in db.Levels on r.LevelId equals l.LevelId
                              join s in db.Subjects on r.SubjectId equals s.SubjectId
                              where r.UserId == userid
                              select new
                              {
                                  Subject = s.SubjectName,
                                  Level = l.LevelName,
                                  MarksObtain = r.MarksObtained

                              }).ToList();

                if (report!=null)
                {
                    return Ok(report);
                }
                else
                {
                    return Ok("Record not Found");
                }
            }catch(Exception e)
            {
                return Ok("Try Afetr Some time");
            }
        }

    }
}
