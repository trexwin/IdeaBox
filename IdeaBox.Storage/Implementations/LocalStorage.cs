using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Xml.Serialization;

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
            var files = Directory.EnumerateFiles(_localFolderPath, "*.xml").Select(Path.GetFileNameWithoutExtension);
            var ids = files.Where(s => int.TryParse(s, out int tmp)).Select(int.Parse); // Can not be null

            _id = ids.Any() ? ids.Max() + 1 : 0;
        }

        public Task<T> StoreValue(T obj)
        {
            obj.Id = _id++;
            obj.CreationDate = DateTime.Now;

            var serializer = new XmlSerializer(typeof(T));
            var path = Path.Combine(_localFolderPath, $"{obj.Id}.xml");
            using (var writer = new StreamWriter(path, false))
            {
                serializer.Serialize(writer, obj);
            }

            return Task.FromResult(obj);
        }

        public Task<IEnumerable<T>> LoadValues()
        {
            var list = new List<T>();
            var serializer = new XmlSerializer(typeof(T));
            foreach (string file in Directory.EnumerateFiles(_localFolderPath, "*.xml"))
            {
                object? val = null;
                using (var reader = new StreamReader(file))
                {
                    val = serializer.Deserialize(reader);
                }
                
                if (val is T tVal)
                    list.Add(tVal);
            }
            return Task.FromResult(list.AsEnumerable());
        }
            
    }
}
