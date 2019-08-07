using Job_Application_Database.Singleton;
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

        private readonly int LEFT_MARGIN = 5;
        private readonly int RIGHT_MARGIN = 5;
        private readonly int TOP_MARGIN = 5;
        private readonly int BOTTOM_MARGIN = 5;

        public BaseGraph()
        {
            _bgw = new BaseGraphWindow();

            _bgw.Loaded += BaseGraphWindow_Loaded;
        }

        private void BaseGraphWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Chart c = new Chart
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Background = Brushes.LightSteelBlue,
                Title = "Job Application Status",
                VerticalAlignment = VerticalAlignment.Bottom,
                Width = 500
        };
            Thickness margin = c.Margin;
            margin.Left = LEFT_MARGIN;
            margin.Top = TOP_MARGIN;
            margin.Right = RIGHT_MARGIN;
            margin.Bottom = BOTTOM_MARGIN;
            c.Margin = margin;

            BarSeries cs = new BarSeries
            {
                DependentValueBinding = new Binding("Value"),
                IndependentValueBinding = new Binding("Key"),
                ItemsSource = Companies.Instance.JobKeyValue(),
                
            };
            c.Height = 35 * ((List<KeyValuePair<string, int>>)cs.ItemsSource).Count;
            cs.Title = "Jobs (" + Companies.Instance.Count + ")";
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
