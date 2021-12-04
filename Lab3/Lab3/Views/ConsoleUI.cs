using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Models;
using Lab3.Controllers;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Lab3.Views
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
            _courseUI = new CourseUI(_courseController, _lectureController, _courseDBContext);
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose working option:\r\n[1] filter data in the database\r\n[2] make changes in the database\r\n\r\nwrite \"exit\" to exit the program");

                try
                {
                    int option = GetIntInput();

                    switch (option)
                    {
                        case 1:
                            RunFilter();
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

        private void RunMakingChanges()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose table:\r\n[1] courses\r\n\r\n write \"back\" to return to the main menu");

                try
                {
                    int option = GetIntInput();

                    switch (option)
                    {
                        case 1:
                            _courseUI.OperationsWithCourses();
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

        private void RunFilter()
        {
            Console.Clear();

            Console.WriteLine("Filtering the course table by created day, cost and name");

            DateTime fromTime, toTime;

            try
            {
                (fromTime, toTime) = GetTimeSpanCreationCourses();

            }
            catch
            {
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            stopwatch.Start();
            _courseDBContext.Courses.Where(course => course.Name.Contains("a") && 
                                           course.Cost < 50 && course.CreatedAt >= fromTime 
                                           && course.CreatedAt <= toTime);
            stopwatch.Stop();

            Console.WriteLine($"Elapsed Time is {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine("Press any key to continue...");
            if (Console.ReadLine() != "")
                return;
        }

        private (DateTime fromTime, DateTime toTime) GetTimeSpanCreationCourses()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Write creation date in such format: 31/12/2020-28/02/2022\r\n write \"back\" to return back");

                string[] entered = Console.ReadLine().Split('-');

                if (entered[0].Equals("back"))
                    throw new Exception();
                    
                DateTime fromTime, toTime;
                try
                {
                    fromTime = DateTime.Parse(entered[0]);
                    toTime = DateTime.Parse(entered[1]);
                }
                catch 
                {
                    continue;
                }

                return (fromTime, toTime);
            }
        }
    }
}
