using Job_Application_Database.Enum;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Job creation window extended from BaseCreation
    /// </summary>
    public class JobCreation : BaseCreation
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public JobCreation() : this(new Job(), EditMode.New) { }

        /// <summary>
        /// Editing Constructor
        /// </summary>
        /// <param name="job">The Job To Edit</param>
        public JobCreation(Job job) : this(job, EditMode.Edit) { }

        /// <summary>
        /// Base Constructor
        /// </summary>
        /// <param name="job">The Job To Edit</param>
        /// <param name="mode">The Editing Mode</param>
        private JobCreation(Job job, EditMode mode) : base(job, mode, "Job", "Salary") { }
    }

}
