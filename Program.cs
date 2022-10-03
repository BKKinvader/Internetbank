using System;
using System.Linq;

namespace Internetbank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Welcome();
        }
        static void Welcome() // 1: Kunden ska mötas av att mata in Inloggning
        {

            Console.WriteLine("Hi welcome to the Bank");
            Console.WriteLine("Please enter your Username");
            string userName = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string passWord = Console.ReadLine();
            string result = SignIn(userName, passWord); // 2:Skicka iväg UserName och Password till SignIn metod
            UserInfo(result); //4: Skicka resultat till UserInfo för att visa korrekt användare.




        }


        private static string SignIn(string N, string P) // 3: SignIn ska stämma av vem som ska loggas in sedan skicka en return till Welcome
        {
            string result = "";
            string[,] Users = {{ "Tim", "12345" },{ "Johan", "54321" },{"Markus","6789" },{"Thomas","6789" },{"Lars","6789" } };
            int loginAttemts = 0;
            bool loggedIn = true;


            Console.WriteLine("Please enter your Username");
            string userName = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string passWord = Console.ReadLine();

                for (int i = 0; i < Users.GetLength(0); i++) // Loopa genom array
                {

                    if (N == Users[i, 0] && P == Users[i, 1])
                    {
                        loggedIn = false;
                    }

                }
                         

            //if(loginAttemts > 2)
            //{
            //    Console.WriteLine("Tyvärr har du försökt att logga in för många gånger");
            //}
            //else
            //{
            //    Console.WriteLine("Du är inloggad !");
            //}




            return result;


        }


       

        static void StartMenu() // Efter inlogning ska användaren göra val
        {
            Console.WriteLine("1. Se dina konton och saldo");
            Console.WriteLine("2. Överföring mellan konton");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4. Logga ut");
            int UserChoice = int.Parse(Console.ReadLine());
        }


        static void UserInfo(string info) // 5: Tar emot info om vem användaren är sedan skicka dem till StartMenu()
        {
            int TN = 100;
            switch (info)
            {
                case "0":
                    Console.WriteLine("Tim Nilsson");
                    Console.WriteLine("Du har {0}kr på kontot", TN);

                    break;



            }

        }


    }





}
