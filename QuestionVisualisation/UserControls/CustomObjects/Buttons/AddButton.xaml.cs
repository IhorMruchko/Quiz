using QuestionVisualisation.Extensions;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.CustomObjects.Buttons
{
    public partial class AddButton : UserControl
    {
        public AddButton()
        {
            InitializeComponent();
        }

        private void AddPlaceholder_MouseEnter(object sender, MouseEventArgs e)
        {
            AddPlaceholder.ChangeColors(Constants.Colors.LightGreen);
        }

        private void AddPlaceholder_MouseLeave(object sender, MouseEventArgs e)
        {
            AddPlaceholder.ChangeColors(Constants.Colors.Transparent);
        }
    }
}
