using Project1WpfMVVM.Models;
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
    public class EditAuthorCommand : ICommand
    {
        private readonly string _currentAuthorName;

        public string CurrentAuthorName
        {
            get
            {
                return _currentAuthorName;
            }
        }

        public readonly AuthorServiceWpf _authorService;

        private readonly INavigator _navigator;

        public INavigator Navigator
        { get { return _navigator; } }

        public EditAuthorCommand(AuthorServiceWpf authorService, INavigator navigator, string currentAuthorName)
        {
            _authorService = authorService;
            _navigator = navigator;
            _currentAuthorName = currentAuthorName;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (parameter is null)
            {
                return false;
            }
            if (parameter is Author)
            {
                Author request = (Author)parameter;
                var tempDateFieldsArr = request.birthDate.Split("/");
                int month = Convert.ToInt32(tempDateFieldsArr[0]);
                int day = Convert.ToInt32(tempDateFieldsArr[1]);
                int year = Convert.ToInt32(tempDateFieldsArr[2].Split(" ")[0]);

                DateTime reqDate = new(year, month, day);

                if (request.authorName == string.Empty || request.email == string.Empty || request.education == string.Empty)
                {
                    MessageBox.Show("All Fields Are Required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
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
            if (_navigator.CurrentViewModel.ToString().Contains("AuthorsViewModel"))
            {
                _navigator.UpdateCurrentViewModelCommand.Execute(ViewTypes.EditAuthor + "," + parameter.ToString());
                return;
            }
            Author request = (Author)parameter;
            _authorService.UpdateAuthor(CurrentAuthorName, request).ContinueWith(task =>
            {
                if (task.Result)
                {
                    MessageBox.Show("Successfully Updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Unsuccessfull Update Operation", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                _navigator.UpdateCurrentViewModelCommand.Execute(ViewTypes.Authors);
            });
        }
    }
}