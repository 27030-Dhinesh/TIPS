namespace ValueAndReferenceTypes.Models
{
    /// <summary>
    /// Represents a teacher.
    /// </summary>
    public struct Teacher
    {
        /// <summary>
        /// The enrollment number of the teacher.
        /// </summary>
        public int EnrollmentNumber;

        /// <summary>
        /// The name of the teacher.
        /// </summary>
        public string Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Teacher"/> struct.
        /// </summary>
        /// <param name="enrollmentNumber">The enrollment number of the teacher.</param>
        /// <param name="name">The name of the teacher.</param>
        public Teacher(int enrollmentNumber, string name)
        {
            this.EnrollmentNumber = enrollmentNumber;
            this.Name = name;
        }
    }
}