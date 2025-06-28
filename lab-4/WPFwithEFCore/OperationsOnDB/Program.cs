using Microsoft.EntityFrameworkCore;
using SMSLibrary.Model;
using System.Collections.Generic;

namespace OperationsOnDB
{

    internal class Program
    {

        private static SmsContext dbContext = new SmsContext();
        static async Task Main(string[] args)
        {
            //await InsertMultipleCourses();

            //RetriveCourses();
            //await DeleteCourse();
            // RetriveCourses();

           // QueryFilters();

            //await InsertNewCourseWithManyEnrollments();

            //RetriveCourses();

           // AggregrationMethod();

            // await RetrieveAndUpdateMultipleCourses();
            //Console.WriteLine("Courses after certain courses removed ");
            //  RetriveCourses();

        
           // ProjectMultipleProperties();
           // GetCourseWithStudents();
            InsertNewCourseWithExistingStudents();
            //  FilterWithRelatedData();

            //await RemoveJoinBetweenCourseAndStudent();

          //  QueryUseRawSqlWithInterpoliation();

            Console.ReadKey();
        }


        private static void RetriveCourses()
        {
            dbContext.Courses.Load();

            var query = (from c in dbContext.Courses.Local
                         select c).ToList();

            Console.WriteLine($"Course Code \t\t Course Title");
            foreach (var course in query)
                Console.WriteLine($"{course.CourseCode} \t\t {course.CourseTitle}");
        }

        private async static Task RetrieveAndUpdateCourse()
        {
            var course = dbContext.Courses.FirstOrDefault();
            course.CourseTitle += " updated";

            dbContext.Courses.Update(course);
            await dbContext.SaveChangesAsync();
        }

        private async static Task RetrieveAndUpdateMultipleCourses()
        {
            var courses = dbContext.Courses.Skip(1).Take(3).ToList();
            courses.ForEach(course => course.CourseTitle += " updated");

            dbContext.UpdateRange(courses);
            await dbContext.SaveChangesAsync();
        }

        private async static Task DeleteCourse()
        {
            var courses = dbContext.Courses.Where(c => c.CourseCode.StartsWith("ECEP")).ExecuteDelete();

          //  dbContext.Courses.RemoveRange(courses);
            await dbContext.SaveChangesAsync();
        }

        private async static Task InsertMultipleCourses()
        {

            var course1 = new Course { CourseCode = "COMP254", CourseTitle = "Data Structures & Algorithms", TotalCourseHours = 56, School = "SETAS", Department = "ICET" };
            var course2 = new Course { CourseCode = "FNN-111", CourseTitle = "Nutrition for Nursing Practice", TotalCourseHours = 56, School = "SCHS", Department = "Health&Wellness" };
            var course3 = new Course { CourseCode = "ECEP-104", CourseTitle = "An Introduction to Early Childhood Education", TotalCourseHours = 56, School = "SCHS", Department = "Health&Wellness" };
            var course4 = new Course { CourseCode = "BAKE-105", CourseTitle = "Baking and Pastry Arts Skills I", TotalCourseHours = 56, School = "SHTCA", Department = "Food&Toursim" };
            //var course5 = new Course { CourseCode = "COMP367", CourseTitle = "DevOps Implementation", TotalCourseHours = 42, School = "SETAS", Department = "ICET" };
            dbContext.Courses.AddRange(course1, course2, course3, course4);
            await dbContext.SaveChangesAsync();
        }

        private async static Task Insert2VariousTable()
        {
            var course1 = new Course { CourseCode = "ECEP-103", CourseTitle = "The Healthy Development of the Whole Child", TotalCourseHours = 56, School = "SCHS", Department = "Health&Wellness" };
            var course2 = new Course { CourseCode = "COOK-101", CourseTitle = "Principles of Nutrition", TotalCourseHours = 56, School = "SHTCA", Department = "Food&Toursim" };
            var student1 = new Student { StudentId = "300123456", FirstName = "Sarah", LastName = "Smiths", Program = "1221" };
            var student2 = new Student { StudentId = "300111122", FirstName = "Mary", LastName = "Jones", Program = "1221" };
            await dbContext.AddRangeAsync(course1, course2, student1, student2);
            await dbContext.SaveChangesAsync();
        }


