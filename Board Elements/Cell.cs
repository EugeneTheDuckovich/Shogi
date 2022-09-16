using System.Drawing;

namespace Shogi
{
    public enum CellColor
    {
        Empty,
        White,
        Black
    }

    public enum Language
    {
        Russian,
        Japanise
    }


    public class Cell : NotifyPropertyChanged
    {
        private ShogiPiece _piece;
        private bool _active;
        private bool _isClicked;
        private Language _pieceLanguage;
        public readonly Point Coordinates;

        public State State // показывает, стоит ли на клетке фигура и какая фигура стоит
        {
            get
            {
                if (_piece == null) return State.Empty;
                return _piece.State;
            }
        }
        public Language PieceLanguage
        {
            get => _pieceLanguage;
            set
            {
                _pieceLanguage = value;
                OnPropertyChanged();
            }
        }
        public CellColor Color
        {
            get
            {
                if (State == State.Empty) return CellColor.Empty;
                else if (State < State.WhiteKing) return CellColor.Black;
                else return CellColor.White;
            }
        }
        public ShogiPiece Piece
        {
            get => _piece;
            set
            {
                _piece = value;
                OnPropertyChanged(nameof(Color));
                OnPropertyChanged(nameof(State));
            }
        }

        public bool Active
        {
            get => _active;
            set
            {
                _active = value;
                OnPropertyChanged();
            }
        }
        public bool IsClicked
        {
            get => _isClicked;
            set
            {
                _isClicked = value;
                OnPropertyChanged();
            }
        }
        public Cell(Point coordinates)
        {
            this.Coordinates = coordinates;
            PieceLanguage = Language.Russian;
        }
    }
}
