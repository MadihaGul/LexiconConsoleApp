using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LexiconConsoleApp
{
    class SelectedFunction
    {
        private string _ErrorMessage = "";

        // Saves the string/text row on hard drive in a text file
        private bool saveHD(string saveText)
        {
            bool issaved = false;
            try
            {
                string Filename = "D:\\Lexiconfil.txt";
                bool Fileexists = CheckifFileExist(Filename);

                // Checks if file exists and prompt user to choose between edit or replace file
                if (Fileexists)
                {
                    Console.WriteLine("\n Det finns redan en fil med det namnet.\n Vill du lägg text i befintliga filen:\tJ=Ja\teller\tN=Nej (Ersätter befintlig fil)");
                    string choiceinput = Console.ReadLine();
                    choiceinput = ChkUserinput(choiceinput);
                    bool choice = IfYesNo(choiceinput);
                    choiceinput = choiceinput + " ";

                    // Edit existing file 
                    if (choice)
                    {
                        FileStream fs = new FileStream(Filename, FileMode.Append);
                        byte[] bdata = Encoding.Default.GetBytes(saveText);
                        fs.Write(bdata, 0, bdata.Length);
                        fs.Close();
                        issaved = true;
                    }
                    // replace existing file
                    else
                    {
                        File.Delete(Filename);

                        FileStream fs = new FileStream(Filename, FileMode.Append);
                        byte[] bdata = Encoding.Default.GetBytes(saveText);
                        fs.Write(bdata, 0, bdata.Length);
                        fs.Close();
                        issaved = true;


                    }


                }
                // Edit existing file 
                else
                {

                    FileStream fs = new FileStream(Filename, FileMode.Append);
                    byte[] bdata = Encoding.Default.GetBytes(saveText);
                    fs.Write(bdata, 0, bdata.Length);
                    fs.Close();
                    issaved = true;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n <font color=red> Oooops! We are facing some problems, Please contact system administrator.</font>"); issaved = false;
            }

            return issaved;
        }

        // Reads the string/text from text file on hard drive
        private string ReadFileHD()
        {
            string data = "";

            // Reads data from a file saved on HD
            try
            {

                FileStream fsReadFile = new FileStream("D:\\Lexiconfil.txt", FileMode.Open, FileAccess.Read);
                using (StreamReader sr = new StreamReader(fsReadFile))
                {
                    data = sr.ReadToEnd();
                }

            }
            // If file with the given name not exists
            catch (FileNotFoundException)
            {
                _ErrorMessage = "Använd funktion no 7 för att skapa en fil";
                Console.WriteLine("Error: Filen hittades inte." + _ErrorMessage + "\n");

            }
            return data;
        }

        // Get text input from user and calls saveHD function to save the input on HD
        public static void SaveTextinFile()
        {
            // Takes text input from user to save on HD
            SelectedFunction ob = new SelectedFunction();
            Console.WriteLine("\n Ange text för att spara i en fil");
            string saveText = Console.ReadLine();
            saveText = ChkUserinput(saveText);
            //Console.WriteLine("\n Ange namn till filen");
            //string Filename = Console.ReadLine();

            // Calls save method 
            bool msg = ob.saveHD(saveText);

            //prints save message on console accordingly
            if (msg) { Console.WriteLine("\n Sparad text i D:\\Lexiconfil.txt"); }
            else { Console.WriteLine("\n Tyvärr! inte Sparad"); }

        }

        // Get text from HD by calling ReadFileHD function and display output on console
        public static void ReadtextfromFile()

        {
            // Calls ReadFileHD to get data from a file saved in HD
            SelectedFunction ob = new SelectedFunction();
            string FileData = ob.ReadFileHD();

            // Prints data on console
            if (ob._ErrorMessage == "")
            {
                if (FileData != "")
                    Console.WriteLine("\n " + FileData);
                else
                    Console.WriteLine("\n Filen är tom. ");
            }
            ob._ErrorMessage = "";

        }

        // Prints multiplication table from 1-10
        public static void multiplicationtabel()
        {
            Console.WriteLine("\n\t Multiplikationstabell från 1 till 10");
            Console.WriteLine("\t ====================================");
            int i, j;
            Console.Write("\n\t");
            for (int x = 1; x <= 10; x++) { Console.Write($"\t{x}"); }
            // Add /n
            // multilies and prints on console
            for (i = 1; i <= 10; i++)
            {
                Console.Write($"\n\t{i}");
                for (j = 1; j <= 10; j++)
                {
                    int m = i * j;


                    Console.Write($"\t{m}");
                }

            }
            Console.WriteLine("\n");
        }
        // Fills an array with random numbers and saves the numbers in ascending order in another array and prints both on console
        public static void Arraysordered()
        {
            bool issizevalid = false;
            var rand = new Random();
            string sizeS;
            Console.WriteLine("\n Ange arrays storlek");
            sizeS = Console.ReadLine();
            sizeS = ChkUserinput(sizeS);
            issizevalid = Checkint(sizeS);
            //Takes array size from user
            while (!issizevalid)
            {
                Console.WriteLine("\n Ange arrays storlek");
                sizeS = Console.ReadLine();
                sizeS = ChkUserinput(sizeS);
                issizevalid = Checkint(sizeS);
            }
            int size = Convert.ToInt32(sizeS);
            //Create Array of random numbers
            if (size > 1 && size <= 100)
            {
                int[] arr = new int[size];
                int[] arr2 = new int[size];
                Console.WriteLine("\n\n\t Array i slumpmässiga ordning");
                Console.WriteLine("\t------------------------------\n");
                for (int i = 0; i < size; i++)
                {
                    arr[i] = rand.Next(1, 100);
                    Console.WriteLine("\t" + arr[i]);

                }


                for (int i = 0; i < size; i++)
                {
                    arr2[i] = arr[i];

                }
                // Sorts array in ascending order
                Array.Sort(arr2);

                // Prints sorted array in ascending order

                Console.WriteLine("\n\n\t Array i stigande ordning");
                Console.WriteLine("\t----------------------------\n");
                for (int i = 0; i < size; i++)
                {

                    Console.WriteLine("\t" + arr2[i]);

                }
            }
            else
            { Console.WriteLine("\n Detta är ogiltig. Minst val är 2 och max val är 100"); }

        }
        // Takes text input from user and print on console if it is palindrome or not
        public static void Palindrom()
        {
            string revtext = "";
            // Takes the text input from user
            Console.WriteLine("\n Ange text eller ord");
            string orignaltext = Console.ReadLine();
            orignaltext = ChkUserinput(orignaltext);
            // Reverse the text input
            for (int i = orignaltext.Length - 1; i >= 0; i--)
            {
                revtext += orignaltext[i].ToString();

            }
            // Compare both values
            if (revtext == orignaltext)
            {

                Console.WriteLine("\n\t Det är en palindrom");

            }
            else
            {
                Console.WriteLine("\n\t Det är inte en palindrom");
            }

        }
        // Takes a decimal value from user and print its root, power of 2 and power of 10
        public static void GetRoot()
        {
            decimal num, root, rootpower2, rootpower10;
            string Snum = "0";
            bool Valid = false;
            while (!Valid)
            {

                Console.WriteLine("\n Ange ett decimal tal:   ");
                Console.Write(" "); Snum = Console.ReadLine();
                Snum = ChkUserinput(Snum);
                Valid = Checkdecimal(Snum);

            }
            num = Convert.ToDecimal(Snum);

            // Calculate root
            if (num < 0)
            {
                root = 0;
                rootpower2 = 0;
                rootpower10 = 0;
            }

            else
            {
                root = num / 3;

                int i;
                for (i = 0; i < 32; i++)
                {
                    root = (root + num / root) / 2;
                }

                // Calls pow method to get value of decimal number raised to desired power
                rootpower2 = Pow(num, 2);
                rootpower10 = Pow(num, 10);
            }
            Console.WriteLine($"\n\tRoten ur:\t{root}");
            Console.WriteLine($"\n\tUpphöjt i 2:\t{rootpower2}");
            Console.WriteLine($"\n\tUpphöjt i 10:\t{rootpower10}");

        }
        // Takes two values from user and prints all numbers betweeen the two inputs
        public static void Numbersintwoinputs()
        {
            bool intchk = false;
            int value1 = 0;
            int value2 = 0;
            // Takes valid input from user
            while (!intchk)
            {
                Console.Write("\n Ange det första numret: ");

                string num1 = Console.ReadLine();
                num1 = ChkUserinput(num1);
                intchk = Checkint(num1);
                if (intchk) { value1 = Convert.ToInt32(num1); }
            }
            intchk = false;
            while (!intchk)
            {
                Console.Write("\n Ange det andra numret: ");

                string num2 = Console.ReadLine();
                num2 = ChkUserinput(num2);
                intchk = Checkint(num2);
                if (intchk) { value2 = Convert.ToInt32(num2); }
            }

            // Find numbers between two inputs and print on console
            if (value1 < value2)
            {
                string s = "";
                int i = value1 + 1;
                if (i != value2)
                {
                    while (i < value2)
                    {
                        if (i == value1 + 1) { s = s + i.ToString(); }
                        else
                        { s = s + ", " + i.ToString(); }
                        i++;
                    }
                    Console.WriteLine($"\n Siffror mellan {value2} och {value1} är {s}");
                }
                else { Console.WriteLine($"\n Det finns ingen siffra mellan {value1} och {value2}."); }

            }
            else if (value1 > value2)
            {
                string s = "";
                int i = value2 + 1;
                if (i != value1)
                {
                    while (i < value1)
                    {
                        if (i == value2 + 1) { s = s + i.ToString(); }
                        else
                        { s = s + ", " + i.ToString(); }
                        i++;
                    }
                    Console.WriteLine($"\n Siffror mellan {value2} och {value1} är {s}");

                }
                else { Console.WriteLine($"\n Det finns ingen siffra mellan {value2} och {value1}."); }
            }
            else { Console.WriteLine("\n Båda värden är jämlika. Det finns ingen siffra mellan de angav värden"); }

        }

        //Gets comma seperated input from user and then sorts as even and odd numbers to print on console
        public static void SeperateEvenOddNumbers()
        {
            bool isvalid = false;
            while (!isvalid)
            {

                string even = "", odd = "";
                Console.WriteLine("\n Ange komma-separerad siffror: ");// check for negative values
                string orignaltext = Console.ReadLine();
                orignaltext = ChkUserinput(orignaltext);
                isvalid = true;
                string[] numbers = orignaltext.Split(",");
                bool iseven = false, isodd = false;
                for (int i = 0; i < numbers.Length; i++)
                {   //double num = Convert.ToDouble(numbers[i]);
                    if (isvalid)
                    {

                        bool Isnum = Checkint(numbers[i]);
                        if (!Isnum)
                        {
                            //Console.WriteLine("\n Inputsen är ogiltig."); 
                            isvalid = false; even = ""; odd = "";
                        }
                    }

                    if (isvalid)
                    {
                        if (i == numbers.Length - 2)
                        {
                            bool Isnum1 = Checkint(numbers[i + 1]);
                            if (Isnum1)
                            {

                                if (Convert.ToInt32(numbers[i + 1]) % 2 == 0) { iseven = true; } else { isodd = true; }
                            }
                        }


                        if (Convert.ToInt32(numbers[i]) % 2 == 0)
                        {
                            if (Convert.ToInt32(numbers[i]) != 0)
                            {
                                even = even + numbers[i];
                            }
                            else
                            {
                                even = even + "0";
                            }

                            if (i != numbers.Length - 1)
                            {
                                if (!isodd)
                                    even = even + ",";
                            }


                        }
                        else
                        {
                            if (Convert.ToInt32(numbers[i]) != 0)
                            {
                                //if (i != numbers.Length - 1)
                                //    odd = odd + numbers[i] + ",";
                                //else
                                odd = odd + numbers[i];
                                if (i != numbers.Length - 1)
                                {
                                    if (!iseven)
                                        odd = odd + ",";
                                }
                            }

                        }
                    }


                    // }
                }
                if (isvalid)
                {

                    if (even == "") { Console.WriteLine("\tJämna värden\t=\tFinns inte i den lade in inputsen"); }
                    else { Console.WriteLine($"\tJämna värden\t=\t{even}"); }
                    if (odd == "") { Console.WriteLine("\tUdda värden\t=\tFinns inte i den lade in inputsen"); }
                    else
                    { Console.WriteLine($"\tUdda värden\t=\t{odd}"); }

                }


            }

        }

        //Gets comma seperated input from user and then adds the values to print sum on console
        public static void Addallnumbers()
        {
            bool isvalid = false;
            while (!isvalid)
            {
                isvalid = true;
                double sum = 0;
                Console.WriteLine("\n Ange komma-separerad siffror: ");
                string orignaltext = Console.ReadLine();
                orignaltext = ChkUserinput(orignaltext);

                string[] numbers = orignaltext.Split(",");
                if (numbers.Length == 1) { Console.Write("\n Ogiltig!   Ange minst två siffror: "); isvalid = false; }
                else
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {   //double num = Convert.ToDouble(numbers[i]);
                        bool Isnum = Checkdouble(numbers[i]);  // Check why error message prints twice
                        if (!Isnum) { Console.WriteLine("\n Inputsen är ogiltig."); isvalid = false; }
                        else sum = sum + Convert.ToDouble(numbers[i]);
                    }

                }
                if (isvalid) { Console.WriteLine($"\t Addera resultat= {sum}"); }
            }
        }

        //Saves user input and random values in two instances of a class and prints values on console
        public static void OpponentsRandomValues()
        {
            Players Player1 = new Players();
            Players Player2 = new Players();

            var rand = new Random();

            Console.WriteLine(" Ange namnet på sin karaktär: ");
            Player1.PlayerName = Console.ReadLine();
            Player1.PlayerName = ChkUserinput(Player1.PlayerName);

            Console.WriteLine(" Ange namnet på sin motståndare: ");
            Player2.PlayerName = Console.ReadLine();
            Player2.PlayerName = ChkUserinput(Player2.PlayerName);

            Player1.Health = rand.Next(1, 1000);
            Player2.Health = rand.Next(1, 1000);

            Player1.Power = rand.Next(0, 100);
            Player2.Power = rand.Next(0, 100);

            Player1.Luck = rand.Next(0, 10);
            Player2.Luck = rand.Next(0, 10);

            Console.WriteLine($"\tDin karaktär: {Player1.PlayerName}\n\tHälsa:\t{Player1.Health}\n\tStyrka:\t{Player1.Power}\n\tTur:\t{Player1.Luck}");
            Console.WriteLine($"\n\tDin motståndare: {Player2.PlayerName}\n\tHälsa:\t{Player2.Health}\n\tStyrka:\t{Player2.Power}\n\tTur:\t{Player2.Luck}");

        }

        // Takes input from user and change the color of input 
        public static void ChangeTextColor()
        {
            bool stopcolorchange = false;
            var rand = new Random();
            Console.WriteLine("\n Ange text för att ändra textens färg");
            string OriginalText = Console.ReadLine();
            OriginalText = ChkUserinput(OriginalText);
            int color = 1;
            while (!stopcolorchange)
            {
                // int color = rand.Next(1, 10);
                if (color > 10) { color = 1; }
                if (color == 1) { Console.ForegroundColor = ConsoleColor.DarkRed; }
                if (color == 2) { Console.ForegroundColor = ConsoleColor.DarkMagenta; }
                if (color == 3) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                if (color == 4) { Console.ForegroundColor = ConsoleColor.Gray; }
                if (color == 5) { Console.ForegroundColor = ConsoleColor.Green; }
                if (color == 6) { Console.ForegroundColor = ConsoleColor.Cyan; }
                if (color == 7) { Console.ForegroundColor = ConsoleColor.Blue; }
                if (color == 8) { Console.ForegroundColor = ConsoleColor.White; }
                if (color == 9) { Console.ForegroundColor = ConsoleColor.Yellow; }
                if (color == 10) { Console.ForegroundColor = ConsoleColor.Magenta; }

                Console.WriteLine($"\n {OriginalText} \n");
                //Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n Ändra textens färg? : J= Ja eller N=Nej?");
                string ChangeColor = Console.ReadLine();
                ChangeColor = ChkUserinput(ChangeColor);
                bool choice = IfYesNo(ChangeColor);

                //while ((ChangeColor != "J") && (ChangeColor != "j") && (ChangeColor != "Ja") && (ChangeColor != "ja") && (ChangeColor != "JA") && (ChangeColor != "n") && (ChangeColor != "N") && (ChangeColor != "Nej") && (ChangeColor != "NEJ") && (ChangeColor != "nej"))

                //{
                //    Console.WriteLine("\n Detta är ogiltig. \n Ändra textens färg?  : J= Ja eller N=Nej ");
                //    ChangeColor = Console.ReadLine();

                //}
                if (choice)
                {
                    color++;
                    stopcolorchange = false;
                }
                else if (!choice)
                {
                    //  Console.ForegroundColor = ConsoleColor.White;
                    stopcolorchange = true;
                }

            }
        }

        // Prints todays date on console
        public static void DateToday()
        {

            Console.WriteLine("\n Datum: " + DateTime.Now.ToString("yyyy-MM-dd"));
        }
        // Prints Hello world on Console
        public static void HelloWorld()
        {
            Console.WriteLine("\n Hello World!");
        }

        // Take two numerical values from user and prints the biggest value on console 
        public static void BiggestValue()
        {
            bool doublechk = false;
            double value1 = 0;
            double value2 = 0;
            while (!doublechk)
            {
                Console.Write("\n Ange det första numret: ");

                string num1 = Console.ReadLine();
                num1 = ChkUserinput(num1);
                doublechk = Checkdouble(num1);
                if (doublechk) { value1 = Convert.ToDouble(num1); }
            }
            doublechk = false;
            while (!doublechk)
            {
                Console.Write("\n Ange det andra numret: ");

                string num2 = Console.ReadLine();
                num2 = ChkUserinput(num2);
                doublechk = Checkdouble(num2);
                if (doublechk) { value2 = Convert.ToDouble(num2); }
            }

            if (value1 > value2) { Console.WriteLine($"\n {value1} är det störst värde"); }
            else if (value1 < value2) { Console.WriteLine($"\n {value2} är det störst värde"); }
            else { Console.WriteLine("\n Båda värden är jämlika"); }
        }

        //Generates random number between 1-100 and prompts user to guess the number thrice
        public static void GuessNumber()
        {
            bool intchk = false;

            string Guess = "";
            int intGuess = 0;
            int MaxTries = 3;
            var rand = new Random();
            int randomnum = rand.Next(1, 101);

            for (int tries = 0; tries < MaxTries; tries++)
            {
                while (!intchk)
                {
                    if (tries == 0)
                        Console.WriteLine("\n Gissa ett tal mellan 1-100: ");
                    else
                        Console.WriteLine("\n Gissa talet igen: ");
                    Guess = Console.ReadLine();
                    Guess = ChkUserinput(Guess);
                    intchk = Checkint(Guess);
                    if (intchk) { intGuess = Convert.ToInt32(Guess); }
                }
                intchk = false;

                if (tries <= (MaxTries - 1))
                {
                    if (intGuess == randomnum)
                    {
                        Console.WriteLine("\n Grattis! Du har gissat rätt i det " + DefineOrdningstal(tries + 1) + " försök\a");
                        break;
                    }
                    else
                    {
                        if (tries == (MaxTries - 1))
                        { Console.WriteLine("\n Tyvärr! Du har inga försök kvar. Talet var " + $"{randomnum}\a"); }
                        else
                        {
                            if (intGuess < randomnum)
                            { Console.WriteLine("\n Tyvärr! Försök igen (Antydan: Talet du har gissat var för litet)"); }
                            else
                            { Console.WriteLine("\n Tyvärr! Försök igen (Antydan: Talet du har gissat var för stort)"); }
                        }
                    }

                }
            }

        }

        // Gets user name and age and prints on console
        public static void PersonalInformation()
        {

            // Declare variables and set to empty.
            string FirstName = "";
            string EfterName = "";

            int age = 0;
            bool intchk = false;


            // Ask the user to type the first name.
            Console.WriteLine("Ange ditt FörNamn och tryck på Enter");
            FirstName = Console.ReadLine();
            FirstName = ChkUserinput(FirstName);


            // Ask the user to type the sur name.
            Console.WriteLine("Ange ditt EfterNamn och tryck på Enter");
            EfterName = Console.ReadLine();
            EfterName = ChkUserinput(EfterName);
            // Ask the user to type age.
            while (!intchk)
            {
                Console.WriteLine("Ange din Ålder");
                string age1 = Console.ReadLine();
                age1 = ChkUserinput(age1);
                intchk = Checkint(age1);//Check for alphabetical error exception

                age = Convert.ToInt32(age1);
                if (age <= 0 || age > 150)
                {
                    Console.Write("Detta är ogiltig. ");//Check for alphabetical error exception
                    intchk = false;
                }
                else
                {
                    Console.WriteLine($"\n Användarens förnamn är: {FirstName}");
                    Console.WriteLine($"Användarens efternamn är: {EfterName}");
                    Console.WriteLine($"{FirstName} {EfterName} är {age} år gammal.\n");
                }
            }

        }

        // Returns power of a decimal number passed as arguments
        public static decimal Pow(decimal x, uint y)
        {
            decimal A = 1m;
            System.Collections.BitArray e = new System.Collections.BitArray(BitConverter.GetBytes(y));
            int t = e.Count;

            for (int i = t - 1; i >= 0; --i)
            {
                A *= A;
                if (e[i] == true)
                {
                    A *= x;
                }
            }
            return A;
        }

        // Defines ordnings tal
        public static string DefineOrdningstal(int n)
        {
            string ordtal = "";
            if (n == 1 || n == 2) { ordtal = n + ":a"; }
            else { ordtal = n + ":e"; }
            return ordtal;
        }

        // Checks if user input is valid
        public static string ChkUserinput(string Userinput)
        {
            while (Userinput == "")
            {
                Console.WriteLine("\n Detta är ogiltig. Ange text");
                Userinput = Console.ReadLine();
            }
            return Userinput;
        }

        // Returns trues false according to user input Yes or No
        public static bool IfYesNo(string Userinput)
        {
            bool choice = false;
            while ((Userinput != "J") && (Userinput != "j") && (Userinput != "Ja") && (Userinput != "ja") && (Userinput != "JA") && (Userinput != "n") && (Userinput != "N") && (Userinput != "Nej") && (Userinput != "NEJ") && (Userinput != "nej"))

            {
                Console.WriteLine("\n Detta är ogiltig. \n Ange:    J= Ja eller N=Nej ");
                Userinput = Console.ReadLine();
                Userinput = ChkUserinput(Userinput);

            }
            if ((Userinput == "J") || (Userinput == "j") || (Userinput == "Ja") || (Userinput == "ja") || (Userinput == "JA"))
            {
                choice = true;
            }
            else if ((Userinput == "n") || (Userinput == "N") || (Userinput == "Nej") || (Userinput == "NEJ") || (Userinput == "nej"))
            {
                choice = false;
            }
            return choice;
        }

        // Checks if file with the same name exists on HD
        public static bool CheckifFileExist(string val1)
        {
            string Chkfile = val1;
            if (File.Exists(@Chkfile))
            {
                return true;
            }
            else { return false; }
        }

        // Check if user entered integer
        public static bool Checkint(string val1)
        {
            if (int.TryParse(val1, out int intval))
            {
                return true;
            }
            else
            {
                Console.Write("Detta är ogiltig. Ange en heltal");
                return false;
            }

        }
        // Check if user entered double
        public static bool Checkdouble(string val1)
        {

            if (double.TryParse(val1, out double Dbval))
            {
                return true;
            }
            else
            {
                Console.Write("Detta är ogiltig. Ange numerisk värde. ");
                return false;
            }

        }
        // Check if user entered decimal
        public static bool Checkdecimal(string val1)
        {

            if (decimal.TryParse(val1, out decimal Dval))
            {
                return true;
            }
            else
            {
                Console.Write("Detta är ogiltig. ");
                return false;
            }

        }
        //------------------------------------
        //--------------------------------------
    }
}
