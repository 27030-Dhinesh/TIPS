namespace ExceptionHandling.TaskOne
{
    /// <summary>
    /// Represents a division operation between two integer values.
    /// Provides access to the dividend, divisor, and the calculated quotient.
    /// </summary>
    public class Divide
    {
        private int _num1;
        private int _num2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Divide"/> class.
        /// </summary>
        /// <param name="num1">
        /// The dividend.
        /// </param>
        /// <param name="num2">
        /// The divisor.
        /// </param>
        public Divide(int num1, int num2)
        {
            this._num1 = num1;
            this._num2 = num2;
        }

        /// <summary>
        /// Gets or sets the dividend used in the division operation.
        /// </summary>
        /// <value>
        /// The value of the dividend.
        /// </value>
        public int Num1
        {
            get
            {
                return this._num1;
            }

            set
            {
                this._num1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the divisor used in the division operation.
        /// </summary>
        /// <value>
        /// The value of the divisor.
        /// </value>
        public int Num2
        {
            get
            {
                return this._num2;
            }

            set
            {
                this._num2 = value;
            }
        }

        /// <summary>
        /// Gets the quotient obtained by dividing <see cref="Num1"/>
        /// by <see cref="Num2"/>.
        /// </summary>
        /// <value>
        /// The quotient obtained upon division.
        /// </value>
        public int Quotient => this.CalculateQuotient();

        private int CalculateQuotient()
        {
            return this.Num1 / this.Num2;
        }
    }
}
