using System;
using WypozyczalniaSprzetu.Models.Users;

namespace WypozyczalniaSprzetu.Services
{
    public class BorrowingPolicy
    {
        public int GetMaxActiveRentals(User user)
        {
            if (user is Student)
            {
                return 2;
            }
            else
            {
                return 5;
            }
        }
    }
}