using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

// Tim Nilsson SUT22
namespace Internetbank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SignIn();
        }
        private static void SignIn() // 1: Welcome SignIn
        {
            int result = -1; // SignIn send "result" as a string to UserAccount to se which array position the user have
            int Attempt = 1; // amoount of attempt if the user try more then 3 times the program crash
            string[,] Users = {
                    { "Tim", "12345" },
                    { "Johan", "54321" },
                    {"Markus","6789" },
                    {"Thomas","6789" },
                    {"Lars","6789" } };           // Array of Username and Password    
            Console.WriteLine("Hi welcome to the Bank");
            do //Log int function
            {
                Console.WriteLine("Please enter your Username");
                string userName = Console.ReadLine();
                Console.WriteLine("Please enter your Password");
                string passWord = Console.ReadLine();
                Console.Clear();
                for (int i = 0; i < Users.GetLength(0); i++) // Loop an array
                {
                    if (userName == Users[i, 0] && passWord == Users[i, 1]) // Check if Username and password is correct in an arry
                    {
                        Attempt = 4;// Correct Username and Password change attempt to 4
                        result = i;// Convert user position from int to string and store it as result 
                        Console.Clear(); // Clear console text after each choice
                        Console.WriteLine("Du är inloggad");
                        UserAcocunt(result);// Send result/ to UserAccount to verify the user
                    }
                }
                Console.WriteLine("Wrong Username or Password {0}",Attempt);
                Attempt++;                
            } while (Attempt < 4); // After 3 attempts the loop breaks
          
            
        }
        private static void UserAcocunt(int User) // 2: After verified user then unlock user data and send the user and userdata to StartMenu()
        {
            decimal account1 = 0;
            decimal account2 = 0;
            decimal[,] userAccounts = {
                    //* Tim *//
                    { 2500.50m, 4500.90m, },
                    //* Johan *//
                    { 600, 300 },
                    //* Markus *//
                    {850,903 },
                    //* Thomas *//
                    {2345,234423 },
                    //* Lars *//
                    {100,270 } };   
            switch (User) // Check which user it is, after that connect account 1 and 2 to usersAccount array and send the user and userdata to StartMenu()
            {
                case 0:
                    Console.WriteLine("Tim Konto");
                    account1 = userAccounts[0, 0];
                    account2 = userAccounts[0, 1];
                    StartMenu(account1,account2);
                    break;
                case 1:
                    Console.WriteLine("Johan Konto");
                    account1 = userAccounts[1, 0];
                    account2 = userAccounts[1, 1];
                    StartMenu(account1, account2);
                    break;
                case 2:
                    Console.WriteLine("Markus Konto");
                    account1 = userAccounts[2, 0];
                    account2 = userAccounts[2, 1];
                    StartMenu(account1, account2);
                    break;
                case 3:
                    Console.WriteLine("Thomas Konto");
                    account1 = userAccounts[3, 0];
                    account2 = userAccounts[3, 1];
                    StartMenu(account1, account2);
                    break;
                case 4:
                    Console.WriteLine("Lars Konto");
                    account1 = userAccounts[4, 0];
                    account2 = userAccounts[4, 1];
                    StartMenu(account1, account2);
                    break;
            }
            Console.Clear();
        }
        static void StartMenu(decimal account1, decimal account2) // 3: Now we have ammount of money in each account
        {
            bool Choice = true;
            do
            {
             // Let the user choose what they want to do next
                Console.WriteLine("Välj bland de alternativ");
                    Console.WriteLine("1. Se dina konton och saldo");
                    Console.WriteLine("2. Överföring mellan konton");
                    Console.WriteLine("3. Ta ut pengar");
                    Console.WriteLine("4. Logga ut");
                    int.TryParse(Console.ReadLine(), out int UserChoice); // Make sure that UserChoice is a number
                    Console.Clear();
                    // Diffrent function in menu
                    switch (UserChoice)
                    {
                        case 1:
                            CheckBalance(account1, account2);
                            Choice = false;
                            break;
                        case 2:
                            Transfer(account1, account2);
                            Choice = false;
                            break;
                        case 3:
                            Withdraw(account1, account2);
                            Choice = false;
                            break;
                        case 4:
                        LogOut();
                        Choice = false;
                        break;
                    default:
                        Console.WriteLine("Du måste skriva en siffra mellan 1- 4");
                        break;
                }
            } while (Choice == true);
        }
        private static void CheckBalance(decimal account1, decimal account2) //4: Choice 1: to check balance
        {
            Console.WriteLine("Konto saldo:");
            Console.WriteLine("Konto 1:");
            Console.WriteLine(account1.ToString("C3", CultureInfo.CurrentCulture)); // skriver ut pengarna i landets valuta plus Kr/sek
            Console.WriteLine("Konto 2:");
            Console.WriteLine(account2.ToString("C3", CultureInfo.CurrentCulture));
            // Check if the user still want to continue or exit after checked balance
            Console.WriteLine("Klicka enter för att komma till huvud meny");
            bool Enter = true;
            do
            {
                string menu = Console.ReadLine().ToUpper();
                Console.Clear();
                switch (menu)
                {
                    case "":
                        StartMenu(account1, account2); // Send back new ammount to StartMenu();
                        Enter = false;
                        break;
                    default:
                        Console.WriteLine("Du skulle trycka på ENTER !!!!!");
                        break;
                }
            } while (Enter == true);
        }
        private static void Transfer(decimal account1, decimal account2) //5: Choice 2: To transfer money in diffrent account
        {
            decimal newAccount1 = 0;
            decimal newAccount2 = 0;
            bool Choice = true;
            do
            {
                Console.WriteLine("Vilket konto vill du överföra ifrån ?");
                Console.WriteLine("Konto 1: ");
                Console.WriteLine(account1.ToString("C3", CultureInfo.CurrentCulture));
                Console.WriteLine("Konto 2: ");
                Console.WriteLine(account2.ToString("C3", CultureInfo.CurrentCulture));
                int.TryParse(Console.ReadLine(), out int UserChoice);
                Console.Clear();
                switch (UserChoice)
                {
                    case 1:
                        Console.WriteLine("Skriv ín summan -> kontot {0}", UserChoice);
                        decimal.TryParse(Console.ReadLine(), out decimal ammount1);
                        Console.Clear();
                        if (ammount1 <= account1)
                        {
                            Console.WriteLine("Du överförde {0} kr från kont 1 till konto 2", ammount1);
                            newAccount1 = account1 - ammount1;
                            newAccount2 = account2 + ammount1;     
                            Choice = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Medges ej, försök igen");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Skriv ín summan -> kontot {0}", UserChoice);
                        decimal.TryParse(Console.ReadLine(), out decimal ammount2);
                        Console.Clear();
                        if (ammount2 <= account2)
                        {
                            Console.WriteLine("Du överförde {0} kr från konto 2 till konto 1", ammount2);
                            newAccount2 = account2 - ammount2;
                            newAccount1 = account1 + ammount2;
                            Choice = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Medges ej, försök igen");
                        }
                        break;
                    default:
                        Console.WriteLine("Du har endast 2 konto att välja i mellan!");
                        break;
                }
            } while (Choice == true);
            Console.WriteLine("Konto 1: ");
            Console.WriteLine(newAccount1.ToString("C3", CultureInfo.CurrentCulture));
            Console.WriteLine("Konto 2:");
            Console.WriteLine(newAccount2.ToString("C3", CultureInfo.CurrentCulture));
            Console.WriteLine("Klicka enter för att komma till huvud meny");
            string menu = Console.ReadLine().ToUpper();
            Console.Clear();
            switch (menu)
            {
                case "":
                    StartMenu(newAccount1, newAccount2); // Send back new ammount to StartMenu();
                    break;
            }
        }
        private static void Withdraw(decimal account1, decimal account2)
        {
            decimal newAccount1 = 0;
            decimal newAccount2 = 0;
            bool Choice = true;
            do
            {
                Console.WriteLine("Vilket konto vill göra uttag på ?");
                Console.WriteLine("Konto 1: ");
                Console.WriteLine(account1.ToString("C3", CultureInfo.CurrentCulture));
                Console.WriteLine("Konto 2: ");
                Console.WriteLine(account2.ToString("C3", CultureInfo.CurrentCulture));
                int.TryParse(Console.ReadLine(), out int UserChoice);
                Console.Clear();
                switch (UserChoice)
                {
                    case 1:
                        Console.WriteLine("Skriv in summan");
                        decimal.TryParse(Console.ReadLine(), out decimal ammount1);
                        if (ammount1 <= account1)
                        {
                            Console.WriteLine("Du tog ut {0} kr från Konto 1", ammount1);
                            newAccount1 = account1 - ammount1;
                            newAccount2 = account2;
                            Choice = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Medges ej, försök igen");

                        }
                        break;
                    case 2:
                        Console.WriteLine("Skriv in summan");
                        decimal.TryParse(Console.ReadLine(), out decimal ammount2);
                        if (ammount2 <= account2)
                        {
                            Console.WriteLine("Du tog ut {0} kr från Konto 1", ammount2);
                            newAccount2 = account2 - ammount2;
                            newAccount1 = account1;
                            Console.WriteLine(newAccount2.ToString("C3", CultureInfo.CurrentCulture));
                            Choice = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Medges ej, försök igen");

                        }
                        break;
                    default:
                        Console.WriteLine("Du har endast 2 konto att välja i mellan!");
                        break;
                }
            } while (Choice == true);
            Console.WriteLine("Konto 1: ");
            Console.WriteLine(newAccount1.ToString("C3", CultureInfo.CurrentCulture));
            Console.WriteLine("Konto 2:");
            Console.WriteLine(newAccount2.ToString("C3", CultureInfo.CurrentCulture));
            Console.WriteLine("Klicka enter för att komma till huvud meny");
            string menu = Console.ReadLine().ToUpper();
            Console.Clear();

            switch (menu)
            {
                case "":
                    StartMenu(newAccount1, newAccount2); // Send back new ammount to StartMenu();
                    break;
            }
        }
        private static void LogOut()
        {
            Console.WriteLine("Tryck Enter för att logga ut");
            bool Enter = true;
            do
            {
                string menu = Console.ReadLine().ToUpper();
                switch (menu)
                {
                    case "":
                        SignIn();
                        Enter = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Du skulle trycka på ENTER !!!!!");
                        Enter = true;
                        break;
                }
            } while (Enter == true);

        }
    }

}
