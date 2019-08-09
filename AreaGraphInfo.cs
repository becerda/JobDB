using Job_Application_Database.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Media;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Inherits from GraphInfo to set up a AreaSeries graph
    /// </summary>
    class AreaGraphInfo : GraphInfo
    {
        /// <summary>
        /// Constructor To Set Up Graph Title And Source
        /// </summary>
        /// <param name="gtitle">The Title Of The Graph</param>
        /// <param name="source">The Source Of The Data</param>
        public AreaGraphInfo(string gtitle, List<KeyValuePair<string, int>> source)
             : base(SeriesType.Area, gtitle, source)
        {
        }

        /// <summary>
        /// Constructor To Set Up Graph Title, Legend Title, And Source
        /// </summary>
        /// <param name="gtitle">The Title Of The Graph</param>
        /// <param name="ltitle">The Title Of The Legend</param>
        /// <param name="source">The Source Of The Data</param>
        public AreaGraphInfo(string gtitle, string ltitle, List<KeyValuePair<string, int>> source)
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
        public AreaGraphInfo(string gtitle, string ltitle, List<KeyValuePair<string, int>> source, Brush color)
            : base(SeriesType.Area, gtitle, ltitle, source, color)
        {
        }
    }
}
