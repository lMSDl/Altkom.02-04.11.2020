using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Operators
{
    public class OperatorsExample
    {
        class Box
        {
            public float Length { get; set; }
            public float Height { get; set; }
            public float Breadth { get; set; }

            public float Volume => Length * Height * Breadth;

            public static Box operator +(Box a, Box b)
            {
                return new Box { Length = a.Length + b.Length, Breadth = a.Breadth + b.Breadth, Height = a.Height + b.Height };
            }

            public static bool operator ==(Box a, Box b)
            {
                return a.Volume == b.Volume;
            }
            public static bool operator !=(Box a, Box b)
            {
                return a.Volume != b.Volume;
            }
        }

        public void Test()
        {
            var box1 = new Box() { Length = 1, Breadth = 1, Height = 1 };
            var box2 = new Box() { Length = 1, Breadth = 3, Height = 5 };

            var box3 = box1 + box2;
            var box4 = box1 + box2;

            Console.WriteLine(box3 == box4);
            Console.WriteLine(box3.Equals(box4));
        }
    }
}
