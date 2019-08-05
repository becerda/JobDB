using System;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Interface For BaseInfo Object
    /// </summary>
    public interface IBaseInfo
    {
        // The Name Of The Object
        string Name { get; set; }

        // A String Extra Of The Object
        string Extra { get; set; }

        // The ID Of The Object
        int ID { get; }

        // Hash Code Override
        int GetHashCode();
    }

    /// <summary>
    /// Base Implimentation of IBaseInfo
    /// </summary>
    public abstract class BaseInfo : IBaseInfo, IEquatable<BaseInfo>, IComparable<BaseInfo>
    {
        // The Name Of The Object
        public abstract string Name { get; set; }

        // A String Extra Of The Object
        public abstract string Extra { get; set; }

        // The ID Of The Object
        public int ID { get; set; }

        // Equals(object) Override
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Rep other = obj as Rep;
            if (other == null) return false;
            else return Equals(other);
        }

        // CompareTo() Override
        public int CompareTo(BaseInfo other)
        {
            if (other == null)
                return 1;
            else
                return this.ID.CompareTo(other.ID);
        }

        // GetHashCode() Override
        public override int GetHashCode()
        {
            return ID;
        }

        // Equals(BaseInfo) Override
        public bool Equals(BaseInfo other)
        {
            if (other == null) return false;
            return this.ID.Equals(other.ID);
        }

        // == Operator Override
        public static bool operator ==(BaseInfo r1, BaseInfo r2)
        {
            if (ReferenceEquals(r1, r2)) return true;
            if (ReferenceEquals(r1, null)) return false;
            if (ReferenceEquals(r2, null)) return false;
            return r1.ID == r2.ID;
        }

        // != Operator Override
        public static bool operator !=(BaseInfo r1, BaseInfo r2)
        {
            return !(r1 == r2);
        }
    }

}
