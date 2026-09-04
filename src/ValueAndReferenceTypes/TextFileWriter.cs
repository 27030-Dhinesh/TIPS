namespace MemoryManagement
{
    /// <summary>
    /// Provides mechanism to write text to a file on disk.
    /// </summary>
    public class TextFileWriter : IDisposable
    {
        private readonly string _filePath;
        private readonly StreamWriter _writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileWriter"/> class.
        /// </summary>
        /// <param name="filePath">The path to text file.</param>
        /// <param name="append">
        /// <see langword="true"/> to append data to file; <see langword="false"/>
        /// to overwrite the file.
        /// </param>
        public TextFileWriter(string filePath, bool append = false)
        {
            this._filePath = filePath;
            this._writer = new StreamWriter(filePath, append: append);
        }

        /// <summary>
        /// Writes a string to the file.
        /// </summary>
        /// <param name="textData">The text to write.</param>
        public void Write(string? textData)
        {
            this._writer.Write(textData);
        }

        /// <summary>
        /// Writes a string to the file, followed by a line terminator.
        /// </summary>
        /// <param name="textData">The text to write.</param>
        public void WriteLine(string? textData)
        {
            this._writer.WriteLine(textData);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Console.WriteLine($@"{nameof(TextFileWriter)}.Dispose invoked.
Calling StreamWriter.Dispose()...");
            this._writer.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
