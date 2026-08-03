namespace ShapeHierarchy.Models
{
    /// <summary>
    /// This model is derived from the Shape class and defines a Circle Shape.
    /// </summary>
    internal class Circle : Shape
    {
        private double _radius;

        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        /// <value>
        /// A positive <see cref="double"/> value representing the radius.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the assigned value is less than or equal to zero.
        /// </exception>
        public double Radius
        {
            get
            {
                return this._radius;
            }

            set
            {
                if (value > 0)
                {
                    this._radius = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"{nameof(this.Radius)} should be positive.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the Circle Shape.
        /// </summary>
        /// <value>Color of the Circle Shape instance.</value>
        public override string Color { get; set; } = "white";

        /// <summary>
        /// Find the area of the Circle.
        /// </summary>
        /// <returns>Area of the Circle instance in sq. units.</returns>
        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }
    }
}
