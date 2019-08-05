using Job_Application_Database.Singleton;
using Newtonsoft.Json;
using System;

namespace Job_Application_Database.Classes
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Company : BaseInfo
    {
        public static int Comp_ID = 0;

        private Job _job;
        private Rep _rep;
        private Board _bor;

        [JsonProperty("Name")]
        public override string Name { get; set; }

        public override string Extra { get; set; }

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

        [JsonProperty("Rep")]
        public int RepID { get; private set; }

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

        [JsonProperty("Job")]
        public int JobID { get; private set; }

        public Board Board
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

        [JsonProperty("Board")]
        public int BoardID { get; private set; }

        [JsonProperty("Position")]
        public Enum.PositionType Position { get; set; }

        [JsonProperty("Status")]
        public Enum.Status Status { get; set; }

        [JsonProperty("AppDate")]
        public DateTime AppDate { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

        [JsonProperty("Notes")]
        public string Notes { get; set; }

        public Company() : this("New Company", "") { }
        public Company(string name, string website)
            : this(name, website, 0) { }
        public Company(string name, string website, int rep)
            : this(name, website, rep, 0) { }
        public Company(string name, string website, int rep, int job)
            : this(name, website, rep, job, 0) { }

        public Company(string name, string website, int rep, int job, int board)
            : this(name, website, rep, job, board, Enum.Status.Applied) { }

        public Company(string name, string website, int rep, int job, int board, Enum.Status status)
            : this(name, website, rep, job, board, status, DateTime.Today) { }
        public Company(string name, string website, int rep, int job, int board, Enum.Status status, DateTime appDate)
            : this(name, website, rep, job, board, status, appDate, "") { }
        public Company(string name, string website, int rep, int job, int board, Enum.Status status, DateTime appDate, string location)
            : this(name, website, rep, job, board, status, appDate, location, Enum.PositionType.Full) { }
        public Company(string name, string website, int rep, int job, int board, Enum.Status status, DateTime appDate, string location, Enum.PositionType type)
            : this(name, website, rep, job, board, status, appDate, location, type, "") { }
        public Company(string name, string website, int repid, int jobid, int boardid, Enum.Status status, DateTime appDate, string location, Enum.PositionType type, string notes)
        {
            Name = name;
            WebSite = website;
            RepID = repid;
            Rep = Reps.Instance.ObjectAt(RepID) as Rep;
            JobID = jobid;
            Job = Jobs.Instance.ObjectAt(JobID) as Job;
            BoardID = boardid;
            Board = Boards.Instance.ObjectAt(BoardID) as Board;
            Status = status;
            AppDate = appDate;
            Location = location;
            Position = type;
            Notes = notes;
            ID = Comp_ID++;
        }
    }

}
