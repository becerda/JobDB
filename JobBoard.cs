using Newtonsoft.Json;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Job Board Implimentation of BaseInfo 
    /// </summary>
    public class JobBoard : BaseInfo
    {
        /// <summary>
        /// Static ID For Tracking All Job Boards
        /// </summary>
        public static int Board_ID = 0;

        /// <summary>
        /// Name Of Job Board
        /// </summary>
        [JsonProperty("Name")]
        public override string Name { get; set; }

        /// <summary>
        /// Website Of Job Board
        /// </summary>
        [JsonProperty("Website")]
        public override string Extra { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public JobBoard() : this(" ") { }

        /// <summary>
        /// String Param Constructor
        /// </summary>
        /// <param name="name">Name Of The Job Board</param>
        public JobBoard(string name) : this(name, " ") { }

        /// <summary>
        /// String, String Param Constructor 
        /// </summary>
        /// <param name="name">Name Of The Job Board</param>
        /// <param name="website">Website Of The Job Board</param>
        public JobBoard(string name, string website)
        {
            Name = name;
            Extra = website;
            ID = Board_ID++;
        }
    }

}
