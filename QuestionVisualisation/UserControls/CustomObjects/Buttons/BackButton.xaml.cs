using QuestionVisualisation.Extensions;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.CustomObjects.Buttons
{
    public partial class BackButton : UserControl
    {
        public BackButton()
        {
            InitializeComponent();
        }

        private void DeletePlaceholder_MouseEnter(object sender, MouseEventArgs e)
        {
            DeletePlaceholder.ChangeColors(Constants.Colors.LightGreen);
        }

        private void DeletePlaceholder_MouseLeave(object sender, MouseEventArgs e)
        {
            DeletePlaceholder.ChangeColors(Constants.Colors.Transparent);
        }
    }
}
