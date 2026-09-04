using System.Runtime.InteropServices;

namespace ValueAndReferenceTypes.Models
{
    /// <summary>
    /// Represents a large value-type structure designed to allocate
    /// an exact block of memory inline.
    /// </summary>
    /// <remarks>
    /// This struct is deliberately inflated to 1024 bytes for memory
    /// profiling demonstration.
    /// </remarks>
    /*
     * - By default, the C# compiler uses LayoutKind.Sequential for structs.
     *   It aligns fields based on their natural size alignment.
     *
     * - LayoutKind.Explicit is used with a fixed Size of 1024 to force
     *   the exact byte footprint.
     *
     * - Because Explicit layout is enforced, all instance fields declared
     *   inside this struct must be explicitly decorated with a
     *   [FieldOffset] attribute.
     */
    [StructLayout(LayoutKind.Explicit, Size = 1024)]
    public struct ExplicitLayoutStruct
    {
        [FieldOffset(0)]
        private decimal _someDecimal = decimal.MaxValue;

        // decimal occupies 16 bytes, hence the offset from the
        // previous decimal of the struct
        [FieldOffset(16)]
        private decimal _anotherDecimal = decimal.MinValue;

        [FieldOffset(32)]
        private decimal _yetAnotherDecimal = decimal.MaxValue;

        [FieldOffset(48)]
        private long _anotherLong = long.MinValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExplicitLayoutStruct"/> struct.
        /// </summary>
        public ExplicitLayoutStruct()
        {
        }
    }
}
