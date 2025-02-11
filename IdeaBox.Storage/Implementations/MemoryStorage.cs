
namespace IdeaBox.Storage.Implementations
{
    /// <summary>
    /// Implementation of IStorage which stores the results in local memory.
    /// </summary>
    public class MemoryStorage<T> : IStorage<T> where T : class, IStorageItem
    {
        private List<T> _values;
        private int _id;

        public MemoryStorage()
        {
            _values = new List<T>();
            _id = 0;
        }

        public Task<T> StoreValue(T obj)
        {
            obj.Sanitise();
            obj.Id = _id++;
            obj.CreationDate = DateTime.Now;

            _values.Add(obj);
            return Task.FromResult(obj);
        }

        public Task<IEnumerable<T>> LoadValues()
            => Task.FromResult(_values.AsEnumerable());
    }
}
