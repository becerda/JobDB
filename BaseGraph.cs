using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Job_Application_Database.Classes
{
    class BaseGraph
    {
        private BaseGraphWindow _bgw;

        private readonly int LEFT_MARGIN = 50;
        private readonly int RIGHT_MARGIN = 0;
        private readonly int TOP_MARGIN = 50;
        private readonly int BOTTOM_MARGIN = 50;

        public BaseGraph()
        {
            _bgw = new BaseGraphWindow();

            _bgw.Loaded += BaseGraphWindow_Loaded;
        }

        private void BaseGraphWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
            valueList.Add(new KeyValuePair<string, int>("Developer", 60));
            valueList.Add(new KeyValuePair<string, int>("Misc", 20));
            valueList.Add(new KeyValuePair<string, int>("Tester", 50));
            valueList.Add(new KeyValuePair<string, int>("QA", 30));
            valueList.Add(new KeyValuePair<string, int>("Project Manager", 40));

            Chart c = new Chart();
            c.Height = 262;
            c.HorizontalAlignment = HorizontalAlignment.Left;
            Thickness margin = c.Margin;
            margin.Left = LEFT_MARGIN;
            margin.Top = TOP_MARGIN;
            margin.Right = RIGHT_MARGIN;
            margin.Bottom = BOTTOM_MARGIN;
            c.Margin = margin;
            c.Title = "Column Series";
            c.VerticalAlignment = VerticalAlignment.Bottom;
            c.Width = 360;

            ColumnSeries cs = new ColumnSeries();
            cs.DependentValueBinding = new Binding("Value");
            cs.IndependentValueBinding = new Binding("Key");
            cs.ItemsSource = valueList;
            c.Series.Add(cs);
            _bgw.gridBase.Children.Add(c);
        }

        public void ShowDialog()
        {
            _bgw.ShowDialog();
        }
    }

    public class RecordCollection : ObservableCollection<Record>
    {
        public RecordCollection(List<Bar> bars)
        {
            //Random rand = new Random();
            //BrushCollection brushes = new BrushCollection();

            foreach(Bar bar in bars)
            {
                //int num = rand.Next(brushes.Count / 3);
                Add(new Record(bar.Value, Brushes.Black, bar.Name));
            }
        }
    }

    public class BrushCollection : ObservableCollection<Brush>
    {
        public BrushCollection()
        {
            Type _bursh = typeof(Brushes);
            PropertyInfo[] props = _bursh.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                Brush _color = (Brush)prop.GetValue(null, null);
                if (_color != Brushes.LightSteelBlue && 
                    _color != Brushes.White && 
                    _color != Brushes.WhiteSmoke && 
                    _color != Brushes.LightCyan && 
                    _color != Brushes.LightYellow && 
                    _color != Brushes.Linen)
                    Add(_color);
            }
        }
    }

    public class Bar
    {
        public string Name { get; set; }

        public int Value { get; set; }
    }

    public class Record : INotifyPropertyChanged
    {
        private int _data;

        public Brush Color { get; set; }

        public string Name { get; set; }

        public int Data
        {
            get
            {
                return _data;
            }
            set
            {
                if (_data != value)
                    _data = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Record(int value, Brush color, string name)
        {
            Data = value;
            Color = color;
            Name = name;
        }

        protected void PropertyOnChange(string propname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }
    }
}
