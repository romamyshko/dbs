using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Models;

namespace Lab2.Controllers
{
    public class LectureController
    {
        private readonly CourseDBContext _courseDBContext;

        public LectureController(CourseDBContext courseDBContext)
        {
            _courseDBContext = courseDBContext;
        }

        public int Create(Lecture lecture)
        {
            int result = 0;

            try
            {
                _courseDBContext.Add(lecture);

                result = 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Creating error!");
                return -1;
            }
            _courseDBContext.SaveChanges();

            return result;
        }

        public void Update(Lecture updatedLecture)
        {
            try
            {
                _courseDBContext.Update(updatedLecture);
                _courseDBContext.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Updating error!");
            }
        }

        public int Delete(int? id)
        {
            if (id == null)
            {
                return 0;
            }

            try
            {
                Lecture lecture = _courseDBContext.Lectures.Find(id);
                _courseDBContext.Lectures.Remove(lecture);
                _courseDBContext.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Deleting error!");
            }

            return 1;
        }
    }
}
