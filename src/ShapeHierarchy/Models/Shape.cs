using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy.Models
{
    /// <summary>
    /// This is an abstract model for Shape.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Gets or sets the color of the Shape.
        /// </summary>
        /// <value>Color of the Shape.</value>
        public abstract string Color { get; set; }

        /// <summary>
        /// Calculate the area of the Shape.
        /// </summary>
        /// <returns>Area of the shape in sq. units.</returns>
        public abstract double CalculateArea();

        /// <summary>
        /// Display the Color and Area of the Shape.
        /// </summary>
        public void PrintDetails()
        {
            Console.WriteLine($@"This is a {this.GetType().Name} of {this.Color} color with {this.CalculateArea()} sq. units.");
        }
    }
}
