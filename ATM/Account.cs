using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public virtual decimal GetBalance()
        {
            return Balance;
        }

        public virtual void WithdrawalMoney(decimal money)
        {
            if ((Balance - money) <= 0)
            {
                Console.WriteLine($"\n******** ALERTA *******" +
                                  $"\n* Dinero insuficiente *" +
                                  $"\n***********************");

            }
            else
            {
                Balance -= money;
                Console.WriteLine($"\n|------------------------------|" +
                                  $"\n| Dinero retirado correctamente|" +
                                  $"\n|------------------------------|");
            }
        }

        public void AddMoney(decimal money)
        {
            Balance += money;
            Console.WriteLine($"\n|-------------------------------|" +
                              $"\n| Dinero ingresado correctamente|" +
                              $"\n|-------------------------------|");
        }


    }
}


