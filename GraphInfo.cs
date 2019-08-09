using Job_Application_Database.Enum;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
        /// The Reference To The Graph
        /// </summary>
        public DataPointSeries Graph { get; set; }

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
            : this(type, gtitle, source, true) { }

        /// <summary>
        /// Constructor To Set Type, Graph Title, Source, And Rotation
        /// </summary>
        /// <param name="type">The Series Type Of The Graph</param>
        /// <param name="gtitle">The Title Of The Graph</param>
        /// <param name="source">The Source Of Data</param>
        /// <param name="rotate">Should The Text Be Rotated?</param>
        public GraphInfo(SeriesType type, string gtitle, List<KeyValuePair<string, int>> source, bool rotate)
            : this(type, gtitle, source, rotate, Brushes.LightSteelBlue) { }

        /// <summary>
        /// Constructor To Set Type, Graph Title, Source, Rotation, And Color
        /// </summary>
        /// <param name="type">The Series Type Of The Graph</param>
        /// <param name="gtitle">The Title Of The Graph</param>
        /// <param name="source">The Source Of Data</param>
        /// <param name="rotate">Should The Text Be Rotated?</param>
        /// <param name="color">The Color Of The Graph</param>
        public GraphInfo(SeriesType type, string gtitle, List<KeyValuePair<string, int>> source, bool rotate, Brush color)
        {
            Type = type;
            switch (type)
            {
                case SeriesType.Area:
                    Graph = new AreaSeries();
                    break;
                case SeriesType.Bar:
                    Graph = new BarSeries();
                    break;
                case SeriesType.Column:
                    Graph = new ColumnSeries();
                    break;
                case SeriesType.Line:
                    Graph = new LineSeries();
                    break;
                case SeriesType.Pie:
                    Graph = new PieSeries();
                    break;
                case SeriesType.Scatter:
                    Graph = new ScatterSeries();
                    break;
            }

            Graph.IndependentValuePath = "Key";
            Graph.DependentValuePath = "Value";

            Graph.Title = gtitle;
            Graph.ItemsSource = source;
            if (color != null)
                SetGraphColor(color);
            if (rotate)
                RotateText(-90);

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
        /// Rotates Independant Axes Text
        /// </summary>
        /// <param name="angle">The Angle To Rotate The Text</param>
        private void RotateText(int angle)
        {
            ControlTemplate ct = new ControlTemplate(typeof(AxisLabel));
            var tb = new FrameworkElementFactory(typeof(TextBlock));
            tb.SetValue(TextBlock.PaddingProperty, new Thickness(5, 5, 5, 5));
            tb.SetValue(TextBlock.TextProperty, new TemplateBindingExtension(AxisLabel.FormattedContentProperty));
            tb.SetValue(TextBlock.LayoutTransformProperty, new RotateTransform { Angle = angle });
            ct.VisualTree = tb;

            Style s = new Style(typeof(AxisLabel));
            s.Setters.Add(new Setter(AxisLabel.TemplateProperty, ct));
            CategoryAxis ca = new CategoryAxis { Orientation = AxisOrientation.X };
            ca.SetValue(CategoryAxis.AxisLabelStyleProperty, s);

            switch (Type)
            {
                case SeriesType.Area:
                    Graph.SetValue(AreaSeries.IndependentAxisProperty, ca);
                    break;
                case SeriesType.Bar:
                    break;
                case SeriesType.Column:
                    Graph.SetValue(ColumnSeries.IndependentAxisProperty, ca);
                    break;
                case SeriesType.Line:
                    Graph.SetValue(LineSeries.IndependentAxisProperty, ca);
                    break;
                case SeriesType.Pie:
                    break;
                case SeriesType.Scatter:
                    Graph.SetValue(ScatterSeries.IndependentAxisProperty, ca);
                    break;
            }
        }

    }

}
