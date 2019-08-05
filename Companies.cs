
namespace Job_Application_Database.Singleton
{
    /// <summary>
    /// Companies Singleton Class
    /// </summary>
    public sealed class Companies : BaseSingleton
    {
        // The Instance Of The Jobs Singleton
        public new static Companies Instance
        {
            get
            {
                return Singleton<Companies>.Instance;
            }
        }
    }

}
