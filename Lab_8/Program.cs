using System;
using System.Transactions;

namespace Lab_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ch;
            do
            {
                Console.Write("Enter task (1 - 3): ");
                ch = int.Parse(Console.ReadLine());
                switch (ch) 
                {
                    case 1:
                        Drib a = new Drib(2, 5);
                        Drib b = new Drib(1, 8);
                        Console.WriteLine("Add drib:");
                        Drib c = a + b;
                        Console.WriteLine($"{c.x}/{c.y}");
                        Console.WriteLine("Subtraction drib:");
                        Drib d = a - b;
                        Console.WriteLine($"{d.x}/{d.y}");
                        Console.WriteLine("Multiply drib:");
                        Drib e = a * b;
                        Console.WriteLine($"{e.x}/{e.y}");
                        Console.WriteLine("Divide drib:");
                        Drib f = a / b;
                        Console.WriteLine($"{f.x}/{f.y}");
                        break;
                    case 2:
                        Complex c1 = new Complex(7, -4);
                        Complex c2 = new Complex(3, 2);
                        Console.WriteLine("First complex number: " + c1.x + " + " + c1.i + "i");
                        Console.WriteLine("Second complex number: " + c2.x + " + " + c2.i + "i");
                        Console.WriteLine("Add complex number:");
                        Complex add = c1 + c2;
                        if(add.i <= 0)
                        {
                            Console.WriteLine($"{add.x}{add.i}i");
                        }
                        else 
                        {
                            Console.WriteLine($"{add.x}+{add.i}i");
                        }
                        Console.WriteLine("Subtract complex number:");
                        Complex sub = c1 - c2;
                        if (sub.i <= 0)
                        {
                            Console.WriteLine($"{sub.x}{sub.i}i");
                        }
                        else
                        {
                            Console.WriteLine($"{sub.x}+{sub.i}i");
                        }
                        Console.WriteLine("Mult complex number:");
                        Complex mult = c1 * c2;
                        if (mult.i <= 0)
                        {
                            Console.WriteLine($"{mult.x}{mult.i}i");
                        }
                        else 
                        {
                            Console.WriteLine($"{mult.x}+{mult.i}i");
                        }
                        Console.WriteLine("Divide complex number:");
                        Complex div = c1 / c2;
                        if (div.i <= 0)
                        {
                            Console.WriteLine($"{div.x}{div.i}i");
                        }
                        else 
                        {
                            Console.WriteLine($"{div.x}+{div.i}i");
                        }
                        break;
                    case 3:
                        Birthday myBirthday = new Birthday(2005, 4, 1);
                        Console.WriteLine($"I borned on {myBirthday.DayOfWeekOfBirthday()}");
                        Console.WriteLine($"In 2025 year my birthay will be on {myBirthday.DayOfWeekOfBirthdayInYear(2025)}");
                        Console.WriteLine($"The day of my birthday will be : {myBirthday.DaysUntilBirthday()}");
                        break;
                    default:
                        Console.WriteLine("Error!");
                        break;
                }
            } while (ch < 1 || ch > 3);
        }
    }



    struct Drib
    {
        public int x;
        public int y;

        public Drib(int X, int Y)
        {
            x = X; 
            y = Y;
        }

        public static Drib operator +(Drib a, Drib b)
        {
            int numerator = (a.x * b.y) + (b.x * a.y);
            int denominator = a.y * b.y;
            return new Drib(numerator, denominator);
        }

        public static Drib operator -(Drib a, Drib b)
        {
            int numerator = (a.x * b.y) - (b.x * a.y);
            int denominator = a.y * b.y;
            return new Drib(numerator, denominator);
        }

        public static Drib operator *(Drib a, Drib b)
        {
            int numerator = a.x * b.x;
            int denominator = a.y * b.y;
            return new Drib(numerator, denominator);
        }

        public static Drib operator /(Drib a, Drib b)
        {
            int numerator = a.x * b.x;
            int denominator = a.y * b.x;
            return new Drib(numerator, denominator);
        }
    }



    struct Complex
    {
        public double x;
        public double i;

        public Complex(double X, double I)
        {
            x = X;
            i = I;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            double integ = (a.x + b.x);
            double com = (a.i + b.i);
            return new Complex(integ, com);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            double integ = (a.x - b.x);
            double com = (a.i - b.i);
            return new Complex(integ, com);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            double integ = ((a.x * b.x) - (a.i * b.i));
            double com = ((a.x * b.i) + (a.i * b.x));
            return new Complex(integ, com);
        }
        public static Complex operator /(Complex a, Complex b)
        {
            double denominator = b.x * b.x + b.i * b.i;
            double integ = a.x * b.x + a.i * b.i;
            double com = a.i * b.x - a.x * b.i;
            return new Complex(integ / denominator, com / denominator);
        }
    }



    struct Birthday
    {
        private DateTime dateOfBirth;

        public Birthday(int year, int month, int day)
        {
            this.dateOfBirth = new DateTime(year, month, day);
        }

        public string DayOfWeekOfBirthday()
        {
            return dateOfBirth.DayOfWeek.ToString();
        }

        public string DayOfWeekOfBirthdayInYear(int year)
        {
            DateTime nextBirthday = new DateTime(year, dateOfBirth.Month, dateOfBirth.Day);
            return nextBirthday.DayOfWeek.ToString();
        }

        public int DaysUntilBirthday()
        {
            DateTime today = DateTime.Today;
            DateTime nextBirthday = new DateTime(today.Year, dateOfBirth.Month, dateOfBirth.Day);

            if (nextBirthday < today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }

            return (nextBirthday - today).Days;
        }
    }
}