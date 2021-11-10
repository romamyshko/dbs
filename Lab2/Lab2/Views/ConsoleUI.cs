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
                Console.WriteLine("Choose working option:\r\n[1] search in the database\r\n[2] make changes in the database");

                string entered = Console.ReadLine();
                int option;

                bool isInt = int.TryParse(entered, out option);

                if (!isInt)
                    continue;


                switch (option)
                {
                    case 1:
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }
            }
        }

        private void RunSearch()
        {
            
        }

        private void RunMakingChanges()
        {
            Console.WriteLine("Choose table:");
        }
    }
}
