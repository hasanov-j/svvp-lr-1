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

namespace project_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBoxValue_TextChanged(object sender, RoutedEventArgs e)
        {
            if (!IsValidInput(textBoxValue.Text))
            {
                MessageBox.Show("Можно вводить только числа и, возможно, одну запятую.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (textBoxValue != null &&
                comboBoxDistanceFrom.SelectedItem != null &&
                comboBoxTimeFrom.SelectedItem != null &&
                comboBoxTimeTo.SelectedItem != null &&
                comboBoxDistanceTo.SelectedItem != null)
            {
                UpdateConvertedValues(
                    textBoxValue,
                    comboBoxDistanceFrom,
                    comboBoxTimeFrom,
                    textBoxResult,
                    comboBoxDistanceTo,
                    comboBoxTimeTo
                );
            }
        }

        private bool IsValidInput(string input)
        {
            // Регулярное выражение для проверки, что в строке содержатся только числа и, возможно, одна запятая
            string pattern = @"^[0-9]+,?([0-9]+)?$";

            return System.Text.RegularExpressions.Regex.IsMatch(input, pattern);
        }

        private void ComboBoxDistanceFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textBoxValue != null &&
                comboBoxDistanceFrom.SelectedItem != null &&
                comboBoxTimeFrom.SelectedItem != null &&
                comboBoxTimeTo.SelectedItem != null &&
                comboBoxDistanceTo.SelectedItem != null)
            {
                UpdateConvertedValues(
                    textBoxValue,
                    comboBoxDistanceFrom,
                    comboBoxTimeFrom,
                    textBoxResult,
                    comboBoxDistanceTo,
                    comboBoxTimeTo
                );
            }
        }

        private void ComboBoxTimeFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textBoxValue != null &&
                comboBoxDistanceFrom.SelectedItem != null &&
                comboBoxTimeFrom.SelectedItem != null &&
                comboBoxTimeTo.SelectedItem != null &&
                comboBoxDistanceTo.SelectedItem != null)
            {
                UpdateConvertedValues(
                    textBoxValue,
                    comboBoxDistanceFrom,
                    comboBoxTimeFrom,
                    textBoxResult,
                    comboBoxDistanceTo,
                    comboBoxTimeTo
                );
            }
        }

        private void ComboBoxDistanceTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textBoxValue != null &&
                comboBoxDistanceTo.SelectedItem != null &&
                comboBoxTimeTo.SelectedItem != null &&
                comboBoxDistanceFrom.SelectedItem != null &&
                comboBoxTimeFrom.SelectedItem != null)
            {
                UpdateConvertedValues(
                    textBoxValue,
                    comboBoxDistanceFrom,
                    comboBoxTimeFrom,
                    textBoxResult,
                    comboBoxDistanceTo,
                    comboBoxTimeTo
                );
            }
        }

        private void ComboBoxTimeTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textBoxValue != null &&
                comboBoxDistanceTo.SelectedItem != null &&
                comboBoxTimeTo.SelectedItem != null &&
                comboBoxDistanceFrom.SelectedItem != null &&
                comboBoxTimeFrom.SelectedItem != null)
            {
                UpdateConvertedValues(
                    textBoxValue,
                    comboBoxDistanceFrom,
                    comboBoxTimeFrom,
                    textBoxResult,
                    comboBoxDistanceTo,
                    comboBoxTimeTo
                );
            }
        }


        private void UpdateConvertedValues(
            TextBox inputTextBox, 
            ComboBox distanceUnitFrom, 
            ComboBox timeUnitFrom, 
            TextBox outputTextBox,
            ComboBox distanceUnitTo,
            ComboBox timeUnitTo
        ) {

            ComboBoxItem distanceItemFrom = distanceUnitFrom.SelectedItem as ComboBoxItem;
            ComboBoxItem timeItemFrom = timeUnitFrom.SelectedItem as ComboBoxItem;
            ComboBoxItem distanceItemTo = distanceUnitTo.SelectedItem as ComboBoxItem;
            ComboBoxItem timeItemTo = timeUnitTo.SelectedItem as ComboBoxItem;

            if (double.TryParse(inputTextBox.Text, out double value)) {

                double conversionToMeterPerSecond = ConvertToMeterPerSecond(value, distanceItemFrom, timeItemFrom);

                outputTextBox.Text = ConvertToNeedUnits(conversionToMeterPerSecond, distanceItemTo, timeItemTo);

            }
        }

        private double ConvertToMeterPerSecond(double value, ComboBoxItem distanceItem, ComboBoxItem timeItem)
        {
            double conversionToMeter = value;

            switch (distanceItem.Tag.ToString())
            {
                case "km": conversionToMeter *= 1000; break;
                case "dm": conversionToMeter *= 0.1; break;
                case "cm": conversionToMeter *= 0.01; break;
                case "mm": conversionToMeter *= 0.001; break;
            }

            switch (timeItem.Tag.ToString())
            {
                case "min": conversionToMeter /= 60; break;
                case "hour": conversionToMeter /= 3600; break;
                case "day": conversionToMeter /= 86400; break;
                case "year": conversionToMeter /= 31536000; break;
            }

            return conversionToMeter;
        }

        private string ConvertToNeedUnits(
            double convertValue,
            ComboBoxItem distanceUnitTo,
            ComboBoxItem timeUnitTo
        ) {

            switch (distanceUnitTo.Tag.ToString())
            {
                case "km": convertValue = convertValue * 0.001; break;
                case "dm": convertValue = convertValue * 10; break;
                case "cm": convertValue = convertValue * 100; break;
                case "mm": convertValue = convertValue * 1000; break;
                default: convertValue = convertValue * 1; break;
            }

            switch (timeUnitTo.Tag.ToString())
            {
                case "min": convertValue = convertValue * 60; break;
                case "hour": convertValue = convertValue * 3600; break;
                case "day": convertValue = convertValue * 86400; break;
                case "year": convertValue = convertValue * 31536000; break;
                default: convertValue = convertValue * 1; break;
            }
            return $"{convertValue:F6}";
        }

    }
}
