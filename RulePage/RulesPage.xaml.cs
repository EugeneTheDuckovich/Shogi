using System.Windows.Controls;

namespace Shogi
{
    /// <summary>
    /// Логика взаимодействия для RulesPage.xaml
    /// </summary>
    public partial class RulesPage : Page
    {
        public RulesPage(Frame mainFrame)
        {
            InitializeComponent();
            DataContext = new RulesViewModel(mainFrame, RulesFrame);
        }
    }
}
