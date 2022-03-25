using System;
using System.Collections.Generic;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount accountA = new SavingsAccount()
            {
                Id = 1,
                Name = "Cuenta de Ahorros",
                Balance = 500000,
            };

            CIFAccount accountB = new CIFAccount()
            {
                Id = 2,
                Name = "Fiducuenta",
                Balance = 1000000,
            };

            User admin = new User()
            {
                Name = "Dayhana",
                LastName = "Ramirez",
                UserName = "DayhanaR",
                Password = "0000",
                Accounts = new List<Account>() { accountA, accountB }   
            };    

            Bank bancolombia = new Bank()
            {
                Users = new List<User>() { admin }

            };

            ATM cajero1 = new ATM();

            cajero1.Login(bancolombia);

   
        }
    }
}
