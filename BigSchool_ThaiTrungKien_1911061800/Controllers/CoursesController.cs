using BigSchool_ThaiTrungKien_1911061800.Models;
using BigSchool_ThaiTrungKien_1911061800.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool_ThaiTrungKien_1911061800.Controllers
{
    public class CoursesController : Controller
    {

        // GET: Course
        private readonly ApplicationDBContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDBContext();
        }
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);  
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place,
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        
        
    }
}