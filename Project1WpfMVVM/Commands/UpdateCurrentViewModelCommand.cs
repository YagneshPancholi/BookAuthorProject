using Project1WpfMVVM.Services;
using Project1WpfMVVM.State.Navigators;
using Project1WpfMVVM.ViewModels;
using System;
using System.Windows.Input;

namespace Project1WpfMVVM.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly INavigator _navigator;
        private readonly AuthorServiceWpf _authorService;
        private readonly BookServiceWpf _bookService;
        private readonly GenreServiceWpf _genreService;
        private readonly PublisherServiceWpf _publisherService;

        public event EventHandler? CanExecuteChanged;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
            _authorService = new AuthorServiceWpf();
            _bookService = new BookServiceWpf();
            _genreService = new GenreServiceWpf();
            _publisherService = new PublisherServiceWpf();
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string currName = string.Empty;
            var tempParameter = parameter.ToString();
            if (tempParameter.Contains(","))
            {
                var tempArr = tempParameter.Split(",");
                if (tempArr[0].Contains("EditAuthor"))
                {
                    parameter = ViewTypes.EditAuthor;
                    currName = tempArr[1];
                }
                if (tempArr[0].Contains("EditBook"))
                {
                    parameter = ViewTypes.EditBook;
                    currName = tempArr[1];
                }
            }
            if (parameter is ViewTypes)
            {
                ViewTypes viewType = (ViewTypes)parameter;
                switch (viewType)
                {
                    case ViewTypes.Home:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;

                    case ViewTypes.Authors:
                        _navigator.CurrentViewModel = new AuthorsViewModel(_authorService, _navigator);
                        break;

                    case ViewTypes.Books:
                        _navigator.CurrentViewModel = new BooksViewModel(_bookService, _navigator);
                        break;

                    case ViewTypes.Genres:
                        _navigator.CurrentViewModel = new GenresViewModel(_genreService, _navigator);
                        break;

                    case ViewTypes.Publishers:
                        _navigator.CurrentViewModel = new PublishersViewModel();
                        break;

                    case ViewTypes.AddAuthor:
                        _navigator.CurrentViewModel = new AddAuthorViewModel(_authorService, _navigator);
                        break;

                    case ViewTypes.EditAuthor:
                        _navigator.CurrentViewModel = new EditAuthorViewModel(_authorService, _navigator, currName);
                        break;

                    case ViewTypes.AddBook:
                        _navigator.CurrentViewModel = new AddBookViewModel(_bookService, _navigator, _authorService, _genreService, _publisherService);
                        break;

                    case ViewTypes.EditBook:
                        _navigator.CurrentViewModel = new EditBookViewModel(_bookService, _navigator, currName, _authorService, _genreService, _publisherService);
                        break;
                }
            }
        }
    }
}