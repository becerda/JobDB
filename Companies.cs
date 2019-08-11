using Job_Application_Database.Classes;
using Job_Application_Database.Enum;
using System.Collections;
using System.Collections.Generic;

namespace Job_Application_Database.Singleton
{
    /// <summary>
    /// Companies Singleton Class
    /// </summary>
    public sealed class Companies : BaseSingleton
    {
        /// <summary>
        /// The Instance Of The Companies Singleton
        /// </summary>
        public new static Companies Instance
        {
            get
            {
                return Singleton<Companies>.Instance;
            }
        }

        /// <summary>
        /// Gets All Position Types In A Counted KeyValuePair
        /// </summary>
        /// <returns>A List\<KeyValuePair\<string,int\>\> Of The Position Types</returns>
        public List<KeyValuePair<string, int>> PositionKeyValue()
        {
            List<KeyValuePair<string, int>> kvp = new List<KeyValuePair<string, int>>();

            int na = 0;
            int pt = 0;
            int ft = 0;
            int ct = 0;

            foreach (Company c in AllObjects())
            {
                if (c.Position == PositionType.NA)
                    na++;
                else if (c.Position == PositionType.Part)
                    pt++;
                else if (c.Position == PositionType.Full)
                    ft++;
                else if (c.Position == PositionType.Contract)
                    ct++;
            }

            kvp.Add(new KeyValuePair<string, int>("N/A", na));
            kvp.Add(new KeyValuePair<string, int>("Part Time", pt));
            kvp.Add(new KeyValuePair<string, int>("Full Time", ft));
            kvp.Add(new KeyValuePair<string, int>("Contract", ct));

            return kvp;
        }

        /// <summary>
        /// Gets All Application Status' In A Counted KeyValuePair
        /// </summary>
        /// <returns>A List\<KeyValuePair\<string,int\>\> Of Application Status'</returns>
        public List<KeyValuePair<string, int>> StatusKeyValue()
        {
            List<KeyValuePair<string, int>> kvp = new List<KeyValuePair<string, int>>();

            int app = 0;
            int hun = 0;
            int ass = 0;
            int intr = 0;
            int off = 0;
            int acc = 0;
            int den = 0;
            int rej = 0;

            foreach (Company c in AllObjects())
            {
                if (c.Status.HasFlag(ApplicationStatus.Applied))
                    app++;
                if (c.Status.HasFlag(ApplicationStatus.Hunted))
                    hun++;
                if (c.Status.HasFlag(ApplicationStatus.Assignment))
                    ass++;
                if (c.Status.HasFlag(ApplicationStatus.Interview))
                    intr++;
                if (c.Status.HasFlag(ApplicationStatus.Offered))
                    off++;
                if (c.Status.HasFlag(ApplicationStatus.Accepted))
                    acc++;
                if (c.Status.HasFlag(ApplicationStatus.Denied))
                    den++;
                if (c.Status.HasFlag(ApplicationStatus.Rejected))
                    rej++;
            }

            kvp.Add(new KeyValuePair<string, int>("Applied", app));
            kvp.Add(new KeyValuePair<string, int>("Hunted", hun));
            kvp.Add(new KeyValuePair<string, int>("Assignment", ass));
            kvp.Add(new KeyValuePair<string, int>("Interviewed", intr));
            kvp.Add(new KeyValuePair<string, int>("Offered", off));
            kvp.Add(new KeyValuePair<string, int>("Accepted", acc));
            kvp.Add(new KeyValuePair<string, int>("Denied", den));
            kvp.Add(new KeyValuePair<string, int>("Rejected", rej));

            return kvp;
        }

        /// <summary>
        /// Gets All Job Titles In A Counted KeyValuePair
        /// </summary>
        /// <returns>A List\<KeyValuePair\<string,int\>\> Of Job Titles</returns>
        public List<KeyValuePair<string, int>> JobKeyValue()
        {
            List<KeyValuePair<string, int>> kvp = new List<KeyValuePair<string, int>>();

            Hashtable table = new Hashtable();

            foreach (Company c in AllObjects())
            {
                if (table[c.JobID] == null)
                    table.Add(c.JobID, 1);
                else
                    table[c.JobID] = (int)table[c.JobID] + 1;
            }

            foreach(DictionaryEntry de in table)
            {
                kvp.Add(new KeyValuePair<string, int>(Jobs.Instance.ObjectAt((int)de.Key).Name, (int)de.Value));
            }

            return kvp;
        }
    }

}
