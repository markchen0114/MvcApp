using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    public class School
    {
        public School()
        {
            #region 課程資料
            CourseCollection = new List<Course>();
            Course newCourse = new Course();
            newCourse.CourseID = CourseCollection.Count();
            newCourse.Name = "計算機概論";
            newCourse.TeacherID = 0;
            CourseCollection.Add(newCourse);
            newCourse = new Course();
            newCourse.CourseID = CourseCollection.Count();
            newCourse.Name = "微積分";
            newCourse.TeacherID = 1;
            CourseCollection.Add(newCourse);
            newCourse = new Course();
            newCourse.CourseID = CourseCollection.Count();
            newCourse.Name = "程式設計";
            newCourse.TeacherID = 0;
            CourseCollection.Add(newCourse);
            newCourse = new Course();
            newCourse.CourseID = CourseCollection.Count();
            newCourse.Name = "統計學";
            newCourse.TeacherID = 2;
            CourseCollection.Add(newCourse);
            newCourse = new Course();
            newCourse.CourseID = CourseCollection.Count();
            newCourse.Name = "離散數學";
            newCourse.TeacherID = 1;
            CourseCollection.Add(newCourse);
            #endregion 課程資料

            #region 老師資料
            TeacherCollection = new List<Teacher>();
            Teacher newTeacher = new Teacher();
            newTeacher.TeacherID = TeacherCollection.Count();
            newTeacher.Name = "計算機老師";
            TeacherCollection.Add(newTeacher);
            newTeacher = new Teacher();
            newTeacher.TeacherID = TeacherCollection.Count();
            newTeacher.Name = "數學老師";
            TeacherCollection.Add(newTeacher);
            newTeacher = new Teacher();
            newTeacher.TeacherID = TeacherCollection.Count();
            newTeacher.Name = "統計學老師";
            TeacherCollection.Add(newTeacher);
            newTeacher = new Teacher();
            newTeacher.TeacherID = TeacherCollection.Count();
            newTeacher.Name = "歷史老師";
            TeacherCollection.Add(newTeacher);
            #endregion 老師資料

            #region 學生資料
            StudentCollection = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                Student newStudent = new Student();
                newStudent.StudentID = StudentCollection.Count();
                newStudent.Name = "學生" + StudentCollection.Count().ToString();
                StudentCollection.Add(newStudent);
            }
            #endregion 學生資料

            #region 學生課程得分資料
            StudentCourseGradeCollection = new List<StudentCourseGrade>();
            StudentCourseGrade newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 0;
            newStudentCourseGrade.CourseID = 0;
            newStudentCourseGrade.Grade = 80;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 0;
            newStudentCourseGrade.CourseID = 1;
            newStudentCourseGrade.Grade = 50;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 0;
            newStudentCourseGrade.CourseID = 2;
            newStudentCourseGrade.Grade = 70;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 0;
            newStudentCourseGrade.CourseID = 3;
            newStudentCourseGrade.Grade = 66;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 0;
            newStudentCourseGrade.CourseID = 4;
            newStudentCourseGrade.Grade = 68;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);

            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 1;
            newStudentCourseGrade.CourseID = 0;
            newStudentCourseGrade.Grade = 60;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 1;
            newStudentCourseGrade.CourseID = 1;
            newStudentCourseGrade.Grade = 80;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 1;
            newStudentCourseGrade.CourseID = 2;
            newStudentCourseGrade.Grade = 75;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 1;
            newStudentCourseGrade.CourseID = 3;
            newStudentCourseGrade.Grade = 73;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 1;
            newStudentCourseGrade.CourseID = 4;
            newStudentCourseGrade.Grade = 62;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);

            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 2;
            newStudentCourseGrade.CourseID = 0;
            newStudentCourseGrade.Grade = 67;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 2;
            newStudentCourseGrade.CourseID = 1;
            newStudentCourseGrade.Grade = 98;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 2;
            newStudentCourseGrade.CourseID = 2;
            newStudentCourseGrade.Grade = 88;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 2;
            newStudentCourseGrade.CourseID = 3;
            newStudentCourseGrade.Grade = 90;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 2;
            newStudentCourseGrade.CourseID = 4;
            newStudentCourseGrade.Grade = 76;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);

            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 3;
            newStudentCourseGrade.CourseID = 0;
            newStudentCourseGrade.Grade = 67;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 3;
            newStudentCourseGrade.CourseID = 1;
            newStudentCourseGrade.Grade = 61;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 3;
            newStudentCourseGrade.CourseID = 2;
            newStudentCourseGrade.Grade = 69;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 3;
            newStudentCourseGrade.CourseID = 3;
            newStudentCourseGrade.Grade = 70;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 3;
            newStudentCourseGrade.CourseID = 4;
            newStudentCourseGrade.Grade = 64;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);

            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 4;
            newStudentCourseGrade.CourseID = 0;
            newStudentCourseGrade.Grade = 71;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 4;
            newStudentCourseGrade.CourseID = 1;
            newStudentCourseGrade.Grade = 68;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 4;
            newStudentCourseGrade.CourseID = 2;
            newStudentCourseGrade.Grade = 79;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 4;
            newStudentCourseGrade.CourseID = 3;
            newStudentCourseGrade.Grade = 72;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 4;
            newStudentCourseGrade.CourseID = 4;
            newStudentCourseGrade.Grade = 62;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);

            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 5;
            newStudentCourseGrade.CourseID = 0;
            newStudentCourseGrade.Grade = 76;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 5;
            newStudentCourseGrade.CourseID = 1;
            newStudentCourseGrade.Grade = 58;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 5;
            newStudentCourseGrade.CourseID = 2;
            newStudentCourseGrade.Grade = 62;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 5;
            newStudentCourseGrade.CourseID = 3;
            newStudentCourseGrade.Grade = 74;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);

            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 6;
            newStudentCourseGrade.CourseID = 0;
            newStudentCourseGrade.Grade = 62;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 6;
            newStudentCourseGrade.CourseID = 1;
            newStudentCourseGrade.Grade = 60;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 6;
            newStudentCourseGrade.CourseID = 4;
            newStudentCourseGrade.Grade = 69;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);

            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 7;
            newStudentCourseGrade.CourseID = 0;
            newStudentCourseGrade.Grade = 82;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 7;
            newStudentCourseGrade.CourseID = 1;
            newStudentCourseGrade.Grade = 86;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 7;
            newStudentCourseGrade.CourseID = 2;
            newStudentCourseGrade.Grade = 87;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 7;
            newStudentCourseGrade.CourseID = 3;
            newStudentCourseGrade.Grade = 81;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 7;
            newStudentCourseGrade.CourseID = 4;
            newStudentCourseGrade.Grade = 89;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);

            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 8;
            newStudentCourseGrade.CourseID = 0;
            newStudentCourseGrade.Grade = 78;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 8;
            newStudentCourseGrade.CourseID = 1;
            newStudentCourseGrade.Grade = 76;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 8;
            newStudentCourseGrade.CourseID = 2;
            newStudentCourseGrade.Grade = 93;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 8;
            newStudentCourseGrade.CourseID = 3;
            newStudentCourseGrade.Grade = 73;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 8;
            newStudentCourseGrade.CourseID = 4;
            newStudentCourseGrade.Grade = 90;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);

            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 9;
            newStudentCourseGrade.CourseID = 0;
            newStudentCourseGrade.Grade = 66;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 9;
            newStudentCourseGrade.CourseID = 1;
            newStudentCourseGrade.Grade = 56;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 9;
            newStudentCourseGrade.CourseID = 2;
            newStudentCourseGrade.Grade = 62;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 9;
            newStudentCourseGrade.CourseID = 3;
            newStudentCourseGrade.Grade = 53;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            newStudentCourseGrade = new StudentCourseGrade();
            newStudentCourseGrade.StudentID = 9;
            newStudentCourseGrade.CourseID = 4;
            newStudentCourseGrade.Grade = 71;
            StudentCourseGradeCollection.Add(newStudentCourseGrade);
            #endregion 學生課程得分資料
        }

        /// <summary>開課資料</summary>
        public List<Course> CourseCollection;
        /// <summary>老師資料</summary>
        public List<Teacher> TeacherCollection;
        /// <summary>學生資料</summary>
        public List<Student> StudentCollection;
        /// <summary>學生課程得分資料</summary>
        public List<StudentCourseGrade> StudentCourseGradeCollection;

        #region 資料物件(取代資料庫) 課程/老師/學生/學生課程得分
        /// <summary>課程</summary>
        public class Course
        {
            /// <summary>課程代號</summary>
            [Display(Name = "課程代號")]
            public int CourseID;
            /// <summary>課程名稱</summary>
            [Display(Name = "課程名稱")]
            public string Name;
            /// <summary>授課老師代號</summary>
            [Display(Name = "授課老師代號")]
            public int TeacherID;
        }

        /// <summary>老師</summary>
        public class Teacher
        {
            /// <summary>老師代號</summary>
            [Display(Name = "老師代號")]
            public int TeacherID;
            /// <summary>老師姓名</summary>
            [Display(Name = "老師姓名")]
            public string Name;
        }

        /// <summary>學生</summary>
        public class Student
        {
            /// <summary>學生代號</summary>
            [Display(Name = "學生代號")]
            public int StudentID;
            /// <summary>學生姓名</summary>
            [Display(Name = "學生姓名")]
            public string Name;
        }

        /// <summary>學生課程得分</summary>
        public class StudentCourseGrade
        {
            /// <summary>學生代號</summary>
            [Display(Name = "學生代號")]
            public int StudentID;
            /// <summary>課程代號</summary>
            [Display(Name = "課程代號")]
            public int CourseID;
            /// <summary>課程得分</summary>
            [Display(Name = "課程得分")]
            public int Grade;
        }
        #endregion 資料物件(取代資料庫) 課程/老師/學生/學生課程得分
    }
}