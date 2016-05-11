using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPF_Stuff
{
    public class SingleRowUsingOnlyCode
    {
        public Grid SingleRowGrid = new Grid
        {
            Height = 25,
            Margin = new Thickness(0),
            VerticalAlignment = VerticalAlignment.Center
        };

        private static readonly Color CellFillColor = Colors.Blue;

        public SingleRowUsingOnlyCode(int numberOfColumns)
        {
            InitializeGrid(numberOfColumns);
        }

        private void InitializeGrid(int numberOfColumns)
        {
            for (int i = 0; i < numberOfColumns; i++)
            {
                AddColumnToGrid();
            }
        }

        private void AddColumnToGrid()
        {
            SingleRowGrid.ColumnDefinitions.Add(new ColumnDefinition());
            int columnIndex = SingleRowGrid.Children.Count;

            Rectangle cell = new Rectangle
            {
                Stroke = new SolidColorBrush(Colors.Black),
                Fill = new SolidColorBrush(CellFillColor)
            };

            cell.SetValue(Grid.ColumnProperty, columnIndex);
            SingleRowGrid.Children.Add(cell);
        }

        public void HighlightColumn(int columnIndex)
        {
            UIElementCollection uiElementCollection = SingleRowGrid.Children;
            foreach (Rectangle rectangle in uiElementCollection.OfType<Rectangle>())
            {
                int rectanglesColumnIndex = -1;
                int.TryParse(rectangle.GetValue(Grid.ColumnProperty).ToString(), out rectanglesColumnIndex);

                Color fillColor = CellFillColor;

                if (rectanglesColumnIndex == columnIndex)
                {
                    fillColor = Colors.Yellow;
                }

                rectangle.Fill = new SolidColorBrush(fillColor);
            }
        }
    }
}
