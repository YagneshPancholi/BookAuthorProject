using Project1WpfMVVM.ViewModels;
using System.Windows.Input;

namespace Project1WpfMVVM.State.Navigators
{
    public enum ViewTypes
    {
        Home,
        Authors,
        AddAuthor,
        EditAuthor,
        Books,
        AddBook,
        EditBook,
        Genres,
        Publishers
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}