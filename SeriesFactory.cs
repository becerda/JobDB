using Job_Application_Database.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;

namespace Job_Application_Database.Factories
{
    class SeriesFactory
    {

        public static readonly IDictionary<SeriesType, Func<string, List<KeyValuePair<string, int>>, DataPointSeries>> Creators =
            new Dictionary<SeriesType, Func<string, List<KeyValuePair<string, int>>, DataPointSeries>>()
            {
                {SeriesType.Area, (title, source) => new AreaSeries{ Title = title, ItemsSource = source} },
                {SeriesType.Bar, (title, source) => new BarSeries{ Title = title, ItemsSource = source} },
                {SeriesType.Column, (title, source) => new ColumnSeries{ Title = title, ItemsSource = source} },
                {SeriesType.Line, (title, source) => new LineSeries{ Title = title, ItemsSource = source} },
                {SeriesType.Pie, (title, source) => new PieSeries{ Title = title, ItemsSource = source} },
                {SeriesType.Scatter, (title, source) => new ScatterSeries{ Title = title, ItemsSource = source} }
            };

        public static DataPointSeries CreateInstance(SeriesType type, string title, List<KeyValuePair<string, int>> source)
        {
            DataPointSeries dps = Creators[type](title, source);
            dps.IndependentValueBinding = new Binding("Key");
            dps.DependentValueBinding = new Binding("Value");
            return dps;
        }
    }

}
