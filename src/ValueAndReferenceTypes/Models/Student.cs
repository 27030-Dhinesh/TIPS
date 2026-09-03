namespace ValueAndReferenceTypes.Models
{
    /// <summary>
    /// Represents a student.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="registerNumber">The register number of the student.</param>
        /// <param name="name">The name of the student.</param>
        public Student(int registerNumber, string name)
        {
            this.RegisterNumber = registerNumber;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the register number of the student.
        /// </summary>
        /// <value>
        /// The register number of the student.
        /// </value>
        public int RegisterNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the student.
        /// </summary>
        /// <value>
        /// The name of the student.
        /// </value>
        public string Name { get; set; }
    }
}