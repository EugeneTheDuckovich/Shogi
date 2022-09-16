using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System;
using System.IO;
using System.Text.Json;

namespace Shogi
{
    public class Board : IEnumerable<Cell>
    {
        private readonly Cell[,] Area;

        public Cell this[int row, int column]
        {
            get => Area[row, column];
        }

        public Board()
        {
            Area = new Cell[9, 9];
            for (int i = 0; i < Area.GetLength(0); i++)
                for (int j = 0; j < Area.GetLength(1); j++)
                    Area[i, j] = new Cell(new Point(i,j));

            for(int i = 0; i < Area.GetLength(0); i++)
            {
                Area[2, i].Piece = new Pawn(CellColor.Black);
                Area[6, i].Piece = new Pawn(CellColor.White);
            }

            Area[7, 1].Piece = new Bishop(CellColor.White);
            Area[1, 7].Piece = new Bishop(CellColor.Black);

            Area[1, 1].Piece = new Rook(CellColor.Black);
            Area[7, 7].Piece = new Rook(CellColor.White);

            Area[0, 0].Piece = new Pyke(CellColor.Black);
            Area[0, 8].Piece = new Pyke(CellColor.Black);
            Area[0, 1].Piece = new Knight(CellColor.Black);
            Area[0, 7].Piece = new Knight(CellColor.Black);
            Area[0, 2].Piece = new Silver(CellColor.Black);
            Area[0, 6].Piece = new Silver(CellColor.Black);
            Area[0, 3].Piece = new Gold(CellColor.Black);
            Area[0, 5].Piece = new Gold(CellColor.Black);
            Area[0, 4].Piece = new King(CellColor.Black);

            Area[8, 0].Piece = new Pyke(CellColor.White);
            Area[8, 8].Piece = new Pyke(CellColor.White);
            Area[8, 1].Piece = new Knight(CellColor.White);
            Area[8, 7].Piece = new Knight(CellColor.White);
            Area[8, 2].Piece = new Silver(CellColor.White);
            Area[8, 6].Piece = new Silver(CellColor.White);
            Area[8, 3].Piece = new Gold(CellColor.White);
            Area[8, 5].Piece = new Gold(CellColor.White);
            Area[8, 4].Piece = new King(CellColor.White);
        }

        public Board(Board board)
        {
            Area = new Cell[board.GetLength(0), board.GetLength(1)];
            for(int i = 0; i<Area.GetLength(0); i++)
            {
                for (int j = 0; j < Area.GetLength(1); j++)
                {
                    Area[i, j] = new Cell(board[i,j].Coordinates);
                    switch(board[i,j].State)
                    {
                        case State.BlackKing:
                        case State.WhiteKing:
                            Area[i, j].Piece = new King(board[i, j].Color);
                            break;
                        case State.BlackGold:
                        case State.WhiteGold:
                            Area[i, j].Piece = new Gold(board[i, j].Color);
                            break;
                        case State.BlackRook:
                        case State.WhiteRook:
                            Area[i, j].Piece = new Rook(board[i, j].Color);
                            break;
                        case State.BlackFlippedRook:
                        case State.WhiteFlippedRook:
                            Area[i, j].Piece = new Rook(board[i, j].Color, true);
                            break;
                        case State.BlackBishop:
                        case State.WhiteBishop:
                            Area[i, j].Piece = new Bishop(board[i, j].Color);
                            break;
                        case State.BlackFlippedBishop:
                        case State.WhiteFlippedBishop:
                            Area[i, j].Piece = new Bishop(board[i, j].Color, true);
                            break;
                        case State.BlackKnight:
                        case State.WhiteKnight:
                            Area[i, j].Piece = new Knight(board[i, j].Color);
                            break;
                        case State.BlackFlippedKnight:
                        case State.WhiteFlippedKnight:
                            Area[i, j].Piece = new Knight(board[i, j].Color, true);
                            break;
                        case State.BlackSilver:
                        case State.WhiteSilver:
                            Area[i, j].Piece = new Silver(board[i, j].Color);
                            break;
                        case State.BlackFlippedSilver:
                        case State.WhiteFlippedSilver:
                            Area[i, j].Piece = new Silver(board[i, j].Color, true);
                            break;
                        case State.BlackPyke:
                        case State.WhitePyke:
                            Area[i, j].Piece = new Pyke(board[i, j].Color);
                            break;
                        case State.BlackFlippedPyke:
                        case State.WhiteFlippedPyke:
                            Area[i, j].Piece = new Pyke(board[i, j].Color, true);
                            break;
                        case State.BlackPawn:
                        case State.WhitePawn:
                            Area[i, j].Piece = new Pawn(board[i, j].Color);
                            break;
                        case State.BlackFlippedPawn:
                        case State.WhiteFlippedPawn:
                            Area[i, j].Piece = new Pawn(board[i, j].Color, true);
                            break;
                    }
                }
            }
        }

