using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPF_Stuff
{
    public partial class MainWindow : Window
    {
        private readonly SingleRowUsingOnlyCode _singleRowUsingOnlyCode;

        public MainWindow()
        {
            InitializeComponent();

            _singleRowUsingOnlyCode = new SingleRowUsingOnlyCode(40);
            _singleRowUsingOnlyCode.SingleRowGrid.SetValue(Grid.RowProperty, 0);
            MainGridPanel.Children.Add(_singleRowUsingOnlyCode.SingleRowGrid);

            BlackOutDates();
        }

        private void BlackOutDates()
        {
            DateTime minDate = FridayPicker.DisplayDateStart ?? DateTime.MinValue;
            DateTime maxDate = FridayPicker.DisplayDateEnd ?? DateTime.MaxValue;

            for (DateTime date = minDate; date <= maxDate && ThereIsAtLeastSevenMoreDaysLeftBeforeMaxValue(date); date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Friday)
                {
                    FridayPicker.BlackoutDates.Add(new CalendarDateRange(date));
                }
            }
        }

        private static bool ThereIsAtLeastSevenMoreDaysLeftBeforeMaxValue(DateTime date)
        {
            return (DateTime.MaxValue - date.AddDays(1)).Days > 1;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int result;
            if(int.TryParse(ColumnIndexTextBox.Text, out result))
            {
                _singleRowUsingOnlyCode.HighlightColumn(result);
            }
        }

        private void ColumnIndexTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs eventArgs)
        {
            int result;
            eventArgs.Handled = !int.TryParse(eventArgs.Text, out result);
        }
    }
}
