using Newtonsoft.Json;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Rep Implimentation of BaseInfo 
    /// </summary>
    public class Rep : BaseInfo
    {
        // Static ID For Tracking All Reps
        public static int Rep_ID = 0;

        // Name Of Rep
        [JsonProperty("Name")]
        public override string Name { get; set; }

        // Email Of Rep
        [JsonProperty("Email")]
        public override string Extra { get; set; }

        // Default Constructor
        public Rep() : this(" ") { }

        // String Param Constructor
        public Rep(string name) : this(name, " ") { }

        // String, String Param Constructor
        public Rep(string name, string email)
        {
            Name = name;
            Extra = email;
            ID = Rep_ID++;
        }
    }
}
