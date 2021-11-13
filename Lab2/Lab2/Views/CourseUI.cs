using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Models;
using Lab2.Controllers;

namespace Lab2.Views
{
    internal class CourseUI
    {
        private CourseController _controller;

        public CourseUI(CourseController controller) => _controller = controller;

        internal void OperationsWithCourses()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose operation:\r\n[1] create\r\n[2] edit\r\n[3] delete\r\n\r\n write \"back\" to step back");

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
                catch
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

                if (_controller.Create(course) == 1)
                {
                    Console.WriteLine("Operation is successfull. Press any key to continue...");
                    if (Console.ReadKey().Equals(new ConsoleKeyInfo()))
                        return;
                }

                return;
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
                Console.Clear();
                Console.WriteLine("Enter course id");

                int courseId = ConsoleUI.GetIntInput();


            }
            
        }

        private void DeleteCourse()
        {

        }

    }
}
