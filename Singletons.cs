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
        /// <summary>
        /// The Lazy Construction Of The Instance
        /// </summary>
        private static readonly Lazy<T> _instance = new Lazy<T>(() => CreateInstance());

        /// <summary>
        /// To Tell If _allobjectnames Needs To Be Refreshed
        /// </summary>
        protected bool _needsRefresh = false;

        /// <summary>
        /// Hash Table To Store All BaseInfo
        /// </summary>
        protected Hashtable _table = new Hashtable();

        /// <summary>
        /// List To Store All BaseInfo Names
        /// </summary>
        protected List<string> _allobjectnames;

        /// <summary>
        /// The Instance Of The Singleton
        /// </summary>
        public static T Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        /// <summary>
        /// Creation Of The Instance
        /// </summary>
        /// <returns></returns>
        private static T CreateInstance()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        protected Singleton()
        {
            _table = new Hashtable();
            _allobjectnames = new List<string>();
        }

        /// <summary>
        /// The Size Of The Hash Table
        /// </summary>
        public int Count
        {
            get
            {
                return _table.Count;
            }
        }

        /// <summary>
        /// Used To Initialized The Hash Table With BaseInfo
        /// </summary>
        public virtual void InitObjectList() { }

        /// <summary>
        /// Refreshes The Names List
        /// </summary>
        protected void Refresh()
        {
            if (_needsRefresh)
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
        }

        /// <summary>
        /// Gets All Of The BaseInfo As A List
        /// </summary>
        /// <returns>A List\<BaseInfo\> Of Objects</returns>
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

        /// <summary>
        /// Adds BaseInfo To The Hash Table
        /// </summary>
        /// <param name="k">The BaseInfo To Add</param>
        public void AddObject(BaseInfo k)
        {
            _table.Add(k.ID, k);
            _needsRefresh = true;
        }

        /// <summary>
        /// Removes BaseInfo From Hast Table
        /// </summary>
        /// <param name="k">The BaseInfo To Remove</param>
        public void RemoveObject(BaseInfo k)
        {
            _table.Remove(k.ID);
            _needsRefresh = true;
        }

        /// <summary>
        /// Gets The BaseInfo With Spesified ID 
        /// </summary>
        /// <param name="id">The ID Of The Object</param>
        /// <returns>The BaseInfo With Supplied ID</returns>
        public BaseInfo ObjectAt(int id)
        {
            return _table[id] as BaseInfo;
        }

        /// <summary>
        /// Gets All BaseInfo Names As A List
        /// </summary>
        /// <returns>A List\<string\> Of All BaseInfo Names</returns>
        public List<string> AllObjectNames()
        {
            Refresh();
            return _allobjectnames;
        }

        /// <summary>
        /// Gets The Location Of BaseInfo In _allobjectnames From It's ID
        /// </summary>
        /// <param name="id">The Id Of The BaseInfo</param>
        /// <returns>The Index Of The BaseInfo</returns>
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

        /// <summary>
        /// Gets The BaseInfo In _table From It's Location in _allobjectnames
        /// </summary>
        /// <param name="index">The Index Of The BaseInfo</param>
        /// <returns>The BaseInfo At The Location</returns>
        public BaseInfo NamesToTable(int index)
        {
            Refresh();
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
