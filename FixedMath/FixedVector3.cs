using System;
using System.Diagnostics;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace FixedMath
{
    /// <summary>
    /// Describes a 3D-vector.
    /// </summary>
    [DataContract]
    [DebuggerDisplay("{DebugDisplayString,nq}")]
    [TypeConverter(typeof(FixedVector3TypeConverter))]
    public struct FixedVector3 : IEquatable<FixedVector3>
    {
        #region Private Fields

        private static readonly FixedVector3 zero = new FixedVector3(Fixed.Zero, Fixed.Zero, Fixed.Zero);
        private static readonly FixedVector3 one = new FixedVector3(Fixed.One, Fixed.One, Fixed.One);
        private static readonly FixedVector3 unitX = new FixedVector3(Fixed.One, Fixed.Zero, Fixed.Zero);
        private static readonly FixedVector3 unitY = new FixedVector3(Fixed.Zero, Fixed.One, Fixed.Zero);
        private static readonly FixedVector3 unitZ = new FixedVector3(Fixed.Zero, Fixed.Zero, Fixed.One);
        private static readonly FixedVector3 up = new FixedVector3(Fixed.Zero, Fixed.One, Fixed.Zero);
        private static readonly FixedVector3 down = new FixedVector3(Fixed.Zero, -Fixed.One, Fixed.Zero);
        private static readonly FixedVector3 right = new FixedVector3(Fixed.One, Fixed.Zero, Fixed.Zero);
        private static readonly FixedVector3 left = new FixedVector3(-Fixed.One, Fixed.Zero, Fixed.Zero);
        private static readonly FixedVector3 forward = new FixedVector3(Fixed.Zero, Fixed.Zero, -Fixed.One);
        private static readonly FixedVector3 backward = new FixedVector3(Fixed.Zero, Fixed.Zero, Fixed.One);

        #endregion

        #region Public Fields

        /// <summary>
        /// The x coordinate of this <see cref="FixedVector3"/>.
        /// </summary>
        [DataMember]
        public Fixed X;

        /// <summary>
        /// The y coordinate of this <see cref="FixedVector3"/>.
        /// </summary>
        [DataMember]
        public Fixed Y;

        /// <summary>
        /// The z coordinate of this <see cref="FixedVector3"/>.
        /// </summary>
        [DataMember]
        public Fixed Z;

        #endregion

        #region Public Properties

        /// <summary>
        /// Returns a <see cref="FixedVector3"/> with components 0, 0, 0.
        /// </summary>
        public static FixedVector3 Zero
        {
            get { return zero; }
        }

        /// <summary>
        /// Returns a <see cref="FixedVector3"/> with components 1, 1, 1.
        /// </summary>
        public static FixedVector3 One
        {
            get { return one; }
        }

        /// <summary>
        /// Returns a <see cref="FixedVector3"/> with components 1, 0, 0.
        /// </summary>
        public static FixedVector3 UnitX
        {
            get { return unitX; }
        }

        /// <summary>
        /// Returns a <see cref="FixedVector3"/> with components 0, 1, 0.
        /// </summary>
        public static FixedVector3 UnitY
        {
            get { return unitY; }
        }

        /// <summary>
        /// Returns a <see cref="FixedVector3"/> with components 0, 0, 1.
        /// </summary>
        public static FixedVector3 UnitZ
        {
            get { return unitZ; }
        }

        /// <summary>
        /// Returns a <see cref="FixedVector3"/> with components 0, 1, 0.
        /// </summary>
        public static FixedVector3 Up
        {
            get { return up; }
        }

        /// <summary>
        /// Returns a <see cref="FixedVector3"/> with components 0, -1, 0.
        /// </summary>
        public static FixedVector3 Down
        {
            get { return down; }
        }

        /// <summary>
        /// Returns a <see cref="FixedVector3"/> with components 1, 0, 0.
        /// </summary>
        public static FixedVector3 Right
        {
            get { return right; }
        }

        /// <summary>
        /// Returns a <see cref="FixedVector3"/> with components -1, 0, 0.
        /// </summary>
        public static FixedVector3 Left
        {
            get { return left; }
        }

        /// <summary>
        /// Returns a <see cref="FixedVector3"/> with components 0, 0, -1.
        /// </summary>
        public static FixedVector3 Forward
        {
            get { return forward; }
        }

        /// <summary>
        /// Returns a <see cref="FixedVector3"/> with components 0, 0, 1.
        /// </summary>
        public static FixedVector3 Backward
        {
            get { return backward; }
        }

        #endregion

        #region Internal Properties

        internal string DebugDisplayString
        {
            get
            {
                return string.Concat(
                    this.X.ToString(), "  ",
                    this.Y.ToString(), "  ",
                    this.Z.ToString()
                );
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a 3d vector with X, Y and Z from three values.
        /// </summary>
        /// <param name="x">The x coordinate in 3d-space.</param>
        /// <param name="y">The y coordinate in 3d-space.</param>
        /// <param name="z">The z coordinate in 3d-space.</param>
        internal FixedVector3(float x, float y, float z)
        {
            this.X = (Fixed)x;
            this.Y = (Fixed)y;
            this.Z = (Fixed)z;
        }

        /// <summary>
        /// Constructs a 3d vector with X, Y and Z from three values.
        /// </summary>
        /// <param name="x">The x coordinate in 3d-space.</param>
        /// <param name="y">The y coordinate in 3d-space.</param>
        /// <param name="z">The z coordinate in 3d-space.</param>
        public FixedVector3(Fixed x, Fixed y, Fixed z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Constructs a 3d vector with X, Y and Z set to the same value.
        /// </summary>
        /// <param name="value">The x, y and z coordinates in 3d-space.</param>
        public FixedVector3(Fixed value)
        {
            this.X = value;
            this.Y = value;
            this.Z = value;
        }

        /// <summary>
        /// Constructs a 3d vector with X, Y from <see cref="FixedVector2"/> and Z from a scalar.
        /// </summary>
        /// <param name="value">The x and y coordinates in 3d-space.</param>
        /// <param name="z">The z coordinate in 3d-space.</param>
        public FixedVector3(FixedVector2 value, Fixed z)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = z;
        }
        
        #endregion
        
        #region Public Methods

        /// <summary>
        /// Performs vector addition on <paramref name="value1"/> and <paramref name="value2"/>.
        /// </summary>
        /// <param name="value1">The first vector to add.</param>
        /// <param name="value2">The second vector to add.</param>
        /// <returns>The result of the vector addition.</returns>
        public static FixedVector3 Add(FixedVector3 value1, FixedVector3 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            value1.Z += value2.Z;
            return value1;
        }

        /// <summary>
        /// Performs vector addition on <paramref name="value1"/> and
        /// <paramref name="value2"/>, storing the result of the
        /// addition in <paramref name="result"/>.
        /// </summary>
        /// <param name="value1">The first vector to add.</param>
        /// <param name="value2">The second vector to add.</param>
        /// <param name="result">The result of the vector addition.</param>
        public static void Add(ref FixedVector3 value1, ref FixedVector3 value2, out FixedVector3 result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            result.Z = value1.Z + value2.Z;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains the cartesian coordinates of a vector specified in barycentric coordinates and relative to 3d-triangle.
        /// </summary>
        /// <param name="value1">The first vector of 3d-triangle.</param>
        /// <param name="value2">The second vector of 3d-triangle.</param>
        /// <param name="value3">The third vector of 3d-triangle.</param>
        /// <param name="amount1">Barycentric scalar <c>b2</c> which represents a weighting factor towards second vector of 3d-triangle.</param>
        /// <param name="amount2">Barycentric scalar <c>b3</c> which represents a weighting factor towards third vector of 3d-triangle.</param>
        /// <returns>The cartesian translation of barycentric coordinates.</returns>
        public static FixedVector3 Barycentric(FixedVector3 value1, FixedVector3 value2, FixedVector3 value3, Fixed amount1, Fixed amount2)
        {
            return new FixedVector3(
                Fixed.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                Fixed.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
                Fixed.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2));
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains the cartesian coordinates of a vector specified in barycentric coordinates and relative to 3d-triangle.
        /// </summary>
        /// <param name="value1">The first vector of 3d-triangle.</param>
        /// <param name="value2">The second vector of 3d-triangle.</param>
        /// <param name="value3">The third vector of 3d-triangle.</param>
        /// <param name="amount1">Barycentric scalar <c>b2</c> which represents a weighting factor towards second vector of 3d-triangle.</param>
        /// <param name="amount2">Barycentric scalar <c>b3</c> which represents a weighting factor towards third vector of 3d-triangle.</param>
        /// <param name="result">The cartesian translation of barycentric coordinates as an output parameter.</param>
        public static void Barycentric(ref FixedVector3 value1, ref FixedVector3 value2, ref FixedVector3 value3, Fixed amount1, Fixed amount2, out FixedVector3 result)
        {
            result.X = Fixed.Barycentric(value1.X, value2.X, value3.X, amount1, amount2);
            result.Y = Fixed.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2);
            result.Z = Fixed.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2);
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains CatmullRom interpolation of the specified vectors.
        /// </summary>
        /// <param name="value1">The first vector in interpolation.</param>
        /// <param name="value2">The second vector in interpolation.</param>
        /// <param name="value3">The third vector in interpolation.</param>
        /// <param name="value4">The fourth vector in interpolation.</param>
        /// <param name="amount">Weighting factor.</param>
        /// <returns>The result of CatmullRom interpolation.</returns>
        public static FixedVector3 CatmullRom(FixedVector3 value1, FixedVector3 value2, FixedVector3 value3, FixedVector3 value4, Fixed amount)
        {
            return new FixedVector3(
                Fixed.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                Fixed.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
                Fixed.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount));
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains CatmullRom interpolation of the specified vectors.
        /// </summary>
        /// <param name="value1">The first vector in interpolation.</param>
        /// <param name="value2">The second vector in interpolation.</param>
        /// <param name="value3">The third vector in interpolation.</param>
        /// <param name="value4">The fourth vector in interpolation.</param>
        /// <param name="amount">Weighting factor.</param>
        /// <param name="result">The result of CatmullRom interpolation as an output parameter.</param>
        public static void CatmullRom(ref FixedVector3 value1, ref FixedVector3 value2, ref FixedVector3 value3, ref FixedVector3 value4, Fixed amount, out FixedVector3 result)
        {
            result.X = Fixed.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount);
            result.Y = Fixed.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount);
            result.Z = Fixed.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount);
        }

        /// <summary>
        /// Round the members of this <see cref="FixedVector3"/> towards positive infinity.
        /// </summary>
        public void Ceiling()
        {
            X = Fixed.Ceiling(X);
            Y = Fixed.Ceiling(Y);
            Z = Fixed.Ceiling(Z);
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains members from another vector rounded towards positive infinity.
        /// </summary>
        /// <param name="value">Source <see cref="FixedVector3"/>.</param>
        /// <returns>The rounded <see cref="FixedVector3"/>.</returns>
        public static FixedVector3 Ceiling(FixedVector3 value)
        {
            value.X = Fixed.Ceiling(value.X);
            value.Y = Fixed.Ceiling(value.Y);
            value.Z = Fixed.Ceiling(value.Z);
            return value;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains members from another vector rounded towards positive infinity.
        /// </summary>
        /// <param name="value">Source <see cref="FixedVector3"/>.</param>
        /// <param name="result">The rounded <see cref="FixedVector3"/>.</param>
        public static void Ceiling(ref FixedVector3 value, out FixedVector3 result)
        {
            result.X = Fixed.Ceiling(value.X);
            result.Y = Fixed.Ceiling(value.Y);
            result.Z = Fixed.Ceiling(value.Z);
        }

        /// <summary>
        /// Clamps the specified value within a range.
        /// </summary>
        /// <param name="value1">The value to clamp.</param>
        /// <param name="min">The min value.</param>
        /// <param name="max">The max value.</param>
        /// <returns>The clamped value.</returns>
        public static FixedVector3 Clamp(FixedVector3 value1, FixedVector3 min, FixedVector3 max)
        {
            return new FixedVector3(
                Fixed.Clamp(value1.X, min.X, max.X),
                Fixed.Clamp(value1.Y, min.Y, max.Y),
                Fixed.Clamp(value1.Z, min.Z, max.Z));
        }

        /// <summary>
        /// Clamps the specified value within a range.
        /// </summary>
        /// <param name="value1">The value to clamp.</param>
        /// <param name="min">The min value.</param>
        /// <param name="max">The max value.</param>
        /// <param name="result">The clamped value as an output parameter.</param>
        public static void Clamp(ref FixedVector3 value1, ref FixedVector3 min, ref FixedVector3 max, out FixedVector3 result)
        {
            result.X = Fixed.Clamp(value1.X, min.X, max.X);
            result.Y = Fixed.Clamp(value1.Y, min.Y, max.Y);
            result.Z = Fixed.Clamp(value1.Z, min.Z, max.Z);
        }

        /// <summary>
        /// Computes the cross product of two vectors.
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>The cross product of two vectors.</returns>
        public static FixedVector3 Cross(FixedVector3 vector1, FixedVector3 vector2)
        {
            Cross(ref vector1, ref vector2, out vector1);
            return vector1;
        }

        /// <summary>
        /// Computes the cross product of two vectors.
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <param name="result">The cross product of two vectors as an output parameter.</param>
        public static void Cross(ref FixedVector3 vector1, ref FixedVector3 vector2, out FixedVector3 result)
        {
            var x = vector1.Y * vector2.Z - vector2.Y * vector1.Z;
            var y = -(vector1.X * vector2.Z - vector2.X * vector1.Z);
            var z = vector1.X * vector2.Y - vector2.X * vector1.Y;
            result.X = x;
            result.Y = y;
            result.Z = z;
        }

        /// <summary>
        /// Returns the distance between two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The distance between two vectors.</returns>
        public static Fixed Distance(FixedVector3 value1, FixedVector3 value2)
        {
            Fixed result;
            DistanceSquared(ref value1, ref value2, out result);
            return Fixed.Sqrt(result);
        }

        /// <summary>
        /// Returns the distance between two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="result">The distance between two vectors as an output parameter.</param>
        public static void Distance(ref FixedVector3 value1, ref FixedVector3 value2, out Fixed result)
        {
            DistanceSquared(ref value1, ref value2, out result);
            result = Fixed.Sqrt(result);
        }

        /// <summary>
        /// Returns the squared distance between two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The squared distance between two vectors.</returns>
        public static Fixed DistanceSquared(FixedVector3 value1, FixedVector3 value2)
        {
            return  (value1.X - value2.X) * (value1.X - value2.X) +
                    (value1.Y - value2.Y) * (value1.Y - value2.Y) +
                    (value1.Z - value2.Z) * (value1.Z - value2.Z);
        }

        /// <summary>
        /// Returns the squared distance between two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="result">The squared distance between two vectors as an output parameter.</param>
        public static void DistanceSquared(ref FixedVector3 value1, ref FixedVector3 value2, out Fixed result)
        {
            result = (value1.X - value2.X) * (value1.X - value2.X) +
                     (value1.Y - value2.Y) * (value1.Y - value2.Y) +
                     (value1.Z - value2.Z) * (value1.Z - value2.Z);
        }

        /// <summary>
        /// Divides the components of a <see cref="FixedVector3"/> by the components of another <see cref="FixedVector3"/>.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/>.</param>
        /// <param name="value2">Divisor <see cref="FixedVector3"/>.</param>
        /// <returns>The result of dividing the vectors.</returns>
        public static FixedVector3 Divide(FixedVector3 value1, FixedVector3 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            value1.Z /= value2.Z;
            return value1;
        }

        /// <summary>
        /// Divides the components of a <see cref="FixedVector3"/> by a scalar.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/>.</param>
        /// <param name="divider">Divisor scalar.</param>
        /// <returns>The result of dividing a vector by a scalar.</returns>
        public static FixedVector3 Divide(FixedVector3 value1, Fixed divider)
        {
            Fixed factor = Fixed.One / divider;
            value1.X *= factor;
            value1.Y *= factor;
            value1.Z *= factor;
            return value1;
        }

        /// <summary>
        /// Divides the components of a <see cref="FixedVector3"/> by a scalar.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/>.</param>
        /// <param name="divider">Divisor scalar.</param>
        /// <param name="result">The result of dividing a vector by a scalar as an output parameter.</param>
        public static void Divide(ref FixedVector3 value1, Fixed divider, out FixedVector3 result)
        {
            Fixed factor = Fixed.One / divider;
            result.X = value1.X * factor;
            result.Y = value1.Y * factor;
            result.Z = value1.Z * factor;
        }

        /// <summary>
        /// Divides the components of a <see cref="FixedVector3"/> by the components of another <see cref="FixedVector3"/>.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/>.</param>
        /// <param name="value2">Divisor <see cref="FixedVector3"/>.</param>
        /// <param name="result">The result of dividing the vectors as an output parameter.</param>
        public static void Divide(ref FixedVector3 value1, ref FixedVector3 value2, out FixedVector3 result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
            result.Z = value1.Z / value2.Z;
        }

        /// <summary>
        /// Returns a dot product of two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The dot product of two vectors.</returns>
        public static Fixed Dot(FixedVector3 value1, FixedVector3 value2)
        {
            return value1.X * value2.X + value1.Y * value2.Y + value1.Z * value2.Z;
        }

        /// <summary>
        /// Returns a dot product of two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="result">The dot product of two vectors as an output parameter.</param>
        public static void Dot(ref FixedVector3 value1, ref FixedVector3 value2, out Fixed result)
        {
            result = value1.X * value2.X + value1.Y * value2.Y + value1.Z * value2.Z;
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is FixedVector3))
                return false;

            var other = (FixedVector3)obj;
            return  X == other.X &&
                    Y == other.Y &&
                    Z == other.Z;
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="FixedVector3"/>.
        /// </summary>
        /// <param name="other">The <see cref="FixedVector3"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public bool Equals(FixedVector3 other)
        {
            return  X == other.X && 
                    Y == other.Y &&
                    Z == other.Z;
        }

        /// <summary>
        /// Round the members of this <see cref="FixedVector3"/> towards negative infinity.
        /// </summary>
        public void Floor()
        {
            X = Fixed.Floor(X);
            Y = Fixed.Floor(Y);
            Z = Fixed.Floor(Z);
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains members from another vector rounded towards negative infinity.
        /// </summary>
        /// <param name="value">Source <see cref="FixedVector3"/>.</param>
        /// <returns>The rounded <see cref="FixedVector3"/>.</returns>
        public static FixedVector3 Floor(FixedVector3 value)
        {
            value.X = Fixed.Floor(value.X);
            value.Y = Fixed.Floor(value.Y);
            value.Z = Fixed.Floor(value.Z);
            return value;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains members from another vector rounded towards negative infinity.
        /// </summary>
        /// <param name="value">Source <see cref="FixedVector3"/>.</param>
        /// <param name="result">The rounded <see cref="FixedVector3"/>.</param>
        public static void Floor(ref FixedVector3 value, out FixedVector3 result)
        {
            result.X = Fixed.Floor(value.X);
            result.Y = Fixed.Floor(value.Y);
            result.Z = Fixed.Floor(value.Z);
        }

        /// <summary>
        /// Gets the hash code of this <see cref="FixedVector3"/>.
        /// </summary>
        /// <returns>Hash code of this <see cref="FixedVector3"/>.</returns>
        public override int GetHashCode() {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains hermite spline interpolation.
        /// </summary>
        /// <param name="value1">The first position vector.</param>
        /// <param name="tangent1">The first tangent vector.</param>
        /// <param name="value2">The second position vector.</param>
        /// <param name="tangent2">The second tangent vector.</param>
        /// <param name="amount">Weighting factor.</param>
        /// <returns>The hermite spline interpolation vector.</returns>
        public static FixedVector3 Hermite(FixedVector3 value1, FixedVector3 tangent1, FixedVector3 value2, FixedVector3 tangent2, Fixed amount)
        {
            return new FixedVector3(Fixed.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount),
                               Fixed.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount),
                               Fixed.Hermite(value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount));
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains hermite spline interpolation.
        /// </summary>
        /// <param name="value1">The first position vector.</param>
        /// <param name="tangent1">The first tangent vector.</param>
        /// <param name="value2">The second position vector.</param>
        /// <param name="tangent2">The second tangent vector.</param>
        /// <param name="amount">Weighting factor.</param>
        /// <param name="result">The hermite spline interpolation vector as an output parameter.</param>
        public static void Hermite(ref FixedVector3 value1, ref FixedVector3 tangent1, ref FixedVector3 value2, ref FixedVector3 tangent2, Fixed amount, out FixedVector3 result)
        {
            result.X = Fixed.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount);
            result.Y = Fixed.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
            result.Z = Fixed.Hermite(value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount);
        }

        /// <summary>
        /// Returns the length of this <see cref="FixedVector3"/>.
        /// </summary>
        /// <returns>The length of this <see cref="FixedVector3"/>.</returns>
        public Fixed Length()
        {
            return Fixed.Sqrt((X * X) + (Y * Y) + (Z * Z));
        }

        /// <summary>
        /// Returns the squared length of this <see cref="FixedVector3"/>.
        /// </summary>
        /// <returns>The squared length of this <see cref="FixedVector3"/>.</returns>
        public Fixed LengthSquared()
        {
            return (X * X) + (Y * Y) + (Z * Z);
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains linear interpolation of the specified vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="amount">Weighting value(between 0.0 and 1.0).</param>
        /// <returns>The result of linear interpolation of the specified vectors.</returns>
        public static FixedVector3 Lerp(FixedVector3 value1, FixedVector3 value2, Fixed amount)
        {
            return new FixedVector3(
                Fixed.Lerp(value1.X, value2.X, amount),
                Fixed.Lerp(value1.Y, value2.Y, amount),
                Fixed.Lerp(value1.Z, value2.Z, amount));
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains linear interpolation of the specified vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="amount">Weighting value(between 0.0 and 1.0).</param>
        /// <param name="result">The result of linear interpolation of the specified vectors as an output parameter.</param>
        public static void Lerp(ref FixedVector3 value1, ref FixedVector3 value2, Fixed amount, out FixedVector3 result)
        {
            result.X = Fixed.Lerp(value1.X, value2.X, amount);
            result.Y = Fixed.Lerp(value1.Y, value2.Y, amount);
            result.Z = Fixed.Lerp(value1.Z, value2.Z, amount);
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains linear interpolation of the specified vectors.
        /// Uses <see cref="Fixed.LerpPrecise"/> on MathHelper for the interpolation.
        /// Less efficient but more precise compared to <see cref="FixedVector3.Lerp(FixedVector3, FixedVector3, Fixed)"/>.
        /// See remarks section of <see cref="Fixed.LerpPrecise"/> on MathHelper for more info.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="amount">Weighting value(between 0.0 and 1.0).</param>
        /// <returns>The result of linear interpolation of the specified vectors.</returns>
        public static FixedVector3 LerpPrecise(FixedVector3 value1, FixedVector3 value2, Fixed amount)
        {
            return new FixedVector3(
                Fixed.LerpPrecise(value1.X, value2.X, amount),
                Fixed.LerpPrecise(value1.Y, value2.Y, amount),
                Fixed.LerpPrecise(value1.Z, value2.Z, amount));
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains linear interpolation of the specified vectors.
        /// Uses <see cref="Fixed.LerpPrecise"/> on MathHelper for the interpolation.
        /// Less efficient but more precise compared to <see cref="FixedVector3.Lerp(ref FixedVector3, ref FixedVector3, Fixed, out FixedVector3)"/>.
        /// See remarks section of <see cref="Fixed.LerpPrecise"/> on MathHelper for more info.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="amount">Weighting value(between 0.0 and 1.0).</param>
        /// <param name="result">The result of linear interpolation of the specified vectors as an output parameter.</param>
        public static void LerpPrecise(ref FixedVector3 value1, ref FixedVector3 value2, Fixed amount, out FixedVector3 result)
        {
            result.X = Fixed.LerpPrecise(value1.X, value2.X, amount);
            result.Y = Fixed.LerpPrecise(value1.Y, value2.Y, amount);
            result.Z = Fixed.LerpPrecise(value1.Z, value2.Z, amount);
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a maximal values from the two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The <see cref="FixedVector3"/> with maximal values from the two vectors.</returns>
        public static FixedVector3 Max(FixedVector3 value1, FixedVector3 value2)
        {
            return new FixedVector3(
                Fixed.Max(value1.X, value2.X),
                Fixed.Max(value1.Y, value2.Y),
                Fixed.Max(value1.Z, value2.Z));
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a maximal values from the two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="result">The <see cref="FixedVector3"/> with maximal values from the two vectors as an output parameter.</param>
        public static void Max(ref FixedVector3 value1, ref FixedVector3 value2, out FixedVector3 result)
        {
            result.X = Fixed.Max(value1.X, value2.X);
            result.Y = Fixed.Max(value1.Y, value2.Y);
            result.Z = Fixed.Max(value1.Z, value2.Z);
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a minimal values from the two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The <see cref="FixedVector3"/> with minimal values from the two vectors.</returns>
        public static FixedVector3 Min(FixedVector3 value1, FixedVector3 value2)
        {
            return new FixedVector3(
                Fixed.Min(value1.X, value2.X),
                Fixed.Min(value1.Y, value2.Y),
                Fixed.Min(value1.Z, value2.Z));
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a minimal values from the two vectors.
        /// </summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="result">The <see cref="FixedVector3"/> with minimal values from the two vectors as an output parameter.</param>
        public static void Min(ref FixedVector3 value1, ref FixedVector3 value2, out FixedVector3 result)
        {
            result.X = Fixed.Min(value1.X, value2.X);
            result.Y = Fixed.Min(value1.Y, value2.Y);
            result.Z = Fixed.Min(value1.Z, value2.Z);
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a multiplication of two vectors.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/>.</param>
        /// <param name="value2">Source <see cref="FixedVector3"/>.</param>
        /// <returns>The result of the vector multiplication.</returns>
        public static FixedVector3 Multiply(FixedVector3 value1, FixedVector3 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            value1.Z *= value2.Z;
            return value1;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a multiplication of <see cref="FixedVector3"/> and a scalar.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/>.</param>
        /// <param name="scaleFactor">Scalar value.</param>
        /// <returns>The result of the vector multiplication with a scalar.</returns>
        public static FixedVector3 Multiply(FixedVector3 value1, Fixed scaleFactor)
        {
            value1.X *= scaleFactor;
            value1.Y *= scaleFactor;
            value1.Z *= scaleFactor;
            return value1;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a multiplication of <see cref="FixedVector3"/> and a scalar.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/>.</param>
        /// <param name="scaleFactor">Scalar value.</param>
        /// <param name="result">The result of the multiplication with a scalar as an output parameter.</param>
        public static void Multiply(ref FixedVector3 value1, Fixed scaleFactor, out FixedVector3 result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
            result.Z = value1.Z * scaleFactor;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a multiplication of two vectors.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/>.</param>
        /// <param name="value2">Source <see cref="FixedVector3"/>.</param>
        /// <param name="result">The result of the vector multiplication as an output parameter.</param>
        public static void Multiply(ref FixedVector3 value1, ref FixedVector3 value2, out FixedVector3 result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
            result.Z = value1.Z * value2.Z;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains the specified vector inversion.
        /// </summary>
        /// <param name="value">Source <see cref="FixedVector3"/>.</param>
        /// <returns>The result of the vector inversion.</returns>
        public static FixedVector3 Negate(FixedVector3 value)
        {
            value = new FixedVector3(-value.X, -value.Y, -value.Z);
            return value;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains the specified vector inversion.
        /// </summary>
        /// <param name="value">Source <see cref="FixedVector3"/>.</param>
        /// <param name="result">The result of the vector inversion as an output parameter.</param>
        public static void Negate(ref FixedVector3 value, out FixedVector3 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
            result.Z = -value.Z;
        }

        /// <summary>
        /// Turns this <see cref="FixedVector3"/> to a unit vector with the same direction.
        /// </summary>
        public void Normalize()
        {
            Fixed factor = Fixed.Sqrt((X * X) + (Y * Y) + (Z * Z));
            factor = Fixed.One / factor;
            X *= factor;
            Y *= factor;
            Z *= factor;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a normalized values from another vector.
        /// </summary>
        /// <param name="value">Source <see cref="FixedVector3"/>.</param>
        /// <returns>Unit vector.</returns>
        public static FixedVector3 Normalize(FixedVector3 value)
        {
            Fixed factor = Fixed.Sqrt((value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z));
            factor = Fixed.One / factor;
            return new FixedVector3(value.X * factor, value.Y * factor, value.Z * factor);
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a normalized values from another vector.
        /// </summary>
        /// <param name="value">Source <see cref="FixedVector3"/>.</param>
        /// <param name="result">Unit vector as an output parameter.</param>
        public static void Normalize(ref FixedVector3 value, out FixedVector3 result)
        {
            Fixed factor = Fixed.Sqrt((value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z));
            factor = Fixed.One / factor;
            result.X = value.X * factor;
            result.Y = value.Y * factor;
            result.Z = value.Z * factor;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains reflect vector of the given vector and normal.
        /// </summary>
        /// <param name="vector">Source <see cref="FixedVector3"/>.</param>
        /// <param name="normal">Reflection normal.</param>
        /// <returns>Reflected vector.</returns>
        public static FixedVector3 Reflect(FixedVector3 vector, FixedVector3 normal)
        {
            // I is the original array
            // N is the normal of the incident plane
            // R = I - (2 * N * ( DotProduct[ I,N] ))
            FixedVector3 reflectedVector;
            // inline the dotProduct here instead of calling method
            Fixed dotProduct = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);
            reflectedVector.X = vector.X - (Fixed.Two * normal.X) * dotProduct;
            reflectedVector.Y = vector.Y - (Fixed.Two * normal.Y) * dotProduct;
            reflectedVector.Z = vector.Z - (Fixed.Two * normal.Z) * dotProduct;

            return reflectedVector;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains reflect vector of the given vector and normal.
        /// </summary>
        /// <param name="vector">Source <see cref="FixedVector3"/>.</param>
        /// <param name="normal">Reflection normal.</param>
        /// <param name="result">Reflected vector as an output parameter.</param>
        public static void Reflect(ref FixedVector3 vector, ref FixedVector3 normal, out FixedVector3 result)
        {
            // I is the original array
            // N is the normal of the incident plane
            // R = I - (2 * N * ( DotProduct[ I,N] ))

            // inline the dotProduct here instead of calling method
            Fixed dotProduct = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);
            result.X = vector.X - (Fixed.Two * normal.X) * dotProduct;
            result.Y = vector.Y - (Fixed.Two * normal.Y) * dotProduct;
            result.Z = vector.Z - (Fixed.Two * normal.Z) * dotProduct;
        }

        /// <summary>
        /// Round the members of this <see cref="FixedVector3"/> towards the nearest integer value.
        /// </summary>
        public void Round()
        {
            X = Fixed.Round(X);
            Y = Fixed.Round(Y);
            Z = Fixed.Round(Z);
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains members from another vector rounded to the nearest integer value.
        /// </summary>
        /// <param name="value">Source <see cref="FixedVector3"/>.</param>
        /// <returns>The rounded <see cref="FixedVector3"/>.</returns>
        public static FixedVector3 Round(FixedVector3 value)
        {
            value.X = Fixed.Round(value.X);
            value.Y = Fixed.Round(value.Y);
            value.Z = Fixed.Round(value.Z);
            return value;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains members from another vector rounded to the nearest integer value.
        /// </summary>
        /// <param name="value">Source <see cref="FixedVector3"/>.</param>
        /// <param name="result">The rounded <see cref="FixedVector3"/>.</param>
        public static void Round(ref FixedVector3 value, out FixedVector3 result)
        {
            result.X = Fixed.Round(value.X);
            result.Y = Fixed.Round(value.Y);
            result.Z = Fixed.Round(value.Z);
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains cubic interpolation of the specified vectors.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/>.</param>
        /// <param name="value2">Source <see cref="FixedVector3"/>.</param>
        /// <param name="amount">Weighting value.</param>
        /// <returns>Cubic interpolation of the specified vectors.</returns>
        public static FixedVector3 SmoothStep(FixedVector3 value1, FixedVector3 value2, Fixed amount)
        {
            return new FixedVector3(
                Fixed.SmoothStep(value1.X, value2.X, amount),
                Fixed.SmoothStep(value1.Y, value2.Y, amount),
                Fixed.SmoothStep(value1.Z, value2.Z, amount));
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains cubic interpolation of the specified vectors.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/>.</param>
        /// <param name="value2">Source <see cref="FixedVector3"/>.</param>
        /// <param name="amount">Weighting value.</param>
        /// <param name="result">Cubic interpolation of the specified vectors as an output parameter.</param>
        public static void SmoothStep(ref FixedVector3 value1, ref FixedVector3 value2, Fixed amount, out FixedVector3 result)
        {
            result.X = Fixed.SmoothStep(value1.X, value2.X, amount);
            result.Y = Fixed.SmoothStep(value1.Y, value2.Y, amount);
            result.Z = Fixed.SmoothStep(value1.Z, value2.Z, amount);
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains subtraction of on <see cref="FixedVector3"/> from a another.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/>.</param>
        /// <param name="value2">Source <see cref="FixedVector3"/>.</param>
        /// <returns>The result of the vector subtraction.</returns>
        public static FixedVector3 Subtract(FixedVector3 value1, FixedVector3 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            value1.Z -= value2.Z;
            return value1;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains subtraction of on <see cref="FixedVector3"/> from a another.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/>.</param>
        /// <param name="value2">Source <see cref="FixedVector3"/>.</param>
        /// <param name="result">The result of the vector subtraction as an output parameter.</param>
        public static void Subtract(ref FixedVector3 value1, ref FixedVector3 value2, out FixedVector3 result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
            result.Z = value1.Z - value2.Z;
        }

        /// <summary>
        /// Returns a <see cref="String"/> representation of this <see cref="FixedVector3"/> in the format:
        /// {X:[<see cref="X"/>] Y:[<see cref="Y"/>] Z:[<see cref="Z"/>]}
        /// </summary>
        /// <returns>A <see cref="String"/> representation of this <see cref="FixedVector3"/>.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(32);
            sb.Append("{X:");
            sb.Append(this.X);
            sb.Append(" Y:");
            sb.Append(this.Y);
            sb.Append(" Z:");
            sb.Append(this.Z);
            sb.Append("}");
            return sb.ToString();
        }

        #region Transform

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a transformation of 3d-vector by the specified <see cref="FixedMatrix"/>.
        /// </summary>
        /// <param name="position">Source <see cref="FixedVector3"/>.</param>
        /// <param name="matrix">The transformation <see cref="FixedMatrix"/>.</param>
        /// <returns>Transformed <see cref="FixedVector3"/>.</returns>
        public static FixedVector3 Transform(FixedVector3 position, FixedMatrix matrix)
        {
            Transform(ref position, ref matrix, out position);
            return position;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a transformation of 3d-vector by the specified <see cref="FixedMatrix"/>.
        /// </summary>
        /// <param name="position">Source <see cref="FixedVector3"/>.</param>
        /// <param name="matrix">The transformation <see cref="FixedMatrix"/>.</param>
        /// <param name="result">Transformed <see cref="FixedVector3"/> as an output parameter.</param>
        public static void Transform(ref FixedVector3 position, ref FixedMatrix matrix, out FixedVector3 result)
        {
            var x = (position.X * matrix.M11) + (position.Y * matrix.M21) + (position.Z * matrix.M31) + matrix.M41;
            var y = (position.X * matrix.M12) + (position.Y * matrix.M22) + (position.Z * matrix.M32) + matrix.M42;
            var z = (position.X * matrix.M13) + (position.Y * matrix.M23) + (position.Z * matrix.M33) + matrix.M43;
            result.X = x;
            result.Y = y;
            result.Z = z;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a transformation of 3d-vector by the specified <see cref="FixedQuaternion"/>, representing the rotation.
        /// </summary>
        /// <param name="value">Source <see cref="FixedVector3"/>.</param>
        /// <param name="rotation">The <see cref="FixedQuaternion"/> which contains rotation transformation.</param>
        /// <returns>Transformed <see cref="FixedVector3"/>.</returns>
        public static FixedVector3 Transform(FixedVector3 value, FixedQuaternion rotation)
        {
            FixedVector3 result;
            Transform(ref value, ref rotation, out result);
            return result;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a transformation of 3d-vector by the specified <see cref="FixedQuaternion"/>, representing the rotation.
        /// </summary>
        /// <param name="value">Source <see cref="FixedVector3"/>.</param>
        /// <param name="rotation">The <see cref="FixedQuaternion"/> which contains rotation transformation.</param>
        /// <param name="result">Transformed <see cref="FixedVector3"/> as an output parameter.</param>
        public static void Transform(ref FixedVector3 value, ref FixedQuaternion rotation, out FixedVector3 result)
        {
            Fixed x = Fixed.Two * (rotation.Y * value.Z - rotation.Z * value.Y);
            Fixed y = Fixed.Two * (rotation.Z * value.X - rotation.X * value.Z);
            Fixed z = Fixed.Two * (rotation.X * value.Y - rotation.Y * value.X);

            result.X = value.X + x * rotation.W + (rotation.Y * z - rotation.Z * y);
            result.Y = value.Y + y * rotation.W + (rotation.Z * x - rotation.X * z);
            result.Z = value.Z + z * rotation.W + (rotation.X * y - rotation.Y * x);
        }

        /// <summary>
        /// Apply transformation on vectors within array of <see cref="FixedVector3"/> by the specified <see cref="FixedMatrix"/> and places the results in an another array.
        /// </summary>
        /// <param name="sourceArray">Source array.</param>
        /// <param name="sourceIndex">The starting index of transformation in the source array.</param>
        /// <param name="matrix">The transformation <see cref="FixedMatrix"/>.</param>
        /// <param name="destinationArray">Destination array.</param>
        /// <param name="destinationIndex">The starting index in the destination array, where the first <see cref="FixedVector3"/> should be written.</param>
        /// <param name="length">The number of vectors to be transformed.</param>
        public static void Transform(FixedVector3[] sourceArray, int sourceIndex, ref FixedMatrix matrix, FixedVector3[] destinationArray, int destinationIndex, int length)
        {
            if (sourceArray == null)
                throw new ArgumentNullException("sourceArray");
            if (destinationArray == null)
                throw new ArgumentNullException("destinationArray");
            if (sourceArray.Length < sourceIndex + length)
                throw new ArgumentException("Source array length is lesser than sourceIndex + length");
            if (destinationArray.Length < destinationIndex + length)
                throw new ArgumentException("Destination array length is lesser than destinationIndex + length");

            // TODO: Are there options on some platforms to implement a vectorized version of this?

            for (var i = 0; i < length; i++)
            {
                var position = sourceArray[sourceIndex + i];
                destinationArray[destinationIndex + i] =
                    new FixedVector3(
                        (position.X * matrix.M11) + (position.Y * matrix.M21) + (position.Z * matrix.M31) + matrix.M41,
                        (position.X * matrix.M12) + (position.Y * matrix.M22) + (position.Z * matrix.M32) + matrix.M42,
                        (position.X * matrix.M13) + (position.Y * matrix.M23) + (position.Z * matrix.M33) + matrix.M43);
            }
        }

        /// <summary>
        /// Apply transformation on vectors within array of <see cref="FixedVector3"/> by the specified <see cref="FixedQuaternion"/> and places the results in an another array.
        /// </summary>
        /// <param name="sourceArray">Source array.</param>
        /// <param name="sourceIndex">The starting index of transformation in the source array.</param>
        /// <param name="rotation">The <see cref="FixedQuaternion"/> which contains rotation transformation.</param>
        /// <param name="destinationArray">Destination array.</param>
        /// <param name="destinationIndex">The starting index in the destination array, where the first <see cref="FixedVector3"/> should be written.</param>
        /// <param name="length">The number of vectors to be transformed.</param>
        public static void Transform(FixedVector3[] sourceArray, int sourceIndex, ref FixedQuaternion rotation, FixedVector3[] destinationArray, int destinationIndex, int length)
        {
            if (sourceArray == null)
                throw new ArgumentNullException("sourceArray");
            if (destinationArray == null)
                throw new ArgumentNullException("destinationArray");
            if (sourceArray.Length < sourceIndex + length)
                throw new ArgumentException("Source array length is lesser than sourceIndex + length");
            if (destinationArray.Length < destinationIndex + length)
                throw new ArgumentException("Destination array length is lesser than destinationIndex + length");

            // TODO: Are there options on some platforms to implement a vectorized version of this?

            for (var i = 0; i < length; i++)
            {
                var position = sourceArray[sourceIndex + i];

                Fixed x = Fixed.Two * (rotation.Y * position.Z - rotation.Z * position.Y);
                Fixed y = Fixed.Two * (rotation.Z * position.X - rotation.X * position.Z);
                Fixed z = Fixed.Two * (rotation.X * position.Y - rotation.Y * position.X);

                destinationArray[destinationIndex + i] =
                    new FixedVector3(
                        position.X + x * rotation.W + (rotation.Y * z - rotation.Z * y),
                        position.Y + y * rotation.W + (rotation.Z * x - rotation.X * z),
                        position.Z + z * rotation.W + (rotation.X * y - rotation.Y * x));
            }
        }

        /// <summary>
        /// Apply transformation on all vectors within array of <see cref="FixedVector3"/> by the specified <see cref="FixedMatrix"/> and places the results in an another array.
        /// </summary>
        /// <param name="sourceArray">Source array.</param>
        /// <param name="matrix">The transformation <see cref="FixedMatrix"/>.</param>
        /// <param name="destinationArray">Destination array.</param>
        public static void Transform(FixedVector3[] sourceArray, ref FixedMatrix matrix, FixedVector3[] destinationArray)
        {
            if (sourceArray == null)
                throw new ArgumentNullException("sourceArray");
            if (destinationArray == null)
                throw new ArgumentNullException("destinationArray");
            if (destinationArray.Length < sourceArray.Length)
                throw new ArgumentException("Destination array length is lesser than source array length");

            // TODO: Are there options on some platforms to implement a vectorized version of this?

            for (var i = 0; i < sourceArray.Length; i++)
            {
                var position = sourceArray[i];                
                destinationArray[i] =
                    new FixedVector3(
                        (position.X*matrix.M11) + (position.Y*matrix.M21) + (position.Z*matrix.M31) + matrix.M41,
                        (position.X*matrix.M12) + (position.Y*matrix.M22) + (position.Z*matrix.M32) + matrix.M42,
                        (position.X*matrix.M13) + (position.Y*matrix.M23) + (position.Z*matrix.M33) + matrix.M43);
            }
        }

        /// <summary>
        /// Apply transformation on all vectors within array of <see cref="FixedVector3"/> by the specified <see cref="FixedQuaternion"/> and places the results in an another array.
        /// </summary>
        /// <param name="sourceArray">Source array.</param>
        /// <param name="rotation">The <see cref="FixedQuaternion"/> which contains rotation transformation.</param>
        /// <param name="destinationArray">Destination array.</param>
        public static void Transform(FixedVector3[] sourceArray, ref FixedQuaternion rotation, FixedVector3[] destinationArray)
        {
            if (sourceArray == null)
                throw new ArgumentNullException("sourceArray");
            if (destinationArray == null)
                throw new ArgumentNullException("destinationArray");
            if (destinationArray.Length < sourceArray.Length)
                throw new ArgumentException("Destination array length is lesser than source array length");

            // TODO: Are there options on some platforms to implement a vectorized version of this?

            for (var i = 0; i < sourceArray.Length; i++)
            {
                var position = sourceArray[i];

                Fixed x = Fixed.Two * (rotation.Y * position.Z - rotation.Z * position.Y);
                Fixed y = Fixed.Two * (rotation.Z * position.X - rotation.X * position.Z);
                Fixed z = Fixed.Two * (rotation.X * position.Y - rotation.Y * position.X);

                destinationArray[i] =
                    new FixedVector3(
                        position.X + x * rotation.W + (rotation.Y * z - rotation.Z * y),
                        position.Y + y * rotation.W + (rotation.Z * x - rotation.X * z),
                        position.Z + z * rotation.W + (rotation.X * y - rotation.Y * x));
            }
        }

        #endregion

        #region TransformNormal

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a transformation of the specified normal by the specified <see cref="FixedMatrix"/>.
        /// </summary>
        /// <param name="normal">Source <see cref="FixedVector3"/> which represents a normal vector.</param>
        /// <param name="matrix">The transformation <see cref="FixedMatrix"/>.</param>
        /// <returns>Transformed normal.</returns>
        public static FixedVector3 TransformNormal(FixedVector3 normal, FixedMatrix matrix)
        {
            TransformNormal(ref normal, ref matrix, out normal);
            return normal;
        }

        /// <summary>
        /// Creates a new <see cref="FixedVector3"/> that contains a transformation of the specified normal by the specified <see cref="FixedMatrix"/>.
        /// </summary>
        /// <param name="normal">Source <see cref="FixedVector3"/> which represents a normal vector.</param>
        /// <param name="matrix">The transformation <see cref="FixedMatrix"/>.</param>
        /// <param name="result">Transformed normal as an output parameter.</param>
        public static void TransformNormal(ref FixedVector3 normal, ref FixedMatrix matrix, out FixedVector3 result)
        {
            var x = (normal.X * matrix.M11) + (normal.Y * matrix.M21) + (normal.Z * matrix.M31);
            var y = (normal.X * matrix.M12) + (normal.Y * matrix.M22) + (normal.Z * matrix.M32);
            var z = (normal.X * matrix.M13) + (normal.Y * matrix.M23) + (normal.Z * matrix.M33);
            result.X = x;
            result.Y = y;
            result.Z = z;
        }

        /// <summary>
        /// Apply transformation on normals within array of <see cref="FixedVector3"/> by the specified <see cref="FixedMatrix"/> and places the results in an another array.
        /// </summary>
        /// <param name="sourceArray">Source array.</param>
        /// <param name="sourceIndex">The starting index of transformation in the source array.</param>
        /// <param name="matrix">The transformation <see cref="FixedMatrix"/>.</param>
        /// <param name="destinationArray">Destination array.</param>
        /// <param name="destinationIndex">The starting index in the destination array, where the first <see cref="FixedVector3"/> should be written.</param>
        /// <param name="length">The number of normals to be transformed.</param>
        public static void TransformNormal(FixedVector3[] sourceArray,
         int sourceIndex,
         ref FixedMatrix matrix,
         FixedVector3[] destinationArray,
         int destinationIndex,
         int length)
        {
            if (sourceArray == null)
                throw new ArgumentNullException("sourceArray");
            if (destinationArray == null)
                throw new ArgumentNullException("destinationArray");
            if(sourceArray.Length < sourceIndex + length)
                throw new ArgumentException("Source array length is lesser than sourceIndex + length");
            if (destinationArray.Length < destinationIndex + length)
                throw new ArgumentException("Destination array length is lesser than destinationIndex + length");

            for (int x = 0; x < length; x++)
            {
                var normal = sourceArray[sourceIndex + x];

                destinationArray[destinationIndex + x] =
                     new FixedVector3(
                        (normal.X * matrix.M11) + (normal.Y * matrix.M21) + (normal.Z * matrix.M31),
                        (normal.X * matrix.M12) + (normal.Y * matrix.M22) + (normal.Z * matrix.M32),
                        (normal.X * matrix.M13) + (normal.Y * matrix.M23) + (normal.Z * matrix.M33));
            }
        }

        /// <summary>
        /// Apply transformation on all normals within array of <see cref="FixedVector3"/> by the specified <see cref="FixedMatrix"/> and places the results in an another array.
        /// </summary>
        /// <param name="sourceArray">Source array.</param>
        /// <param name="matrix">The transformation <see cref="FixedMatrix"/>.</param>
        /// <param name="destinationArray">Destination array.</param>
        public static void TransformNormal(FixedVector3[] sourceArray, ref FixedMatrix matrix, FixedVector3[] destinationArray)
        {
            if(sourceArray == null)
                throw new ArgumentNullException("sourceArray");
            if (destinationArray == null)
                throw new ArgumentNullException("destinationArray");
            if (destinationArray.Length < sourceArray.Length)
                throw new ArgumentException("Destination array length is lesser than source array length");

            for (var i = 0; i < sourceArray.Length; i++)
            {
                var normal = sourceArray[i];

                destinationArray[i] =
                    new FixedVector3(
                        (normal.X*matrix.M11) + (normal.Y*matrix.M21) + (normal.Z*matrix.M31),
                        (normal.X*matrix.M12) + (normal.Y*matrix.M22) + (normal.Z*matrix.M32),
                        (normal.X*matrix.M13) + (normal.Y*matrix.M23) + (normal.Z*matrix.M33));
            }
        }

        #endregion

        /// <summary>
        /// Deconstruction method for <see cref="FixedVector3"/>.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Deconstruct(out Fixed x, out Fixed y, out Fixed z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        /// <summary>
        /// Returns a <see cref="System.Numerics.Vector3"/>.
        /// </summary>
        public System.Numerics.Vector3 ToNumerics()
        {
            return new System.Numerics.Vector3((float)this.X, (float)this.Y, (float)this.Z);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Converts a <see cref="System.Numerics.Vector3"/> to a <see cref="FixedVector3"/>.
        /// </summary>
        /// <param name="value">The converted value.</param>
        public static implicit operator FixedVector3(System.Numerics.Vector3 value)
        {
            return new FixedVector3((Fixed)value.X, (Fixed)value.Y, (Fixed)value.Z);
        }

        /// <summary>
        /// Compares whether two <see cref="FixedVector3"/> instances are equal.
        /// </summary>
        /// <param name="value1"><see cref="FixedVector3"/> instance on the left of the equal sign.</param>
        /// <param name="value2"><see cref="FixedVector3"/> instance on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(FixedVector3 value1, FixedVector3 value2)
        {
            return value1.X == value2.X
                && value1.Y == value2.Y
                && value1.Z == value2.Z;
        }

        /// <summary>
        /// Compares whether two <see cref="FixedVector3"/> instances are not equal.
        /// </summary>
        /// <param name="value1"><see cref="FixedVector3"/> instance on the left of the not equal sign.</param>
        /// <param name="value2"><see cref="FixedVector3"/> instance on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>	
        public static bool operator !=(FixedVector3 value1, FixedVector3 value2)
        {
            return !(value1 == value2);
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/> on the left of the add sign.</param>
        /// <param name="value2">Source <see cref="FixedVector3"/> on the right of the add sign.</param>
        /// <returns>Sum of the vectors.</returns>
        public static FixedVector3 operator +(FixedVector3 value1, FixedVector3 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            value1.Z += value2.Z;
            return value1;
        }

        /// <summary>
        /// Inverts values in the specified <see cref="FixedVector3"/>.
        /// </summary>
        /// <param name="value">Source <see cref="FixedVector3"/> on the right of the sub sign.</param>
        /// <returns>Result of the inversion.</returns>
        public static FixedVector3 operator -(FixedVector3 value)
        {
            value = new FixedVector3(-value.X, -value.Y, -value.Z);
            return value;
        }

        /// <summary>
        /// Subtracts a <see cref="FixedVector3"/> from a <see cref="FixedVector3"/>.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/> on the left of the sub sign.</param>
        /// <param name="value2">Source <see cref="FixedVector3"/> on the right of the sub sign.</param>
        /// <returns>Result of the vector subtraction.</returns>
        public static FixedVector3 operator -(FixedVector3 value1, FixedVector3 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            value1.Z -= value2.Z;
            return value1;
        }

        /// <summary>
        /// Multiplies the components of two vectors by each other.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/> on the left of the mul sign.</param>
        /// <param name="value2">Source <see cref="FixedVector3"/> on the right of the mul sign.</param>
        /// <returns>Result of the vector multiplication.</returns>
        public static FixedVector3 operator *(FixedVector3 value1, FixedVector3 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            value1.Z *= value2.Z;
            return value1;
        }

        /// <summary>
        /// Multiplies the components of vector by a scalar.
        /// </summary>
        /// <param name="value">Source <see cref="FixedVector3"/> on the left of the mul sign.</param>
        /// <param name="scaleFactor">Scalar value on the right of the mul sign.</param>
        /// <returns>Result of the vector multiplication with a scalar.</returns>
        public static FixedVector3 operator *(FixedVector3 value, Fixed scaleFactor)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            value.Z *= scaleFactor;
            return value;
        }

        /// <summary>
        /// Multiplies the components of vector by a scalar.
        /// </summary>
        /// <param name="scaleFactor">Scalar value on the left of the mul sign.</param>
        /// <param name="value">Source <see cref="FixedVector3"/> on the right of the mul sign.</param>
        /// <returns>Result of the vector multiplication with a scalar.</returns>
        public static FixedVector3 operator *(Fixed scaleFactor, FixedVector3 value)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            value.Z *= scaleFactor;
            return value;
        }

        /// <summary>
        /// Divides the components of a <see cref="FixedVector3"/> by the components of another <see cref="FixedVector3"/>.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/> on the left of the div sign.</param>
        /// <param name="value2">Divisor <see cref="FixedVector3"/> on the right of the div sign.</param>
        /// <returns>The result of dividing the vectors.</returns>
        public static FixedVector3 operator /(FixedVector3 value1, FixedVector3 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            value1.Z /= value2.Z;
            return value1;
        }

        /// <summary>
        /// Divides the components of a <see cref="FixedVector3"/> by a scalar.
        /// </summary>
        /// <param name="value1">Source <see cref="FixedVector3"/> on the left of the div sign.</param>
        /// <param name="divider">Divisor scalar on the right of the div sign.</param>
        /// <returns>The result of dividing a vector by a scalar.</returns>
        public static FixedVector3 operator /(FixedVector3 value1, Fixed divider)
        {
            Fixed factor = Fixed.One / divider;
            value1.X *= factor;
            value1.Y *= factor;
            value1.Z *= factor;
            return value1;
        }

        #endregion
    }
}
