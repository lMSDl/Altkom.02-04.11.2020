using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Calculator" in both code and config file together.
    public class Calculator : ICalculator
    {
        public float Add(float a, float b)
        {
            return a + b;
        }

        public float Divide(float a, float b)
        {
            return a / b;
        }

        public float Multiply(float a, float b)
        {
            return a * b;
        }

        public float Substract(float a, float b)
        {
            return a - b;
        }
    }
}
