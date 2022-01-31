using System;
using System.IO;
using System.Text.Json;

namespace CSharpUtils
{
    /// <summary>
    /// FileMan (short for File Manager) does
    /// JSON serialization / deserialization
    /// to and from files.
    /// </summary>
    public class FileMan<T>
    {
        private string _path;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">Path of the file to save objects to/load objects from.</param>
        public FileMan(string path)
        {
            _path = path + ".json";
        }
        /// <summary>
        /// Create or overwrite the file with this object that will be serialized.
        /// </summary>
        /// <param name="obj">The object to serialize and save to the file.</param>
        public void Serialize(T obj)
        {
            var json = JsonSerializer.Serialize(obj);
            File.WriteAllText(_path, json);
        }
        /// <summary>
        /// Deserialize the object from the file specified.
        /// </summary>
        /// <returns></returns>
        public T Deserialize()
        {
            return JsonSerializer.Deserialize<T>(File.ReadAllText(_path));
        }
        /// <summary>
        /// Set the file path this instance uses.
        /// </summary>
        /// <param name="path">The new file path to change it to.</param>
        public void SetPath(string path)
        {
            _path = path + ".json";
        }
        /// <summary>
        /// Get the file path this instance uses..
        /// </summary>
        /// <returns>The file path this instance uses.</returns>
        public string GetPath()
        {
            return _path;
        }
    }
}