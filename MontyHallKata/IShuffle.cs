namespace MontyHallKata
{
    public interface IShuffle
    {
        public T[] GetShuffledArray<T>(T[] array);
    }
}