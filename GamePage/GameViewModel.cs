using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Shogi
{
    public class GameViewModel : NotifyPropertyChanged
    {
        private readonly GameModel _gameModel;
        private readonly Frame _mainFrame;
        public IEnumerable<char> Numbers => "123456789";
        public IEnumerable<char> Letters => "ihgfedcda";
        public Board Board 
        { 
            get => _gameModel.Board;
            set
            {
                _gameModel.Board = value;
                OnPropertyChanged();
            }
        }
        private Reserve Reserve
        {
            get => _gameModel.Reserve;
            set { _gameModel.Reserve = value; }
        }
        public Cell[] BlackReserve
        {
            get => Reserve.BlackReserve;
        }
        public Cell[] WhiteReserve
        {
            get => Reserve.WhiteReserve;
        }
        public bool IsGameOn
        {
            get => _gameModel.IsGameOn;
            set
            {
                _gameModel.IsGameOn = value;
                OnPropertyChanged(nameof(IsGameOn));
            }
        }
        public bool Turn
        {
            get => _gameModel.Turn;
            set
            {
                _gameModel.Turn = value;
                IsGameOn = !_gameModel.WinCheck();
                OnPropertyChanged(nameof(Turn));
            }
        }

        public GameViewModel(Frame mainFrame)
        {
            _gameModel = new();
            _mainFrame = mainFrame;
            //isOtherColorActivated = false;
        }

        public ICommand BoardCellCommand => new RelayCommand(parameter =>
        {
            if (!IsGameOn) return;
            Cell cell = (Cell)parameter;
            if (!cell.Active && cell.State == State.Empty) return;

            if (!cell.Active && ((cell.Color == CellColor.White && !Turn) || (cell.Color == CellColor.Black && Turn)))
            {
                Board.Deactivate();
                Reserve.Deactivate();
                cell.IsClicked = true;
                cell.Piece.ActivateCells(Board, cell, false);
            }
            else if (cell.Active)
            {
                Cell clickedCell;
                if (BlackReserve.FirstOrDefault(x => x.IsClicked) != null)
                    clickedCell = BlackReserve.FirstOrDefault(x => x.IsClicked);
                else if (WhiteReserve.FirstOrDefault(x => x.IsClicked) != null)
                    clickedCell = WhiteReserve.FirstOrDefault(x => x.IsClicked);
                else
                { 
                    clickedCell = Board.FirstOrDefault(x => x.IsClicked);
                    clickedCell.Piece.OnCellActivation(clickedCell);
                }
                    

                if (Board.FirstOrDefault(x => x.IsClicked) != null)
                    Board.Move(clickedCell, cell, Reserve);
                else Board.Move(clickedCell, cell);

                Board.Deactivate();
                Reserve.Deactivate();
                Turn = !Turn;
            }
        }, parameter => parameter is Cell);

        public ICommand BeatenPiecesCellCommand => new RelayCommand(parameter =>
        {
            if (!_gameModel.IsGameOn) return;
            Cell cell = (Cell)parameter;
            if ((cell.Color == CellColor.White && Turn) || (cell.Color == CellColor.Black && !Turn)) return;
            Board.Deactivate();
            Reserve.Deactivate();
            cell.Piece.DropActivateCells(Board, Reserve, cell);
            cell.IsClicked = true;
        },parameter => parameter is Cell);

        public ICommand NewGameCommand => new RelayCommand(
        parameter =>
        {
            if (File.Exists("Save\\board.json") && File.Exists("Save\\blackreserve.json") && 
                File.Exists("Save\\whitereserve.json") && File.Exists("Save\\turn.json") && 
                MessageBox.Show("В вас є збережена гра, хочете продовжити?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Board = new("Save\\board.json");
                Reserve.Erase();
                Reserve.WriteFromJson("Save\\whitereserve.json", "Save\\blackreserve.json");
                Turn = JsonSerializer.Deserialize<bool>(File.ReadAllText("Save\\turn.json"));
                _gameModel.IsGameWrittenFromFile = true;
                string messageText = "гра завантажена, продовжують ";
                if (Turn) messageText += "чорні";
                else messageText += "білі";
                MessageBox.Show(messageText);
            }
            else
            {
                Board = new();
                Reserve = new();
                Random rnd = new();
                int result = rnd.Next();
                Turn = !(result % 2 == 0);
                string messageText = "гра починається, починають ";
                if (Turn) messageText += "чорні";
                else messageText += "білі";
                MessageBox.Show(messageText);
            }
            _gameModel.IsGameOn = true;
        });

        public ICommand ChangeLanguage => new RelayCommand(parameter =>
        {
            foreach (Cell cell in Board)
            {
                if (cell.PieceLanguage == Language.Russian) cell.PieceLanguage++;
                else cell.PieceLanguage--;
            }
        });

        public ICommand BackToMenuCommand => new RelayCommand(parameter =>
        {
            if (IsGameOn && MessageBox.Show("Ви хочете зберегти гру?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                File.WriteAllText("Save\\board.json", JsonSerializer.Serialize(Board.Select(x => x.State).Cast<State>()));
                File.WriteAllText("Save\\blackreserve.json", JsonSerializer.Serialize(BlackReserve.Select(x => x.State).Cast<State>()));
                File.WriteAllText("Save\\whitereserve.json", JsonSerializer.Serialize(WhiteReserve.Select(x => x.State).Cast<State>()));
                File.WriteAllText("Save\\turn.json", JsonSerializer.Serialize(Turn));
            }
            _mainFrame.Content = new MenuPage(_mainFrame);
        });
        public ICommand ExitCommand => new RelayCommand(parameter =>
        {
            if (MessageBox.Show("Ви впевнені, що хочете вийти з гри?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        });

        //public ICommand ActivateOtherColorCommand => new RelayCommand(parameter =>
        //{
        //    if (isOtherColorActivated) _mainModel.Board.Deactivate();
        //    else
        //    {
        //        Cell[] otherColorPieces;
        //        if (Turn)
        //        {
        //            otherColorPieces = Board.Where(x => x.Color == "white").ToArray();
        //            Board.FirstOrDefault(x => x.State == State.BlackKing).IsClicked = true;
        //        }
        //        else
        //        {
        //            otherColorPieces = Board.Where(x => x.Color == "black").ToArray();
        //            Board.FirstOrDefault(x => x.State == State.WhiteKing).IsClicked = true;
        //        }
        //        foreach (var otherColor in otherColorPieces)
        //            otherColor.Piece.ActivateCells(Board, otherColor, true);
        //    }
        //    isOtherColorActivated = !isOtherColorActivated;
        //});
    }
}