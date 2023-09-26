using ChessMovimentControl.Service;
using System.Windows;
using System.Windows.Controls;

namespace phoneKeyboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DialPad : Window
    {
        public SeriesNumber _serieNumber;

        public DialPad()
        {
            InitializeComponent();
            _serieNumber = new SeriesNumber();
        }

        private void Digitbutton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            _serieNumber.AddNumber(button.Content.ToString().ToCharArray()[0]);

            if (_serieNumber.IsFinished())
            {
                MessageBox.Show($"The finish number is: {_serieNumber.Get()}");
                _serieNumber.Clear();
            }
        }
    }
   
}
