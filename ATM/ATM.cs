using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ATM
    {
        public void Login(Bank bank)
        {
            string userName = string.Empty;
            string password = string.Empty;
            Console.WriteLine($"╔══════════════════════════════════╗" +
                              $"\n║ Bienvenido al cajero Bancolombia ║" +
                              $"\n╚══════════════════════════════════╝");
            do
            {
                Console.WriteLine("\nDigite su nombre de usuario");
                userName = Console.ReadLine();
                Console.WriteLine("\nDigite su contraseña");
                password = Console.ReadLine();

                if (LoginValidation(userName, password, bank))
                    Menu(GetUser(userName, password, bank));
                else
                    Console.WriteLine($"\n************************ ALERTA ***********************" +
                                      $"\n* Por favor ingrese un usuario y/o contraseña válidos *" +
                                      $"\n*******************************************************");

            } while (!LoginValidation(userName, password, bank));
        }

        public void Menu(User user)
        {
            int answer = 0;
            do
            {
                try
                {
                     
                    Console.WriteLine($"\nBienvenid@, {user.Name} {user.LastName}" +
                                      $"\n" +
                                      $"\n================================" +
                                      $"\n============= Menu =============" +
                                      $"\n================================" +
                                      $"\n                                " +
                                      $"\n       1. Ingresar dinero       " +
                                      $"\n       2. Retirar dinero        " +
                                      $"\n       3. Consulta de saldo     " +
                                      $"\n       4. Cambio de clave       " +
                                      $"\n       5. Salir                 " +
                                      $"\n                                " +
                                      $"\n================================" +
                                      $"\n                                " +
                                      $"\nSeleccione una opción:");

                    answer = Convert.ToInt32(Console.ReadLine());

                    switch (answer)
                    {
                        case 1:
                            int answerAdd = CheckAccount(user);
                            string moneyToAdd = string.Empty;
                            Console.WriteLine($"" +
                                $"\n¿Cuánto dinero desea ingresar?");
                            moneyToAdd = Console.ReadLine();
                            int moneyToAddNumber = ConvertNumber(moneyToAdd);
                            user.Accounts[answerAdd].AddMoney((decimal)moneyToAddNumber);
                            break;

                        case 2:
                            int answerRetire = CheckAccount(user);
                            string moneyToRetire = string.Empty;
                            Console.WriteLine($"" +
                                $"\n¿Cuánto dinero desea retirar?");
                            moneyToRetire = Console.ReadLine();
                            int moneyToRetireNumber = ConvertNumber(moneyToRetire);
                            user.Accounts[answerRetire].WithdrawalMoney((decimal)moneyToRetireNumber);
                            break;

                        case 3:
                            int answerCheck = CheckAccount(user);
                            Console.WriteLine($"" +
                                $"\n{user.Accounts[answerCheck].GetBalance()}");
                            break;

                        case 4:
                            Console.WriteLine("\nIngrese la contraseña actual:");
                            string actualPassword = Console.ReadLine();

                            if(actualPassword == user.Password)
                            {
                                Console.WriteLine("\nIngrese la nueva contraseña");
                                string newPassword = Console.ReadLine();
                                user.ChangePassword(newPassword);

                                Console.WriteLine($"\nAntigua contraseña: {actualPassword}" +
                                                  $"\nNueva contraseña: {newPassword}");
                            }
                            else
                            {
                                Console.WriteLine($"\n************ ALERTA ************ " +
                                                  $"\n* Las contraseñas no coinciden *" +
                                                  $"\n********************************");
                            }

                            break;

                        case 5:
                            Console.WriteLine($"\n╔═══════════════════════════════════════╗" +
                                              $"\n║ ¡Gracias por usar nuestros servicios! ║" +
                                              $"\n╚═══════════════════════════════════════╝");
                            return;

                        default:
                            Console.WriteLine($"\n*********************** ALERTA **********************" +
                                              $"\n* Por favor seleccione una de las opciones del menu *" +
                                              $"\n*****************************************************");
                            break;

                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"\n*************** ALERTA ****************" +
                                      $"\n* Por favor ingrese una opción válida *" +
                                      $"\n***************************************");
                }

            } while (true);

        }

        public bool LoginValidation(string userName, string password, Bank bank)
        {
            var found = bank.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);

            if (found == null)
                return false;
            else
                return true; 
        }

        public User GetUser(string userName, string password, Bank bank)
        {
            return bank.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }

        public string ShowAccounts(List<Account> accounts)
        {
            int counter = 0;
            string answer = string.Empty;
            Console.WriteLine("\nEscoja el número de la cuenta");
            Console.WriteLine("");
            foreach (var account in accounts)
            {
                Console.WriteLine($"{counter + 1}. {account.Name}");
                counter++;
            }
            answer = Console.ReadLine();
            return answer;
        }

        public bool ValidateNumber(string number)
        {
            try
            {
                int convertNumber = Convert.ToInt32(number);
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine($"\n*************** ALERTA ****************" +
                                  $"\n* Por favor ingrese una opción válida *" +
                                  $"\n***************************************");
                return false;
            }
        }

        public int ConvertNumber(string number)
        {
            return Convert.ToInt32(number); 
        }

        public int CheckAccount(User user)
        {
            string answer = ShowAccounts(user.Accounts);
            while (!ValidateNumber(answer))
            {
                answer = ShowAccounts(user.Accounts);
            }
            return ConvertNumber(answer) - 1;
        }
    }
}

