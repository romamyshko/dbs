using System;
using Lab2.Models;
using Lab2.Views;
using Lab2.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string databaseConnection = "Server=127.0.0.1;Port=5432;Database=student01_DB;User Id=postgres;Password=1;Include Error Detail=True";

            Run(databaseConnection);
        }

        static void Run(string databaseConnection)
        {
            CourseDBContext _courseDBContext;
            DbConnectionInfo _dbConnectionInfo = new DbConnectionInfo();

            _dbConnectionInfo.CourseDBContext = databaseConnection;
            _courseDBContext = new CourseDBContext(_dbConnectionInfo);

            ConsoleUI console = new ConsoleUI(databaseConnection);
            console.Run();
        }
    }
}
