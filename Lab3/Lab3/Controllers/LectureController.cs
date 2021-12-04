using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Models;

namespace Lab3.Controllers
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
            try
            {
                _courseDBContext.Add(lecture);
                return _courseDBContext.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Update(Lecture updatedLecture)
        {
            try
            {
                _courseDBContext.Update(updatedLecture);
                return _courseDBContext.SaveChanges();
            }
            catch
            {
                return -1;
            }
        }

        public Lecture GetLecture(int id)
        {
            return _courseDBContext.Lectures.Find(id);
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
                return _courseDBContext.SaveChanges();
            }
            catch
            {
                return -1;
            }
        }
    }
}
