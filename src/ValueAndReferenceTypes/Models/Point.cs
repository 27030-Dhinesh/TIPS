namespace MemoryManagement.Models
{
    /// <summary>
    /// Represents a point on a 2D coordinate system.
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// The abscissa of the point.
        /// </summary>
        public int X;

        /// <summary>
        /// The ordinate of the point.
        /// </summary>
        public int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x">The abscissa of the point.</param>
        /// <param name="y">The ordinate of the point.</param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
