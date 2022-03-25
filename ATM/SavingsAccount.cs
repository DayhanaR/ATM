using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class SavingsAccount : Account
    {
        public float InterestRate { get; set; }

        public override decimal GetBalance()
        {
            InterestRate = 0.01F;
            return (Balance * (decimal)InterestRate);
        }

    }
}