        public Board(string FileName)
        {
            Area = new Cell[9, 9];
            State[] data = JsonSerializer.Deserialize<State[]>(File.ReadAllText(FileName));
            for (int i = 0; i < Area.GetLength(0); i++)
            {
                for (int j = 0; j < Area.GetLength(1); j++)
                {
                    Area[i, j] = new Cell(new Point(i,j));
                    switch (data[i*9 + j])
                    {
                        case State.BlackKing:
                            Area[i, j].Piece = new King(CellColor.Black);
                            break;
                        case State.WhiteKing:
                            Area[i, j].Piece = new King(CellColor.White);
                            break;
                        case State.BlackGold:
                            Area[i, j].Piece = new Gold(CellColor.Black);
                            break;
                        case State.WhiteGold:
                            Area[i, j].Piece = new Gold(CellColor.White);
                            break;
                        case State.BlackRook:
                            Area[i, j].Piece = new Rook(CellColor.Black);
                            break;
                        case State.WhiteRook:
                            Area[i, j].Piece = new Rook(CellColor.White);
                            break;
                        case State.BlackFlippedRook:
                            Area[i, j].Piece = new Rook(CellColor.Black, true);
                            break;
                        case State.WhiteFlippedRook:
                            Area[i, j].Piece = new Rook(CellColor.White, true);
                            break;
                        case State.BlackBishop:
                            Area[i, j].Piece = new Bishop(CellColor.Black);
                            break;
                        case State.WhiteBishop:
                            Area[i, j].Piece = new Bishop(CellColor.White);
                            break;
                        case State.BlackFlippedBishop:
                            Area[i, j].Piece = new Bishop(CellColor.Black, true);
                            break;
                        case State.WhiteFlippedBishop:
                            Area[i, j].Piece = new Bishop(CellColor.White, true);
                            break;
                        case State.BlackKnight:
                            Area[i, j].Piece = new Knight(CellColor.Black);
                            break;
                        case State.WhiteKnight:
                            Area[i, j].Piece = new Knight(CellColor.White);
                            break;
                        case State.BlackFlippedKnight:
                            Area[i, j].Piece = new Knight(CellColor.Black, true);
                            break;
                        case State.WhiteFlippedKnight:
                            Area[i, j].Piece = new Knight(CellColor.White, true);
                            break;
                        case State.BlackSilver:
                            Area[i, j].Piece = new Silver(CellColor.Black);
                            break;
                        case State.WhiteSilver:
                            Area[i, j].Piece = new Silver(CellColor.White);
                            break;
                        case State.BlackFlippedSilver:
                            Area[i, j].Piece = new Silver(CellColor.Black, true);
                            break;
                        case State.WhiteFlippedSilver:
                            Area[i, j].Piece = new Silver(CellColor.White, true);
                            break;
                        case State.BlackPyke:
                            Area[i, j].Piece = new Pyke(CellColor.Black);
                            break;
                        case State.WhitePyke:
                            Area[i, j].Piece = new Pyke(CellColor.White);
                            break;
                        case State.BlackFlippedPyke:
                            Area[i, j].Piece = new Pyke(CellColor.Black, true);
                            break;
                        case State.WhiteFlippedPyke:
                            Area[i, j].Piece = new Pyke(CellColor.White, true);
                            break;
                        case State.BlackPawn:
                            Area[i, j].Piece = new Pawn(CellColor.Black);
                            break;
                        case State.WhitePawn:
                            Area[i, j].Piece = new Pawn(CellColor.White);
                            break;
                        case State.BlackFlippedPawn:
                            Area[i, j].Piece = new Pawn(CellColor.Black, true);
                            break;
                        case State.WhiteFlippedPawn:
                            Area[i, j].Piece = new Pawn(CellColor.White, true);
                            break;
                    }
                }
            }
        }

        public void Deactivate()
        {
            foreach (Cell c in Area) 
            { 
                c.Active = false;
                c.IsClicked = false;
            }
        }

        public static void Move(Cell startingCell, Cell finishingCell, Reserve beatenPieces = null)
        {
            if (startingCell.Piece == null) throw new InvalidOperationException();
            
            if (beatenPieces != null)
            {
                if (finishingCell.Piece != null)
                {
                    finishingCell.Piece.OnBeat();
                    beatenPieces.Add(finishingCell.Piece);
                }
                startingCell.Piece.OnMove(finishingCell);
            }
            finishingCell.Piece = startingCell.Piece;
            startingCell.Piece = null;
        }

        public bool IsChecked(CellColor color)
        {
            Cell king;
            Cell[] otherColorPieces;
            Board copy = new(this);
            if(color == CellColor.Black)
            {
                king = copy.FirstOrDefault(x => x.State == State.BlackKing);
                otherColorPieces = copy.Where(x => x.Color == CellColor.White).ToArray();
            }
            else
            {
                king = copy.FirstOrDefault(x => x.State == State.WhiteKing);
                otherColorPieces = copy.Where(x => x.Color == CellColor.Black).ToArray();
            }
            bool result = false;
            foreach (Cell cell in otherColorPieces)
                cell.Piece.ActivateCells(copy, cell, true);
            return king.Active;
        }

        public bool MateCheck(CellColor color, Reserve reserve)
        {
            if (color == CellColor.Empty) throw new ArgumentException();
            if (!IsChecked(color)) return false;
            Cell[] allPieces;
            Board copy = new(this);
            if (color == CellColor.Black)
            {
                allPieces = copy.Where(x => x.Color == CellColor.Black).ToArray();
                foreach (var cell in reserve.BlackReserve.Where(x=>x.State!=State.Empty)) 
                    cell.Piece.DropActivateCells(copy, reserve, cell);
            }
            else
            {
                allPieces = copy.Where(x => x.Color == CellColor.White).ToArray();
                foreach (var cell in reserve.WhiteReserve.Where(x => x.State != State.Empty)) 
                    cell.Piece.DropActivateCells(copy, reserve, cell);
            }
            foreach (var cell in allPieces) cell.Piece.ActivateCells(copy, cell, false);
            return !copy.Any(x=>x.Active);            
        }

        public int GetLength(int dimention)
        {
            return Area.GetLength(dimention);
        }

        public IEnumerable<Cell> Cast()
        {
            return Area.Cast<Cell>();
        }

        public IEnumerator<Cell> GetEnumerator()
            => Area.Cast<Cell>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Area.GetEnumerator();
    }
}