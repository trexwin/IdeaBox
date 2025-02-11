using System.Text.Json;

namespace IdeaBox.Storage.Implementations
{
    /// <summary>
    /// Provides a basis for an implementation of IStorage which stores the results on the local machine.
    /// </summary>
    public abstract class BaseLocalStorage<T, U> : BaseStorage<T, U> where T : class where U : class, IStorageItem
    {
        private string _localFolderPath;

        public BaseLocalStorage(string localFolderPath) : base(0)
        {
            _localFolderPath = localFolderPath;

            var files = Directory.EnumerateFiles(_localFolderPath, "*.json").Select(Path.GetFileNameWithoutExtension);
            var ids = files.Select(s => int.TryParse(s, out int tmp) ? tmp : -1);

            if(ids.Any())
                _id = ids.Max() + 1;
        }

        protected override Task<IEnumerable<U>> GetValuesFromStorage()
        {
            if (!Directory.Exists(_localFolderPath))
                return Task.FromResult(Enumerable.Empty<U>());

            var files = Directory.GetFiles(_localFolderPath, "*.json").Select(File.ReadAllText);

            var values = new List<U>();
            foreach (var file in files)
            {
                var val = JsonSerializer.Deserialize<U>(file);
                if (val != null)
                    values.Add(val);
            }
            return Task.FromResult(values.AsEnumerable());
        }

        protected override Task<U> PutValueInStorage(U obj)
        {
            var jsonString = JsonSerializer.Serialize(obj);
            var path = Path.Combine(_localFolderPath, $"{obj.Id}.json");
            File.WriteAllText(path, jsonString);

            return Task.FromResult(obj);
        }
    }
}
