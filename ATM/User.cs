using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class User
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public List <Account> Accounts { get; set; }

        public void ChangePassword(string password)
        {
            Password = password;
            Console.WriteLine("Contraseña cambiada correctamente");
        }
    }
}
