using Project1WpfMVVM.Models;
using Project1WpfMVVM.Services;
using Project1WpfMVVM.Commands;
using System.Collections.Generic;
using Project1WpfMVVM.State.Navigators;

namespace Project1WpfMVVM.ViewModels
{
    public class AuthorsViewModel : ViewModelBase
    {
        public readonly AuthorServiceWpf _authorService;
        private readonly INavigator _navigator;
        private List<Author>? _authors;

        public INavigator Navigator
        {
            get { return _navigator; }
        }

        public List<Author>? Authors
        {
            get
            {
                return _authors;
            }
            set
            {
                _authors = value;
                OnPropertyChanged(nameof(Authors));
            }
        }

        public AuthorsViewModel(AuthorServiceWpf authorService, INavigator navigator)
        {
            _authorService = authorService;
            _navigator = navigator;
            LoadAuthors(authorService);
        }

        private void LoadAuthors(AuthorServiceWpf authorService)
        {
            DeleteAuthorCommand deleteAuthorCommand = new DeleteAuthorCommand(authorService, _navigator);
            _authorService.GetAllAuthors().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    var tempAuthors = new List<Author>();
                    foreach (var author in task.Result)
                    {
                        EditAuthorCommand editAuthorCommand = new EditAuthorCommand(authorService, _navigator, author.authorName);
                        tempAuthors.Add(new Author
                        {
                            authorName = author.authorName,
                            birthDate = author.birthDate.Split(" ")[0],
                            email = author.email,
                            education = author.education,
                            DeleteAuthorCommand = deleteAuthorCommand,
                            EditAuthorCommand = editAuthorCommand
                        });
                    }
                    Authors = tempAuthors;
                }
            });
        }
    }
}