namespace ExceptionHandling.TaskTwo
{
    /// <summary>
    /// Represents an integer array initialized with random values.
    /// Provides access to array elements by index.
    /// </summary>
    public class ArrayTask
    {
        private int[] _numbers;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayTask"/> class.
        /// </summary>
        /// <param name="length">
        /// The number of elements to allocate in the internal array.
        /// </param>
        public ArrayTask(int length)
        {
            this._numbers = new int[length];
            this.Initialize();
        }

        /// <summary>
        /// Retrieves the value stored at the specified index.
        /// </summary>
        /// <param name="index">
        /// The zero-based index of the element to retrieve.
        /// </param>
        /// <returns>
        /// The integer value stored at the specified index.
        /// </returns>
        public int GetAt(int index)
        {
            return this._numbers[index];
        }

        private void Initialize()
        {
            for (int i = 0; i < this._numbers.Length; ++i)
            {
                this._numbers[i] = Random.Shared.Next(1, 101);
            }
        }
    }
}
