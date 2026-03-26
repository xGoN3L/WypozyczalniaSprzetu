using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaSprzetu.Models.Users
{
    public class User
    {
        private static int _nextId = 1;
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }
        public User(string firstName, string lastName, UserType userType)
        {
            Id = _nextId++;
            FirstName = firstName;
            LastName = lastName;
            UserType = userType;
        }
    }
}
