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
        private int col = 0;

        /// <summary>
        /// Current Row
        /// </summary>
        private int row = 0;

        /// <summary>
        /// The Referance To The Current Chart
        /// </summary>
        private Chart Chart { get; set; }

        /// <summary>
        /// The Reference To The Current Graph
        /// </summary>
        protected DataPointSeries Graph { get; set; }

        /// <summary>
        /// All Of The Charts
        /// </summary>
        private Hashtable Charts;

        /// <summary>
        /// The Reference To GraphWindow
        /// </summary>
        protected GraphWindow Wind { get; set; }

        /// <summary>
        /// The SeriesType Of The Graph
        /// </summary>
        public SeriesType Type { get; set; }

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
            AddGraph(chart);
        }

        /// <summary>
        /// Sets Up The Window And Charts Hashtable
        /// </summary>
        /// <param name="title">The Title Of The Window</param>
        private void Init(string title)
        {
            Wind = new GraphWindow();
            Charts = new Hashtable
            {
                { SeriesType.Area, Wind.AreaChart },
                { SeriesType.Bar, Wind.BarChart },
                { SeriesType.Column, Wind.ColumnChart },
                { SeriesType.Line, Wind.LineChart },
                { SeriesType.Pie, Wind.PieChart },
                { SeriesType.Scatter, Wind.ScatterChart }
            };
            Wind.Title = title;
            HideAllCharts();
        }

        /// <summary>
        /// Add A Graph To The Window
        /// </summary>
        /// <param name="chart">The Chart To Add To The Window</param>
        public void AddGraph(ChartInfo chart)
        {
            Type = chart.Graph.Type;

            switch (Type)
            {
                case SeriesType.Area:
                    Wind.AreaSeries.DataContext = chart.Graph.Source;
                    Chart = Wind.AreaChart;
                    Graph = Wind.AreaSeries;
                    break;
                case SeriesType.Bar:
                    Wind.BarSeries.DataContext = chart.Graph.Source;
                    Chart = Wind.BarChart;
                    Graph = Wind.BarSeries;
                    break;
                case SeriesType.Column:
                    Wind.ColumnSeries.DataContext = chart.Graph.Source;
                    Chart = Wind.ColumnChart;
                    Graph = Wind.ColumnSeries;
                    break;
                case SeriesType.Line:
                    Wind.LineSeries.DataContext = chart.Graph.Source;
                    Chart = Wind.LineChart;
                    Graph = Wind.LineSeries;
                    break;
                case SeriesType.Pie:
                    Wind.PieSeries.DataContext = chart.Graph.Source;
                    Chart = Wind.PieChart;
                    Graph = Wind.PieSeries;
                    break;
                case SeriesType.Scatter:
                    Wind.ScatterSeries.DataContext = chart.Graph.Source;
                    Chart = Wind.ScatterChart;
                    Graph = Wind.ScatterSeries;
                    break;
            }


            Chart.Height = chart.Height;
            Chart.Width = chart.Width;
            Chart.Background = chart.Color;
            Chart.Title = chart.Title;
            Chart.LegendTitle = chart.Graph.LegendTitle;

            Graph.Title = chart.Graph.GraphTitle;
            if (chart.Graph.Color != null)
                SetGraphColor(chart.Graph.Color);

            Chart.SetValue(Grid.ColumnProperty, col++);
            Chart.SetValue(Grid.RowProperty, row);

            if (col >= MaxCols)
            {
                row++;
                col = 0;
            }

            if (row >= MaxRows)
            {
                row = 0;
                col = 0;
            }

            ShowChart();
        }

        /// <summary>
        /// Change The Color Of The Graphs Data Points
        /// </summary>
        /// <param name="color">The Color To Change To</param>
        public void SetGraphColor(Brush color)
        {
            Style style = new Style(typeof(DataPoint));
            Setter setter = new Setter(DataPointSeries.BackgroundProperty, color);
            style.Setters.Add(setter);
            Graph.DataPointStyle = style;
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
                HideChart(((SeriesType)de.Key));
            }
        }

        /// <summary>
        /// Shows All Of The Charts
        /// </summary>
        public void ShowAllCharts()
        {
            foreach (DictionaryEntry de in Charts)
            {
                ShowChart(((SeriesType)de.Key));
            }
        }

        /// <summary>
        /// Shows The Current Chart
        /// </summary>
        public void ShowChart()
        {
            ShowChart(Type);
        }

        /// <summary>
        /// Shows The Selected Chart
        /// </summary>
        /// <param name="type"></param>
        public void ShowChart(SeriesType type)
        {
            ((Chart)Charts[type]).Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Hides All Of The Charts
        /// </summary>
        public void HideChart()
        {
            HideChart(Type);
        }

        /// <summary>
        /// Hides The Selected Chart
        /// </summary>
        /// <param name="type"></param>
        public void HideChart(SeriesType type)
        {
            ((Chart)Charts[type]).Visibility = Visibility.Hidden;
        }
    }
}
