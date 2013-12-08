using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.ViewModels
{
    public class LinqToObjectViewModel
    {
        public LinqToObjectViewModel()
        {
            School = new Models.School();
            CourseStatCollection = new List<CourseStat>();
            StudentStatCollection = new List<StudentStat>();
        }

        public Models.School School;

        /// <summary>所有課程資料統計</summary>
        public List<CourseStat> CourseStatCollection { get; set; }
        /// <summary>所有學生成績統計</summary>
        public List<StudentStat> StudentStatCollection { get; set; }

        /// <summary>課程資料統計</summary>
        public class CourseStat
        {
            /// <summary>課程名稱</summary>
            public string CourseName { get; set; }
            /// <summary>修課人數</summary>
            public int StudentCount { get; set; }
            /// <summary>課程平均成績</summary>
            public decimal AverageGrade { get; set; }
            /// <summary>課程最高成績</summary>
            public int MaxGrade { get; set; }
            /// <summary>課程最低成績</summary>
            public int MinGrade { get; set; }
            /// <summary>及格的學生人數</summary>
            public int StudentPassCount { get; set; }
        }

        /// <summary>學生成績統計</summary>
        public class StudentStat
        {
            /// <summary>學生姓名</summary>
            public string StudentName { get; set; }
            /// <summary>平均成績</summary>
            public decimal AverageGrade { get; set; }
            /// <summary>最高得分</summary>
            public int MaxGrade { get; set; }
            /// <summary>最低得分</summary>
            public int MinGrade { get; set; }
            /// <summary>修課數</summary>
            public int CourseCount { get; set; }
            /// <summary>修課及格數</summary>
            public int CoursePassCount { get; set; }
        }
    }
}