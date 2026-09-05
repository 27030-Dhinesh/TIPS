namespace MemoryManagement
{
    /// <summary>
    /// Provides mechanism to write text to a file on disk.
    /// </summary>
    public class TextFileWriter : IDisposable
    {
        private readonly string _filePath;
        private readonly StreamWriter _writer;

        private bool _disposedValue;

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
            this.Initialize();
            this._writer = new StreamWriter(filePath, append: append);
        }

        /// <summary>
        /// Writes a string to the file.
        /// </summary>
        /// <param name="textData">The text to write.</param>
        /// <exception cref="ObjectDisposedException">
        /// Throws when attempting to write to file after disposing the instance.
        /// </exception>
        public void Write(string? textData)
        {
            if (this._disposedValue)
            {
                throw new ObjectDisposedException(nameof(TextFileWriter), "The text file writer has been disposed; cannot write to file.");
            }

            this._writer.Write(textData);
        }

        /// <summary>
        /// Writes a string to the file, followed by a line terminator.
        /// </summary>
        /// <param name="textData">The text to write.</param>
        /// <exception cref="ObjectDisposedException">
        /// Throws when attempting to write to file after disposing the instance.
        /// </exception>
        public void WriteLine(string? textData)
        {
            if (this._disposedValue)
            {
                throw new ObjectDisposedException(nameof(TextFileWriter), "The text file writer has been disposed; cannot write to file.");
            }

            this._writer.WriteLine(textData);
        }

        /// <summary>
        /// Releases all resources used by the current <see cref="TextFileWriter"/> instance.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the current instance and,
        /// optionally, releases the managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <see langword="true"/> to dispose both managed and unmanaged resources;
        /// <see langword="false"/> to dispose only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposedValue)
            {
                if (disposing)
                {
                    Console.WriteLine("Cleaning up stream writer resources...");

                    this._writer.Flush();
                    this._writer.Close();
                    this._writer.Dispose();
                }

                this._disposedValue = true;
            }
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
    }
}
