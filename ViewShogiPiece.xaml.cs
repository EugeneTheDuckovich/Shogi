using System.Windows;
using System.Windows.Controls;

namespace Shogi
{
    /// <summary>
    /// Логика взаимодействия для ViewShogiPiece.xaml
    /// </summary>
    public partial class ViewShogiPiece : UserControl
    {
        public static readonly DependencyProperty PieceProperty = DependencyProperty.Register("Piece", typeof(State), typeof(ViewShogiPiece));
        public static readonly DependencyProperty PieceLanguageProperty = DependencyProperty.Register("PieceLanguage", typeof(Language), typeof(ViewShogiPiece));
        public static readonly DependencyProperty PieceColorProperty = DependencyProperty.Register("PieceColor", typeof(CellColor), typeof(ViewShogiPiece));
        public State Piece
        {
            get => (State)GetValue(PieceProperty);
            set => SetValue(PieceProperty,value);
        }
        public bool PieceLanguage
        {
            get => (bool)GetValue(PieceLanguageProperty);
            set => SetValue(PieceLanguageProperty, value);
        }
        public CellColor PieceColor
        {
            get => (CellColor)GetValue(PieceColorProperty);
            set => SetValue(PieceColorProperty, value);
        }
        public ViewShogiPiece()
        {
            InitializeComponent();
        }
    }
}