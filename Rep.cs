using Newtonsoft.Json;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Rep Implimentation of BaseInfo 
    /// </summary>
    public class Rep : BaseInfo
    {
        /// <summary>
        /// Static ID For Tracking All Reps
        /// </summary>
        public static int Rep_ID = 0;

        /// <summary>
        /// Name Of Rep
        /// </summary>
        [JsonProperty("Name")]
        public override string Name { get; set; }

        /// <summary>
        /// Email Of Rep
        /// </summary>
        [JsonProperty("Email")]
        public override string Extra { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Rep() : this(" ") { }

        /// <summary>
        /// String Constructor
        /// </summary>
        /// <param name="name">The Name Of The Rep</param>
        public Rep(string name) : this(name, " ") { }

        /// <summary>
        /// String, String Constructor
        /// </summary>
        /// <param name="name">The Name Of The Rep</param>
        /// /// <param name="email">The Email Of The Rep</param>
        public Rep(string name, string email)
        {
            Name = name;
            Extra = email;
            ID = Rep_ID++;
        }
    }

}
