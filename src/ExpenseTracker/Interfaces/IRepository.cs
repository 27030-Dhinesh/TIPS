using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces
{
    /// <summary>
    /// Defines a generic repository contract for managing entities
    /// that implement <see cref="IEntry"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The type of entity managed by the repository.
    /// </typeparam>
    public interface IRepository<T>
        where T : IEntry
    {
        /// <summary>
        /// Determines whether the repository contains any entries.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the repository contains no entries; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        bool IsEmpty();

        /// <summary>
        /// Gets the total number of entries in the repository.
        /// </summary>
        /// <returns>
        /// The number of entries currently stored in the repository.
        /// </returns>
        int GetEntriesCount();

        /// <summary>
        /// Adds a new entry to the repository.
        /// </summary>
        /// <param name="entry">
        /// The entry to add.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the entry was added successfully; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        bool Add(T entry);

        /// <summary>
        /// Updates an existing entry identified by the specified identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the entry to update.
        /// </param>
        /// <param name="entry">
        /// The updated entry data.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the entry was updated successfully; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        bool Edit(Guid id, T entry);

        /// <summary>
        /// Removes an entry from the repository.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the entry to remove.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the entry was removed successfully; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        bool Delete(Guid id);

        /// <summary>
        /// Retrieves all entries from the repository.
        /// </summary>
        /// <returns>
        /// A list containing all entries in the repository.
        /// </returns>
        List<T> GetAll();

        /// <summary>
        /// Determines whether an entry with the specified identifier exists in the repository.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the entry to locate.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if an entry with the specified identifier exists; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        bool Contains(Guid id);

        /// <summary>
        /// Gets the identifier of the entry at the specified index.
        /// </summary>
        /// <param name="index">
        /// The zero-based index of the entry.
        /// </param>
        /// <returns>
        /// The unique identifier of the entry at the specified index.
        /// </returns>
        public Guid GetIdByIndex(int index);
    }
}
