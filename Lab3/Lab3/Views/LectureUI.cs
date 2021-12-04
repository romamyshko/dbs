using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Lab3.Models;
using Lab3.Controllers;

namespace Lab3.Views
{
    internal class LectureUI
    {
        private LectureController _controller;
        public int CurrCourseId { get; set; }
        public List<Lecture> lectures { get; set; }

        public LectureUI(LectureController controller) => _controller = controller;

        internal void OperationsWithLectures()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Choose operation [lecture of course [#{CurrCourseId}]]:\r\n[1] create\r\n[2] edit\r\n[3] delete\r\n\r\n write \"back\" to step back");

                try
                {
                    int option = ConsoleUI.GetIntInput();

                    switch (option)
                    {
                        case 1:
                            CreateLecture();
                            break;
                        case 2:
                            EditLecture();
                            break;
                        case 3:
                            DeleteLecture();
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
                    return;
                }
            }
        }

        internal void CreateLecture()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Write name of lecture\r\n\r\n write \"back\" to step back");

                string name = Console.ReadLine();
                if (name.Equals("back"))
                    break;

                Lecture lecture = new Lecture();
                lecture.Name = name;
                lecture.CourseId = CurrCourseId;

                if (_controller.Create(lecture) == 1)
                {
                    Console.WriteLine(lecture.ToString()+"\r\n"+"Press any key to continue...");
                    if (Console.ReadKey().Equals(new ConsoleKeyInfo()))
                        return;
                }

                return;
            }
        }

        private void PrintLectures()
        {
            foreach(var lecture in lectures)
            {
                Console.WriteLine(lecture);
            }
        }

        internal void EditLecture()
        {
            while (true)
            {
                Console.Clear();

                try
                { 
                    PrintLectures(); 
                }
                catch
                {
                    Console.WriteLine("Error printing lectures");
                    Thread.Sleep(4000);
                }
                 
                int lectureId = -1;
                try
                {
                    lectureId = GetLectureId();
                }
                catch
                {
                    return;
                }

                if (lectureId == -1)
                    continue;

                Lecture lecture = _controller.GetLecture(lectureId);

                if (lecture == null)
                {
                    Console.WriteLine("Lecture was not found");
                    Thread.Sleep(1000);
                    continue;
                }

                Console.WriteLine("Lecture by Id #{0}, name: {1}, courseId: {2}", lecture.LectureId, lecture.Name, lecture.CourseId);
                Console.WriteLine("\r\nWrite new name");
                string enteredData = Console.ReadLine();

                try
                {
                    lecture.Name = enteredData;
                    
                    if (_controller.Update(lecture) == 1)
                    {
                        Console.WriteLine("Operation is successfull. Press any key to continue...");
                        if (Console.ReadKey().Equals(new ConsoleKeyInfo()))
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

        private void DeleteLecture()
        {
            while (true)
            {
                int courseId = -1;
                try
                {
                    courseId = GetLectureId();
                }
                catch
                {
                    return;
                }

                if (courseId == -1)
                    continue;
                try
                {
                    if (_controller.Delete(courseId) == 1)
                    {
                        Console.WriteLine("Operation is successfull. Press any key to continue...");
                        if (Console.ReadKey().Equals(new ConsoleKeyInfo()))
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

        private int GetLectureId()
        {
            
            Console.WriteLine("Enter lecture id\r\n\r\n write \"back\" to step back");

            int lectureId  = -1;

            try
            {
                lectureId = ConsoleUI.GetIntInput();
            }
            catch (ArgumentException)
            {
                return lectureId;
            }

            return lectureId;
        }
    }
}
