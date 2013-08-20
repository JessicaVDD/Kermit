using System;

namespace Willow.Kermit
{
    public class MethodKey : IEquatable<MethodKey>
    {
        private readonly string _Method;
        private readonly Type[] _Types;
        private readonly int _Hashcode;

        public MethodKey(string method, Type returnValueOrDelegate, params Type[] args)
        {
            this._Method = method;
            if (args == null)
                this._Types = new[] {returnValueOrDelegate};
            else
            {
                this._Types = new Type[args.Length + 1];
                this._Types[0] = returnValueOrDelegate;
                for (var i = 1; i < this._Types.Length; i++) 
                    this._Types[i] = args[i - 1];
            }
            this._Hashcode = this.CalculateHash();
        }

        private int CalculateHash()
        {
            var hc = this._Method.GetHashCode();
            unchecked
            {
                for (var i = 0; i < this._Types.Length; i++) 
                    hc = hc * 23 + this._Types[i].GetHashCode();
            }

            return hc;
        }

        public override int GetHashCode()
        {
            return this._Hashcode;
        }

        public bool Equals(MethodKey other)
        {
            if (other == null) return false;
            if (other._Method != this._Method) return false;
            if (other._Types.Length != this._Types.Length) return false;

            for (var i = 0; i < this._Types.Length; i++)
            {
                if (this._Types[i] != other._Types[i]) 
                    return false;
            }

            return true;
        }
    }
}