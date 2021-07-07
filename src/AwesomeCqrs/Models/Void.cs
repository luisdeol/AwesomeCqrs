using System;
using System.Threading.Tasks;

namespace AwesomeCqrs
{
    public readonly struct Void : IEquatable<Void>, IComparable<Void>, IComparable
    {
        private static readonly Void _value = new();

        public static ref readonly Void Value => ref _value;
        public static Task<Void> Task { get; } = System.Threading.Tasks.Task.FromResult(_value);

        public int CompareTo(object obj)
        {
            return 0;
        }

        public int CompareTo(Void other)
        {
            return 0;
        }

        public bool Equals(Void other)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}