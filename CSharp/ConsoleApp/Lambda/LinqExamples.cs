using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lambda
{
    public class LinqExamples
    {
        int[] numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        List<string> strings = "Wlazł kotek na płotek i mruga".Split(' ').ToList();

        List<Student> students = new List<Student>
        {
            new Student { FirstName = "Adam", LastName = "Adamski", BirthDate = new DateTime(1978, 2, 21) },
            new Student { FirstName = "Ewa", LastName = "Ewowska", BirthDate = new DateTime(1990, 1, 1), Gender = Genders.Female  } ,
            new Student { FirstName = "Adam", LastName = "Ewowska", BirthDate = new DateTime(1978, 2, 21) },
            new Student { FirstName = "Ewa", LastName = "Adamska", BirthDate = new DateTime(1990, 1, 1), Gender = Genders.Female  } ,
            new Student { FirstName = "Piotr", LastName = "Adamski", BirthDate = new DateTime(1978, 2, 21) },
            new Student { FirstName = "Kamila", LastName = "Ewowska", BirthDate = new DateTime(1990, 1, 1), Gender = Genders.Female  }
        };

        public void Test()
        {
            var result = from x in numbers where x <= 4 select x;
                result = from number in numbers where number <= 4 || number >= 9 select number;

            result = numbers.Where(number => number <= 4 || number >= 9).ToList();

            result = (from @string in strings select @string.Length).OrderByDescending(x => x);

            var stringsResult = strings.OrderByDescending(x => x.Length).ToList();
            stringsResult = strings.OrderByDescending(x => x.Length).ThenBy(x => x).Select(x => x.ToUpper()).ToList();

            var singleString = strings.Where(x => x.Contains("x")).FirstOrDefault();

            singleString = students.Aggregate("", (a, b) => string.IsNullOrEmpty(a) ? $"{b.FirstName} {b.LastName}" : $"{a}, {b.FirstName} {b.LastName}");

            var numberResult = numbers.Sum();
            numberResult = students.Sum(x => DateTime.Today.Year - x.BirthDate.Year);
        }

    }
}
