using QuestionVisualisation.Extensions;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.CustomObjects.Buttons
{
    public partial class ShowButton : UserControl
    {
        public ShowButton()
        {
            InitializeComponent();
        }

        private void ViewPlaceholder_MouseEnter(object sender, MouseEventArgs e)
        {
            ViewPlaceholder.ChangeColors(Constants.Colors.LightGreen);
        }

        private void ViewPlaceholder_MouseLeave(object sender, MouseEventArgs e)
        {
            ViewPlaceholder.ChangeColors(Constants.Colors.Transparent);
        }
    }
}
