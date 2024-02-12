using Project1WpfMVVM.State.Navigators;

namespace Project1WpfMVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();

        public MainViewModel()
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewTypes.Home);
        }
    }
}