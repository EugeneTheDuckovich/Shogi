
namespace Shogi
{
    public class King : ShogiPiece
    {
        public King(CellColor color) 
        {
            if (color == CellColor.Empty) throw new System.Exception("a piece cannot have an empty color");
            if (color == CellColor.Black) _state = State.BlackKing;
            else _state = State.WhiteKing;
        }
        public override void ActivateCells(Board board, Cell position, bool isCalledInCheck)
        {
            PieceMovement.KingActivateCells(board, position);
            if (!isCalledInCheck) ActivationCheck(board, position);
        }
    }
}
