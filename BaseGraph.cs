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
    class BaseGraph
    {
        // Default Height Of Chart
        public static int DefaultHeight = 500;

        // Default Width Of Chart
        public static int DefaultWidth = 600;

        // Default Item Spacing Of Chart
        public static int DefaultItemSpacing = 50;

        // The Referance To The Current Chart
        private Chart Chart { get; set; }

        // The Reference To The Current Graph
        private DataPointSeries Graph { get; set; }

        // All Of The Charts
        private Hashtable Charts;

        // The Reference To GraphWindow
        protected GraphWindow Wind { get; set; }

        // The SeriesType Of The Graph
        public SeriesType Type { get; }

        // Default Constructor
        public BaseGraph(string ctitle, string ltitle, string gtitle, List<KeyValuePair<string, int>> source, SeriesType type, int height, int width, Brush chartcolor, Brush barcolor)
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
            HideAllCharts();

            Type = type;

            switch (type)
            {
                case SeriesType.Area:
                    Wind.AreaSeries.DataContext = source;
                    Chart = Wind.AreaChart;
                    Graph = Wind.AreaSeries;
                    break;
                case SeriesType.Bar:
                    Wind.BarSeries.DataContext = source;
                    Chart = Wind.BarChart;
                    Graph = Wind.BarSeries;
                    break;
                case SeriesType.Column:
                    Wind.ColumnSeries.DataContext = source;
                    Chart = Wind.ColumnChart;
                    Graph = Wind.ColumnSeries;
                    break;
                case SeriesType.Line:
                    Wind.LineSeries.DataContext = source;
                    Chart = Wind.LineChart;
                    Graph = Wind.LineSeries;
                    break;
                case SeriesType.Pie:
                    Wind.PieSeries.DataContext = source;
                    Chart = Wind.PieChart;
                    Graph = Wind.PieSeries;
                    break;
                case SeriesType.Scatter:
                    Wind.ScatterSeries.DataContext = source;
                    Chart = Wind.ScatterChart;
                    Graph = Wind.ScatterSeries;
                    break;
            }


            Chart.Height = height;
            Chart.Width = width;
            Chart.Background = chartcolor;

            Chart.Title = ctitle;
            Chart.LegendTitle = ltitle;

            Graph.Title = gtitle;

            Style style = new Style(typeof(DataPoint));
            Setter setter = new Setter(DataPointSeries.BackgroundProperty, barcolor);
            style.Setters.Add(setter);
            Graph.DataPointStyle = style;

            ShowChart();
        }

        // Shows GraphWindow's Dialog
        public void ShowDialog()
        {
            Wind.ShowDialog();
        }

        // Hides All Of The Charts
        public void HideAllCharts()
        {
            foreach (DictionaryEntry de in Charts)
            {
                HideChart(((SeriesType)de.Key));
            }
        }

        // Shows All Of The Charts
        public void ShowAllCharts()
        {
            foreach (DictionaryEntry de in Charts)
            {
                ShowChart(((SeriesType)de.Key));
            }
        }

        // Shows The Current Chart
        public void ShowChart()
        {
            ShowChart(Type);
        }

        // Shows The Selected Chart
        public void ShowChart(SeriesType type)
        {
            ((Chart)Charts[type]).Visibility = Visibility.Visible;
        }

        // Hides All Of The Charts
        public void HideChart()
        {
            HideChart(Type);
        }

        // Hides The Selected Chart
        public void HideChart(SeriesType type)
        {
            ((Chart)Charts[type]).Visibility = Visibility.Hidden;
        }
    }
}
