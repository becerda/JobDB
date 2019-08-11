using Newtonsoft.Json;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Job Implimentation of BaseInfo 
    /// </summary>
    public class Job : BaseInfo
    {
        /// <summary>
        /// Static ID For Tracking All Jobs
        /// </summary>
        public static int Job_ID = 0;

        /// <summary>
        /// Title Of Job
        /// </summary>
        [JsonProperty("Title")]
        public override string Name { get; set; }

        /// <summary>
        /// Salary Of Job
        /// </summary>
        [JsonProperty("Salary")]
        public override string Extra { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Job() : this(" ") { }

        /// <summary>
        /// String Constructor
        /// </summary>
        /// <param name="title">The Name Of The Job</param>
        public Job(string title) : this(title, "0") { }

        /// <summary>
        /// String, String Constructor
        /// </summary>
        /// <param name="title">The Name Of The Job</param>
        /// <param name="salery">The Salary Of The Job</param>
        [JsonConstructor]
        public Job(string title, string salery)
        {
            Name = title;
            Extra = salery;
            ID = Job_ID++;
        }
    }

}
