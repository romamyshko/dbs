using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Models;
using Lab2.Controllers;
using Microsoft.Extensions.Options;

namespace Lab2.Views
{
    public class ConsoleUI
    {
        private readonly CourseDBContext _courseDBContext;
        private readonly DbConnectionInfo _dbConnectionInfo;
        private readonly CourseController _courseController;
        private readonly LectureController _lectureController;

        public ConsoleUI(string databaseConnection)
        {
            _dbConnectionInfo = new DbConnectionInfo();
            _dbConnectionInfo.CourseDBContext = databaseConnection;
            _courseDBContext = new CourseDBContext(_dbConnectionInfo);
            _courseController = new CourseController(_courseDBContext);
            _lectureController = new LectureController(_courseDBContext);
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Choose working option:\r\n[1] search in the database\r\n[2] make changes in the database\r\n\r\nwrite \"exit\" to exit the program");

                string entered = Console.ReadLine();

                if (entered.Equals("exit"))
                {
                    Console.WriteLine("Ending session...");
                    break;
                }
                    
                int option;

                bool isInt = int.TryParse(entered, out option);

                if (!isInt)
                {
                    Console.Clear();
                    continue;
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine();
                        break;
                    case 2:
                        RunMakingChanges();
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }
        }

        private void RunSearch()
        {
            Console.Clear();
        }

        private void RunMakingChanges()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Choose table:\r\n[1] courses\r\n[2] lectures\r\n\r\n write \"back\" to return to the main menu");

                string entered = Console.ReadLine();

                if (entered.Equals("back"))
                    break;
                

                int option;

                bool isInt = int.TryParse(entered, out option);

                if (!isInt)
                {
                    Console.Clear();
                    continue;
                }

                switch (option)
                {
                    case 1:
                        OperationsWithCourses();
                        break;
                    case 2:
                        OperationsWithLectures();
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }
        }

        private void OperationsWithCourses()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Choose operation:\r\n[1] create\r\n[2] edit\r\n[3] delete\r\n\r\n write \"back\" to step back");

                string entered = Console.ReadLine();

                if (entered.Equals("back"))
                    break;


                int option;

                bool isInt = int.TryParse(entered, out option);

                if (!isInt)
                {
                    Console.Clear();
                    continue;
                }

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

                Console.Clear();
            }
        }

        private void CreateCourse()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Write name of course\r\n\r\n write \"back\" to step back");

                Course course = new Course();   
                string name = Console.ReadLine();

                if (name.Equals("back"))
                    break;

                course.Name = name;

                string cost;
                int intCost = -1;

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("Write cost of course\r\n\r\n write \"back\" to step back");

                    cost = Console.ReadLine();

                    if (cost.Equals("back"))
                        break;

                    bool isInt = int.TryParse(cost, out intCost);

                    if (!isInt)
                    {
                        Console.Clear();
                        continue;
                    }

                    break;
                }

                if (intCost == -1)
                    break;

                course.Cost = intCost;
                course.CreatedAt = DateTime.Now;

                

                if (_courseController.Create(course) == 1)
                {
                    Console.WriteLine("Operation is successfull. Press any key to continue...");
                    if (Console.ReadLine() != "")
                        return;
                }


                return;
            }
        }

        private void EditCourse()
        {

        }

        private void DeleteCourse()
        {

        }

        private void OperationsWithLectures()
        {

        }
    }
}
