using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CIFAccount : Account
    {
        public override void WithdrawalMoney(decimal money)
        {
            if (Balance - money <= 50000)
                Console.WriteLine("\nDinero insuficiente");
            else
            {
                Balance -= money;
                Console.WriteLine("\nDinero retirado correctamente");
            }
        }
    }
}


