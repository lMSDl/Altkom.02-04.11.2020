using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class DelegateExample
    {
        public delegate void NoParametersNoReturnDelegate();
        public delegate void ParametersNoReturnDelegate(string @string);
        public delegate bool ParametersDelegate(int a, int b);

        public void Func1()
        {
            Console.WriteLine(nameof(Func1));
        }

        public void Func2(string param)
        {
            Console.WriteLine($"{nameof(Func2)}: {param}");
        }

        public bool Func3(int x, int y) {
            Console.WriteLine($"{nameof(Func3)}: {x} {y}");
            return x == y;
        }

        public ParametersDelegate Delegate3 {get; set;}

        public void Test()
        {
            var delegate1 = new NoParametersNoReturnDelegate(Func1);
            delegate1();

            ParametersNoReturnDelegate delegate2 = null;
            delegate2 = Func2;
            //if (delegate2 != null)
            //    delegate2("param");
            delegate2?.Invoke("param");

            Delegate3 += Func3;

            for (var i = 0; i < 3; i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    if(Delegate3(i, ii))
                        Console.WriteLine($"{i} == {ii}");
                    else
                        Console.WriteLine($"{i} != {ii}");
                }
            } 
        }
    }
}
