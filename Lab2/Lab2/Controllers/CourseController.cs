using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2.Models;
using System.Threading.Tasks;

namespace Lab2.Controllers
{
    public class CourseController
    {
        private readonly CourseDBContext _courseDBContext;

        public CourseController(CourseDBContext courseDBContext)
        {
            _courseDBContext = courseDBContext;
        }

        public int Create(Course course)
        {
            int result = 0;

            try
            {
                _courseDBContext.Add(course);

                result = 1;
            }
            catch (Exception)
            {
                return -1;
            }
            _courseDBContext.SaveChanges();

            return result;
        }

        public int Update(Course updatedCourse)
        {
            try
            {
                _courseDBContext.Update(updatedCourse);
                 return _courseDBContext.SaveChanges();
            }
            catch
            {
                return -1;
            }
        }

        public Course GetCourse(int id)
        {
            return _courseDBContext.Courses.Find(id);
        }

        public int Delete(int? id)
        {
            if (id == null)
            {
                return 0;
            }

            try
            {
                Course course = _courseDBContext.Courses.Find(id);
                _courseDBContext.Courses.Remove(course);
                _courseDBContext.SaveChanges();
            }
            catch
            {
                return -1;
            }

            return 1;
        }
    }
}
