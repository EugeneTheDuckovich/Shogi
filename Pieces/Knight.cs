

namespace Shogi
{
    public class Knight : FlippablePiece
    {
        public Knight(CellColor color, bool IsFlipped = false) : base(IsFlipped)
        {
            if (color == CellColor.Empty) throw new System.Exception("a piece cannot have an empty color");
            if (color == CellColor.Black) _state = State.BlackKnight;
            else _state = State.WhiteKnight;
            if (IsFlipped) _state++;
        }
        public override void ActivateCells(Board board, Cell position, bool isCalledInCheck)
        {
            if (!_isFlipped) PieceMovement.KnightActivateCells(board, position);
            else PieceMovement.GoldActivateCells(board, position);
            if (!isCalledInCheck) ActivationCheck(board, position);
        }
        public override void DropActivateCells(Board board, Reserve beatenPieces, Cell position)
        {
            base.DropActivateCells(board, beatenPieces, position);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (Color == CellColor.Black)
                {
                    board[8, i].Active = false;
                    board[7, i].Active = false;
                }
                else
                {
                    board[0, i].Active = false;
                    board[1, i].Active = false;
                }
            }
        }
        public override void OnCellActivation(Cell position){}
        public override void OnMove(Cell position)
        {
            if ((State >= State.WhiteKing && position.Coordinates.X > 1) || (State < State.WhiteKing && position.Coordinates.X < 7))
                base.OnMove(position);
            else if (!_isFlipped)
            {
                State++;
                _isFlipped = true;
            }
        }
    }
}
