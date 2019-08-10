using Job_Application_Database.Classes;
using System.Collections;

namespace Job_Application_Database.Singleton
{
    /// <summary>
    /// Job Boards Singleton Class
    /// </summary>
    public sealed class JobBoards : BaseSingleton
    {
        /// <summary>
        /// The Instance Of The Job Boards Singleton
        /// </summary>
        public new static JobBoards Instance
        {
            get
            {
                return Singleton<JobBoards>.Instance;
            }
        }

        /// <summary>
        /// Initialize The Hash Table With Basic Job Boards
        /// </summary>
        public override void InitObjectList()
        {
            _table = new Hashtable
            {
                { 0, new JobBoard(" ") },
                { 1, new JobBoard("Glassdoor", "www.glassdoor.com") },
                { 2, new JobBoard("Indeed", "www.indeed.com") },
                { 3, new JobBoard("Linkedin", "www.linkedin.com") },
                { 4, new JobBoard("Monster", "www.monster.com") }
            };
        }
    }

}
