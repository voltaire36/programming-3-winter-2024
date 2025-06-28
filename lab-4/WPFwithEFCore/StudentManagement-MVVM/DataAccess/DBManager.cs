using Microsoft.EntityFrameworkCore;
using SMSLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace StudentManagement_MVVM.DataAccess
{
   public class DBManager
    {
        public SmsContext dbContext;

       

        public DBManager()
        {
            dbContext=new SmsContext();
        }


        public ObservableCollection<Course> GetCourses()
        {
            ObservableCollection<Course> courses = new ObservableCollection<Course>();

            var result=dbContext.Courses.ToList();

            foreach (var course in result) 
            {
                courses.Add(course);
            }

            return courses;
        }

        public void DeleteCourse(Course SelectedCourse)
        {
            dbContext.Courses.Where(course => course.CourseCode == SelectedCourse.CourseCode).ExecuteDelete();

            dbContext.SaveChanges();
        }

    }
}
