using System;
using System.Linq;

namespace MontyHallKata
{
    public class Shuffler : IShuffle
    {
        public T[] GetShuffledArray<T>(T[] array)
        {
            var random = new Random();
            return array.OrderBy(_ => random.Next()).ToArray();
        }
    }
}