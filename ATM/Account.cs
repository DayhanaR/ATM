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
            if(Balance - money == 0)
                Console.WriteLine("\nDinero insuficiente");
            else
            {
                Balance -= money;
                Console.WriteLine("\nDinero retirado correctamente");
            }
        }

        public void AddMoney(decimal money)
        {
            Balance += money;
            Console.WriteLine("\nDinero ingresado correctamente");
        }


    }
}
