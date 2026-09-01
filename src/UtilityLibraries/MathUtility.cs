namespace UtilityLibraries
{
    /// <summary>
    /// Provides utility methods for performing basic arithmetic calculations.
    /// </summary>
    public static class MathUtility
    {
        /// <summary>
        /// Calculates the sum of two integers.
        /// </summary>
        /// <param name="num1">
        /// The first addend.
        /// </param>
        /// <param name="num2">
        /// The second addend.
        /// </param>
        /// <returns>
        /// The sum of <paramref name="num1"/> and <paramref name="num2"/>.
        /// </returns>
        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        /// <summary>
        /// Calculates the difference between two integers.
        /// </summary>
        /// <param name="num1">
        /// The minuend.
        /// </param>
        /// <param name="num2">
        /// The subtrahend.
        /// </param>
        /// <returns>
        /// The result of subtracting <paramref name="num2"/> from <paramref name="num1"/>.
        /// </returns>
        public static int Difference(int num1, int num2)
        {
            return num1 - num2;
        }

        /// <summary>
        /// Calculates the product of two integers.
        /// </summary>
        /// <param name="num1">
        /// The multiplicand.
        /// </param>
        /// <param name="num2">
        /// The multiplier.
        /// </param>
        /// <returns>
        /// The product of <paramref name="num1"/> and <paramref name="num2"/>.
        /// </returns>
        public static int Product(int num1, int num2)
        {
            return num1 * num2;
        }

        /// <summary>
        /// Calculates the quotient of dividing one integer by another.
        /// </summary>
        /// <param name="num1">
        /// The dividend.
        /// </param>
        /// <param name="num2">
        /// The divisor.
        /// </param>
        /// <returns>
        /// The quotient of <paramref name="num1"/> divided by <paramref name="num2"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="num2"/> parameter is 0.
        /// </exception>
        public static int Quotient(int num1, int num2)
        {
            if (num2 == 0)
            {
                throw new ArgumentException($"Cannot divide by zero.", nameof(num2));
            }

            return num1 / num2;
        }

        /// <summary>
        /// Calculates the remainder when one integer is divided by another.
        /// </summary>
        /// <param name="num1">
        /// The dividend.
        /// </param>
        /// <param name="num2">
        /// The divisor.
        /// </param>
        /// <returns>
        /// The remainder of dividing <paramref name="num1"/> by <paramref name="num2"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="num2"/> parameter is 0.
        /// </exception>
        public static int Remainder(int num1, int num2)
        {
            if (num2 == 0)
            {
                throw new ArgumentException($"Cannot divide by zero.", nameof(num2));
            }

            return num1 % num2;
        }
    }
}
