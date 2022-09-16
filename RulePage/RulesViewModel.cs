using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Shogi.RulePage;

namespace Shogi
{
    class RulesViewModel
    {
        private readonly Frame _mainFrame;
        private readonly Frame _rulesFrame;
        public RulesViewModel(Frame mainFrame, Frame rulesFrame) 
        { 
            _mainFrame = mainFrame; 
            _rulesFrame = rulesFrame;
            _rulesFrame.Content = new CommonRulesPage();
        }

        public ICommand BackToMenuCommand => new RelayCommand(parameter =>
        {
            _mainFrame.Content = new MenuPage(_mainFrame);
        });
        public ICommand ExitCommand => new RelayCommand(parameter =>
        {
            if (MessageBox.Show("Ви впевнені, що хочете вийти з гри?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        });

        public ICommand GoToCommonRulesCommand => new RelayCommand(parameter =>
        {
            _rulesFrame.Content = new CommonRulesPage();
        });
        public ICommand GoToHowPiecesMoveCommand => new RelayCommand(parameter =>
        {
            _rulesFrame.Content = new HowPiecesMovePage();
        });
        public ICommand GoToMovementRulesCommand => new RelayCommand(parameter =>
        {
            _rulesFrame.Content = new MovementRulesPage();
        });
        public ICommand GoToTransformationRulesCommand => new RelayCommand(parameter =>
        {
            _rulesFrame.Content = new TransformationRulesPage();
        });
    }
}
