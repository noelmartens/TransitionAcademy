using System;
using System.Collections.Generic;
using System.Text;


namespace Calculator_mvc
{
    class Calculator_controller
    {
        private double input1;
        private double input2;
        private string op;
        private double result;
        Boolean enterMore = true;
        Calculator_view v = new Calculator_view();
        Calculator_model m = new Calculator_model();

        public Calculator_controller()
        {
            while (enterMore)
            {
                op = v.SendWelcome().ToUpper();
                if (op == "N")
                {
                    enterMore = false;
                    break;
                }
                input1 = v.GetFirstInput();
                input2 = v.GetFirstInput();
                op = v.GetOperand();
                switch (op)
                {
                    case "a":
                        result = m.AddOperation(input1, input2);
                        v.ShowResults(result);
                        break;

                    case "s":
                        result = m.SubOperation(input1, input2);
                        v.ShowResults(result);
                        break;

                    case "m":
                        result = m.MultOperation(input1, input2);
                        v.ShowResults(result);
                        break;

                    case "d":
                        // Ask the user to enter a non-zero divisor.
                        if (input2 != 0)
                        {
                            result = m.DivOperation(input1, input2);
                            v.ShowResults(result);
                            break;

                        }

                        // throw an error
                        v.ShowError("You can't divide by zero.  Retry");
                        break;


                    case "q":
                        enterMore = false;           
                        break;


                    default:
                        break;
                }

            }
        }

    }
}
