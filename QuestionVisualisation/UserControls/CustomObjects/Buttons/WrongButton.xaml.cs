using QuestionVisualisation.Extensions;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.CustomObjects.Buttons
{
    public partial class WrongButton : UserControl
    {
        public WrongButton()
        {
            InitializeComponent();
        }

        private void WrongPlaceholder_MouseEnter(object sender, MouseEventArgs e)
        {
            WrongPlaceholder.ChangeColors(Constants.Colors.LightRed);
        }

        private void WrongPlaceholder_MouseLeave(object sender, MouseEventArgs e)
        {
            WrongPlaceholder.ChangeColors(Constants.Colors.Transparent);
        }
    }
}
