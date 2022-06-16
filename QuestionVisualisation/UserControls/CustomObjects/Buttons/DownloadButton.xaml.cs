using QuestionVisualisation.Extensions;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.CustomObjects.Buttons
{
    public partial class DownloadButton : UserControl
    {
        public DownloadButton()
        {
            InitializeComponent();
        }

        private void OpenPlaceholder_MouseEnter(object sender, MouseEventArgs e)
        {
            OpenPlaceholder.ChangeColors(Constants.Colors.LightGreen);
        }

        private void OpenPlaceholder_MouseLeave(object sender, MouseEventArgs e)
        {
            OpenPlaceholder.ChangeColors(Constants.Colors.Transparent);
        }
    }
}
