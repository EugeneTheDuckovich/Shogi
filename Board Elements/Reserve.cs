using System.Linq;
using System.IO;
using System.Text.Json;

namespace Shogi
{
    public class Reserve : NotifyPropertyChanged
    {
        public Cell[] BlackReserve;
        public Cell[] WhiteReserve;
        public Reserve()
        {
            BlackReserve = new Cell[19];
            WhiteReserve = new Cell[19];
            OnPropertyChanged(nameof(BlackReserve));
            OnPropertyChanged(nameof(WhiteReserve));

            for (int i = 0; i < 19; i++)
            {
                BlackReserve[i] = new Cell(new System.Drawing.Point(-1,-1));
                WhiteReserve[i] = new Cell(new System.Drawing.Point(-1,-1));
            }
        }

        public void WriteFromJson(string WhiteFileName, string BlackFileName)
        {
            var whiteData = JsonSerializer.Deserialize<State[]>(File.ReadAllText(WhiteFileName));
            var blackData = JsonSerializer.Deserialize<State[]>(File.ReadAllText(BlackFileName));
            for (int i = 0; i < 19; i++)
            {
                switch (whiteData[i])
                {
                    case State.WhiteKing:
                        WhiteReserve[i].Piece = new King(CellColor.White);
                        break;
                    case State.WhiteGold:
                        WhiteReserve[i].Piece = new Gold(CellColor.White);
                        break;
                    case State.WhiteRook:
                        WhiteReserve[i].Piece = new Rook(CellColor.White);
                        break;
                    case State.WhiteFlippedRook:
                        WhiteReserve[i].Piece = new Rook(CellColor.White, true);
                        break;
                    case State.WhiteBishop:
                        WhiteReserve[i].Piece = new Bishop(CellColor.White);
                        break;
                    case State.WhiteFlippedBishop:
                        WhiteReserve[i].Piece = new Bishop(CellColor.White, true);
                        break;
                    case State.WhiteKnight:
                        WhiteReserve[i].Piece = new Knight(CellColor.White);
                        break;
                    case State.WhiteFlippedKnight:
                        WhiteReserve[i].Piece = new Knight(CellColor.White, true);
                        break;
                    case State.WhiteSilver:
                        WhiteReserve[i].Piece = new Silver(CellColor.White);
                        break;
                    case State.WhiteFlippedSilver:
                        WhiteReserve[i].Piece = new Silver(CellColor.White, true);
                        break;
                    case State.WhitePyke:
                        WhiteReserve[i].Piece = new Pyke(CellColor.White);
                        break;
                    case State.WhiteFlippedPyke:
                        WhiteReserve[i].Piece = new Pyke(CellColor.White, true);
                        break;
                    case State.WhitePawn:
                        WhiteReserve[i].Piece = new Pawn(CellColor.White);
                        break;
                    case State.WhiteFlippedPawn:
                        WhiteReserve[i].Piece = new Pawn(CellColor.White, true);
                        break;
                    default:
                        WhiteReserve[i].Piece = null;
                        break;
                }
                switch (blackData[i])
                {
                    case State.BlackKing:
                        BlackReserve[i].Piece = new King(CellColor.Black);
                        break;
                    case State.BlackGold:
                        BlackReserve[i].Piece = new Gold(CellColor.Black);
                        break;
                    case State.BlackRook:
                        BlackReserve[i].Piece = new Rook(CellColor.Black);
                        break;
                    case State.BlackFlippedRook:
                        BlackReserve[i].Piece = new Rook(CellColor.Black, true);
                        break;
                    case State.BlackBishop:
                        BlackReserve[i].Piece = new Bishop(CellColor.Black);
                        break;
                    case State.BlackFlippedBishop:
                        BlackReserve[i].Piece = new Bishop(CellColor.Black, true);
                        break;
                    case State.BlackKnight:
                        BlackReserve[i].Piece = new Knight(CellColor.Black);
                        break;
                    case State.BlackFlippedKnight:
                        BlackReserve[i].Piece = new Knight(CellColor.Black, true);
                        break;
                    case State.BlackSilver:
                        BlackReserve[i].Piece = new Silver(CellColor.Black);
                        break;
                    case State.BlackFlippedSilver:
                        BlackReserve[i].Piece = new Silver(CellColor.Black, true);
                        break;
                    case State.BlackPyke:
                        BlackReserve[i].Piece = new Pyke(CellColor.Black);
                        break;
                    case State.BlackFlippedPyke:
                        BlackReserve[i].Piece = new Pyke(CellColor.Black, true);
                        break;
                    case State.BlackPawn:
                        BlackReserve[i].Piece = new Pawn(CellColor.Black);
                        break;
                    case State.BlackFlippedPawn:
                        BlackReserve[i].Piece = new Pawn(CellColor.Black, true);
                        break;
                    default:
                        BlackReserve[i].Piece = null;
                        break;
                }
            }
        }

        public void Add(ShogiPiece piece)
        {
            if(piece.State >= State.WhiteKing)
            {
                for(int i = 0;i < WhiteReserve.Length;i++)
                {
                    if (WhiteReserve[i].State == State.Empty)
                    {
                        WhiteReserve[i].Piece = piece;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < BlackReserve.Length; i++)
                {
                    if (BlackReserve[i].State == State.Empty)
                    {
                        BlackReserve[i].Piece = piece;
                        break;
                    }
                }
            }
        }
        public void Deactivate()
        {
            if(BlackReserve.FirstOrDefault(x => x.IsClicked)!=null) 
                BlackReserve.FirstOrDefault(x => x.IsClicked).IsClicked = false;
            if(WhiteReserve.FirstOrDefault(x => x.IsClicked)!=null)
                WhiteReserve.FirstOrDefault(x => x.IsClicked).IsClicked = false;
        }
        public void Erase()
        {
            for (int i = 0; i < BlackReserve.Length; i++)
            {
                BlackReserve[i].Piece = null;
                WhiteReserve[i].Piece = null;
            }
        }
    }
}
