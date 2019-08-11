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
        /// <summary>
        /// The Name Of The Object
        /// </summary>
        public abstract string Name { get; set; }

        /// <summary>
        /// A String Extra Of The Object
        /// </summary>
        public abstract string Extra { get; set; }

        /// <summary>
        /// The ID Of The Object
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Equals(object) Override
        /// </summary>
        /// <param name="obj">The Object To Compair To</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Rep other = obj as Rep;
            if (other == null) return false;
            else return Equals(other);
        }

        /// <summary>
        /// CompareTo() Override
        /// </summary>
        /// <param name="other">The BaseInfo To Comapair To</param>
        /// <returns></returns>
        public int CompareTo(BaseInfo other)
        {
            if (other == null)
                return 1;
            else
                return this.ID.CompareTo(other.ID);
        }

        /// <summary>
        /// GetHashCode() Override
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ID;
        }

        /// <summary>
        /// Equals(BaseInfo) Override
        /// </summary>
        /// <param name="other">The BaseInfo To Compair To</param>
        /// <returns></returns>
        public bool Equals(BaseInfo other)
        {
            if (other == null) return false;
            return this.ID.Equals(other.ID);
        }

        /// <summary>
        /// == Operator Override
        /// </summary>
        /// <param name="r1">A BaseInfo Object</param>
        /// <param name="r2">A BaseInfo Object</param>
        /// <returns></returns>
        public static bool operator ==(BaseInfo r1, BaseInfo r2)
        {
            if (ReferenceEquals(r1, r2)) return true;
            if (ReferenceEquals(r1, null)) return false;
            if (ReferenceEquals(r2, null)) return false;
            return r1.ID == r2.ID;
        }

        /// <summary>
        /// != Operator Override
        /// </summary>
        /// <param name="r1">A BaseInfo Object</param>
        /// <param name="r2">A BaseInfo Object</param>
        /// <returns></returns>
        public static bool operator !=(BaseInfo r1, BaseInfo r2)
        {
            return !(r1 == r2);
        }
    }

}
