using Project1WpfMVVM.Commands;
using Project1WpfMVVM.Models;
using Project1WpfMVVM.Services;
using Project1WpfMVVM.State.Navigators;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project1WpfMVVM.ViewModels
{
    public class EditBookViewModel : ViewModelBase
    {
        private INavigator _navigator;

        public INavigator Navigator
        {
            get
            {
                return _navigator;
            }
        }

        private Book _currentBook;

        public Book CurrentBook
        {
            get { return _currentBook; }
            set
            {
                if (_currentBook != value)
                {
                    _currentBook = value;
                }
            }
        }

        private ICommand _editBookCommand;

        public ICommand EditBookCommand
        {
            get
            {
                return _editBookCommand;
            }
        }

        public List<Author> AllAuthors2 { get; set; }
        public List<Genre> AllGenres2 { get; set; }
        public List<Publisher> AllPublishers2 { get; set; }

        public EditBookViewModel(BookServiceWpf bookService, INavigator navigator, string currName, AuthorServiceWpf authorServiceWpf, GenreServiceWpf genreServiceWpf, PublisherServiceWpf publisherServiceWpf)
        {
            bookService.GetBook(currName).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    CurrentBook = task.Result;
                }
            });
            AllAuthors2 = new List<Author>();
            AllGenres2 = new List<Genre>();
            AllPublishers2 = new List<Publisher>();
            authorServiceWpf.GetAllAuthors().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    AllAuthors2.AddRange(task.Result);
                }
            });
            genreServiceWpf.GetAllGenres().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    AllGenres2.AddRange(task.Result);
                }
            });
            publisherServiceWpf.GetAllPublishers().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    AllPublishers2.AddRange(task.Result);
                }
            });
            Thread.Sleep(100);
            _editBookCommand = new EditBookCommand(bookService, navigator, currName);
            _navigator = navigator;
        }
    }
}