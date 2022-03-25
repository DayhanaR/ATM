using System;
using System.Collections.Generic;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount account1 = new SavingsAccount()
            {
                Id = 1,
                Name = "Cuenta de Ahorros",
                Balance = 500000,
            };

            SavingsAccount account3 = new SavingsAccount()
            {
                Id = 3,
                Name = "Cuenta de Ahorros",
                Balance = 2000000,
            };

            CIFAccount account2 = new CIFAccount()
            {
                Id = 2,
                Name = "Fiducuenta",
                Balance = 1000000,
            };

            CIFAccount account4 = new CIFAccount()
            {
                Id = 4,
                Name = "Fiducuenta",
                Balance = 3000000,
            };

            User admin = new User()
            {
                Name = "Dayhana",
                LastName = "Ramirez",
                UserName = "DayhanaR",
                Password = "0000",
                Accounts = new List<Account>() { account1, account2 }   
            };


            User user1 = new User()
            {
                Name = "Angela",
                LastName = "Moreno",
                UserName = "AngelaM",
                Password = "0000",
                Accounts = new List<Account>() { account3, account4 }
            };

            Bank bancolombia = new Bank()
            {
                Users = new List<User>() { admin, user1 }
            };

            ATM cajero1 = new ATM();
            cajero1.Login(bancolombia);
        }
    }
}
