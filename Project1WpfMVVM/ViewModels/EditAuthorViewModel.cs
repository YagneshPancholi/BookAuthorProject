using Project1WpfMVVM.Commands;
using Project1WpfMVVM.Models;
using Project1WpfMVVM.Services;
using Project1WpfMVVM.State.Navigators;
using System;
using System.Linq;
using System.Windows.Input;

namespace Project1WpfMVVM.ViewModels
{
    public class EditAuthorViewModel : ViewModelBase
    {
        private bool _isSubmitEnabled;

        public bool IsSubmitEnabled
        {
            get
            {
                return _isSubmitEnabled;
            }
            set
            {
                if (_author.authorName == null || _author.email == null || _author.education == null)
                {
                    _isSubmitEnabled = false;
                }
                _isSubmitEnabled = true;
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

        private readonly ICommand _editAuthorCommand;

        public ICommand EditAuthorCommand
        {
            get
            {
                return _editAuthorCommand;
            }
        }

        public EditAuthorViewModel(AuthorServiceWpf authorServiceWpf, INavigator navigator, string currentAuthorName)
        {
            authorServiceWpf.GetAuthor(currentAuthorName).ContinueWith(task =>
            {
                if (task != null)
                {
                    Author = task.Result;
                    IsSubmitEnabled = true;
                }
            });
            _navigator = navigator;

            _editAuthorCommand = new EditAuthorCommand(authorServiceWpf, navigator, currentAuthorName);
        }
    }
}