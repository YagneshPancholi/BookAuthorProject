using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project1WpfMVVM.Views
{
    /// <summary>
    /// Interaction logic for AddAuthor.xaml
    /// </summary>
    public partial class AddAuthorView : UserControl
    {
        private bool IsValidInput = false;

        public AddAuthorView()
        {
            InitializeComponent();
        }

        private void PreviewMouseDownEventToClearDefaultData(object sender, MouseButtonEventArgs e)
        {
            if (sender.ToString().Contains("Enter Author Name"))
            {
                AuthorName.Text = string.Empty;
            }
            else if (sender.ToString().Contains("Enter Email"))
            {
                Email.Text = string.Empty;
            }
            else if (sender.ToString().Contains("Enter Education"))
            {
                Education.Text = string.Empty;
            }
        }
    }
}