using Project1WpfMVVM.State.Navigators;
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
    /// Interaction logic for EditBookView.xaml
    /// </summary>
    public partial class EditBookView : UserControl
    {
        private List<string> selectedAuthorNames;
        private List<string> selectedGenreNames;
        private List<string> selectedPublisherNames;
        private int Count = 0;

        public EditBookView()
        {
            selectedAuthorNames = new List<string>();
            selectedGenreNames = new List<string>();
            selectedPublisherNames = new List<string>();
            InitializeComponent();
        }

        private void box1_DropDownOpened(object sender, EventArgs e)
        {
            if (Count == 0)
            {
                LoadData();
                Count = 1;
            }
        }

        private void LoadData()
        {
            foreach (var name in selectedAuthorNamesBox.Text.Split(", "))
            {
                selectedAuthorNames.Add(name.Trim());
            }
            foreach (var name in selectedGenreNamesBox.Text.Split(", "))
            {
                selectedGenreNames.Add(name.Trim());
            }
            foreach (var name in selectedPublisherNamesBox.Text.Split(", "))
            {
                selectedPublisherNames.Add(name.Trim());
            }
            //foreach (var Item in box1.Items)
            //{
            //    var CheckBox = (CheckBox)Item;
            //    if (selectedAuthorNames.Contains(CheckBox.Content.ToString()))
            //    {
            //        CheckBox.IsChecked = true;
            //    }
            //}
            //foreach (var Item in box2.Items)
            //{
            //    var CheckBox = (CheckBox)Item;
            //    if (selectedGenreNames.Contains(CheckBox.Content.ToString()))
            //    {
            //        CheckBox.IsChecked = true;
            //    }
            //}
            //foreach (var Item in box3.Items)
            //{
            //    var CheckBox = (CheckBox)Item;
            //    if (selectedPublisherNames.Contains(CheckBox.Content.ToString()))
            //    {
            //        CheckBox.IsChecked = true;
            //    }
            //}
        }

        private void SelectAuthor(object sender, System.Windows.RoutedEventArgs e)
        {
            var data = (CheckBox)sender;
            var name = data.Content.ToString();
            if (data.Name.Equals("authorNameCheckBox"))
            {
                if (!selectedAuthorNames.Contains(name))
                {
                    selectedAuthorNames.Add(name);
                }
                selectedAuthorNamesBox.Text = string.Join(", ", selectedAuthorNames);
            }
            else if (data.Name.Equals("genreNameCheckBox"))
            {
                if (!selectedGenreNames.Contains(name))
                {
                    selectedGenreNames.Add(name);
                }
                selectedGenreNamesBox.Text = string.Join(", ", selectedGenreNames);
            }
            else
            {
                if (!selectedPublisherNames.Contains(name))
                {
                    selectedPublisherNames.Add(name);
                }
                selectedPublisherNamesBox.Text = string.Join(", ", selectedPublisherNames);
            }
        }

        private void UnselectAuthor(object sender, System.Windows.RoutedEventArgs e)
        {
            var data = (CheckBox)sender;
            var name = data.Content.ToString();
            if (data.Name.Equals("authorNameCheckBox"))
            {
                if (name != string.Empty)
                {
                    selectedAuthorNames.Remove(name);
                }
                selectedAuthorNamesBox.Text = string.Join(", ", selectedAuthorNames);
            }
            else if (data.Name.Equals("genreNameCheckBox"))
            {
                if (name != string.Empty)
                {
                    selectedGenreNames.Remove(name);
                }
                selectedGenreNamesBox.Text = string.Join(", ", selectedGenreNames);
            }
            else
            {
                if (name != string.Empty)
                {
                    selectedPublisherNames.Remove(name);
                }
                selectedPublisherNamesBox.Text = string.Join(", ", selectedPublisherNames);
            }
        }
    }
}