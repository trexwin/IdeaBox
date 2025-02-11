namespace IdeaBox.Storage
{
    public interface IStorage<T> where T: class
    {
        public Task<T> StoreValue(T obj);
        public Task<IEnumerable<T>> LoadValues();
    }
}
