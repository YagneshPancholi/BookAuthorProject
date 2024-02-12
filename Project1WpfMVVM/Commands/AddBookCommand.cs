using Project1WpfMVVM.Models;
using Project1WpfMVVM.Services;
using Project1WpfMVVM.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project1WpfMVVM.Commands
{
    public class AddBookCommand : ICommand
    {
        private readonly INavigator _navigator;
        private readonly BookServiceWpf _bookServiceWpf;
        int Count = 0;
        public AddBookCommand(INavigator navigator, BookServiceWpf bookServiceWpf)
        {
            _navigator = navigator;
            _bookServiceWpf = bookServiceWpf;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (parameter is null)
            {
                return false;
            }
            if (parameter is Book)
            {
                Book request = (Book)parameter;
                if (!request.bookName.Contains("Enter Book Name") || Count != 0)
                {
                    if(request.bookName.Contains("Enter Book Name") || request.bookName == string.Empty )
                    {
                        MessageBox.Show("Please Enter Book Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    if ( request.authorNames.Count == 0 || request.genreNames.Count == 0 || request.publisherNames.Count == 0)
                    {
                        MessageBox.Show("All Fields Are Required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    if (request.price < 0)
                    {
                        MessageBox.Show("Price Must Be Greate Than 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }else
                {
                    Count = 1;
                }
            }
            return true;
        }

        public void Execute(object? parameter)
        {
            Book request = (Book)parameter;
            _bookServiceWpf.AddBook(request).ContinueWith(task =>
            {
                if (task.Result)
                {
                    MessageBox.Show("Successfully Added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigator.UpdateCurrentViewModelCommand.Execute(ViewTypes.Books);
                }
                else
                {
                    MessageBox.Show("Unsuccessfull Add Operation", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}