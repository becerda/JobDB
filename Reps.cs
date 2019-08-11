using Job_Application_Database.Classes;
using System.Collections;

namespace Job_Application_Database.Singleton
{
    /// <summary>
    /// Reps Singleton Class
    /// </summary>
    public sealed class Reps : BaseSingleton
    {
        /// <summary>
        /// The Instance Of The Reps Singleton
        /// </summary>
        public new static Reps Instance
        {
            get
            {
                return Singleton<Reps>.Instance;
            }
        }

        /// <summary>
        /// Initialize The Hash Table As Empty
        /// </summary>
        public override void InitObjectList()
        {
            _table = new Hashtable
            {
                { 0, new Rep() }
            };

            _needsRefresh = true;
        }
    }

}
