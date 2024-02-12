using Project1WpfMVVM.Commands;
using Project1WpfMVVM.Models;
using Project1WpfMVVM.Services;
using Project1WpfMVVM.State.Navigators;
using System;
using System.Windows.Input;

namespace Project1WpfMVVM.ViewModels
{
    public class AddAuthorViewModel : ViewModelBase
    {
        private bool _isSubmitEnabled = false;

        public bool IsSubmitEnabled
        {
            get
            {
                return _isSubmitEnabled;
            }
            set
            {
                _isSubmitEnabled = value;
                OnPropertyChanged(nameof(IsSubmitEnabled));
            }
        }

        private Author _author;

        public Author Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        private readonly INavigator _navigator;

        public INavigator Navigator
        {
            get
            {
                return _navigator;
            }
        }

        private readonly ICommand _addAuthorCommand;

        public ICommand AddAuthorCommand
        {
            get
            {
                return _addAuthorCommand;
            }
        }

        public AddAuthorViewModel(AuthorServiceWpf authorServiceWpf, INavigator navigator)
        {
            _author = new Author
            {
                authorName = "Enter Author Name",
                birthDate = DateTime.Now.ToString("d"),
                email = "Enter Email",
                education = "Enter Education"
            };
            _navigator = navigator;
            _addAuthorCommand = new AddAuthorCommand(authorServiceWpf, navigator);
        }
    }
}