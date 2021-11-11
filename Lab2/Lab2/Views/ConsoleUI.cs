using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Models;
using Microsoft.Extensions.Options;

namespace Lab2.Views
{
    public class ConsoleUI
    {
        private readonly CourseDBContext _courseDBContext;
        private readonly DbConnectionInfo _dbConnectionInfo;

        public ConsoleUI(string databaseConnection)
        {
            _dbConnectionInfo = new DbConnectionInfo();
            _dbConnectionInfo.CourseDBContext = databaseConnection;
            _courseDBContext = new CourseDBContext(_dbConnectionInfo);
        }

        // need to add controllers

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

                Console.WriteLine("Choose operation:\r\n[1] create\r\n[2] edit\r\n[3] delete\r\n\r\n write \"back\" to return to the main menu");

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

        private void CreateCourse()
        {

        }

        private void OperationsWithLectures()
        {

        }
    }
}
