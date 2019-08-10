using Job_Application_Database.Classes;
using System.Collections;

namespace Job_Application_Database.Singleton
{
    /// <summary>
    /// Jobs Singleton Class
    /// </summary>
    public sealed class Jobs : BaseSingleton
    {
        /// <summary>
        /// The Instance Of The Jobs Singleton
        /// </summary>
        public new static Jobs Instance
        {
            get
            {
                return Singleton<Jobs>.Instance;
            }
        }

        /// <summary>
        /// Initialize The Hash Table With Basic Job Titles
        /// </summary>
        public override void InitObjectList()
        {
            _table = new Hashtable
            {
                { 0, new Job() },
                { 1, new Job("Android Developer") },
                { 2, new Job("Embedded Software Engineer I") },
                { 3, new Job("Full Stack Developer I") },
                { 4, new Job("Game Developer") },
                { 5, new Job("Game R&D") },
                { 6, new Job("Java Developer") },
                { 7, new Job("Mobile Game Developer") },
                { 8, new Job("Software Engineer I") },
                { 9, new Job("Software Tester I") }
            };

            _needsRefresh = true;
        }
    }

}
