using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy.Models
{
    /// <summary>
    /// This model is derived from the Shape class and defines a Rectangle Shape.
    /// </summary>
    internal class Rectangle : Shape
    {
        /// <summary>
        /// Gets or sets the color of the Rectangle Shape.
        /// </summary>
        /// <value>Color of the Rectangle Shape instance.</value>
        public override string Color { get; set; } = "white";

        /// <summary>
        /// Gets or sets the Width of the Rectangle.
        /// </summary>
        /// <value>Width of the Rectangle; defaults to 1.</value>
        public double Width { get; set; } = 1.0;

        /// <summary>
        /// Gets or sets the Height of the Rectangle.
        /// </summary>
        /// <value>Height of the Rectangle; defaults to 1.</value>
        public double Height { get; set; } = 1.0;

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
