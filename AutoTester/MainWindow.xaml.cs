using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            InitializeComponent();
            DataContext = new TesterViewModel();
        }
        private static readonly Regex _posReg = new Regex("[^0-9]+");
        private static readonly Regex _posRegDouble = new Regex("[^0-9,]+");
        private static readonly Regex _reg = new Regex("[^0-9,-]+");
        private static readonly Regex _regSpace = new Regex("[^0-9 ,-]+");

        private static bool IsTextAllowedPos(string text)
        {
            return !_posReg.IsMatch(text);
        }
        private static bool IsTextAllowedPosDouble(string text)
        {
            return !_posRegDouble.IsMatch(text);
        }
        private static bool IsTextAllowed(string text)
        {
            return !_reg.IsMatch(text);
        }
        private static bool IsTextAllowedSpace(string text)
        {
            return !_regSpace.IsMatch(text);
        }

        private void TextBox_PreviewPositive(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowedPos(e.Text);
        }
        private void TextBox_PreviewPositiveDouble(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowedPosDouble(e.Text);
        }
        private void TextBox_Preview(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private void TextBox_PreviewSpace(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowedSpace(e.Text);
        }

        private void propList_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            scroller.ScrollToVerticalOffset(scroller.VerticalOffset - (e.Delta / 3));
            e.Handled = true;
        }
    }
}