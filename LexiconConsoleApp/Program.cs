using System;

namespace LexiconConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            while (!endApp)  // Control Application Exit
            {

                menu();      // Show menu (Visa meny)
                bool intchk = false;
                while (!intchk)  // Loop until user enters integer
                {
                    Console.Write("\n  Ditt val? ");
                    string op = Console.ReadLine();
                    intchk = SelectedFunction.Checkint(op); // Check if user entered integer
                    if (intchk)
                    {
                        try
                        {
                            PerformUserchoice(op); // Execute the function selected by user

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oh no! An exception occurred.\n - Details: " + e.Message);
                        }
                        if ((op != "10") && (endApp != true)) { Console.WriteLine("\t\t------------------------\n"); } // Indicate end of executed function 
                    }


                }

                // Wait for the user to respond before closing.(Vänta för användaren före avsluta) 
                if (!endApp)
                {
                    Console.Write("Tryck på Enter eller valfri knapp för att fortsätta: ");
                    Console.ReadLine();
                    Console.Clear();
                }
                Console.WriteLine("\n"); // Friendly linespacing.
            }

            // Calls the function user chose to run
            void PerformUserchoice(string op1)
            {
                int op = Convert.ToInt32(op1);

                switch (op)
                {
                    case 1: SelectedFunction.HelloWorld(); break;
                    case 2: SelectedFunction.PersonalInformation(); break;
                    case 3: SelectedFunction.ChangeTextColor(); break;
                    case 4: SelectedFunction.DateToday(); break;
                    case 5: SelectedFunction.BiggestValue(); break;
                    case 6: SelectedFunction.GuessNumber(); break;

                    case 7: SelectedFunction.SaveTextinFile(); break;
                    case 8: SelectedFunction.ReadtextfromFile(); break;
                    case 9: SelectedFunction.GetRoot(); break;
                    case 10: SelectedFunction.multiplicationtabel(); break;
                    case 11: SelectedFunction.Arraysordered(); break;
                    case 12: SelectedFunction.Palindrom(); break;

                    case 13: SelectedFunction.Numbersintwoinputs(); break;
                    case 14: SelectedFunction.SeperateEvenOddNumbers(); break;
                    case 15: SelectedFunction.Addallnumbers(); break;
                    case 16: SelectedFunction.OpponentsRandomValues(); break;

                    case 17: Console.Clear(); break;
                    case 0: endApp = true; break;
                    default: Console.WriteLine("\tVälj en funktion för att fortsätta eller 0 för avsluta app"); break;

                }
            }

            // Display menu of functions
            void menu()
            {
                // Display title as LexiconApp in C#.
                Console.WriteLine("LexiconApp in C#\r");
                Console.WriteLine("-----------------\n");

                // Ask the user to choose an operator.
                Console.WriteLine("\tVälj en funktion från den följande lista:");
                Console.WriteLine("\t========================================================================================");
                Console.WriteLine("\t1 - Skriv ut HelloWorld\t\t\t|\t9 - Få roten ur\n\t----------------------------------------------------------------------------------------");
                Console.WriteLine("\t2 - Personal Information\t\t|\t10 - Multiplikationstabell\n\t----------------------------------------------------------------------------------------");
                Console.WriteLine("\t3 - Ändra färg på texten\t\t|\t11 - Arrayer\n\t----------------------------------------------------------------------------------------");
                Console.WriteLine("\t4 - Skriva ut dagens datum\t\t|\t12 - Är det palindrom\n\t----------------------------------------------------------------------------------------");
                Console.WriteLine("\t5 - Hitta störst mellan två värden\t|\t13 - Siffror mellan två inputsen\n\t----------------------------------------------------------------------------------------");
                Console.WriteLine("\t6 - Gissa tal mellan 1-100\t\t|\t14 - Udda och jämna i ett antal värden\n\t----------------------------------------------------------------------------------------");
                Console.WriteLine("\t7 - Spara text i en fil\t\t\t|\t15 - Addera ett antal värden\n\t----------------------------------------------------------------------------------------");
                Console.WriteLine("\t8 - Visa text från en fil\t\t|\t16 - Motståndarnas Hälsa, Styrka och Tur");//\n\t----------------------------------------------------------------------------------------");
                Console.WriteLine("\t=========================================================================================");

                //Console.WriteLine("\n");//\t=========================================================================================");
                Console.WriteLine("\n\t0 - Avsluta\t\t\t\t|\t17 - Rensa konsolen");//\n\t========================================================================================");
                Console.WriteLine("\t=========================================================================================");

            }


            return;
        }


    }

}

//git branch -m master Main
//git fetch origin
//git branch -u origin/Main Main
//git remote set-head origin -a
