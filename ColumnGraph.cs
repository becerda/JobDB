using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Media;
using Job_Application_Database.Enum;

namespace Job_Application_Database.Classes
{
    /// <summary>
    /// Class That Controls Column Graph Usage
    /// </summary>
    class ColumnGraph : BaseGraph
    {
        // Default Constructor
        public ColumnGraph(string ctitle, string ltitle, string gtitle, List<KeyValuePair<string, int>> source) 
            : this(ctitle, ltitle, gtitle, source, Brushes.LightSteelBlue)
        {
        }

        public ColumnGraph(string ctitle, string ltitle, string gtitle, List<KeyValuePair<string, int>> source, Brush chartcolor)
            : this(ctitle, ltitle, gtitle, source, chartcolor, chartcolor)
        {
        }

        public ColumnGraph(string ctitle, string ltitle, string gtitle, List<KeyValuePair<string, int>> source, Brush chartcolor, Brush barcolor)
            : base(ctitle, ltitle, gtitle, source, SeriesType.Column, DefaultHeight, DefaultItemSpacing * source.Count, chartcolor, barcolor)
        {
        }
    }
}
