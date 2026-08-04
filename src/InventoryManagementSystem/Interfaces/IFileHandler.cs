namespace InventoryManagementSystem.Interfaces
{
    /// <summary>
    /// Defines the contract for handling file-related operations.
    /// Implementations of this interface provide functionality for
    /// reading, writing, or managing files.
    /// </summary>
    internal interface IFileHandler : IFileReader, IFileWriter
    {
    }
}
