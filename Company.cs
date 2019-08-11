using Job_Application_Database.Enum;
using Job_Application_Database.Singleton;
using Newtonsoft.Json;
using System;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Company Implimentation of BaseInfo 
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Company : BaseInfo
    {
        /// <summary>
        /// ID For Each Company
        /// </summary>
        public static int Comp_ID = 0;

        /// <summary>
        /// Reference To The Job
        /// </summary>
        private Job _job;

        /// <summary>
        /// Reference To The Rep
        /// </summary>
        private Rep _rep;
        
        /// <summary>
        /// Reference To The JobBoard
        /// </summary>
        private JobBoard _bor;

        /// <summary>
        /// The Name Of The Company
        /// </summary>
        [JsonProperty("Name")]
        public override string Name { get; set; }

        /// <summary>
        /// String Extra Implementation Used For Website
        /// </summary>
        public override string Extra { get; set; }

        /// <summary>
        /// The Website Of The Company
        /// </summary>
        [JsonProperty("Web")]
        public string WebSite
        {
            get
            {
                return Extra;
            }
            set
            {
                Extra = value;
            }
        }

        /// <summary>
        /// The Rep Of The Company
        /// Also Sets RepID
        /// </summary>
        public Rep Rep
        {
            get
            {
                return _rep;
            }
            set
            {
                _rep = value;
                RepID = value.ID;
            }
        }

        /// <summary>
        /// The Rep ID Used For Saving File
        /// </summary>
        [JsonProperty("Rep")]
        public int RepID { get; private set; }

        /// <summary>
        /// The Job Of The Company
        /// Also Sets JobID
        /// </summary>
        public Job Job
        {
            get
            {
                return _job;
            }
            set
            {
                _job = value;
                JobID = value.ID;
            }
        }

        /// <summary>
        /// The Job ID Used For Saving File
        /// </summary>
        [JsonProperty("Job")]
        public int JobID { get; private set; }

        /// <summary>
        /// The JobBoard Of The Company
        /// Also Sets JobBoardID
        /// </summary>
        public JobBoard Board
        {
            get
            {
                return _bor;
            }
            set
            {
                _bor = value;
                BoardID = value.ID;
            }
        }

        /// <summary>
        /// The JobBoard ID Used For Saving
        /// </summary>
        [JsonProperty("Board")]
        public int BoardID { get; private set; }

        /// <summary>
        /// The Position Type Of The Company
        /// </summary>
        [JsonProperty("Position")]
        public PositionType Position { get; set; }

        /// <summary>
        /// The Application Status Of The Company
        /// </summary>
        [JsonProperty("Status")]
        public ApplicationStatus Status { get; set; }

        /// <summary>
        /// The Application Date Of The Company
        /// </summary>
        [JsonProperty("AppDate")]
        public DateTime AppDate { get; set; }

        /// <summary>
        /// The Location Of The Company
        /// </summary>
        [JsonProperty("Location")]
        public string Location { get; set; }

        /// <summary>
        /// The Notes Of The Company
        /// </summary>
        [JsonProperty("Notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Company() : this("New Company", "") { }
        
        /// <summary>
        /// String, String Constructor
        /// </summary>
        /// <param name="name">The Name Of Company</param>
        /// <param name="website">The Website Of Company</param>
        public Company(string name, string website)
            : this(name, website, 0) { }

        /// <summary>
        /// String, String, Int Constructor
        /// </summary>
        /// <param name="name">The Name Of Company</param>
        /// <param name="website">The Website Of Company</param>
        /// <param name="rep">The ID Of The Rep</param>
        public Company(string name, string website, int rep)
            : this(name, website, rep, 0) { }

        /// <summary>
        /// String, String, Int, Int Constructor
        /// </summary>
        /// <param name="name">The Name Of Company</param>
        /// <param name="website">The Website Of Company</param>
        /// <param name="rep">The ID Of The Rep</param>
        /// <param name="job">The ID Of The Job</param>
        public Company(string name, string website, int rep, int job)
            : this(name, website, rep, job, 0) { }

        /// <summary>
        /// String, String, Int, Int, Int Constructor
        /// </summary>
        /// <param name="name">The Name Of Company</param>
        /// <param name="website">The Website Of Company</param>
        /// <param name="rep">The ID Of The Rep</param>
        /// <param name="job">The ID Of The Job</param>
        /// <param name="board">The ID Of The JobBoard</param>
        public Company(string name, string website, int rep, int job, int board)
            : this(name, website, rep, job, board, ApplicationStatus.Applied) { }

        /// <summary>
        /// String, String, Int, Int, Int, ApplicationStatus Constructor
        /// </summary>
        /// <param name="name">The Name Of Company</param>
        /// <param name="website">The Website Of Company</param>
        /// <param name="rep">The ID Of The Rep</param>
        /// <param name="job">The ID Of The Job</param>
        /// <param name="board">The ID Of The JobBoard</param>
        /// <param name="status">The Application Status Of The Job</param>
        public Company(string name, string website, int rep, int job, int board, ApplicationStatus status)
            : this(name, website, rep, job, board, status, DateTime.Today) { }

        /// <summary>
        /// String, String, Int, Int, Int, ApplicationStatus, DateTime Constructor
        /// </summary>
        /// <param name="name">The Name Of Company</param>
        /// <param name="website">The Website Of Company</param>
        /// <param name="rep">The ID Of The Rep</param>
        /// <param name="job">The ID Of The Job</param>
        /// <param name="board">The ID Of The JobBoard</param>
        /// <param name="status">The Application Status Of The Job</param>
        /// <param name="appDate">The Time Of Application</param>
        public Company(string name, string website, int rep, int job, int board, ApplicationStatus status, DateTime appDate)
            : this(name, website, rep, job, board, status, appDate, "") { }

        /// <summary>
        /// String, String, Int, Int, Int, ApplicationStatus, DateTime, String Constructor
        /// </summary>
        /// <param name="name">The Name Of Company</param>
        /// <param name="website">The Website Of Company</param>
        /// <param name="rep">The ID Of The Rep</param>
        /// <param name="job">The ID Of The Job</param>
        /// <param name="board">The ID Of The JobBoard</param>
        /// <param name="status">The Application Status Of The Job</param>
        /// <param name="appDate">The Time Of Application</param>
        /// <param name="location">The Location Of The Company</param>
        public Company(string name, string website, int rep, int job, int board, ApplicationStatus status, DateTime appDate, string location)
            : this(name, website, rep, job, board, status, appDate, location, PositionType.Full) { }

        /// <summary>
        /// String, String, Int, Int, Int, ApplicationStatus, DateTime, String, PositionType Constructor
        /// </summary>
        /// <param name="name">The Name Of Company</param>
        /// <param name="website">The Website Of Company</param>
        /// <param name="rep">The ID Of The Rep</param>
        /// <param name="job">The ID Of The Job</param>
        /// <param name="board">The ID Of The JobBoard</param>
        /// <param name="status">The Application Status Of The Job</param>
        /// <param name="appDate">The Time Of Application</param>
        /// <param name="location">The Location Of The Company</param>
        /// <param name="type">The Postition Type Of The Job</param>
        public Company(string name, string website, int rep, int job, int board, ApplicationStatus status, DateTime appDate, string location, PositionType type)
            : this(name, website, rep, job, board, status, appDate, location, type, "") { }

        /// <summary>
        /// String, String, Int, Int, Int, ApplicationStatus, DateTime, String, PositionType, String Constructor
        /// </summary>
        /// <param name="name">The Name Of Company</param>
        /// <param name="website">The Website Of Company</param>
        /// <param name="rep">The ID Of The Rep</param>
        /// <param name="job">The ID Of The Job</param>
        /// <param name="board">The ID Of The JobBoard</param>
        /// <param name="status">The Application Status Of The Job</param>
        /// <param name="appDate">The Time Of Application</param>
        /// <param name="location">The Location Of The Company</param>
        /// <param name="type">The Postition Type Of The Job</param>
        /// <param name="notes">The Notes Of The Company</param>
        public Company(string name, string website, int repid, int jobid, int boardid, ApplicationStatus status, DateTime appDate, string location, PositionType type, string notes)
        {
            Name = name;
            WebSite = website;
            RepID = repid;
            Rep = Reps.Instance.ObjectAt(RepID) as Rep;
            JobID = jobid;
            Job = Jobs.Instance.ObjectAt(JobID) as Job;
            BoardID = boardid;
            Board = JobBoards.Instance.ObjectAt(BoardID) as JobBoard;
            Status = status;
            AppDate = appDate;
            Location = location;
            Position = type;
            Notes = notes;
            ID = Comp_ID++;
        }
    }

}
