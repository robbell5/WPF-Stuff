using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Stuff
{
    public partial class SingleRow : UserControl
    {
        public SingleRow()
        {
            InitializeComponent();
        }

        public void AddColumn()
        {
            TheGrid.ColumnDefinitions.Add(new ColumnDefinition());

            Rectangle rectangle = new Rectangle
            {
                Stroke = new SolidColorBrush(Colors.Black),
                Fill = new SolidColorBrush(Colors.Blue)
            };

            int columnIndex = (TheGrid.Children.Count);
            rectangle.SetValue(Grid.ColumnProperty, columnIndex);
            TheGrid.Children.Add(rectangle);
        }
    }
}
