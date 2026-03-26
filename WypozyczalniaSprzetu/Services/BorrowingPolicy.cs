using System;
using WypozyczalniaSprzetu.Models.Users;

public class BorrowingPolicy
{
    public int GetMaxActiveRentals(User user)
    {
        if (user.UserType == UserType.Student)
        {
            return 2;
        }
        else
        {
            return 5;
        }
    }
}
