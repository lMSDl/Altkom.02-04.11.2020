using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class BuildinDelegatesExample
    {
        public event EventHandler<OddNumberEventArgs> OddNumberEvent;

        public void Add(int a, int b)
        {
            var result = a + b;
            Console.WriteLine(result);

            if (result % 2 != 0)
                OddNumberEvent?.Invoke(this, new OddNumberEventArgs { Result = result });
        }
        public bool Substract(int a, int b)
        {
            var result = a - b;
            Console.WriteLine(result);
            return result % 2 != 0;
        }

        private int _counter = 0;

        void CountOddNumbers()
        {
            _counter++;
        }

        public void Test()
        {
            OddNumberEvent += BuildinDelegatesExample_OddNumberEvent1;
            OddNumberEvent += BuildinDelegatesExample_OddNumberEvent2;

            NewMethod(Add, Substract);

            Console.WriteLine($"Counter = {_counter}");
        }

        private void BuildinDelegatesExample_OddNumberEvent1(object sender, OddNumberEventArgs e)
        {
            Console.WriteLine($"** Wykryto liczbę **: {e.Result}");
        }
        private void BuildinDelegatesExample_OddNumberEvent2(object sender, EventArgs e)
        {
            CountOddNumbers();
        }

        //public delegate void Delegate1(int a, int b);
        //public delegate bool Delegate2(int a, int b);

        private void NewMethod(Action<int, int> a, Func<int, int, bool> b)
        {
            for (var i = 0; i < 3; i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    a(i, ii);
                    b(i, ii);
                }
            }
        }

        public class OddNumberEventArgs : EventArgs
        {
            public int Result { get; set; }
        }
    }
}
