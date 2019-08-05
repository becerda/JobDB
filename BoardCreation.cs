

using Job_Application_Database.Enum;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Job Board creation window extended from BaseCreation
    /// </summary>
    public class BoardCreation : BaseCreation
    {
        // Default Constructor
        public BoardCreation() : this(new Board(), EditMode.New) { }

        // Editing Constructor
        public BoardCreation(Board board) : this(board, EditMode.Edit) { }

        // Base Constructor
        public BoardCreation(Board board, EditMode mode) : base(board, mode, "Job Board", "Website") { }
    }
}
