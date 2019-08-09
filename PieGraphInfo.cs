using Job_Application_Database.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Inherits from GraphInfo to set up a PieSeries graph
    /// </summary>
    class PieGraphInfo : GraphInfo
    {
        /// <summary>
        /// Constructor To Set Up Graph Title, Legend Title, And Source
        /// </summary>
        /// <param name="source">The Source Of The Data</param>
        public PieGraphInfo(List<KeyValuePair<string, int>> source)
           : this(source, null)
        {
        }

        /// <summary>
        /// Constructor To Set Up Graph Title, Legend Title, Source And Color 
        /// </summary>
        /// <param name="source">The Source Of The Data</param>
        /// <param name="color">The Color Of The Graph</param>
        public PieGraphInfo(List<KeyValuePair<string, int>> source, Brush color)
            : base(SeriesType.Pie, null, source, false, color)
        {
        }
    }
}
