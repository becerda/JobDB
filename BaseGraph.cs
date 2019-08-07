using Job_Application_Database.Factories;
using Job_Application_Database.Singleton;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Media;

namespace Job_Application_Database.Classes
{
    class BaseGraph
    {

        private DataPointSeries _diag;

        private string _title;
        private int _height;
        private int _width;
        private Brush _color;

        // Default Margin Values
        protected static readonly int LEFT_MARGIN = 5;
        protected static readonly int RIGHT_MARGIN = 5;
        protected static readonly int TOP_MARGIN = 5;
        protected static readonly int BOTTOM_MARGIN = 5;

        // Default Height And Width
        protected static readonly int DEFAULT_WIDTH = 500;
        protected static readonly int DEFAULT_HEIGHT = 500;

        // Default Item Spacing
        protected static readonly int ITEM_SPACING = 35;

        // Reference To The Base Graph Window
        protected BaseGraphWindow Wind { get; private set; }

        public BaseGraph(DataPointSeries diagram, string title) : this(diagram, title, Brushes.LightSteelBlue) { }

        public BaseGraph(DataPointSeries diagram, string title, Brush color) : this(diagram, title, color, ITEM_SPACING * ((List<KeyValuePair<string, int>>)diagram.ItemsSource).Count, DEFAULT_WIDTH) { }
        public BaseGraph(DataPointSeries diagram, string title, Brush color, int height, int width)
        {
            Wind = new BaseGraphWindow();

            _diag = diagram;
            _title = title;
            _color = color;
            _height = height;
            _width = width;

            Wind.Loaded += BaseGraphWindow_Loaded;
        }

        private void BaseGraphWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Chart c = NewChart(_title,
                _height,
                _width,
                _color,
                _diag);

            Wind.gridBase.Children.Add(c);
        }

        public void ShowDialog()
        {
            Wind.ShowDialog();
        }

        protected Chart NewChart(string title, int height, int width, Brush background, Series diagram)
        {
            Chart c = new Chart
            {
                Title = title,
                Height = height,
                Width = width,
                Background = background,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            Thickness margin = c.Margin;
            margin.Left = LEFT_MARGIN;
            margin.Top = TOP_MARGIN;
            margin.Right = RIGHT_MARGIN;
            margin.Bottom = BOTTOM_MARGIN;
            c.Margin = margin;

            c.Series.Add(diagram);

            return c;
        }
    }

}
