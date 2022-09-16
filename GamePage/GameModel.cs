using System;
using System.IO;
using System.Windows;

namespace Shogi
{
    public class GameModel
    {
        public Board Board;
        public Reserve Reserve;
        //true - партія йде
        public bool IsGameOn;
        //true - хід чорних, false - хід білих
        public bool Turn;
        //true - стан даної гри був завантажений з файлу та файли слід видалити при завершені гри
        public bool IsGameWrittenFromFile;
        
        public GameModel()
        {            
            Board = new();
            Reserve = new();
            IsGameOn = false;
            Random rnd = new();
            int result = rnd.Next();
            Turn = result % 2 == 0;
            IsGameWrittenFromFile = false;
        }

        //метод для перевірки на перемогу одного з гравців, викликається при кожній зміні значення змінної Turn
        public bool WinCheck()
        {
            if(!Turn && Board.MateCheck(CellColor.White, Reserve))
            {
                MessageBox.Show("Чорні перемогли!");
                if(IsGameWrittenFromFile)
                {
                    File.Delete("Save\\board.json");
                    File.Delete("Save\\whitereserve.json");
                    File.Delete("Save\\blackreserve.json");
                    File.Delete("Save\\turn.json");
                }
                return true;
            }
            if(Turn && Board.MateCheck(CellColor.Black, Reserve))
            {
                MessageBox.Show("Білі перемогли!");
                if (IsGameWrittenFromFile)
                {
                    File.Delete("Save\\board.json");
                    File.Delete("Save\\whitereserve.json");
                    File.Delete("Save\\blackreserve.json");
                    File.Delete("Save\\turn.json");
                }
                return true;
            }                     
            return false;
        }
    }
}
