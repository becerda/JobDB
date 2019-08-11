using Job_Application_Database.Enum;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Rep Creation Window Extended From BaseCreation
    /// </summary>
    public class RepCreation : BaseCreation
    {
        /// <summary>
        /// New Rep Constructor
        /// </summary>
        public RepCreation() : this(new Rep(), EditMode.New) { }

        /// <summary>
        /// Editing Constructor
        /// </summary>
        /// <param name="rep">The Rep To Edit</param>
        public RepCreation(Rep rep) : this(rep, EditMode.Edit) { }

        /// <summary>
        /// Base Constructor
        /// </summary>
        /// <param name="rep"></param>
        /// <param name="mode"></param>
        private RepCreation(Rep rep, EditMode mode) : base(rep, mode, "Representative", "Email") { }
    }

}
