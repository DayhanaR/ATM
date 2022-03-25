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
                Console.WriteLine($"\n******** ALERTA *******" +
                                  $"\n* Dinero insuficiente *" +
                                  $"\n***********************");
            else
            {
                Balance -= money;
                Console.WriteLine($"\n|------------------------------|" +
                                  $"\n| Dinero retirado correctamente|" +
                                  $"\n|------------------------------|");
            }
        }
    }
}


