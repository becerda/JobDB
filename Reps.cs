using Job_Application_Database.Classes;
using System.Collections;

namespace Job_Application_Database.Singleton
{
    /// <summary>
    /// Reps Singleton Class
    /// </summary>
    public sealed class Reps : BaseSingleton
    {
        // The Instance Of The Reps Singleton
        public new static Reps Instance
        {
            get
            {
                return Singleton<Reps>.Instance;
            }
        }

        // Initialize The Hash Table As Empty
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
