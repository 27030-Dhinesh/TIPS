using ShapeHierarchy.Models;

namespace ShapeHierarchy.Services
{
    /// <summary>
    /// Service layer to support Shape Hierarchy task.
    /// </summary>
    internal class ShapeService
    {
        /// <summary>
        /// Instantiate a new Circle for given radius, optional color.
        /// </summary>
        /// <param name="radius">Radius of the Circle Shape.</param>
        /// <param name="color">Color of the Circle Shape.</param>
        /// <returns>A new Circle Shape object.</returns>
        public Circle CreateCircle(double radius, string color = "white")
        {
            return new Circle() { Radius = radius, Color = color };
        }

        /// <summary>
        /// Instantiate a new Rectangle for given width, height, and optional color.
        /// </summary>
        /// <param name="width">Width of the Rectangle Shape.</param>
        /// <param name="height">Height of the Rectangle Shape.</param>
        /// <param name="color">Color of the Rectangle Shape.</param>
        /// <returns>A new Rectangle Shape object.</returns>
        public Models.Rectangle CreateRectangle(double width, double height, string color = "white")
        {
            return new Models.Rectangle() { Width = width, Height = height, Color = color };
        }
    }
}
