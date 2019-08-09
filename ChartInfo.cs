using System.Windows.Media;

namespace Job_Application_Database.Classes
{
    class ChartInfo
    {
        // Default Height Of Chart
        public static int DefaultHeight = 500;

        // Default Width Of Chart
        public static int DefaultWidth = 500;

        // Default Item Spacing Of Chart
        public static int DefaultItemSpacing = 50;

        public GraphInfo Graph { get; set; }

        public string Title { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public Brush Color { get; set; }

        public ChartInfo() { }

        public ChartInfo(GraphInfo graph)
            : this("", graph) { }

        public ChartInfo(string title, GraphInfo graph)
        : this(title, DefaultHeight, DefaultWidth, Brushes.LightSteelBlue, graph) { }

        public ChartInfo(string title, int height, int width, GraphInfo graph)
        : this(title, height, width, Brushes.LightSteelBlue, graph) { }


        public ChartInfo(string title, int height, int width, Brush color, GraphInfo graph)
        {
            Title = title;
            Height = height;
            Width = width;
            Color = color;
            Graph = graph;
        }
    }
}
