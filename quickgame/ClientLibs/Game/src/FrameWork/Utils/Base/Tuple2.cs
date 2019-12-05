// --------------------------------------------------------------------------
// Functional Programming in .NET - Chapter 3
// --------------------------------------------------------------------------
// NOTE: This library contains several useful classes for functional 
// programming in C# that we implemented in chapter 3 and that we'll 
// extend and use later in the book. Each secion is marked with a reference
// to a code listing or section in the book where it was discussed.
// --------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace xc
{
    // --------------------------------------------------------------------------
    // Section 3.2.2: Implementing tuple in C#

    // Listing 3.7: Implementing the tuple type in C#

    /// <summary>
    /// Represents a functional tuple that can be used to store 
    /// two values of different types inside one object.
    /// </summary>
    /// <typeparam name="T1">The type of the first element</typeparam>
    /// <typeparam name="T2">The type of the second element</typeparam>
    public sealed class Tuple<T1, T2>
    {
        private readonly T1 item1_;
        private readonly T2 item2_;

        /// <summary>
        /// Retyurns the first element of the tuple
        /// </summary>
        public T1 get_item1_
        {
            get { return item1_; }
        }

        /// <summary>
        /// Returns the second element of the tuple
        /// </summary>
        public T2 get_item2_
        {
            get { return item2_; }
        }

        /// <summary>
        /// Create a new tuple value
        /// </summary>
        /// <param name="item1">First element of the tuple</param>
        /// <param name="second">Second element of the tuple</param>
        public Tuple(T1 item1, T2 item2)
        {
            this.item1_ = item1;
            this.item2_ = item2;
        }

        public override string ToString()
        {
			return string.Format("Tuple({0}, {1})", get_item1_, get_item2_);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + item1_.GetHashCode();
            hash = hash * 23 + item2_.GetHashCode();
            return hash;
        }

        public override bool Equals(object _o)
        {
            if (_o.GetType() != typeof(Tuple<T1, T2>)) {
                return false;
            }

            var other = (Tuple<T1, T2>) _o;

            return this == other;
        }

        public static bool operator==(Tuple<T1, T2> _a, Tuple<T1, T2> _b)
        {
            return 
           		 _a.item1_.Equals(_b.item1_) && 
                _a.item2_.Equals(_b.item2_);            
        }

        public static bool operator!=(Tuple<T1, T2> _a, Tuple<T1, T2> _b)
        {
            return !(_a == _b);
        }

        public void Unpack(Action<T1, T2> _unpacker_delegate)
        {
			_unpacker_delegate(get_item1_, get_item2_);
        }
    }
}
