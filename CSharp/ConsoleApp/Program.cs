using ConsoleApp.Delegates;
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
            var example = new EventExample();
            example.Test();

            System.Console.ReadLine();
        }
    }
}
