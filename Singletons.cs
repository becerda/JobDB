using Job_Application_Database.Classes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Job_Application_Database.Singleton
{
    /// <summary>
    /// Singleton Class
    /// </summary>
    public abstract class Singleton<T> where T : class, new()
    {
        // The Lazy Construction Of The Instance
        private static readonly Lazy<T> _instance = new Lazy<T>(() => CreateInstance());

        // To Tell If _allobjectnames Needs To Be Refreshed
        protected bool _needsRefresh = false;

        // Hash Table To Store All BaseInfo
        protected Hashtable _table = new Hashtable();

        // List To Store All BaseInfo Names
        protected List<string> _allobjectnames;

        // The Instance Of The Singleton
        public static T Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        // Creation Of The Instance
        private static T CreateInstance()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }

        // Default Constructor
        protected Singleton()
        {
            _table = new Hashtable();
            _allobjectnames = new List<string>();
        }

        // The Size Of The Hash Table
        public int Count
        {
            get
            {
                return _table.Count;
            }
        }

        // Used To Initialized The Hash Table With BaseInfo
        public virtual void InitObjectList() { }

        // Refreshes The Names List
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

        // Gets All Of The BaseInfo As A List
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

        // Adds BaseInfo To The Hash Table
        public void AddObject(BaseInfo k)
        {
            _table.Add(k.ID, k);
            _needsRefresh = true;
        }

        // Removes BaseInfo From Hast Table
        public void RemoveObject(BaseInfo k)
        {
            _table.Remove(k.ID);
            _needsRefresh = true;
        }

        // Gets The BaseInfo With Spesified ID 
        public BaseInfo ObjectAt(int id)
        {
            return _table[id] as BaseInfo;
        }

        // Gets All BaseInfo Names As A List
        public List<string> AllObjectNames()
        {
            if (_needsRefresh) Refresh();
            return _allobjectnames;
        }

        // Gets The Location Of BaseInfo In _allobjectnames From It's ID
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

        // Gets The BaseInfo In _table From It's Location in _allobjectnames
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

}
