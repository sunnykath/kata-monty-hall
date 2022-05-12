namespace MontyHallKata.Models.Randomizer
{
    public interface IRandomizer
    {
        public T[] GetRandomizedArray<T>(T[] array);
    }
}