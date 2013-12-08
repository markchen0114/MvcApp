using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class LinqToObjectController : Controller
    {
        public ActionResult Index()
        {
            ViewModels.LinqToObjectViewModel linqToObjectViewModel = new ViewModels.LinqToObjectViewModel();
            return View(linqToObjectViewModel);
        }

        [HttpPost]
        public ActionResult Index(ViewModels.LinqToObjectViewModel linqToObjectViewModel, string act = "")
        {
            if (linqToObjectViewModel == null)
                linqToObjectViewModel = new ViewModels.LinqToObjectViewModel();
            switch (act.ToLower())
            {
                case "course":
                    linqToObjectViewModel.CourseStatCollection = (
                        from c in linqToObjectViewModel.School.CourseCollection
                        join g in linqToObjectViewModel.School.StudentCourseGradeCollection on c.CourseID equals g.CourseID
                        group g by new { c.CourseID, c.Name } into gb
                        select new ViewModels.LinqToObjectViewModel.CourseStat()
                        {
                            CourseName = gb.Key.Name,
                            StudentCount = gb.Count(),
                            AverageGrade = (decimal)gb.Average(a => a.Grade),
                            MaxGrade = gb.Max(m => m.Grade),
                            MinGrade = gb.Min(m => m.Grade),
                            StudentPassCount = gb.Where(w => w.Grade >= 60).Count()
                        }).ToList();
                    break;
                case "student":
                    linqToObjectViewModel.StudentStatCollection = (
                        from s in linqToObjectViewModel.School.StudentCollection
                        join g in linqToObjectViewModel.School.StudentCourseGradeCollection on s.StudentID equals g.StudentID
                        group g by new { s.StudentID, StudentName = s.Name } into gb
                        select new ViewModels.LinqToObjectViewModel.StudentStat()
                        {
                            StudentName = gb.Key.StudentName,
                            CourseCount = gb.Count(),
                            AverageGrade = (decimal)gb.Average(a => a.Grade),
                            MaxGrade = gb.Max(m => m.Grade),
                            MinGrade = gb.Min(m => m.Grade),
                            CoursePassCount = gb.Where(w => w.Grade >= 60).Count()
                        }).ToList();
                    break;
            }
            return View(linqToObjectViewModel);
        }
    }
}
