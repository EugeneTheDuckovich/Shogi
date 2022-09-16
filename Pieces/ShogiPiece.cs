using System.Linq;

namespace Shogi
{
    public enum State
    {
        Empty,
        BlackKing,
        BlackGold,
        BlackRook,
        BlackFlippedRook,
        BlackBishop,
        BlackFlippedBishop,
        BlackKnight,
        BlackFlippedKnight,
        BlackSilver,
        BlackFlippedSilver,
        BlackPyke,
        BlackFlippedPyke,
        BlackPawn,
        BlackFlippedPawn,
        WhiteKing,
        WhiteGold,
        WhiteRook,
        WhiteFlippedRook,
        WhiteBishop,
        WhiteFlippedBishop,
        WhiteKnight,
        WhiteFlippedKnight,
        WhiteSilver,
        WhiteFlippedSilver,
        WhitePyke,
        WhiteFlippedPyke,
        WhitePawn,
        WhiteFlippedPawn,
    }
    abstract public class ShogiPiece : NotifyPropertyChanged
    {
        protected State _state;
        public State State
        {
            get => _state; 
            protected set
            {
                _state = value;
                OnPropertyChanged(nameof(Color));
                OnPropertyChanged(nameof(State));
            }
        }
        // false - белая фигура, true - черная
        protected CellColor Color
        {
            get
            {
                if (_state < State.WhiteKing) return CellColor.Black;
                else return CellColor.White;
            }
        }

        public abstract void ActivateCells(Board board, Cell position, bool isCalledInCheck);

        public virtual void DropActivateCells(Board board, Reserve beatenPieces, Cell position)
        {
            foreach(Cell cell in board.Where(x => x.State == State.Empty)) cell.Active = true;
            ActivationCheck(board, position);
        }

        protected void ActivationCheck(Board board, Cell position)
        {
            foreach (Cell activeCell in board.Where(x => x.Active))
            {
                Board copy = new(board);
                int posX = position.Coordinates.X;
                int posY = position.Coordinates.Y;
                int actX = activeCell.Coordinates.X;
                int actY = activeCell.Coordinates.Y;
                if(posX == -1 && posY == -1) Board.Move(position, copy[actX, actY]);
                else Board.Move(copy[posX, posY], copy[actX, actY]);
                if (copy.IsChecked(Color))
                    activeCell.Active = false;
                if (posX == -1 && posY == -1) Board.Move(copy[actX, actY], position);
            }
        }

        public virtual void OnBeat() 
        {
            if (Color == CellColor.Black) State += 14;
            else State -= 14;
        }

        public virtual void OnCellActivation(Cell piecePosition) { }

        public virtual void OnMove(Cell piecePosition) { }
    }
}
