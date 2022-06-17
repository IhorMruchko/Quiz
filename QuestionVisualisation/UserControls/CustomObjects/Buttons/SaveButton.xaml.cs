using QuestionVisualisation.Extensions;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.CustomObjects.Buttons
{
    public partial class SaveButton : UserControl
    {
        public SaveButton()
        {
            InitializeComponent();
        }

        private void SavePlaceholder_MouseEnter(object sender, MouseEventArgs e)
        {
            SavePlaceholder.ChangeColors(Constants.Colors.LightGreen);
        }

        private void SavePlaceholder_MouseLeave(object sender, MouseEventArgs e)
        {
            SavePlaceholder.ChangeColors(Constants.Colors.Transparent);
        }
    }
}
