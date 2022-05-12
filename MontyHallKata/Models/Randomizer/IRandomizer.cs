using System;

namespace MontyHallKata.Models.Randomizer
{
    public interface IRandomizer
    {
        public T[] GetRandomizedArray<T>(T[] array);

        public int GetRandomNumber(int min = 0, int max = int.MaxValue);
    }
}