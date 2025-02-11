
namespace IdeaBox.Storage
{
    public abstract class BaseStorage<T, U> : IStorage<T> where T : class where U : class, IStorageItem
    {
        protected int _id;

        public BaseStorage(int id)
            => _id = id;

        public async Task<IEnumerable<T>> LoadValues()
            => (await GetValuesFromStorage()).Select(ToMemory);

        public async Task<T> StoreValue(T obj)
        {
            var val = ToStorage(obj);
            
            val.Id = _id++;
            val.CreationDate = DateTime.Now;

            return ToMemory(await PutValueInStorage(ToStorage(obj)));
        }

        protected abstract Task<IEnumerable<U>> GetValuesFromStorage();
        protected abstract  Task<U> PutValueInStorage(U obj);

        protected abstract U ToStorage(T obj);
        protected abstract T ToMemory(U obj);

    }
}
