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
    public class Files
    {
        private static readonly Lazy<Files> _fm = new Lazy<Files>(() => CreateInstance());
        private Reps _rm;
        private Jobs _jm;
        private Companies _cm;
        private Boards _bm;

        private string _saveFile;

        private Files()
        {
            _jm = Jobs.Instance;
            _rm = Reps.Instance;
            _cm = Companies.Instance;
            _bm = Boards.Instance;
        }

        public static Files Instance
        {
            get
            {
                return _fm.Value;
            }
        }

        private static Files CreateInstance()
        {
            return Activator.CreateInstance(typeof(Files), true) as Files;
        }

        public void LoadRepFile()
        {
            LoadSingletonObject<Rep>(_rm, Properties.Settings.Default.RepSaveFile);
        }

        public void SaveRepFile()
        {
            SaveSingletonObject(_rm.AllObjects(), Properties.Settings.Default.RepSaveFile);
        }

        public void LoadJobFile()
        {
            LoadSingletonObject<Job>(_jm, Properties.Settings.Default.JobSaveFile);
        }

        public void SaveJobFile()
        {
            SaveSingletonObject(_jm.AllObjects(), Properties.Settings.Default.JobSaveFile);
        }

        public void LoadBoardFile()
        {
            LoadSingletonObject<Board>(_bm, Properties.Settings.Default.BoardSaveFile);
        }

        public void SaveBoardFile()
        {
            SaveSingletonObject(_bm.AllObjects(), Properties.Settings.Default.BoardSaveFile);
        }

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
                    Enum.Status s = Enums.ParseStatus(Int32.Parse(status));
                    string date = match.Groups["date"].Value;
                    string[] dates = date.Split('-');
                    string location = match.Groups["location"].Value;
                    string notes = match.Groups["notes"].Value;
                    Company c = new Company(name, website, Int32.Parse(rep), Int32.Parse(job), Int32.Parse(board), s, new DateTime(Int32.Parse(dates[0]), Int32.Parse(dates[1]), Int32.Parse(dates[2])), location, p, notes);
                    _cm.AddObject(c);
                }

            }
        }

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

        public void FullSave()
        {
            SaveCompanyFile();
            SaveJobFile();
            SaveRepFile();
            SaveBoardFile();
        }
    }
}
