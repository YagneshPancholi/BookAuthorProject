using Project1WpfMVVM.Services;
using Project1WpfMVVM.State.Navigators;
using System;
using System.Windows;
using System.Windows.Input;

namespace Project1WpfMVVM.Commands
{
    public class DeleteAuthorCommand : ICommand
    {
        private readonly AuthorServiceWpf _authorService;
        private readonly INavigator _navigator;

        public DeleteAuthorCommand(AuthorServiceWpf authorService, INavigator navigator)
        {
            _authorService = authorService;
            _navigator = navigator;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (parameter is null)
            {
                return false;
            }
            return true;
        }

        private bool IsDeleteConfirmed(string authorName)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show($"This Will Delete {authorName}.Are You Sure?", "Delete Author", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public void Execute(object? parameter)
        {
            string AuthorName = parameter.ToString();
            if (IsDeleteConfirmed(AuthorName))
            {
                _authorService.DeleteAuthor(AuthorName).ContinueWith(x =>
                {
                    if (x.Result)
                    {
                        MessageBox.Show("Succesfully Deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        _navigator.UpdateCurrentViewModelCommand.Execute(ViewTypes.Authors);
                    }
                });
            }
        }
    }
}