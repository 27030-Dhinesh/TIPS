using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    /// <summary>
    /// Specifies the storage mechanism used for persisting or managing data.
    /// </summary>
    public enum StorageType
    {
        /// <summary>
        /// Stores data in a Comma-Separated Values (CSV) file.
        /// </summary>
        CSV,

        /// <summary>
        /// Stores data in memory for the lifetime of the application without
        /// processing it to disk.
        /// </summary>
        InMemory,
    }
}
