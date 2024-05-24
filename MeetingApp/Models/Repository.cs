using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApp.Models
{
    public static class Repository
    {
        private static List<UserInfo> _users = new();

        static Repository()
        {
            _users.Add(new UserInfo() { Id = 1, Name = "Enes", Email = "asd@sdf.com", Phone = "1565", WillAttend = true });
            _users.Add(new UserInfo() { Id = 2, Name = "Dilara", Email = "ada@sdf.com", Phone = "14214", WillAttend = true });
            _users.Add(new UserInfo() { Id = 3, Name = "Melda", Email = "dagaga@sdf.com", Phone = "1512", WillAttend = false });
            _users.Add(new UserInfo() { Id = 4, Name = "Emine", Email = "afggaf@sdf.com", Phone = "61524", WillAttend = true });
        }

        public static List<UserInfo> Users
        {
            get
            {
                return _users;
            }
        }


        public static void CreateUser(UserInfo user)
        {

            user.Id = _users.Count + 1;
            _users.Add(user);
        }

        public static UserInfo? GetById(int id)
        {
            return _users.FirstOrDefault(u=>u.Id==id);
        }
    }
}