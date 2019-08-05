using Newtonsoft.Json;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Job Board Implimentation of BaseInfo 
    /// </summary>
    public class Board : BaseInfo
    {
        // Static ID For Tracking All Job Boards
        public static int Board_ID = 0;

        // Name Of Job Board
        [JsonProperty("Name")]
        public override string Name { get; set; }

        // Website Of Job Board
        [JsonProperty("Website")]
        public override string Extra { get; set; }

        // Default Constructor
        public Board() : this(" ") { }

        // String Param Constructor
        public Board(string name) : this(name, " ") { }

        // String, String Param Constructor 
        public Board(string name, string website)
        {
            Name = name;
            Extra = website;
            ID = Board_ID++;
        }
    }
}
