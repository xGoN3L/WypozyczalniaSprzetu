using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaSprzetu.Models.Users
{
    public class Student : User
    {
        public Student(string firstName, string lastName) : base(firstName, lastName)
        {
        }
    }
}
