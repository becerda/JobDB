using Job_Application_Database.Enum;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Class That Controls Graph Usage
    /// </summary>
    class GraphHolder : BaseWindow
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
        protected GraphWindow GraphWindow
        {
            get
            {
                return (GraphWindow)base.Window;
            }
        }

        /// <summary>
        /// The Exit Status Of GraphWindow
        /// </summary>
        public override ExitStatus Exit { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public GraphHolder() : base(new GraphWindow(), "Graphs")
        {
            Charts = new Hashtable();
        }

        /// <summary>
        /// Constructor To Set The Window Title
        /// </summary>
        /// <param name="wtitle"></param>
        public GraphHolder(string wtitle) : base(new GraphWindow(), wtitle)
        {
            Charts = new Hashtable();
        }

        /// <summary>
        /// Constructor To Set Window Title And Add A Chart
        /// </summary>
        /// <param name="wtitle">The Title Of The Window</param>
        /// <param name="chart">The Chart To Be Added</param>
        public GraphHolder(string wtitle, ChartInfo chart) : base(new GraphWindow(), wtitle)
        {
            Charts = new Hashtable();
            AddChart(chart);
        }

        /// <summary>
        /// Overrided Window Loaded Event Method
        /// </summary>
        /// <param name="sender">The Object That Called Triggered This Event</param>
        /// <param name="e">The Event Arguments</param>
        protected override void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// Overrided Window Closing Event Method
        /// </summary>
        /// <param name="sender">The Object That Called Triggered This Event</param>
        /// <param name="e">The Event Arguments</param>
        protected override void Window_Closing(object sender, CancelEventArgs e)
        {
            
        }

        /// <summary>
        /// Overrided Window Key Down Event Method
        /// </summary>
        /// <param name="sender">The Object That Called Triggered This Event</param>
        /// <param name="e">The Event Arguments</param>
        protected override void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

        /// <summary>
        /// Add A Chart To The Window
        /// </summary>
        /// <param name="chart">The Chart To Add To The Window</param>
        public void AddChart(ChartInfo chart)
        {
            GraphWindow.Grid.Children.Add(chart.Chart);
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
