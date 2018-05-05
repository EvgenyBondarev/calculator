using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This simple application allows you performing some basic operations with two digits. The following operations are supported: adding, subtracting, multiplicating, and dividing");

            //parameter of the invoked method is used for placing the number's index (1 or 2) in the message for users
            float digit1 = GetInputDouble(1);
            float digit2 = GetInputDouble(2);
            float result = CheckOperand(digit1, digit2);

            //if result equals infinity then the user tried to divide by zero
            if (float.IsInfinity(result))
            {
                Console.WriteLine("One does not simply divides by zero");
            }
            else
            {
                Console.WriteLine("Result = " + result);
            }

            Console.ReadLine();
        }

        private static float GetInputDouble(int order)
        {
            //asks for the number 1 and number 2
            float number = 0;
            Console.WriteLine(string.Format("Please enter the digit #{0}: ", order));

            //uses the typical US format for digits where points are used for float numbers. Inupt with a comma will be treated as a wrong format
            if (float.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.Float, new CultureInfo("en-US"), out number) == false)
            {
                Console.WriteLine("You've entered a comma. Please consider entering a point (dot) instead");
                return GetInputDouble(order);
            }

            return number;
        }

        private static float CheckOperand(float digit1, float digit2)
        {
            //asks for an operand
            Console.WriteLine("Please enter the required action you need to perform with the digits: ");
            Console.WriteLine("Make sure that you've entered one of the following symbols: +, -, *, /");
            string operand = Console.ReadLine();

            //makes the necessary calculations;
            switch (operand)
            {
                case "+":
                    return digit1 + digit2;
                case "-":
                    return digit1 - digit2;
                case "*":
                    return digit1 * digit2;
                case "/":
                    return digit1 / digit2;
                default:
                    //in case if the user enters a non-supported operand, asks for a correct operand once again with the help of recursion
                    Console.WriteLine("You've entered the action that is not supported by this application");
                    return CheckOperand(digit1, digit2);
            }

        }
    }
}
