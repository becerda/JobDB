using Job_Application_Database.Classes;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Application_Database.Singleton
{

    public abstract class Singleton<T> where T : class, new()
    {

        private static readonly Lazy<T> _instance = new Lazy<T>(() => CreateInstance());

        protected bool _needsRefresh = false;
        protected Hashtable _table = new Hashtable();
        protected List<string> _allobjectnames;

        public static T Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private static T CreateInstance()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }

        protected Singleton()
        {
            _table = new Hashtable();
            _allobjectnames = new List<string>();
        }


        public int Count
        {
            get
            {
                return _table.Count;
            }
        }

        public virtual void InitObjectList() { }

        protected void Refresh()
        {
            _allobjectnames.Clear();
            foreach (DictionaryEntry de in _table)
            {
                BaseInfo c = de.Value as BaseInfo;
                _allobjectnames.Add(c.Name);
            }
            _allobjectnames.Sort();
            _needsRefresh = false;
        }

        public List<BaseInfo> AllObjects()
        {
            List<BaseInfo> list = new List<BaseInfo>();
            foreach (DictionaryEntry de in _table)
                list.Add(de.Value as BaseInfo);

            list.Sort(delegate (BaseInfo x, BaseInfo y)
            {
                if (x.Name == null && y.Name == null) return 0;
                else if (x.Name == null) return -1;
                else if (y.Name == null) return 1;
                else return x.Name.CompareTo(y.Name);
            });
            return list;
        }

        public void AddObject(BaseInfo k)
        {
            _table.Add(k.ID, k);
            _needsRefresh = true;
        }

        public void RemoveObject(BaseInfo k)
        {
            _table.Remove(k.ID);
            _needsRefresh = true;
        }

        public BaseInfo ObjectAt(int id)
        {
            return _table[id] as BaseInfo;
        }

        public List<string> AllObjectNames()
        {
            if (_needsRefresh) Refresh();
            return _allobjectnames;
        }

        public int TableToNames(int id)
        {
            Refresh();
            BaseInfo b = _table[id] as BaseInfo;
            for (int i = 0; i < _allobjectnames.Count; i++)
            {
                if (b.Name == _allobjectnames[i])
                    return i;
            }

            return -1;
        }

        public BaseInfo NamesToTable(int index)
        {
            string name = _allobjectnames[index];
            foreach (DictionaryEntry d in _table)
            {
                BaseInfo b = d.Value as BaseInfo;
                if (b.Name == name)
                {
                    return b;
                }
            }
            return null;
        }
    }

    public class BaseSingleton : Singleton<BaseSingleton>
    {
        
    }

    public sealed class Jobs : BaseSingleton
    {
        public new static Jobs Instance
        {
            get
            {
                return Singleton<Jobs>.Instance;
            }
        }

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

    public sealed class Reps : BaseSingleton
    {

        public new static Reps Instance
        {
            get
            {
                return Singleton<Reps>.Instance;
            }
        }

        public override void InitObjectList()
        {
            _table = new Hashtable
            {
                { 0, new Rep() }
            };

            _needsRefresh = true;
        }
    }

    public sealed class Companies : BaseSingleton
    {
        public new static Companies Instance
        {
            get
            {
                return Singleton<Companies>.Instance;
            }
        }
    }

    public sealed class Boards : BaseSingleton
    {
        public new static Boards Instance
        {
            get
            {
                return Singleton<Boards>.Instance;
            }
        }

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
