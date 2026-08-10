namespace ShapeHierarchy.Models
{
    /// <summary>
    /// This model is derived from the Shape class and defines a Rectangle Shape.
    /// </summary>
    internal class Rectangle : Shape
    {
        private double _width;
        private double _height;

        /// <summary>
        /// Gets or sets the color of the Rectangle Shape.
        /// </summary>
        /// <value>Color of the Rectangle Shape instance.</value>
        public override string Color { get; set; } = "white";

        /// <summary>
        /// Gets or sets the Width of the Rectangle.
        /// </summary>
        /// <value>
        /// A positive <see cref="double"/> value representing the width of the rectangle.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the assigned value is less than or equal to zero.
        /// </exception>
        public double Width
        {
            get
            {
                return this._width;
            }

            set
            {
                if (value > 0)
                {
                    this._width = value; // using `Width = value` might result an infinite recursion.
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"{nameof(this.Width)} should be positive.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Height of the Rectangle.
        /// </summary>
        /// <value>
        /// A positive <see cref="double"/> value representing the height of the rectangle.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the assigned value is less than or equal to zero.
        /// </exception>
        public double Height
        {
            get
            {
                return this._height;
            }

            set
            {
                if (value > 0)
                {
                    this._height = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"{nameof(this.Height)} should be positive.");
                }
            }
        }

        /// <summary>
        /// Find the area of the Rectangle.
        /// </summary>
        /// <returns>Area of the Rectangle instance in sq. units.</returns>
        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }
    }
}
