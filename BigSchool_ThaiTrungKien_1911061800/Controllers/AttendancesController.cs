using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigSchool_ThaiTrungKien_1911061800.Models;
using Microsoft.AspNet.Identity;

namespace BigSchool_ThaiTrungKien_1911061800.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDBContext _dbContext;

        public AttendancesController()
        {
            _dbContext = new ApplicationDBContext();
        }

        [HttpPost]
        public IHttpActionResult Attend([FromBody] int courseId)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == courseId))
                return BadRequest("the attendance already exists");
            var attendance = new Attendance
            {
                CourseId = courseId,
                AttendeeId = userId
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
