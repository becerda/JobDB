using Job_Application_Database.Enum;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Job Board creation window extended from BaseCreation
    /// </summary>
    public class JobBoardCreation : BaseCreation
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public JobBoardCreation() : this(new JobBoard(), EditMode.New) { }

        /// <summary>
        /// Editing Constructor
        /// </summary>
        /// <param name="board">The Job Board To Edit</param>
        public JobBoardCreation(JobBoard board) : this(board, EditMode.Edit) { }

        /// <summary>
        /// Base Constructor
        /// </summary>
        /// <param name="board">The Job Board To Edit</param>
        /// <param name="mode">The Editing Mode</param>
        private JobBoardCreation(JobBoard board, EditMode mode) : base(board, mode, "Job Board", "Website") { }
    }

}
