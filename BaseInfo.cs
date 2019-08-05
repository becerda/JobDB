using Newtonsoft.Json;
using System;

namespace Job_Application_Database
{

    public interface IBaseInfo
    {
        string Name { get; set; }

        string Extra { get; set; }

        int ID { get; }

        int GetHashCode();
    }

    public abstract class BaseInfo : IBaseInfo, IEquatable<BaseInfo>, IComparable<BaseInfo>
    {
        public abstract string Name { get; set; }

        public abstract string Extra { get; set; }

        public int ID { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Rep other = obj as Rep;
            if (other == null) return false;
            else return Equals(other);
        }

        public int SortByNameAscending(string name1, string name2)
        {
            return name1.CompareTo(name2);
        }


        public int CompareTo(BaseInfo other)
        {
            if (other == null)
                return 1;
            else
                return this.ID.CompareTo(other.ID);
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public bool Equals(BaseInfo other)
        {
            if (other == null) return false;
            return this.ID.Equals(other.ID);
        }

        public static bool operator ==(BaseInfo r1, BaseInfo r2)
        {
            if (ReferenceEquals(r1, r2)) return true;
            if (ReferenceEquals(r1, null)) return false;
            if (ReferenceEquals(r2, null)) return false;
            return r1.ID == r2.ID;
        }

        public static bool operator !=(BaseInfo r1, BaseInfo r2)
        {
            return !(r1 == r2);
        }
    }

    public class Board : BaseInfo
    {
        public static int Board_ID = 0;

        [JsonProperty("Name")]
        public override string Name { get; set; }

        [JsonProperty("Website")]
        public override string Extra { get; set; }

        public Board() : this(" ") { }

        public Board(string name) : this(name, " ") { }

        public Board(string name, string website)
        {
            Name = name;
            Extra = website;
            ID = Board_ID++;
        }
    }

    public class Rep : BaseInfo
    {
        public static int Rep_ID = 0;

        [JsonProperty("Name")]
        public override string Name { get; set; }

        [JsonProperty("Email")]
        public override string Extra { get; set; }

        public Rep() : this(" ") { }

        public Rep(string name) : this(name, " ") { }

        public Rep(string name, string email)
        {
            Name = name;
            Extra = email;
            ID = Rep_ID++;
        }
    }

    public class Job : BaseInfo
    {
        public static int Job_ID = 0;

        [JsonProperty("Title")]
        public override string Name { get; set; }

        [JsonProperty("Salary")]
        public override string Extra { get; set; }

        public Job() : this(" ") { }

        public Job(string title) : this(title, "0") { }

        [JsonConstructor]
        public Job(string title, string salery)
        {
            Name = title;
            Extra = salery;
            ID = Job_ID++;
        }
    }
}
