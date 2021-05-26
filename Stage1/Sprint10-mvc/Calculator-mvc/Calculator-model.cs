using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_mvc
{
    class Calculator_model
    {
        // Declare variables and set to empty.
        public Calculator_model()
        {

        }
        public double AddOperation(double num1, double num2) 
        {
            return ( num1 + num2) ;
        }

        public double SubOperation(double num1, double num2)
        {
            return (num1 - num2);
        }

        public double MultOperation(double num1, double num2)
        {
            return (num1 * num2);
        }

        public double DivOperation(double num1, double num2)
        {
            return (num1 / num2);
        }
    }
}
