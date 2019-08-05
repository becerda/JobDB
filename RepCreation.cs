using Job_Application_Database.Enum;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Rep creation window extended from BaseCreation
    /// </summary>
    public class RepCreation : BaseCreation
    {
        // Default Constructor
        public RepCreation() : this(new Rep(), EditMode.New) { }

        // Editing Constructor
        public RepCreation(Rep rep) : this(rep, EditMode.Edit) { }

        // Base Constructor
        public RepCreation(Rep rep, EditMode mode) : base(rep, mode, "Representative", "Email") { }
    }

}
