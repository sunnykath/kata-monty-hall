using System;
using System.Linq;

namespace MontyHallKata.Models.Randomizer
{
    public class CustomRandomizer : IRandomizer
    {
        public T[] GetRandomizedArray<T>(T[] array)
        {
            var random = new Random();
            return array.OrderBy(_ => random.Next()).ToArray();
        }
    }
}