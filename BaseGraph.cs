using Job_Application_Database.Enum;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;

namespace Job_Application_Database.Classes
{
    class BaseGraph
    {
        public static int DefaultHeight = 500;
        public static int DefaultWidth = 600;
        public static int DefaultItemSpacing = 50;

        private Chart _cchart;
        private DataPointSeries _graph;

        private AxisOrientation _orientation;

        private Hashtable _charts;

        protected GraphWindow Wind { get; set; }

        public SeriesType Type { get; }

        public BaseGraph(string ctitle, string ltitle, string gtitle, List<KeyValuePair<string, int>> source, SeriesType type)
        {
            Wind = new GraphWindow();
            _charts = new Hashtable
            {
                { SeriesType.Area, Wind.AreaChart },
                { SeriesType.Bar, Wind.BarChart },
                { SeriesType.Column, Wind.ColumnChart },
                { SeriesType.Line, Wind.LineChart },
                { SeriesType.Pie, Wind.PieChart },
                { SeriesType.Scatter, Wind.ScatterChart }
            };
            HideAllCharts();

            Type = type;

            switch (type)
            {
                case SeriesType.Area:
                    Wind.AreaSeries.DataContext = source;
                    _cchart = Wind.AreaChart;
                    _graph = Wind.AreaSeries;
                    _orientation = AxisOrientation.X;
                    break;
                case SeriesType.Bar:
                    Wind.BarSeries.DataContext = source;
                    _cchart = Wind.BarChart;
                    _graph = Wind.BarSeries;
                    _orientation = AxisOrientation.Y;
                    break;
                case SeriesType.Column:
                    Wind.ColumnSeries.DataContext = source;
                    _cchart = Wind.ColumnChart;
                    _graph = Wind.ColumnSeries;
                    _orientation = AxisOrientation.X;
                    break;
                case SeriesType.Line:
                    Wind.LineSeries.DataContext = source;
                    _cchart = Wind.LineChart;
                    _graph = Wind.LineSeries;
                    _orientation = AxisOrientation.X;
                    break;
                case SeriesType.Pie:
                    Wind.PieSeries.DataContext = source;
                    _cchart = Wind.PieChart;
                    _graph = Wind.PieSeries;
                    break;
                case SeriesType.Scatter:
                    Wind.ScatterSeries.DataContext = source;
                    _cchart = Wind.ScatterChart;
                    _graph = Wind.ScatterSeries;
                    _orientation = AxisOrientation.X;
                    break;
            }

            if(_orientation == AxisOrientation.X)
            {
                _cchart.Height = DefaultHeight;
                _cchart.Width = DefaultItemSpacing * source.Count;
            }
            else if(_orientation == AxisOrientation.Y)
            {
                _cchart.Height = DefaultItemSpacing * source.Count;
                _cchart.Width = DefaultWidth;
            } else
            {
                _cchart.Height = DefaultHeight;
                _cchart.Width = DefaultWidth;
            }

            
            _cchart.Title = ctitle;
            _cchart.LegendTitle = ltitle;

            _graph.Title = gtitle;

            ShowChart();
        }

        public void SetMaximum(int max)
        {
            if(Type != SeriesType.Pie)
            {
                
            }
            
        }

        public void ShowDialog()
        {
            Wind.ShowDialog();
        }

        public void HideAllCharts()
        {
            foreach (DictionaryEntry de in _charts)
            {
                HideChart(((SeriesType)de.Key));
            }
        }

        public void ShowAllCharts()
        {
            foreach (DictionaryEntry de in _charts)
            {
                ShowChart(((SeriesType)de.Key));
            }
        }

        public void ShowChart()
        {
            ShowChart(Type);
        }

        public void ShowChart(SeriesType type)
        {
            ((Chart)_charts[type]).Visibility = Visibility.Visible;
        }

        public void HideChart()
        {
            HideChart(Type);
        }

        public void HideChart(SeriesType type)
        {
            ((Chart)_charts[type]).Visibility = Visibility.Hidden;
        }
    }
}
