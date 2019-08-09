using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Media;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Wrapper Class For A Chart
    /// </summary>
    class ChartInfo
    {
        /// <summary>
        /// Default Height Of Chart
        /// </summary>
        public static int DefaultHeight = 500;

        /// <summary>
        /// Default Width Of Chart
        /// </summary>
        public static int DefaultWidth = 500;

        /// <summary>
        /// Default Item Spacing Of Chart
        /// </summary>
        public static int DefaultItemSpacing = 50;

        /// <summary>
        /// The Reference To The Chart To Display
        /// </summary>
        public Chart Chart { get; set; }

        /// <summary>
        /// The Reference To The Graph Info
        /// </summary>
        public GraphInfo GraphInfo { get; set; }

        /// <summary>
        /// Constructor To Set Up The Graph
        /// </summary>
        public ChartInfo()
            : this("") { }

        /// <summary>
        /// Constructor To Set Up The Title, And Graph
        /// </summary>
        /// <param name="title">The Title Of The Graph</param>
        public ChartInfo(string title)
            : this(title, "Legend") { }

        /// <summary>
        /// Constructor To Set Up The Title, Legend Title, And Graph
        /// </summary>
        /// <param name="title">The Title Of The Graph</param>
        /// <param name="ltitle">The Title Of The Legend</param>
        public ChartInfo(string title, string ltitle)
            : this(title, ltitle, DefaultHeight, DefaultWidth, Brushes.LightSteelBlue) { }

        /// <summary>
        /// Constructor To Set Up The Title, Legend Title, Height, Width, And Graph
        /// </summary>
        /// <param name="title">The Title Of The Graph</param>
        /// <param name="ltitle">The Title Of The Legend</param>
        /// <param name="height">The Height Of The Chart</param>
        /// <param name="width">The Width Of The Chart</param>
        public ChartInfo(string title, string ltitle, int height, int width)
            : this(title, ltitle, height, width, Brushes.LightSteelBlue) { }

        /// <summary>
        /// Constructor To Set Up The Title, Legend Title, Height, Width, Color And Graph
        /// </summary>
        /// <param name="title">The Title Of The Graph</param>
        /// <param name="ltitle">The Title Of The Legend</param>
        /// <param name="height">The Height Of The Chart</param>
        /// <param name="width">The Width Of The Chart</param>
        /// <param name="color">The Color Of The Chart</param>
        public ChartInfo(string title, string ltitle, int height, int width, Brush color)
        {
            Chart = new Chart
            {
                Title = title,
                LegendTitle = ltitle,
                Height = height,
                Width = width,
                Background = color
            };
        }

        /// <summary>
        /// Wrapper Method To Add A Graph To The Chart
        /// </summary>
        /// <param name="graph">The Graph To Add</param>
        public void AddGraph(GraphInfo graph)
        {
            Chart.Series.Add(graph.Graph);
        }
    }
}
