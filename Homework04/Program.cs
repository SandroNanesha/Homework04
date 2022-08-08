using System;
using System.Linq;

namespace Homework04
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomGenericList<int> _listOfIntegers = new CustomGenericList<int>();
            _listOfIntegers.Add(1);
            //_listOfIntegers.Add(0);
            //_listOfIntegers.Add(1);

            _listOfIntegers.Remove(1);

            Console.WriteLine(_listOfIntegers.ElementAt(0) == 0);

            Console.WriteLine($"Btw, you can use this place as a playground to try some methods of your CustomGenericList<T>");
        }
    }
}