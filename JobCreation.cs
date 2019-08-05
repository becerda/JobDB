using Job_Application_Database.Enum;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Job creation window extended from BaseCreation
    /// </summary>
    public class JobCreation : BaseCreation
    {
        // Default Constructor
        public JobCreation() : this(new Job(), EditMode.New) { }

        // Editing Constructor
        public JobCreation(Job job) : this(job, EditMode.Edit) { }

        // Base Constructor
        public JobCreation(Job job, EditMode mode) : base(job, mode, "Job", "Salary") { }
    }

}
