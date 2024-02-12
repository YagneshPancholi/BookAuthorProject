using Project1WpfMVVM.Services;
using Project1WpfMVVM.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project1WpfMVVM.Commands
{
    public class DeleteBookCommand : ICommand
    {
        private readonly BookServiceWpf _bookServiceWpf;
        private readonly INavigator _navigator;

        public DeleteBookCommand(BookServiceWpf bookServiceWpf, INavigator navigator)
        {
            _bookServiceWpf = bookServiceWpf;
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

        public void Execute(object? parameter)
        {
            string name = parameter.ToString();
            if (IsDeleteConfirmed(name))
            {
                _bookServiceWpf.DeleteBook(name).ContinueWith(x =>
                {
                    if (x.Result)
                    {
                        MessageBox.Show("Succesfully Deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        _navigator.UpdateCurrentViewModelCommand.Execute(ViewTypes.Books);
                    }
                });
            }
        }

        private bool IsDeleteConfirmed(string name)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show($"This Will Delete {name}.Are You Sure?", "Delete Book", MessageBoxButton.YesNo, MessageBoxImage.Warning);

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
    }
}