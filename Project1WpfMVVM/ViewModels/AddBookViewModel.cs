using Project1WpfMVVM.Commands;
using Project1WpfMVVM.Models;
using Project1WpfMVVM.Services;
using Project1WpfMVVM.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project1WpfMVVM.ViewModels
{
    public class AddBookViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;

        public INavigator Navigator
        {
            get
            {
                return _navigator;
            }
        }

        private ICommand _addBookCommand;

        public ICommand AddBookCommand
        {
            get
            {
                return _addBookCommand;
            }
        }

        private Book _book;

        public Book Book
        {
            get
            {
                return _book;
            }
            set
            {
                _book = value;
                OnPropertyChanged(nameof(Book));
                OnPropertyChanged(nameof(AddBookCommand));
            }
        }

        public List<string> AllAuthors { get; set; }
        public List<Author> AllAuthors2 { get; set; }
        public List<string> AllGenres { get; set; }
        public List<Genre> AllGenres2 { get; set; }
        public List<string> AllPublishers { get; set; }
        public List<Publisher> AllPublishers2 { get; set; }

        public AddBookViewModel(BookServiceWpf bookService, INavigator navigator, AuthorServiceWpf authorServiceWpf, GenreServiceWpf genreServiceWpf, PublisherServiceWpf publisherServiceWpf)
        {
            AllAuthors = new List<string>();
            AllAuthors2 = new List<Author>();
            AllGenres = new List<string>();
            AllGenres2 = new List<Genre>();
            AllPublishers = new List<string>();
            AllPublishers2 = new List<Publisher>();
            LoadAuthorNames(authorServiceWpf);
            LoadGenreNames(genreServiceWpf);
            LoadPublisherNames(publisherServiceWpf);
            _navigator = navigator;
            _book = new Book
            {
                bookName = "Enter Book Name",
                price = 50,
                authorNames = new List<string>(),
                genreNames = new List<string>(),
                publisherNames = new List<string>()
            };
            _addBookCommand = new AddBookCommand(navigator, bookService);
        }

        private void LoadAuthorNames(AuthorServiceWpf authorServiceWpf)
        {
            authorServiceWpf.GetAllAuthors().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    foreach (var author in task.Result)
                    {
                        AllAuthors2.Add(author);
                        AllAuthors.Add(author.authorName);
                    }
                }
            });
        }

        private void LoadGenreNames(GenreServiceWpf genreServiceWpf)
        {
            genreServiceWpf.GetAllGenres().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    foreach (var genre in task.Result)
                    {
                        AllGenres2.Add(genre);
                        AllGenres.Add(genre.genreName);
                    }
                }
            });
        }

        private void LoadPublisherNames(PublisherServiceWpf publisherServiceWpf)
        {
            publisherServiceWpf.GetAllPublishers().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    foreach (var publisher in task.Result)
                    {
                        AllPublishers2.Add(publisher);
                        AllPublishers.Add(publisher.publisherName);
                    }
                }
            });
        }
    }
}