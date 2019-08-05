using Newtonsoft.Json;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Job Implimentation of BaseInfo 
    /// </summary>
    public class Job : BaseInfo
    {
        // Static ID For Tracking All Jobs
        public static int Job_ID = 0;

        // Title Of Job
        [JsonProperty("Title")]
        public override string Name { get; set; }

        // Salary Of Job
        [JsonProperty("Salary")]
        public override string Extra { get; set; }

        // Default Constructor
        public Job() : this(" ") { }

        // String Param Constructor
        public Job(string title) : this(title, "0") { }

        // String, String Param Constructor
        [JsonConstructor]
        public Job(string title, string salery)
        {
            Name = title;
            Extra = salery;
            ID = Job_ID++;
        }
    }
}
