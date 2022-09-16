using System.Windows;
using System.Windows.Controls;

namespace Shogi
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage(Frame mainFrame)
        {
            InitializeComponent();
            DataContext = new MenuViewModel(mainFrame);
        }
    }
}
