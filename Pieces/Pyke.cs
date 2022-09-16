

namespace Shogi
{
    class Pyke : FlippablePiece
    {
        public Pyke(CellColor color, bool IsFlipped = false) : base(IsFlipped)
        {
            if (color == CellColor.Empty) throw new System.Exception("a piece cannot have an empty color");
            if (color == CellColor.Black) _state = State.BlackPyke;
            else _state = State.WhitePyke;
            if (IsFlipped) _state++;
        }
        public override void ActivateCells(Board board, Cell position, bool isCalledInCheck)
        {
            if (!_isFlipped) PieceMovement.PykeActivateCells(board, position);
            else PieceMovement.GoldActivateCells(board, position);
            if (!isCalledInCheck) ActivationCheck(board, position);
        }
        public override void DropActivateCells(Board board, Reserve beatenPieces, Cell position)
        {
            base.DropActivateCells(board, beatenPieces, position);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (Color == CellColor.Black) board[8, i].Active = false;
                else board[0, i].Active = false;
            }
        }
        public override void OnCellActivation(Cell position)
        {
            if ((State >= State.WhiteKing && position.Coordinates.X > 1) || (State < State.WhiteKing && position.Coordinates.X < 7))
                base.OnCellActivation(position);
        }
        public override void OnMove(Cell piecePosition)
        {
            if ((State >= State.WhiteKing && piecePosition.Coordinates.X > 0) || (State < State.WhiteKing && piecePosition.Coordinates.X < 8))
                base.OnMove(piecePosition);
            else if (!_isFlipped)
            { 
                State++;
                _isFlipped = true;
            } 
        }
    }
}
