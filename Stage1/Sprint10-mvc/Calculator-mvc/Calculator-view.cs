using System;

namespace Calculator_mvc
{
    class Calculator_view
    {
        public string SendWelcome()
        {
            // Ask the user to type the first number.
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("  Welcome to simple calculator...Continue(y/n)?: ");          
            return Console.ReadLine(); 
        }
        public double GetFirstInput()
        {
            // Ask the user to type the first number.
            Console.Write("  Type a number, and then press Enter: ");
            string numInput1 = Console.ReadLine();
            double num = 0;
            while (!double.TryParse(numInput1, out num))  // discards result of parse
            {
                Console.Write("  This is not valid input. Please enter an integer value: ");
                numInput1 = Console.ReadLine();
            }
            return num;
        }

        public double GetSecondtInput()
        {
            // Ask the user to type the second number.
            Console.Write("  Type another number, and then press Enter: ");
            string numInput2 = Console.ReadLine();
            double num = 0;
            while (!double.TryParse(numInput2, out num)) // discards result of parse
            {
                Console.Write("  This is not valid input. Please enter an integer value: ");
                numInput2 = Console.ReadLine();
            }
            return num;
        }

        public string GetOperand()
        {
            // Ask the user to choose an operator.
            Console.WriteLine("  Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.WriteLine("\tQ - Quit");
            Console.Write("  Your option? ");
            string op = Console.ReadLine();
            return op;
        }
        public void ShowResults(double result)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("  Result is..... " + result);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

        public void ShowError(string result)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(result);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
    }
}
