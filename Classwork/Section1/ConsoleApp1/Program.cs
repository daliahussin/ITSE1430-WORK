/*
 * ITSE 1430
 * Sample implementation
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool notQuit;
            do
            {
                notQuit = DisplayMenu();
            } while (notQuit);

            // PlayWithStrings();
        }

        private static void PlayWithObjects ()
        {
            int hours = 10;
            Int32 hoursFull = 10;
            var areEqual = hours == hoursFull;

            var obj1 = ("Hello");
           DisplayObject(obj1);
            
            
        }
        private static void DisplayObject (object value)
        {
            if (value == null)
                return;
            // Approach1
            if (value is string)
            {
                var str = (string)value;
                Console.WriteLine(str);
            }else
                {
                var str = value.ToString();
                Console.WriteLine(str);
            };

            //Approach2
            var str2 = value as string;
            if (str2 != null)
                Console.WriteLine(str2);
            else
                Console.WriteLine(value.ToString());

            //Approach 3
            var str3 = value as string;
            Console.WriteLine((str3 != null) ? str3.ToString() : value.ToString());

            //Approach 4
            var str4 = value as string;
            Console.WriteLine((str4 ?? value).ToString());

            //Approach 5**
            //  var str5 = value is string;
            if (value is string str5)
                Console.WriteLine(str5.ToString());
            else
                Console.WriteLine(value.ToString());

            //Approach 6**
            var str6 = value as string;
            Console.WriteLine(str6?.ToString());

        }

        private static void PlayWithStrings()
        {

            string hoursString = "10A";
            // int hours = Int32.Parse(hoursString);//must be proper primitive
            //int hours;
            //bool result = Int32.TryParse(hoursString, out hours); //out parameter HOW YOU PARSE STRINGS
            //bool result = Int32.TryParse(hoursString, out int hours); //^ previous 2 lines can be combined for clarity and maintenance using local declarations
            //TryParse is used to validate user input

            //ToString
            // hoursString = hours.ToString();// works on any expression; converts any expression to its string equivalent
            //4.75.ToString();
            //457.ToString
            //Console.ReadLine().ToSTring();

            string message = "Hello\tworld";
            string filePath = @"C:\\Temp\\Test"; // \\maps to one character = used to make filepath valid
                                                 //verbatim strings
            filePath = @"C:\\Temp\\Test";

            //Concat
            string firstName = "Bob";
            string lastName = "Smith";
            string name = firstName + " " + lastName;

            // strings are immutable - this produces a new string
            name = "Hello" + name;
            Console.WriteLine("hello" + name);//just want to print it to the console - 6 max per program when using +  Approach 1
            Console.WriteLine("Hello {0} {1}", firstName, lastName); //alternative to +.  No maximum. approach 2
            string str = String.Format("Hello {0} {1}, firstName, lastName");  // approach 3
            Console.WriteLine(str);

            //Approach 4
            Console.WriteLine($"Hello {firstName} {lastName}");//interpreted string - language limitations compiler will tell you, stick with identifiers and integers
                                                               //String is more readable, can't screw it up?,

            string missing = null;
            string empty = " ";
            string empty2 = String.Empty;

            //checking for empty stringss
            // if (firstName.Lenght==0)
            // if (FirstName != null&& firstName != "")
            if (!String.IsNullOrEmpty(firstName))
                Console.WriteLine(firstName);

            //Other stuff
            string upperName = firstName.ToUpper();

            string lowerName = firstName.ToLower();

            // Comparison
            bool areEqual = firstName == lastName;
            areEqual = firstName.ToLower() == lastName.ToLower();
            areEqual = String.Compare(firstName, lastName, true) == 0;

            bool startsWithA = firstName.StartsWith("A");
            bool endsWithA = firstName.EndsWith("A");
            bool hasA = firstName.IndexOf("A") >= 0;
            String sbset = firstName.Substring(4);

            //Clean up
            string cleanMe = firstName.Trim(); //TrimStart , TrimEnd
            String makeLonger = firstName.PadLeft(20); //PadRight
        }

        private static void PlayWithArrays()
        {
            int count = ReadInt32("How many names? ", 1);

            string[] names = new string[count];
            for (int index = 0; index < count; ++index)
            {
                Console.WriteLine("Name? ");
                names[index] = Console.ReadLine();
            };

            foreach (string name in names)
            //   for ( int index =0; index < names.Length; ++index)
            {
                // readonly - not allowed
                //name= "";
                string str = name;
                str = "";
                //   Console.WriteLine(names[index]);
                Console.WriteLine(name);
            };
        }
        private static bool DisplayMenu()

        {
            while (true)
            {
                Console.WriteLine("A)dd Movie");
                Console.WriteLine("E)dit Movie");
                Console.WriteLine("D)elete Movie");
                Console.WriteLine("V)iew Movies");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine();
                switch (input[0])//(input[0]) searches for a character in a string - strings are not arrays in C#

                {
                    case 'a':
                    case 'A': AddMovie(); return true;  //required in C# - every case statement requires a break

                    case 'e':
                    case 'E': EditMovie(); return true;

                    case 'd':
                    case 'D': DeleteMovie(); return true;

                    case 'v':
                    case 'V': ViewMovies(); return true;

                    case 'q':
                    case 'Q':; return false;


                    default:
                        Console.WriteLine("Please enter a valid value.");
                        break;
                };
            };
        }

 

        private static void ViewMovies()
        {
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("No movies available");
                return;
            };
            Console.WriteLine(name);

            if (string.IsNullOrEmpty(desciption))
                Console.WriteLine(desciption);

            //  Console.WriteLine("Run length (mins) = " + runLength);
            Console.WriteLine($"Run length = {runLength} mins");
        }

        private static void EditMovie()
        {
            ViewMovies();

            string newName = ReadString("Enter a name (or press ENTER fo default): ", false);
            if (!String.IsNullOrEmpty(newName))
                name = newName;

            string newDesciption = ReadString("Enter a description (or press ENTER fo default): ");
            if (!String.IsNullOrEmpty(newDesciption))
                desciption = newDesciption;

            int newLength = ReadInt32("Enter run length (in minutes): ", 0);
            if (newLength > 0)
                runLength = newLength;
        }

        private static void AddMovie()
        {
            name = ReadString("Enter a name: ", true);
            desciption = ReadString("Enter a description: ");
            runLength = ReadInt32("Enter run length (in minutes): ", 0);
        }
        //
        private static void DeleteMovie()
        {
            if (Confirm("Are you sure you want to delete this movie?"))
            {
                // "Delete" the movie
                name = null;
                desciption = null;
                runLength = 0;
            };
        }

        private static bool Confirm(string message)
        {
            Console.WriteLine($"{message} (Y/N)");

            do
            {
                ConsoleKeyInfo Key = Console.ReadKey(true);
                switch (Key.KeyChar)
                {
                    case 'Y':
                    case 'y': return true;

                    case 'N':
                    case 'n': return false;
                };
            } while (true);
        }
        // if (Key.KeyChar == 'Y')
        //  return true;
        //   else if (Key.KeyChar == 'N')
        // return false;

        private static int ReadInt32(string message, int minValue)
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out int result))
                {
                    if (result > minValue)
                        return result;
                };
                Console.WriteLine($"You must enter an integer value >= {minValue}");
            };
        }

        private static string ReadString(string message)
        {
            return ReadString(message, false);
        }
        private static string ReadString(string message, bool required)
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input) || !required)

                    return input;
                Console.WriteLine("You must enter a value");
            };

        }
        // A movie
        static string name;
        static string desciption;
        static int runLength;
        // static DateTime releaseDate;
    }
}


