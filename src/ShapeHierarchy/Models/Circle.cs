using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy.Models
{
    /// <summary>
    /// This model is derived from the Shape class and defines a Circle Shape.
    /// </summary>
    internal class Circle : Shape
    {
        private double _radius;

        /// <summary>
        /// Gets or sets the Radius of the Circle.
        /// </summary>
        /// <value>Radius of the Circle; defaults to 1.</value>
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
                    this._radius = 1.0;
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
