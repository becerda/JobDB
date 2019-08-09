using Job_Application_Database.Enum;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Media;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Class That Controls Graph Usage
    /// </summary>
    class GraphWindowHolder
    {
        /// <summary>
        /// To Keep Track Of The Number Of Charts
        /// </summary>
        private int _chartid = 0;

        /// <summary>
        /// Maximum Number Of Columns In The Window
        /// </summary>
        private readonly int MaxCols = 3;

        /// <summary>
        /// Maximum Number Of Rows In The Window
        /// </summary>
        private readonly int MaxRows = 2;

        /// <summary>
        /// Current Column
        /// </summary>
        private int _col = 0;

        /// <summary>
        /// Current Row
        /// </summary>
        private int _row = 0;

        /// <summary>
        /// All Of The Charts
        /// </summary>
        public Hashtable Charts { get; set; }

        /// <summary>
        /// The Most Recently Added Chart's ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The Reference To GraphWindow
        /// </summary>
        protected GraphWindow Wind { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public GraphWindowHolder() { Init("Graphs"); }

        /// <summary>
        /// Constructor To Set The Window Title
        /// </summary>
        /// <param name="wtitle"></param>
        public GraphWindowHolder(string wtitle)
        {
            Init(wtitle);
        }

        /// <summary>
        /// Constructor To Set Window Title And Add A Chart
        /// </summary>
        /// <param name="wtitle">The Title Of The Window</param>
        /// <param name="chart">The Chart To Be Added</param>
        public GraphWindowHolder(string wtitle, ChartInfo chart)
        {
            Init(wtitle);
            AddChart(chart);
        }

        /// <summary>
        /// Sets Up The Window And Charts Hashtable
        /// </summary>
        /// <param name="title">The Title Of The Window</param>
        private void Init(string title)
        {
            Wind = new GraphWindow();
            Charts = new Hashtable();
            Wind.Title = title;
        }

        /// <summary>
        /// Add A Chart To The Window
        /// </summary>
        /// <param name="chart">The Chart To Add To The Window</param>
        public void AddChart(ChartInfo chart)
        {
            Wind.Grid.Children.Add(chart.Chart);
            Grid.SetRow(chart.Chart, _row);
            Grid.SetColumn(chart.Chart, _col++);

            if (_col >= MaxCols)
            {
                _row++;
                _col = 0;
            }

            if (_row >= MaxRows)
            {
                _row = 0;
                _col = 0;
                _chartid = 0;
            }

            if (Charts[_chartid] != null)
                Charts.Remove(_chartid);
            Charts.Add(_chartid, chart.Chart);
            ID = _chartid++;

            ShowChart();

        }

        /// <summary>
        /// Shows GraphWindow's Dialog
        /// </summary>
        public void ShowDialog()
        {
            Wind.ShowDialog();
        }

        /// <summary>
        /// Shows GraphWindow
        /// </summary>
        public void Show()
        {
            Wind.Show();
        }

        /// <summary>
        /// Hides All Of The Charts
        /// </summary>
        public void HideAllCharts()
        {
            foreach (DictionaryEntry de in Charts)
            {
                HideChart(((int)de.Key));
            }
        }

        /// <summary>
        /// Shows All Of The Charts
        /// </summary>
        public void ShowAllCharts()
        {
            foreach (DictionaryEntry de in Charts)
            {
                ShowChart(((int)de.Key));
            }
        }

        /// <summary>
        /// Shows The Current Chart
        /// </summary>
        public void ShowChart()
        {
            ShowChart(ID);
        }

        /// <summary>
        /// Shows The Selected Chart
        /// </summary>
        /// <param name="id">The ID Of The Chart To Show</param>
        public void ShowChart(int id)
        {
            ((Chart)Charts[id]).Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Hides All Of The Charts
        /// </summary>
        public void HideChart()
        {
            HideChart(ID);
        }

        /// <summary>
        /// Hides The Selected Chart
        /// </summary>
        /// <param name="id">The ID Of The Chart To Hide</param>
        public void HideChart(int id)
        {
            ((Chart)Charts[id]).Visibility = Visibility.Hidden;
        }
    }
}
