using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            Play:
            Console.WriteLine("Welcome.");
            Console.WriteLine("Enter your name to continue.");
            Console.Write("Name:");
            string Name="";
            Name = Console.ReadLine();
            Console.WriteLine("Greetings "+ Name);
            Console.WriteLine(Name+" When is your birthday");

            string Year;
            string Error = "";
            do
            {
                if(Error!=string.Empty)
                    Console.WriteLine(Error);
                Console.Write("Year:");
                Year = Console.ReadLine();
            } while (Year != null && !IsValidYear(Year,out Error)) ;


            string Month;
            Error = "";
            do
            {
                if (Error != string.Empty)
                    Console.WriteLine(Error);
                Console.Write("Month:");
                Month = Console.ReadLine();
            } while (Month != null && !IsValidMonth(Month, out Error));

            string Day;
            Error = "";
            do
            {
                if (Error != string.Empty)
                    Console.WriteLine(Error);
                Console.Write("Day:");
                Day = Console.ReadLine();
            } while (Day != null && !IsValidDay(Day, out Error));

            DateTime BirthDay = DateTime.ParseExact(string.Format(Day+"{0}"+Month+ "{0}"+Year,"/"), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime BirthDayThisYear= DateTime.ParseExact(string.Format(Day + "{0}" + Month + "{0}" + DateTime.Today.Year.ToString(), "/"), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(Name + " you are born on "+ BirthDay.ToString("dd/MM/yyyy"));
            int Age = 0;
            if (DateTime.Today >= BirthDayThisYear)
            {
                Age = (DateTime.Today.Year - BirthDay.Year);
            }
            else
            {
                Age = (DateTime.Today.Year-1 - BirthDay.Year);
            }

            Console.WriteLine( "You are " + Age.ToString()+" old");

            Console.WriteLine("Do you know in fibonacci sequence your age "+ Age.ToString() + " will result to "+ fibonacci(Age).ToString());

            Console.WriteLine("Replay Y/N");
            string Replay = Console.ReadLine();
            if(Replay=="Y")
            {
                goto Play;
            }

        }

        private static bool IsValidYear(string Year,out string strError)
        {
            bool IsValid = false;
            strError = string.Empty;
            try
            {
                int myInt;
                bool isNumerical = int.TryParse(Year, out myInt);
                if (!isNumerical)
                {
                    strError = "Year entered is not numeric";
                }
                else
                {
                    if (myInt > DateTime.Today.Year)
                    {
                        strError = "You are unborn.";
                    }
                    else if (myInt < 1800)
                    {
                        strError = "Are you still alive";
                    }
                    else
                    {
                        strError = "";
                        IsValid = true;
                    }

                }               
            }
            catch (Exception ex)
            {
                strError = "Please enter an year";
            }
            return IsValid;
        }

        private static bool IsValidMonth(string Month, out string strError)
        {
            bool IsValid = false;
            strError = string.Empty;
            try
            {
                int myInt;
                bool isNumerical = int.TryParse(Month, out myInt);
                if (!isNumerical)
                {
                    strError = "Month entered is not numeric";
                }
                else
                {
                    if (myInt > 12)
                    {
                        strError = "Invalid Month";
                    }
                    else if (myInt < 1)
                    {
                        strError = "Invalid Month";
                    }
                    else
                    {
                        strError = "";
                        IsValid = true;
                    }

                }
            }
            catch (Exception ex)
            {
                strError = "Please enter a valid month";
            }
            return IsValid;
        }

        private static bool IsValidDay(string Day, out string strError)
        {
            bool IsValid = false;
            strError = string.Empty;
            try
            {
                int myInt;
                bool isNumerical = int.TryParse(Day, out myInt);
                if (!isNumerical)
                {
                    strError = "Day entered is not numeric";
                }
                else
                {
                    if (myInt > 31)
                    {
                        strError = "Invalid Day";
                    }
                    else if (myInt < 1)
                    {
                        strError = "Invalid Day";
                    }
                    else
                    {
                        strError = "";
                        IsValid = true;
                    }

                }
            }
            catch (Exception ex)
            {
                strError = "Please enter a valid day";
            }
            return IsValid;
        }

        private static int fibonacci(int n)
        {
            int m = 0;
            int p = 1;
            for (int i= 0;i < n-1;i++)
            {               
                int k = p;              
                p = m + p;
                m = k;
               
            }
            return p;
        }

    }
}