        private static void QueryFilters()
        {
            var courseCode = "COMP254";
            var result1 = dbContext.Courses.Where(course => course.CourseCode == "COMP254").ToList();
            var result2 = dbContext.Courses.Where(course => course.CourseCode == courseCode).ToList();

            var filterKey = "Programming";
            var result3 = dbContext.Courses.Where(course => course.CourseTitle.Contains(filterKey));

            var result = dbContext.Courses.Where(
                         course => EF.Functions.Like(course.CourseTitle, "%Programming%")).ToList();

            Console.WriteLine($"Course Code \t\t Course Title");
            foreach (var course in result)
                Console.WriteLine($"{course.CourseCode} \t\t {course.CourseTitle}");
        }

        private static void AggregrationMethod()
        {
            var filterKey = "Programming";
            var result = dbContext.Courses.FirstOrDefault(course => course.CourseTitle.Contains(filterKey));
            var last = dbContext.Courses.OrderBy(course => course.CourseCode).LastOrDefault();

            if (result is not null) Console.WriteLine($"Result of FirstOrDefault {result.CourseCode} \t\t {result.CourseTitle} ");
            if (last is not null) Console.WriteLine($"Result of LastOrDefault {last.CourseCode} \t\t {last.CourseTitle} ");
        }

        private static void InsertNewCourseWithExistingStudents()
        {
            var student1 = dbContext.Students.FirstOrDefault(s => s.StudentId == "300111222");

            if (student1 != null)
            {
                student1.CourseCodes.Add(new Course
                {
                    CourseCode = "COMP-999",
                    CourseTitle = "Introduction to Artificial Intelligence",
                    Department = "ICET",
                    School = "SETAS",
                    TotalCourseHours = 56
                });
            }
            
            dbContext.SaveChanges();
        }



            private async static Task InsertEnrollments2ExistingCourse()
        {
            var course = dbContext.Courses.Find("COMP-237");
            course.Students.Add(new Student { StudentId = "300444555" });
            await dbContext.SaveChangesAsync();
        }



        private static void ProjectMultipleProperties()
        {
            // projecting an undefined "anonymous" type
            var course = dbContext.Courses.Select(c => new
            {
                c.CourseCode,
                c.CourseTitle,
            });

            foreach (var c in course)
            {
                Console.WriteLine($"{c.CourseCode} \t\t {c.CourseTitle} ");

            }


        }


        private static void FilterWithRelatedData()
        {
            var courses = dbContext.Courses.Include(c => c.Students)
                                 .Where(c => c.Students.Count >= 2)
                                 .ToList();

            foreach (var c in courses)
            {
                Console.WriteLine($"{c.CourseCode} \t\t {c.CourseTitle} \t\t {c.Students.Count}");

            }
        }

        //private async static Task RemoveRelatedData()
        //{
        //    var course = dbContext.Courses.Include(c => c.Enrollments)
        //                                 .FirstOrDefault(c => c.CourseTitle.Contains("Programming"));

        //    var e = course.Enrollments.FirstOrDefault();
        //    course.Enrollments.Remove(e);
        //    await dbContext.SaveChangesAsync();
        //}

        private async static Task RemoveJoinBetweenCourseAndStudent()
        {
            var e = new { StudentId = "300111222", CourseCode = "COMP212" };
            dbContext.Remove(e);
            await dbContext.SaveChangesAsync();
        }



        private static void GetCourseWithStudents()
        {
            var coursewithStudents = dbContext.Courses
                                            .Include(c => c.Students)
                                            .FirstOrDefault(course => course.CourseCode.Equals("COMP306"));

            var coursewithStudent2 = dbContext.Courses.Where(c => c.CourseCode.Equals("COMP306"))
                                                     .Select(s => new
                                                     {
                                                         course = s,
                                                         students = s.Students.Select(e => e.CourseCodes.Equals("COMP306"))
                                                     })
                                                     .FirstOrDefault();
        }


        private static void QueryUseRawSqlWithInterpoliation()
        {
            string courseCode = "COMP212";
            var course = dbContext.Courses
                                .FromSqlInterpolated($"select * from course where courseCode={courseCode}")
                                .ToList();
        }

    }
}
