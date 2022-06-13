using QuestionVisualisation.Extensions;
using QuestionVisualisation.Services;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.CustomObjects.Controllers
{
    public partial class DeleteButton : UserControl
    {
        public DeleteButton()
        {
            InitializeComponent();
        }

        private void DeleteIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            DeleteIcon.ChangeColors(Constants.LightRed);
        }

        private void DeleteIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            DeleteIcon.ChangeColors(Constants.White);
        }
    }
}
