using System;
using System.Linq;

namespace MontyHallKata.Models.Randomizer
{
    public class DefaultRandomizer : IRandomizer
    {
        private readonly Random _random = new();
        public T[] GetRandomizedArray<T>(T[] array)
        {
            return array.OrderBy(_ => _random.Next()).ToArray();
        }

        public int GetRandomNumber(int min = 0, int max = int.MaxValue)
        {
            return _random.Next(min, max);
        }
    }
}