

namespace Shogi
{
    class Silver : FlippablePiece
    {
        public Silver(CellColor color, bool IsFlipped = false) : base(IsFlipped)
        {
            if (color == CellColor.Empty) throw new System.Exception("a piece cannot have an empty color");
            if (color == CellColor.Black) _state = State.BlackSilver;
            else _state = State.WhiteSilver;
            if (IsFlipped) _state++;
        }
        public override void ActivateCells(Board board, Cell position, bool isCalledInCheck)
        {
            if (_isFlipped) PieceMovement.GoldActivateCells(board, position);
            else PieceMovement.SilverActivateCells(board, position);
            if(!isCalledInCheck) ActivationCheck(board, position);
        }
    }
}
