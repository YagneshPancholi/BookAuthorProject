using Project1WpfMVVM.Models;
using Project1WpfMVVM.Services;
using Project1WpfMVVM.State.Navigators;
using System;
using System.Windows;
using System.Windows.Input;

namespace Project1WpfMVVM.Commands
{
    public class AddAuthorCommand : ICommand
    {
        private readonly AuthorServiceWpf _authorService;
        private readonly INavigator _navigator;

        public event EventHandler? CanExecuteChanged;

        public AddAuthorCommand(AuthorServiceWpf authorService, INavigator navigator)
        {
            _authorService = authorService;
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is null)
            {
                return false;
            }
            if (parameter is Author)
            {
                Author request = (Author)parameter;
                if (request.authorName == string.Empty || request.email == string.Empty || request.education == string.Empty)
                {
                    MessageBox.Show("All Fields Are Required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                var tempDateFieldsArr = request.birthDate.Split("/");
                int month = Convert.ToInt32(tempDateFieldsArr[0]);
                int day = Convert.ToInt32(tempDateFieldsArr[1]);
                int year = Convert.ToInt32(tempDateFieldsArr[2].Split(" ")[0]);
                DateTime reqDate = new(year, month, day);
                if (reqDate > DateTime.Now)
                {
                    MessageBox.Show("BirthDate Can Not Be From Future", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }

        public void Execute(object? parameter)
        {
            Author request = (Author)parameter;
            _authorService.AddAuthor(request).ContinueWith(task =>
            {
                if (task.Result)
                {
                    MessageBox.Show("Successfully Added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Unsuccessfull Add Operation", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                _navigator.UpdateCurrentViewModelCommand.Execute(ViewTypes.Authors);
            });
        }
    }
}