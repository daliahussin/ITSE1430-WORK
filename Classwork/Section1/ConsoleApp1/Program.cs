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
            
    //DisplayMenu();
        PlayWithStrings();
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

    private static void DisplayMenu()
    {
        Console.WriteLine("A)dd Movie");
        Console.WriteLine("E)dit Movie");
        Console.WriteLine("D)elete Movie");
        Console.WriteLine("V)iew Movies");
        Console.WriteLine("Q)uit");

        string input = Console.ReadLine();
        switch (input[0])//(input[0]) searches for a character in a string - strings are not arrays in C#
        {
            case 'A': AddMovie(); break; //required in C# - every case statement requires a break
            case 'E': EditMovie(); break;
            case 'D': DeleteMovie(); break;
            case 'V': ViewMovies(); break;
            case 'Q':; break;

            default: Console.WriteLine("Please enter a valid value."); break;
        };
    }

    private static void AddMovie()
    {
        throw new NotImplementedException();
    }

    private static void EditMovie()
    {
        throw new NotImplementedException();
    }

    private static void ViewMovies()
    {
        throw new NotImplementedException();
    }

    private static void DeleteMovie()
    {
        throw new NotImplementedException();
    }
}
}
    }
}
