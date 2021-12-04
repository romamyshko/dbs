using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Lab3.Models;
using Lab3.Controllers;

namespace Lab3.Views
{
    internal class CourseUI
    {
        private readonly CourseController _courseController;
        private readonly LectureController _lectureController;
        private readonly CourseDBContext _dbContext;

        public CourseUI(CourseController courseController, LectureController lectureController, CourseDBContext courseDBContext)
        {
            _courseController = courseController;
            _lectureController = lectureController;
            _dbContext = courseDBContext;
        }

        internal void OperationsWithCourses()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose operation [course]:\r\n[1] create\r\n[2] edit\r\n[3] delete\r\n\r\n write \"back\" to step back");

                try
                {
                    int option = ConsoleUI.GetIntInput();

                    switch (option)
                    {
                        case 1:
                            CreateCourse();
                            break;
                        case 2:
                            EditCourse();
                            break;
                        case 3:
                            DeleteCourse();
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException)
                {
                    continue;
                }
                catch (Exception)
                {
                    break;
                }
            }
        }

        private void CreateCourse()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Write name of course\r\n\r\n write \"back\" to step back");

                string name = Console.ReadLine();
                if (name.Equals("back"))
                    break;

                int intCost = -1;
                intCost = GetCost();

                if (intCost == -1)
                    break;

                Course course = new Course();
                course.Name = name;
                course.Cost = intCost;
                course.CreatedAt = DateTime.Now;

                if (_courseController.Create(course) == 1)
                {
                    Console.WriteLine("Course was added successfully. Do you want to add lectures? [y/n]");
                    string answer = Console.ReadLine();

                    if(answer.Equals("y"))
                    {
                        OpenCreateLectureUI(course.CourseId);
                    }
                    return;
                }

                return;
            }
        }

        private void OpenCreateLectureUI(int courseId)
        {
            LectureUI lectureUI = new LectureUI(_lectureController);
            lectureUI.CurrCourseId = courseId;
            lectureUI.CreateLecture();
            lectureUI.OperationsWithLectures();
        }

        private void OpenEditLectureUI(int courseId)
        {
            LectureUI lectureUI = new LectureUI(_lectureController);
            lectureUI.CurrCourseId = courseId;
            lectureUI.lectures = _dbContext.Lectures.Where(lecture => lecture.CourseId.Equals(courseId)).ToList<Lecture>();
            lectureUI.EditLecture();
            lectureUI.OperationsWithLectures();
        }

        private void ShowLectures(List<Lecture> lectures)
        {
            foreach (Lecture l in lectures)
            {
                Console.WriteLine(l);
            }
        }

        private int GetCost()
        {
            int cost = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Write cost of course\r\n\r\n write \"back\" to step back");

                try
                {
                    cost = ConsoleUI.GetIntInput();
                }
                catch (ArgumentException)
                {
                    continue;
                }
                catch (Exception)
                {
                    return -1;
                }

                if (cost < 0)
                    continue;

                break;
            }

            return cost;
        }

        private void EditCourse()
        {
            while (true)
            {
                int courseId = -1;
                try
                {
                    courseId = GetCourseId();
                }
                catch
                {
                    return;
                }

                if (courseId == -1)
                    continue;

                Course course = _courseController.GetCourse(courseId);

                if (course == null)
                {
                    Console.WriteLine("Course was not found");
                    Thread.Sleep(1000);
                    continue;
                }

                Console.WriteLine("Course by Id #{0}, name: {1}, cost: {2}, created at: {3}", course.CourseId, course.Name, course.Cost, course.CreatedAt);
                Console.WriteLine("\r\nWrite new name and new cost in such format\r\nnewName;cost");
                string[] enteredData = Console.ReadLine().Split(';');

                if (enteredData.Length != 2)
                    continue;
                try
                {
                    course.Name = enteredData[0];
                    course.Cost = int.Parse(enteredData[1]);
                    if (_courseController.Update(course) == 1)
                    {
                        Console.WriteLine("Course was edited successfully. Do you want to edit lectures? [y/n]");
                        string answer = Console.ReadLine();

                        if (answer.Equals("y"))
                        {
                            OpenEditLectureUI(course.CourseId);
                        }
                        return;
                    }
                }
                catch
                {
                    continue;
                }
                
                return;
            }
        }

        private void DeleteLectures(List<Lecture> lectures)
        {
            foreach (Lecture l in lectures)
            {
                _lectureController.Delete(l.LectureId);
            }
        }

        private void DeleteCourse()
        {
            while (true)
            {
                int courseId = -1;
                try
                {
                    courseId = GetCourseId();
                }
                catch
                {
                    return;
                }

                if (courseId == -1)
                    continue;
                try
                {
                    List<Lecture> lectures = _dbContext.Lectures.Where(lecture => lecture.CourseId.Equals(courseId)).ToList<Lecture>();

                    ShowLectures(lectures);

                    Console.WriteLine("Lectures will be deleted. Do you want to delete course? [y/n]");
                    string answer = Console.ReadLine();

                    if (answer.Equals("y"))
                    {
                        DeleteLectures(lectures);
                    }

                    if (_courseController.Delete(courseId) == 1)
                    {

                        Console.WriteLine("Operation is successfull. Press any key to continue...");
                        if (Console.ReadLine() != "")
                            return;
                    } 
                    else
                    {
                        Console.WriteLine("Course was not found");
                        Thread.Sleep(1000);
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Some error occur");
                    Thread.Sleep(1000);
                    return;
                }

                return;
            }
        }

        private int GetCourseId()
        {
            Console.Clear();
            Console.WriteLine("Enter course id\r\n\r\n write \"back\" to step back");

            int courseId = -1;

            try
            {
                courseId = ConsoleUI.GetIntInput();
            }
            catch (ArgumentException)
            {
                return courseId;
            }
            
            return courseId;
        }
    }
}