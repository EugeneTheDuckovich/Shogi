

namespace Shogi
{
    public class Rook : FlippablePiece
    {
        public Rook(CellColor color, bool IsFlipped = false) : base(IsFlipped)
        {
            if (color == CellColor.Empty) throw new System.Exception("a piece cannot have an empty color");
            if (color == CellColor.Black) _state = State.BlackRook;
            else _state = State.WhiteRook;
            if (IsFlipped) _state++;
        }
        public override void ActivateCells(Board board, Cell position, bool isCalledInCheck)
        {
            if (_isFlipped) PieceMovement.KingActivateCells(board, position);
            PieceMovement.RookActivateCells(board, position);
            if (!isCalledInCheck) ActivationCheck(board, position);
        }
    }
}
