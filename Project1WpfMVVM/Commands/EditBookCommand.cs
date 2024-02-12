using Project1WpfMVVM.Models;
using Project1WpfMVVM.Services;
using Project1WpfMVVM.State.Navigators;
using System;
using System.Windows;
using System.Windows.Input;

namespace Project1WpfMVVM.Commands
{
    public class EditBookCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly string _currentBookName;
        private readonly INavigator _navigator;
        private readonly BookServiceWpf _bookServiceWpf;

        public string CurrentBookName
        { get { return _currentBookName; } }

        public INavigator Navigator
        { get { return _navigator; } }

        public EditBookCommand(BookServiceWpf bookServiceWpf, INavigator navigator, string currentBookName)
        {
            _bookServiceWpf = bookServiceWpf;
            _navigator = navigator;
            _currentBookName = currentBookName;
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is null)
            {
                return false;
            }
            if (parameter is Book)
            {
                Book request = (Book)parameter;

                if (request.bookName == string.Empty  || request.AuthorNamesStr == string.Empty || request.GenreNamesStr == string.Empty || request.PublisherNamesStr== string.Empty)
                {
                    MessageBox.Show("All Fields Are Required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if( request.price < 0)
                {
                    MessageBox.Show("Price Should Be Equal Or Greater Than Zero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }

        public void Execute(object? parameter)
        {
            if (_navigator.CurrentViewModel.ToString().Contains("BooksViewModel"))
            {
                _navigator.UpdateCurrentViewModelCommand.Execute(ViewTypes.EditBook + "," + parameter.ToString());
                return;
            }
            Book request = (Book)parameter;
            _bookServiceWpf.UpdateBook(CurrentBookName, request).ContinueWith(task =>
            {
                if (task.Result)
                {
                    MessageBox.Show("Successfully Updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Unsuccessfull Update Operation", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                _navigator.UpdateCurrentViewModelCommand.Execute(ViewTypes.Books);
            });
        }
    }
}