using System.Collections.Generic;
using System.Windows.Media;
using Job_Application_Database.Enum;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Inherits from GraphInfo to set up a ColumnSeries graph
    /// </summary>
    class ColumnGraphInfo : GraphInfo
    {
        /// <summary>
        /// Constructor To Set Up Graph Title And Source
        /// </summary>
        /// <param name="gtitle">The Title Of The Graph</param>
        /// <param name="source">The Source Of The Data</param>
        public ColumnGraphInfo(string gtitle, List<KeyValuePair<string, int>> source)
            : base(SeriesType.Column, gtitle, source)
        {
        }

        /// <summary>
        /// Constructor To Set Up Graph Title, Legend Title, And Source
        /// </summary>
        /// <param name="gtitle">The Title Of The Graph</param>
        /// <param name="ltitle">The Title Of The Legend</param>
        /// <param name="source">The Source Of The Data</param>
        public ColumnGraphInfo(string gtitle, string ltitle, List<KeyValuePair<string, int>> source)
           : this(gtitle, ltitle, source, Brushes.LightSteelBlue)
        {
        }

        /// <summary>
        /// Constructor To Set Up Graph Title, Legend Title, Source And Color 
        /// </summary>
        /// <param name="gtitle">The Title Of The Graph</param>
        /// <param name="ltitle">The Title Of The Legend</param>
        /// <param name="source">The Source Of The Data</param>
        /// <param name="color">The Color Of The Graph</param>
        public ColumnGraphInfo(string gtitle, string ltitle, List<KeyValuePair<string, int>> source, Brush color) 
            : base(SeriesType.Column, gtitle, ltitle, source, color)
        {
        }
    }
}
