using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Shogi
{
    class MenuViewModel
    {
        Frame _mainFrame;
        public MenuViewModel(Frame mainFrame) => _mainFrame = mainFrame;
        public ICommand StartGameCommand => new RelayCommand(parameter =>
        {
            _mainFrame.Content = new GamePage(_mainFrame);
        });
        public ICommand RulesCommand => new RelayCommand(parameter =>
        {
            _mainFrame.Content = new RulesPage(_mainFrame);
        });
        public ICommand ExitCommand => new RelayCommand(parameter =>
        {
            if(MessageBox.Show("Ви впевнені, що хочете вийти з гри?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes) 
                Application.Current.Shutdown();
        });
    }
}
