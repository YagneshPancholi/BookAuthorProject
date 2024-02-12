using Project1WpfMVVM.Models;
using Project1WpfMVVM.Services;
using Project1WpfMVVM.State.Navigators;
using System.Collections.Generic;

namespace Project1WpfMVVM.ViewModels
{
    public class GenresViewModel : ViewModelBase
    {
        private List<Genre>? _genres;
        private readonly GenreServiceWpf _genreService;

        public List<Genre>? Genres
        {
            get
            {
                return _genres;
            }
            set
            {
                _genres = value;
                OnPropertyChanged(nameof(Genres));
            }
        }

        public GenresViewModel(GenreServiceWpf genreService, INavigator navigator)
        {
            _genreService = genreService;
            LoadGenres();
        }

        private void LoadGenres()
        {
            _genreService.GetAllGenres().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Genres = task.Result;
                }
            });
        }
    }
}