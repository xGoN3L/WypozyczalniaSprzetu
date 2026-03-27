using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaSprzetu.Models.Users
{
    public class Employee : User
    {
        public Employee(string firstName, string lastName) : base(firstName, lastName)
        {
        }
    }
}
