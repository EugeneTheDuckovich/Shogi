using System.Windows.Controls;

namespace Shogi
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage(Frame MainFrame)
        {
            InitializeComponent();
            DataContext = new GameViewModel(MainFrame);
        }
    }
}
