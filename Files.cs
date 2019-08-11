using Newtonsoft.Json;
using System;
using System.IO;
using Job_Application_Database.Singleton;
using Job_Application_Database.Classes;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using Job_Application_Database.Enum;
using System.Collections.Generic;

namespace Job_Application_Database.IO
{
    /// <summary>
    /// Class Handling All File Related Functions
    /// </summary>
    public class Files
    {
        /// <summary>
        /// The Lazy Construction Of The Instance
        /// </summary>
        private static readonly Lazy<Files> _fm = new Lazy<Files>(() => CreateInstance());

        /// <summary>
        /// Reference To The Reps Singleton
        /// </summary>
        private Reps _rm;

        /// <summary>
        /// Reference To The Jobs Singleton
        /// </summary>
        private Jobs _jm;

        /// <summary>
        /// Reference To The Companies Singleton
        /// </summary>
        private Companies _cm;

        /// <summary>
        /// Reference To The JobBoards Singleton
        /// </summary>
        private JobBoards _bm;

        /// <summary>
        /// The Name Of The File To Save To
        /// </summary>
        private string _saveFile;

        /// <summary>
        /// Default Constructor
        /// </summary>
        private Files()
        {
            _jm = Jobs.Instance;
            _rm = Reps.Instance;
            _cm = Companies.Instance;
            _bm = JobBoards.Instance;
        }

        /// <summary>
        /// The Instance Of Files Singleton
        /// </summary>
        public static Files Instance
        {
            get
            {
                return _fm.Value;
            }
        }

        /// <summary>
        /// Creation Of The Instance
        /// </summary>
        /// <returns></returns>
        private static Files CreateInstance()
        {
            return Activator.CreateInstance(typeof(Files), true) as Files;
        }

        /// <summary>
        /// Loads The Rep File
        /// </summary>
        public void LoadRepFile()
        {
            LoadSingletonObject<Rep>(_rm, Properties.Settings.Default.RepSaveFile);
        }

        /// <summary>
        /// Saves The Rep File
        /// </summary>
        public void SaveRepFile()
        {
            SaveSingletonObject(_rm.AllObjects(), Properties.Settings.Default.RepSaveFile);
        }

        /// <summary>
        /// Loads The Job File
        /// </summary>
        public void LoadJobFile()
        {
            LoadSingletonObject<Job>(_jm, Properties.Settings.Default.JobSaveFile);
        }

        /// <summary>
        /// Saves The Job File
        /// </summary>
        public void SaveJobFile()
        {
            SaveSingletonObject(_jm.AllObjects(), Properties.Settings.Default.JobSaveFile);
        }

        /// <summary>
        /// Loads The Job Board File
        /// </summary>
        public void LoadBoardFile()
        {
            LoadSingletonObject<JobBoard>(_bm, Properties.Settings.Default.BoardSaveFile);
        }

        /// <summary>
        /// Saves The Job Board File
        /// </summary>
        public void SaveBoardFile()
        {
            SaveSingletonObject(_bm.AllObjects(), Properties.Settings.Default.BoardSaveFile);
        }

        /// <summary>
        /// Opens The Company File
        /// </summary>
        public void OpenCompanyFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.Filter = "All (*.*)|*.*|json (*.json)|*.json";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == true)
            {
                _saveFile = ofd.FileName;
                Properties.Settings.Default.LastLoadedFile = ofd.FileName;
                LoadCompanyFile(ofd.FileName);
            }

        }

        /// <summary>
        /// Loads A Specified File
        /// </summary>
        /// <param name="filepath">The File Path To Load</param>
        public void LoadCompanyFile(string filepath)
        {
            _saveFile = filepath;

            string content = new StreamReader(filepath).ReadToEnd();

            string[] lines = content.Split('\n');
            foreach (string line in lines)
            {

                Match match = Regex.Match(line, Properties.Settings.Default.CompanyLoadRegex);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string website = match.Groups["website"].Value;
                    string rep = match.Groups["repid"].Value;
                    string job = match.Groups["jobid"].Value;
                    string board = match.Groups["boardid"].Value;
                    string salery = match.Groups["salary"].Value;
                    string position = match.Groups["position"].Value;
                    Enum.PositionType p = Enums.ParsePositionType(Int32.Parse(position));
                    string status = match.Groups["status"].Value;
                    Enum.ApplicationStatus s = Enums.ParseStatus(Int32.Parse(status));
                    string date = match.Groups["date"].Value;
                    string[] dates = date.Split('-');
                    string location = match.Groups["location"].Value;
                    string notes = match.Groups["notes"].Value;
                    Company c = new Company(name, website, Int32.Parse(rep), Int32.Parse(job), Int32.Parse(board), s, new DateTime(Int32.Parse(dates[0]), Int32.Parse(dates[1]), Int32.Parse(dates[2])), location, p, notes);
                    _cm.AddObject(c);
                }

            }
        }

        /// <summary>
        /// Saves The Company File
        /// </summary>
        public void SaveCompanyFile()
        {
            if (_saveFile == null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "All (*.*)|*.*|json (*.json)|*.json";
                sfd.FilterIndex = 2;
                sfd.AddExtension = true;
                sfd.RestoreDirectory = true;
                if (sfd.ShowDialog() == true)
                {
                    _saveFile = sfd.FileName;
                }
                else
                {
                    return;
                }
            }

            SaveSingletonObject(_cm.AllObjects(), _saveFile);
        }

        /// <summary>
        /// Saves A Singleton's Object Data
        /// </summary>
        /// <param name="list">The Data To Save</param>
        /// <param name="filename">The File Name</param>
        private void SaveSingletonObject(List<BaseInfo> list, string filename)
        {
            string json = String.Empty;
            foreach (BaseInfo b in list)
            {
                json += JsonConvert.SerializeObject(b);
                json += "\n";
            }

            File.WriteAllText(filename, json);
        }

        /// <summary>
        /// Loads A Singleton's Object Data
        /// </summary>
        /// <typeparam name="T">The Type Of Object Data</typeparam>
        /// <param name="bs">The Singleton To Save To</param>
        /// <param name="filename">The File To Load From</param>
        private void LoadSingletonObject<T>(BaseSingleton bs, string filename)
        {
            if (File.Exists(filename))
            {
                string content = new StreamReader(filename).ReadToEnd();

                string[] objs = content.Split('\n');
                foreach (string obj in objs)
                {
                    if (obj.Length > 0)
                    {
                        var b = JsonConvert.DeserializeObject<T>(obj);
                        bs.AddObject(b as BaseInfo);
                    }
                }
            }
            else
            {
                bs.InitObjectList();
                SaveSingletonObject(bs.AllObjects(), filename);
            }
        }

        /// <summary>
        /// Saves All Files
        /// </summary>
        public void FullSave()
        {
            SaveCompanyFile();
            SaveJobFile();
            SaveRepFile();
            SaveBoardFile();
        }
    }

}
