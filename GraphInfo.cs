using Job_Application_Database.Enum;
using System.Collections.Generic;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Media;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Stores Information About The Graph To Be Created
    /// </summary>
    class GraphInfo
    {
        /// <summary>
        /// The Series Type Of The Graph
        /// </summary>
        public SeriesType Type { get; set; }

        /// <summary>
        /// The Title Of The Graph
        /// </summary>
        public string GraphTitle { get; set; }

        /// <summary>
        /// The Legend Title
        /// </summary>
        public string LegendTitle { get; set; }

        /// <summary>
        /// The Source Of Data
        /// </summary>
        public List<KeyValuePair<string, int>> Source { get; set; }

        /// <summary>
        /// The Color Of The Graph
        /// </summary>
        public Brush Color { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public GraphInfo() { }

        /// <summary>
        /// Constructor To Set Type, Graph Title, And Source
        /// </summary>
        /// <param name="type">The Series Type Of The Graph</param>
        /// <param name="gtitle">The Title Of The Graph</param>
        /// <param name="source">The Source Of Data</param>
        public GraphInfo(SeriesType type, string gtitle, List<KeyValuePair<string, int>> source)
            : this(type, gtitle, "Legend", source, Brushes.LightSteelBlue) { }

        public GraphInfo(SeriesType type, string gtitle, string ltitle, List<KeyValuePair<string, int>> source)
            : this(type, gtitle, ltitle, source, Brushes.LightSteelBlue) { }

        /// <summary>
        /// Constructor To Set Type, Graph Title, Legend Title, Source, And Color
        /// </summary>
        /// <param name="type">The Series Type Of The Graph</param>
        /// <param name="gtitle">The Title Of The Graph</param>
        /// <param name="ltitle">The Title Of The Legend</param>
        /// <param name="source">The Source Of Data</param>
        /// <param name="color">The Color Of The Graph</param>
        public GraphInfo(SeriesType type, string gtitle, string ltitle, List<KeyValuePair<string, int>> source, Brush color)
        {
            Type = type;
            GraphTitle = gtitle;
            LegendTitle = ltitle;
            Source = source;
            Color = color;
        }

    }
}
