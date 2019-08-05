using Job_Application_Database.Classes;
using System.Collections;

namespace Job_Application_Database.Singleton
{
    /// <summary>
    /// Job Boards Singleton Class
    /// </summary>
    public sealed class Boards : BaseSingleton
    {
        // The Instance Of The Job Boards Singleton
        public new static Boards Instance
        {
            get
            {
                return Singleton<Boards>.Instance;
            }
        }

        // Initialize The Hash Table With Basic Job Boards
        public override void InitObjectList()
        {
            _table = new Hashtable
            {
                { 0, new Board(" ") },
                { 1, new Board("Glassdoor", "www.glassdoor.com") },
                { 2, new Board("Indeed", "www.indeed.com") },
                { 3, new Board("Linkedin", "www.linkedin.com") },
                { 4, new Board("Monster", "www.monster.com") }
            };
        }
    }

}
