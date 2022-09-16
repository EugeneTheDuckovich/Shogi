using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shogi
{
    public static class PieceMovement
    {
        public static void PawnActivateCells(Board board, Cell position)
        {
            int X = position.Coordinates.X;
            int Y = position.Coordinates.Y;
            if (position.Color == CellColor.Black)
            {
                if (X < 8 && board[X + 1, Y].Color != position.Color)
                    board[X + 1, Y].Active = true;

            }
            else
            {
                if (X > 0 && board[X - 1, Y].Color != position.Color)
                    board[X - 1, Y].Active = true;
            }
        }

        public static void KnightActivateCells(Board board, Cell position)
        {
            int X = position.Coordinates.X;
            int Y = position.Coordinates.Y;
            if (position.Color == CellColor.Black)
            {
                if (X < 7 && Y < 8 && board[X + 2, Y + 1].Color != position.Color)
                {
                    board[X + 2, Y + 1].Active = true;
                }
                if (X < 7 && Y > 0 &&
                    board[X + 2, Y - 1].Color != position.Color)
                {
                    board[X + 2, Y - 1].Active = true;
                }
            }
            else
            {
                if (X > 1 && Y < 8 &&board[X - 2, Y + 1].Color != position.Color)
                {
                    board[X - 2, Y + 1].Active = true;
                }
                if (X > 1 && Y > 0 && board[X - 2, Y - 1].Color != position.Color)
                {
                    board[X - 2, Y - 1].Active = true;
                }
            }
        }

        public static void GoldActivateCells(Board board, Cell position)
        {
            int X = position.Coordinates.X;
            int Y = position.Coordinates.Y;
            if (X < 8 && board[X + 1, Y].Color != position.Color)
                board[X + 1, Y].Active = true;
            if (X > 0 && board[X - 1, Y].Color != position.Color)
                board[X - 1, Y].Active = true;
            if (Y < 8 && board[X, Y + 1].Color != position.Color)
                board[X, Y + 1].Active = true;
            if (Y > 0 && board[X, Y - 1].Color != position.Color)
                board[X, Y - 1].Active = true;
            if (position.Color == CellColor.Black)
            {
                if (X < 8 && Y < 8 && board[X + 1, Y + 1].Color != position.Color)
                    board[X + 1, Y + 1].Active = true;
                if (X < 8 && Y > 0 && board[X + 1, Y - 1].Color != position.Color)
                    board[X + 1, Y - 1].Active = true;
            }
            else
            {
                if (X > 0 && Y < 8 && board[X - 1, Y + 1].Color != position.Color)
                    board[X - 1, Y + 1].Active = true;
                if (X > 0 && Y > 0 && board[X - 1, Y - 1].Color != position.Color)
                    board[X - 1, Y - 1].Active = true;
            }
        }

        public static void SilverActivateCells(Board board, Cell position)
        {
            int X = position.Coordinates.X;
            int Y = position.Coordinates.Y;
            if (X < 8 && Y < 8 && board[X + 1, Y + 1].Color != position.Color)
                board[X + 1, Y + 1].Active = true;
            if (X > 0 && Y < 8 && board[X - 1, Y + 1].Color != position.Color)
                board[X - 1, Y + 1].Active = true;
            if (X < 8 && Y > 0 && board[X + 1, Y - 1].Color != position.Color)
                board[X + 1, Y - 1].Active = true;
            if (X > 0 && Y > 0 && board[X - 1, Y - 1].Color != position.Color)
                board[X - 1, Y - 1].Active = true;
            if (position.Color == CellColor.Black)
            {
                if (X < 8 && board[X + 1, Y].Color != position.Color)
                    board[X + 1, Y].Active = true;
            }
            else
            {
                if (X > 0 && board[X - 1, Y].Color != position.Color)
                    board[X - 1, Y].Active = true;
            }
        }

        public static void KingActivateCells(Board board, Cell position)
        {

            int X = position.Coordinates.X;
            int Y = position.Coordinates.Y;
            if (X < 8 && board[X + 1, Y].Color != position.Color)
                board[X + 1, Y].Active = true;
            if (X < 8 && Y < 8 && board[X + 1, Y + 1].Color != position.Color)
                board[X + 1, Y + 1].Active = true;
            if (Y < 8 && board[X, Y + 1].Color != position.Color)
                board[X, Y + 1].Active = true;
            if (X > 0 && Y < 8 && board[X - 1, Y + 1].Color != position.Color)
                board[X - 1, Y + 1].Active = true;
            if (X > 0 && board[X - 1, Y].Color != position.Color)
                board[X - 1, Y].Active = true;
            if (X > 0 && Y > 0 && board[X - 1, Y - 1].Color != position.Color)
                board[X - 1, Y - 1].Active = true;
            if (Y > 0 && board[X, Y - 1].Color != position.Color)
                board[X, Y - 1].Active = true;
            if (X < 8 && Y > 0 && board[X + 1, Y - 1].Color != position.Color)
                board[X + 1, Y - 1].Active = true;
        }

        public static void PykeActivateCells(Board board, Cell position)
        {
            int X = position.Coordinates.X;
            int Y = position.Coordinates.Y;
            if (position.Color == CellColor.Black)
            {
                for (int i = 1; X + i <= 8; i++)
                {
                    if (board[X + i, Y].Color == position.Color) break;
                        board[X + i, Y].Active = true;
                    if (board[X + i, Y].State != State.Empty) break;
                }
            }
            else
            {
                for (int i = 1; X >= i; i++)
                {
                    if (board[X - i, Y].Color == position.Color) break;
                        board[X - i, Y].Active = true;
                    if (board[X - i, Y].State!=State.Empty) break;
                }
            }
        }

        public static void RookActivateCells(Board board, Cell position)
        {
            int X = position.Coordinates.X;
            int Y = position.Coordinates.Y;
            for (int i = 1; X + i <= 8; i++)
            {
                if (board[X + i, Y].Color == position.Color) break;
                    board[X + i, Y].Active = true;
                if (board[X + i, Y].State != State.Empty) break;
            }
            for (int i = 1; position.Coordinates.X >= i; i++)
            {
                if (board[X - i, Y].Color == position.Color) break;
                    board[X - i, Y].Active = true;
                if (board[X - i, Y].State != State.Empty) break;
            }
            for (int i = 1; Y + i <= 8; i++)
            {
                if (board[X, Y + i].Color == position.Color) break;
                    board[X, Y + i].Active = true;
                if (board[X, Y + i].State != State.Empty) break;
            }
            for (int i = 1; Y >= i; i++)
            {
                if (board[X, Y - i].Color == position.Color) break;
                    board[X, Y - i].Active = true;
                if (board[X, Y - i].State != State.Empty) break;
            }
        }

        public static void BishopActivateCells(Board board, Cell position)
        {
            int X = position.Coordinates.X;
            int Y = position.Coordinates.Y;
            for (int i = 1; X + i <= 8 && Y + i <= 8; i++)
            {
                if (board[X + i, Y + i].Color == position.Color) break;
                    board[X + i, Y + i].Active = true;
                if (board[X + i, Y + i].State != State.Empty) break;
            }
            for (int i = 1; X + i <= 8 && Y >= i; i++)
            {
                if (board[X + i, Y - i].Color == position.Color) break;
                    board[X + i, Y - i].Active = true;
                if (board[X + i, Y - i].State != State.Empty) break;
            }
            for (int i = 1; X >= i && Y + i <= 8; i++)
            {
                if (board[X - i, Y + i].Color == position.Color) break;
                    board[X - i, Y + i].Active = true;
                if (board[X - i, Y + i].State != State.Empty) break;
            }
            for (int i = 1; X >= i && Y >= i; i++)
            {
                if (board[X - i, Y - i].Color == position.Color) break;
                    board[X - i, Y - i].Active = true;
                if (board[X - i, Y - i].State != State.Empty) break;
            }
        }
    }
}
