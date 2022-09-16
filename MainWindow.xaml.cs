using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using Shogi;
using System.Linq;

namespace Soges
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        void Game_Closing(object sender, CancelEventArgs e)
        {
            if (MainFrame.Content.GetType() != typeof(GamePage)) return;
            var frame = (GamePage)MainFrame.Content;
            var viewmodel = (GameViewModel)frame.DataContext;
            if (viewmodel.IsGameOn && MessageBox.Show("Ви хочете зберегти гру?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                File.WriteAllText("Save\\board.json", JsonSerializer.Serialize(viewmodel.Board.Select(x=>x.State).Cast<State>()));
                File.WriteAllText("Save\\blackreserve.json", JsonSerializer.Serialize(viewmodel.BlackReserve.Select(x => x.State).Cast<State>()));
                File.WriteAllText("Save\\whitereserve.json", JsonSerializer.Serialize(viewmodel.WhiteReserve.Select(x => x.State).Cast<State>()));
                File.WriteAllText("Save\\turn.json", JsonSerializer.Serialize(viewmodel.Turn));
            }
        }

        void Window_Loaded(object sender, System.EventArgs e)
        {
            MainFrame.Content = new MenuPage(MainFrame);
        }
    }
}
