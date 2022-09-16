using System.Windows;

namespace Shogi
{
    public abstract class FlippablePiece : ShogiPiece
    {
        protected bool _isTransformDialogPopped;
        protected bool _isFlipped;

        public FlippablePiece(bool IsFlipped) 
        {
            _isTransformDialogPopped = false;
            _isFlipped = IsFlipped;
        }
        protected void TransformDialog(Cell piecePosition)
        {
            if (((piecePosition.Coordinates.X >= 6 && State < State.WhiteKing) || (piecePosition.Coordinates.X <= 2 && State >= State.WhiteKing))
                && !_isFlipped)
            {
                if (MessageBox.Show("Ви хочете перевтілити цю фигуру?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    State++;
                    _isFlipped = true;
                }
                _isTransformDialogPopped = true;
            }
        }

        public override void OnBeat()
        {
            base.OnBeat();
            if (_isFlipped)
            {
                --State;                
                _isFlipped = false;
            }
        }

        public override void OnCellActivation(Cell position)
        {
            TransformDialog(position);
        }

        public override void OnMove(Cell position)
        {
            if (!_isTransformDialogPopped) 
            {
                TransformDialog(position);
                _isTransformDialogPopped = false;
            } 
        }
    }
}
