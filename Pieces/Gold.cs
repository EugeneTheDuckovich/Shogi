

namespace Shogi
{
    class Gold : ShogiPiece
    {
        public Gold(CellColor color)
        {
            if (color == CellColor.Empty) throw new System.Exception("a piece cannot have an empty color");
            if (color == CellColor.Black) _state = State.BlackGold;
            else _state = State.WhiteGold;
        }
        public override void ActivateCells(Board board, Cell position, bool isCalledInCheck)
        {
            PieceMovement.GoldActivateCells(board, position);
            if(!isCalledInCheck) ActivationCheck(board, position);
        }
    }
}
