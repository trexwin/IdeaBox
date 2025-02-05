namespace IdeaBox.Storage
{
    public interface IStorage<T> where T: class, IStorageItem
    {
        public Task<T> StoreValue(T obj);
        public Task<IEnumerable<T>> LoadValues();
    }
}
