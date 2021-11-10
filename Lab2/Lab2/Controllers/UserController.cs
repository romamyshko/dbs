using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Models;
using Microsoft.Extensions.Options;

namespace Lab2.Controllers
{
    public class UserController
    { 
        private readonly CourseDBContext _courseDBContext;

        public UserController(CourseDBContext courseDBContext)
        {
            _courseDBContext = courseDBContext;
        }

        public int Create(User user)
        {
            int result = 0;

            try
            {
                _courseDBContext.Add(user);
                
                result = 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Creating error!");
                return -1;
            }
            _courseDBContext.SaveChanges();
            return result;
        }

        public void Update(User updatedUser)
        {
            try
            {
                _courseDBContext.Update(updatedUser);
                _courseDBContext.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Updating error!");
            }
        }

        public int Delete(int? id)
        {
            if (id == null)
            {
                return 0;
            }

            try
            {
                User user = _courseDBContext.Users.Find(id);
                _courseDBContext.Users.Remove(user);
                _courseDBContext.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Deleting error!");
            }

            return 1;
        }
    }
}
