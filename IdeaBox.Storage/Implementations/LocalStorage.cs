using System.Text.Json;

namespace IdeaBox.Storage.Implementations
{
    public class LocalStorage<T> : IStorage<T> where T : class, IStorageItem
    {
        private int _id;
        private string _localFolderPath;

        public LocalStorage(string localFolderPath)
        {
            if (!Directory.Exists(localFolderPath))
                throw new DirectoryNotFoundException($"The directory \"{localFolderPath}\" does not exist.");

            _localFolderPath = localFolderPath;

            // Retrieve highest id
            var files = Directory.EnumerateFiles(_localFolderPath, "*.json").Select(Path.GetFileNameWithoutExtension);
            var ids = files.Select(s => int.TryParse(s, out int tmp) ? tmp : -1);
            _id = ids.Any() ? ids.Max() + 1 : 0;
        }

        public Task<T> StoreValue(T obj)
        {
            obj.Sanitise();
            obj.Id = _id++;
            obj.CreationDate = DateTime.Now;

            var jsonString = JsonSerializer.Serialize(obj);
            var path = Path.Combine(_localFolderPath, $"{obj.Id}.json");
            File.WriteAllText(path, jsonString);

            return Task.FromResult(obj);
        }

        public Task<IEnumerable<T>> LoadValues()
        {
            if (!Directory.Exists(_localFolderPath))
                return Task.FromResult(Enumerable.Empty<T>());

            var files = Directory.GetFiles(_localFolderPath, "*.json").Select(File.ReadAllText);

            var values = new List<T>();
            foreach (var file in files)
            {
                var val = JsonSerializer.Deserialize<T>(file);
                if(val != null)
                    values.Add(val);
            }
            return Task.FromResult(values.AsEnumerable());
        }
    }
}
