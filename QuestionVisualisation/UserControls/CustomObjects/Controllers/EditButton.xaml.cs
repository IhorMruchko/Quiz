using QuestionVisualisation.Extensions;
using QuestionVisualisation.Services;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.CustomObjects.Controllers
{
    public partial class EditButton : UserControl
    {
        public EditButton()
        {
            InitializeComponent();
        }
        private void EditIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            EditIcon.ChangeColors(Constants.Purple);
        }

        private void EditIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            EditIcon.ChangeColors(Constants.White);
        }
    }
}
