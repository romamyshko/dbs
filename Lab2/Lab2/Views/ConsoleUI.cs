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
        private readonly CourseUI _courseUI;

        public ConsoleUI(string databaseConnection)
        {
            _dbConnectionInfo = new DbConnectionInfo();
            _dbConnectionInfo.CourseDBContext = databaseConnection;
            _courseDBContext = new CourseDBContext(_dbConnectionInfo);
            _courseController = new CourseController(_courseDBContext);
            _lectureController = new LectureController(_courseDBContext);
            _courseUI = new CourseUI(_courseController);
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose working option:\r\n[1] search in the database\r\n[2] make changes in the database\r\n\r\nwrite \"exit\" to exit the program");

                try
                {
                    int option = GetIntInput();

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

        internal static int GetIntInput()
        {
            string entered = Console.ReadLine();

            if (entered.Equals("exit"))
            {
                Console.WriteLine("Ending session...");
                Environment.Exit(0);
            }
            else if (entered.Equals("back"))
            {
                throw new Exception();
            }

            int option;
            bool isInt = int.TryParse(entered, out option);

            if (!isInt)
            {
                Console.Clear();
                throw new ArgumentException(entered);
            }

            return option;
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

                try
                {
                    int option = GetIntInput();

                    switch (option)
                    {
                        case 1:
                            _courseUI.OperationsWithCourses();
                            break;
                        case 2:
                            OperationsWithLectures();
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

        

        private void OperationsWithLectures()
        {

        }
    }
}
