using System.Linq;
using System.Windows.Controls;
using static System.Math;

namespace QuestionVisualisation.UserControls.CustomObjects.Input
{
    public partial class IntInputBox : UserControl
    {
        public IntInputBox()
        {
            InitializeComponent();
        }

        public int MinValue { get; set; } = 0;

        public int MaxValue { get; set; } = 1;

        public int Value => (int)IntPicker.SelectedItem;

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            IntPicker.ItemsSource = Enumerable.Range(Min(MaxValue, MinValue), Abs(MaxValue - MinValue) + 1);
            IntPicker.SelectedIndex = 0;
        }
    }
}
