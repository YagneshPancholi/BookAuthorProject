using Project1WpfMVVM.Commands;
using Project1WpfMVVM.Models;
using Project1WpfMVVM.Services;
using Project1WpfMVVM.State.Navigators;
using System.Collections.Generic;

namespace Project1WpfMVVM.ViewModels
{
    public class BooksViewModel : ViewModelBase
    {
        public readonly BookServiceWpf _bookServiceWpf;
        private readonly INavigator _navigator;
        private List<Book>? _books;

        public INavigator Navigator
        {
            get { return _navigator; }
        }

        public List<Book>? Books
        {
            get
            {
                return _books;
            }
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        public BooksViewModel(BookServiceWpf bookServiceWpf, INavigator navigator)
        {
            _bookServiceWpf = bookServiceWpf;
            _navigator = navigator;
            LoadBooks(bookServiceWpf);
        }

        private void LoadBooks(BookServiceWpf bookServiceWpf)
        {
            DeleteBookCommand deleteBookCommand = new DeleteBookCommand(bookServiceWpf, _navigator);
            EditBookCommand editBookCommand = new EditBookCommand(bookServiceWpf, _navigator, "");
            _bookServiceWpf.GetAllBooks().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    var tempBooks = new List<Book>();
                    foreach (var book in task.Result)
                    {
                        tempBooks.Add(new Book
                        {
                            bookName = book.bookName,
                            PriceStr = book.price.ToString(),
                            authorNames = book.authorNames,
                            genreNames = book.genreNames,
                            publisherNames = book.publisherNames,
                            DeleteBookCommand = deleteBookCommand,
                            EditBookCommand = editBookCommand
                        });
                    }
                    Books = tempBooks;
                }
            });
        }
    }
}