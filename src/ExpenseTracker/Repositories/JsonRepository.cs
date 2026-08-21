using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;
using ExpenseTracker.Repositories.Utility;

namespace ExpenseTracker.Repositories
{
    /// <summary>
    /// Provides an in-memory implementation of <see cref="IRepository{T}"/> for storing
    /// and managing entries during the application's lifetime.
    /// </summary>
    /// <typeparam name="T">
    /// The type of entry managed by the repository. The type must implement
    /// <see cref="IEntry"/>.
    /// </typeparam>
    public class JsonRepository<T> : IRepository<T>
        where T : IEntry
    {
        private readonly List<T> _repository;
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRepository{T}"/> class.
        /// </summary>
        /// <param name="filePath">
        /// The path to the JSON file used for repository persistence.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="filePath"/> is <see langword="null"/>, empty, or consists only of white-space characters.
        /// </exception>
        public JsonRepository(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException($"'{nameof(filePath)}' cannot be null or whitespace.", nameof(filePath));
            }

            this._filePath = filePath;
            this.CreateFileIfNotExists();

            this._jsonSerializerOptions = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Converters = { new JsonDateOnlyConverter(), },
            };
            this._repository = this.LoadAllEntries();
        }

        /// <inheritdoc/>
        public bool Add(T entry)
        {
            this._repository.Add(entry);
            this.WriteToFile();

            return true;
        }

        /// <inheritdoc/>
        public bool Contains(Guid id)
        {
            return this._repository.Any(entry => entry.Id == id);
        }

        /// <inheritdoc/>
        public bool Delete(Guid id)
        {
            int removeCount = this._repository.RemoveAll(entry => entry.Id == id);

            if (removeCount > 0)
            {
                this.WriteToFile();
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Edit(Guid id, T updatedEntry)
        {
            T oldEntry = this.GetById(id);
            oldEntry.Id = updatedEntry.Id;
            oldEntry.Amount = updatedEntry.Amount;
            oldEntry.Date = updatedEntry.Date;
            oldEntry.Category = updatedEntry.Category;

            this.WriteToFile();

            return true;
        }

        /// <inheritdoc/>
        public List<T> GetAll()
        {
            return this._repository.Select(item => (T)item.Clone()).ToList();
        }

        /// <inheritdoc/>
        public int GetEntriesCount()
        {
            return this._repository.Count;
        }

        /// <inheritdoc/>
        public Guid GetIdByIndex(int index)
        {
            return this._repository[index].Id;
        }

        /// <inheritdoc/>
        public bool IsEmpty()
        {
            return this._repository.Count == 0;
        }

        /// <inheritdoc/>
        public decimal GetTotalAmount()
        {
            return this._repository.Sum(entry => entry.Amount);
        }

        private T GetById(Guid id)
        {
            return this._repository.FirstOrDefault(entry => entry.Id == id) !;
        }

        private void CreateFileIfNotExists()
        {
            if (!File.Exists(this._filePath))
            {
                using (File.Create(this._filePath))
                {
                    return;
                }
            }
        }

        private List<T> LoadAllEntries()
        {
            string jsonData = File.ReadAllText(this._filePath);

            return JsonSerializer.Deserialize<List<T>>(jsonData, this._jsonSerializerOptions)
                    ?? new List<T>();
        }

        private void WriteToFile()
        {
            string json = JsonSerializer.Serialize<List<T>>(this._repository, options: this._jsonSerializerOptions);
            File.WriteAllText(this._filePath, json);
        }
    }
}
