using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaSprzetu.Services
{
    public class PenaltyCalculator
    {
        private const decimal DailyPenaltyRate = 5.0m;

        public decimal CalculatePenalty(DateTime rentReturnDate)
        {
            if (DateTime.Now <= rentReturnDate)
            {
                return 0;
            }
            int daysLate = (DateTime.Now - rentReturnDate).Days;
            return daysLate * DailyPenaltyRate;
        }
    }
}
