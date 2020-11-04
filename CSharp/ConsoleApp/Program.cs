using ConsoleApp.Delegates;
using ConsoleApp.Indexers;
using ConsoleApp.Lambda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new IndexerExample();
            example.Test();

            ServiceReference3.ICalculator calculator = new ServiceReference3.CalculatorClient();
            Console.WriteLine(  calculator.Multiply(3, 5));

            ServiceReference2.IDALService dal = new ServiceReference2.DALServiceClient();
            var educators = dal.Read();

            Nullable<int> a = null;
            int? b = 5;
            int c;

            if(a - b == 0 || a - b == null)
            {
                c = (a + b) ?? 0;
            }
            else
            {
                var result = a - b;
                if (result.HasValue)// (result != null)
                    c = result.Value;
                else
                    c = 0;
            }

            c = (a - b == 0 || a - b == null) ? ((a + b) ?? 0) : (a - b ?? 0);
            c = ((a - b == 0 || a - b == null) ? (a + b) : (a - b)) ?? 0;


            System.Console.ReadLine();
        }
    }
}
