using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repositories
{
    /// <summary>
    /// Provides a CSV-based implementation of <see cref="IRepository{T}"/> for
    /// persisting and retrieving entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The entity type managed by the repository. The type must implement
    /// <see cref="IEntry"/> and expose a parameterless constructor.
    /// </typeparam>
    public class CSVRepository<T>
        : IRepository<T>
        where T : IEntry, new()
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVRepository{T}"/> class.
        /// </summary>
        /// <param name="filePath">The path where the entries will be stored.</param>
        public CSVRepository(string filePath)
        {
            this._filePath = filePath;
            this.Initialize();
        }

        /// <inheritdoc/>
        public bool Add(T entry)
        {
            string csvRow = $"{entry.Id},{entry.Amount},{entry.Date},{entry.Category}{Environment.NewLine}";
            File.AppendAllText(this._filePath, csvRow);

            return true;
        }

        /// <inheritdoc/>
        public bool Contains(Guid id)
        {
            return this.GetAll().Any(item => item.Id == id);
        }

        /// <inheritdoc/>
        public bool Delete(Guid id)
        {
            List<T> entries = this.GetAll();
            int removeCount = entries.RemoveAll(item => item.Id == id);

            if (removeCount > 0)
            {
                this.WriteEntries(entries);
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Edit(Guid id, T entry)
        {
            List<T> entries = this.GetAll();

            T? oldEntry = entries.FirstOrDefault(item => item.Id == id);
            if (oldEntry is null)
            {
                return false;
            }

            oldEntry.Id = entry.Id;
            oldEntry.Amount = entry.Amount;
            oldEntry.Date = entry.Date;
            oldEntry.Category = entry.Category;

            this.WriteEntries(entries);

            return true;
        }

        /// <inheritdoc/>
        public List<T> GetAll()
        {
            List<T> result = new List<T>();

            string[] entries = File.ReadAllLines(this._filePath);
            string[] fields;

            foreach (string entry in entries)
            {
                fields = entry.Split(",");
                if (fields.Length == 4)
                {
                    T item = new T();
                    item.Id = Guid.Parse(fields[0]);
                    item.Amount = decimal.Parse(fields[1]);
                    item.Date = DateOnly.Parse(fields[2]);
                    item.Category = fields[3];

                    result.Add(item);
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public int GetEntriesCount()
        {
            return File.ReadAllLines(this._filePath).Length;
        }

        /// <inheritdoc/>
        public Guid GetIdByIndex(int index)
        {
            string[] lines = File.ReadAllLines(this._filePath);

            if (index < 0 || index > lines.Length)
            {
                return Guid.Empty;
            }

            string row = lines[index];
            string id = row.Split(",")[0];

            if (Guid.TryParse(id, out Guid parsedId))
            {
                return parsedId;
            }

            return Guid.Empty;
        }

        /// <inheritdoc/>
        public decimal GetTotalAmount()
        {
            return this.GetAll().Sum(item => item.Amount);
        }

        /// <inheritdoc/>
        public bool IsEmpty()
        {
            return File.ReadAllLines(this._filePath).Length == 0;
        }

        private void Initialize()
        {
            if (!File.Exists(this._filePath))
            {
                using (File.Create(this._filePath))
                {
                }
            }
        }

        private void WriteEntries(List<T> entries)
        {
            using (StreamWriter writer = new StreamWriter(this._filePath, append: false))
            {
                foreach (T entry in entries)
                {
                    writer.WriteLine($"{entry.Id},{entry.Amount},{entry.Date},{entry.Category}");
                }
            }
        }
    }
}
