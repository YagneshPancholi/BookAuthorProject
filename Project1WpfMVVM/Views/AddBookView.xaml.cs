using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Project1WpfMVVM.Views
{
    /// <summary>
    /// Interaction logic for AddBookView.xaml
    /// </summary>
    public partial class AddBookView : UserControl
    {
        private List<string> selectedAuthorNames;
        private List<string> selectedGenreNames;
        private List<string> selectedPublisherNames;

        public AddBookView()
        {
            selectedAuthorNames = new List<string>();
            selectedGenreNames = new List<string>();
            selectedPublisherNames = new List<string>();
            InitializeComponent();
        }

        private void PreviewMouseDownEventToClearDefaultData(object sender, MouseButtonEventArgs e)
        {
            if (sender.ToString().Contains("Enter Book Name"))
            {
                BookName.Text = string.Empty;
            }
        }

        private void SelectAuthor(object sender, System.Windows.RoutedEventArgs e)
        {
            var data = (CheckBox)sender;
            if (data.Name.Equals("authorNameCheckBox"))
            {
                var name = data.Content.ToString();
                if (name != string.Empty)
                {
                    selectedAuthorNames.Add(name);
                }
                selectedAuthorNamesBox.Text = string.Join(", ", selectedAuthorNames);
            }
            else if (data.Name.Equals("genreNameCheckBox"))
            {
                var name = data.Content.ToString();
                if (name != string.Empty)
                {
                    selectedGenreNames.Add(name);
                }
                selectedGenreNamesBox.Text = string.Join(", ", selectedGenreNames);
            }
            else
            {
                var name = data.Content.ToString();
                if (name != string.Empty)
                {
                    selectedPublisherNames.Add(name);
                }
                selectedPublisherNamesBox.Text = string.Join(", ", selectedPublisherNames);
            }
        }

        private void UnselectAuthor(object sender, System.Windows.RoutedEventArgs e)
        {
            var data = (CheckBox)sender;
            if (data.Name.Equals("authorNameCheckBox"))
            {
                var name = data.Content.ToString();
                if (name != string.Empty)
                {
                    selectedAuthorNames.Remove(name);
                }
                selectedAuthorNamesBox.Text = string.Join(", ", selectedAuthorNames);
            }
            else if (data.Name.Equals("genreNameCheckBox"))
            {
                var name = data.Content.ToString();
                if (name != string.Empty)
                {
                    selectedGenreNames.Remove(name);
                }
                selectedGenreNamesBox.Text = string.Join(", ", selectedGenreNames);
            }
            else
            {
                var name = data.Content.ToString();
                if (name != string.Empty)
                {
                    selectedPublisherNames.Remove(name);
                }
                selectedPublisherNamesBox.Text = string.Join(", ", selectedPublisherNames);
            }
        }
    }
}