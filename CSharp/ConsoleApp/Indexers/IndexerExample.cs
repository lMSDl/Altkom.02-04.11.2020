using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Indexers
{
    public class IndexerExample
    {
        public class StringDataStore
        {
            private string[] strings = new string[10];

            public string this[int index]
            {
                get
                {
                    if (index >= strings.Length || index < 0)
                        return null;
                    return strings[index];
                }
                set
                {
                    if (index < strings.Length && index >= 0)
                        strings[index] = value;
                }
            }

            public int this[string data]
            {
                get
                {
                    //if (!strings.Contains(data))
                    if (!strings.Any(x => x == data))
                        return -1;
                    return strings.ToList().IndexOf(data);
                    //return strings.Select((value, index) => new { value, index }).Where(x => x.value == data).Select(x => x.index).First();
                }
            }

            public void SetString(int index, string value)
            {
                this[index] = value;
            }

            public string GetString(int index)
            {
                return this[index];
            }
        }

        public void Test()
        {
            var dataStore = new StringDataStore();
            dataStore.SetString(0, "1");
            dataStore.SetString(1, "two");
            dataStore.SetString(2, "III");

            dataStore[3] = "4";
            dataStore[4] = "five";
            dataStore[5] = "IV";

            var index = dataStore["five"];
            dataStore[index] = "5";

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(dataStore[i]);
            }
        }
    }
}
