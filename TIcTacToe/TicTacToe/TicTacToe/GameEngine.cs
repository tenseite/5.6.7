using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class GameEngine
    {
        internal enum GameMode
        {
            None,
            PlayerVsPlayer,
            PlayerVsCPU
        }

        internal enum WhooseTurn
        {
            Player1Human,
            Player2Human,
            Player2CPU
        }
                 private GameMode Mode { get; set; } = GameMode.None;
        private WhooseTurn Turn { get; set; } = WhooseTurn.Player1Human;
        private string Winner { get; set; } = "";
        private int player1Score = 0;
        private int player2Score = 0;
        private int numberOfDraws = 0;
        const char EMPTY_CELL = '-';
        const char X_MARK = 'X';
        const char O_MARK = 'O';

        public const string PLAYER_HUMAN_TITLE = "Игрок";
        public const string PLAYER_CPU_TITLE = "Компьютер";
        private char[][] gameField = new char[][] {
            new char[] { EMPTY_CELL, EMPTY_CELL, EMPTY_CELL },
            new char[] { EMPTY_CELL, EMPTY_CELL, EMPTY_CELL },
            new char[] { EMPTY_CELL, EMPTY_CELL, EMPTY_CELL } };
              public GameMode GetCurrentMode()
        {
            return Mode;
        }

        public bool IsGameStarted()
        {
            return Mode != GameMode.None;
        }

        public WhooseTurn GetCurrentTurn()
        {
            return Turn;
        }

        public string GetWinner()
        {
            return Winner;
        }

        public bool IsPlayer1HumanTurn()
        {
            return Turn == WhooseTurn.Player1Human;
        }

        public void SetPlayer1HumanTurn()
        {
            Turn = WhooseTurn.Player1Human;
        }

        public void ResetScore()
        {
            player1Score = 0;
            player2Score = 0;
            numberOfDraws = 0;
        }

        public void PrepareForNewGame()
        {
            Mode = GameMode.None;
            ResetScore();
        }
        public void StartGame(GameMode gameMode)
        {
            if (gameMode == GameMode.None)
            {
                return;
            }
            ResetScore();
            Mode = gameMode;
            Turn = WhooseTurn.Player1Human;
        }
            public string GetCurrentPlayer1Title()
        {
            switch (Mode)
            {
                case GameMode.PlayerVsCPU:
                    return PLAYER_HUMAN_TITLE;
                case GameMode.PlayerVsPlayer:
                    return PLAYER_HUMAN_TITLE + " 1";
            }
            return "";
        }

        public string GetCurrentPlayer2Title()
        {
            switch (Mode)
            {
                case GameMode.PlayerVsCPU:
                    return PLAYER_CPU_TITLE;
                case GameMode.PlayerVsPlayer:
                    return PLAYER_HUMAN_TITLE + " 2";
            }
            return "";
        }
        public string GetCurrentMarkLabelText()
        {
            if (IsPlayer1HumanTurn())
            {
                return X_MARK.ToString();
            }
            else
            {
                return O_MARK.ToString();
            }
        }
        public Color GetCurrentMarkLabelColor()
        {
            if (IsPlayer1HumanTurn())
            {
                return Color.Gold;
            }
            else
            {
                return Color.Fuchsia;
            }
        }
                  public int GetPlayer1Score()
        {
            return player1Score;
        }

        public int GetPlayer2Score()
        {
            return player2Score;
        }
                 /// <summary> 
                 /// Возвращает строку с именем игрока, чей ход в данный момент 
                 /// </summary> 
                 /// <returns>строка с именем игрока</returns> 
        public string GetWhooseTurnTitle()
        {
            switch (Mode)
            {
                case GameMode.PlayerVsCPU:
                    return Turn == WhooseTurn.Player1Human ?
PLAYER_HUMAN_TITLE : PLAYER_CPU_TITLE;
                case GameMode.PlayerVsPlayer:
                    return Turn == WhooseTurn.Player1Human ?
PLAYER_HUMAN_TITLE + " 1" : PLAYER_HUMAN_TITLE + " 2";
            }
            return "";
        }

        /// <summary> 
        /// Возвращает строку с именем игрока, для которого будет следующий ход
        /// </summary> 
        /// <returns>строка с именем игрока</returns> 
        public string GetWhooseNextTurnTitle()
        {
            switch (Mode)
            {
                case GameMode.PlayerVsCPU:
                    return Turn == WhooseTurn.Player1Human ? PLAYER_CPU_TITLE
: PLAYER_HUMAN_TITLE;
                case GameMode.PlayerVsPlayer:
                    return Turn == WhooseTurn.Player1Human ?
PLAYER_HUMAN_TITLE + " 2" : PLAYER_HUMAN_TITLE + " 1";
            }
            return "";
        }
              /// <summary> 
              /// Очищает игровое поле, заполняя каждую клетку признаком 
              /// пустой клетки (по умолчанию это символ '-') 
              /// </summary> 
        public void ClearGameField()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    gameField[row][col] = EMPTY_CELL;
                }
            }
        }

        public void MakeTurnAndFillGameFieldCell(int row, int column)
        {
            if (IsPlayer1HumanTurn())
            {
                gameField[row][column] = X_MARK;
                if (Mode == GameMode.PlayerVsCPU)
                {
                    Turn = WhooseTurn.Player2CPU;
                }
                else if (Mode == GameMode.PlayerVsPlayer)
                {
                    Turn = WhooseTurn.Player2Human;
                }
            }
            else
            {
                gameField[row][column] = O_MARK;
                Turn = WhooseTurn.Player1Human;
            }
        }
                   private Cell GetHorizontalCellForAttackOrDefence(char checkMark)
        {
            for (int row = 0; row < 3; row++)
            {
                int currentSumHorizontal = 0;
                int freeCol = -1;
                for (int col = 0; col < 3; col++)
                {
                    if (gameField[row][col] == EMPTY_CELL)
                    {
                        freeCol = col;
                    }
                    currentSumHorizontal += gameField[row][col] == checkMark ? 1 : 0;
                }

                if (currentSumHorizontal == 2 && freeCol >= 0)
                {
                    return Cell.From(row, freeCol);
                }
            }
            return Cell.ErrorCell();
        }

        private Cell GetVerticalCellForAttackOrDefence(char checkMark)
        {
            for (int col = 0; col < 3; col++)
            {
                int currentSumVert = 0;
                int freeRow = -1;
                for (int row = 0; row < 3; row++)
                {
                    if (gameField[row][col] == EMPTY_CELL)
                    {
                        freeRow = row;
                    }
                    currentSumVert += gameField[row][col] == checkMark ? 1 : 0;
                }

                if (currentSumVert == 2 && freeRow >= 0)
                {
                    return Cell.From(freeRow, col);
                }
            }
            return Cell.ErrorCell();
        }

        private Cell GetDiagonalCellForAttackOrDefence(char checkMark)
        {
            // диагональ 1: 
            // * - - 
            // - * - 
            // - - * 
            // координаты клеток: (0; 0), (1; 1), (2; 2) 
            // формула для вычисления столбца по ряду: <column> = row 

            // диагональ 2: 
            // - - * 
            // - * - 
            // * - - 
            // координаты клеток: (0; 2), (1; 1), (2, 0) 
            // формула для вычисления столбца по ряду: <column> = 2 - row 

            int diagonal1Sum = 0;
            int diagonal2Sum = 0;
            int freeCol1 = -1, freeRow1 = -1;
            int freeCol2 = -1, freeRow2 = -1;
            for (int row = 0; row < 3; row++)
            {
                diagonal1Sum += gameField[row][row] == checkMark ? 1 : 0;
                diagonal2Sum += gameField[row][2 - row] == checkMark ? 1 : 0;

                if (gameField[row][row] == EMPTY_CELL)
                {
                    freeCol1 = row;
                    freeRow1 = row;
                }
                if (gameField[row][2 - row] == EMPTY_CELL)
                {
                    freeCol2 = 2 - row;
                    freeRow2 = row;
                }

                if (diagonal1Sum == 2 && freeRow1 >= 0 && freeCol1 >= 0)
                {
                    return Cell.From(freeRow1, freeCol1);
                }
                else if (diagonal2Sum == 2 && freeRow2 >= 0 && freeCol2 >= 0)
                {
                    return Cell.From(freeRow2, freeCol2);
                }
            }

            return Cell.ErrorCell(); }
            private Cell ComputerTryAttackHorizontalCell()
        {
            return GetHorizontalCellForAttackOrDefence(O_MARK);
        }

        private Cell ComputerTryAttackVerticalCell()
        {
            return GetVerticalCellForAttackOrDefence(O_MARK);
        }

        private Cell ComputerTryAttackDiagonalCell()
        {
            return GetDiagonalCellForAttackOrDefence(O_MARK);
        }

        private Cell ComputerTryDefendHorizontalCell()
        {
            return GetHorizontalCellForAttackOrDefence(X_MARK);
        }

        private Cell ComputerTryDefendVerticalCell()
        {
            return GetVerticalCellForAttackOrDefence(X_MARK);
        }

        private Cell ComputerTryDefendDiagonalCell()
        {
            return GetDiagonalCellForAttackOrDefence(X_MARK);
        }

        private Cell ComputerTryAttackCell()
        {
            // Пытаемся атаковать по горизонтальным клеткам 
            Cell attackedHorizontalCell = ComputerTryAttackHorizontalCell();
            if (!attackedHorizontalCell.IsErrorCell())
            {
                return attackedHorizontalCell;
            }

            // Пытаемся атаковать по вертикальным клеткам 
            Cell attackedVerticalCell = ComputerTryAttackVerticalCell();
            if (!attackedVerticalCell.IsErrorCell())
            {
                return attackedVerticalCell;
            }

            // Пытаемся атаковать по диагональным клеткам 
            Cell attackedDiagonalCell = ComputerTryAttackDiagonalCell();
            if (!attackedDiagonalCell.IsErrorCell())
            {
                return attackedDiagonalCell;
            }

            // Нет приемлемых клеток для атаки - возвращаем спецклетку с признаком ошибки
            return Cell.ErrorCell();
        }

        private Cell ComputerTryDefendCell()
        {
            // Пытаемся защищаться по горизонтальным клеткам 
            Cell defendedHorizontalCell = ComputerTryDefendHorizontalCell();
            if (!defendedHorizontalCell.IsErrorCell())
            {
                return defendedHorizontalCell;
            }

            // Пытаемся защищаться по вертикальным клеткам 
            Cell defendedVerticalCell = ComputerTryDefendVerticalCell();
            if (!defendedVerticalCell.IsErrorCell())
            {
                return defendedVerticalCell;
            }

            // Пытаемся защищаться по диагональным клеткам 
            Cell defendedDiagonalCell = ComputerTryDefendDiagonalCell();
            if (!defendedDiagonalCell.IsErrorCell())
            {
                return defendedDiagonalCell;
            }

            // Нет приемлемых клеток для обороны - возвращаем спецклетку с признаком ошибки
            return Cell.ErrorCell();
        }
        private Cell ComputerTrySelectRandomFreeCell()
        {
            Random random = new Random();
            int randomRow, randomCol;
            const int max_attempts = 1000;  // кол-во попыток можно настроить по вкусу.чем больше, тем вероятнее может произойти подвисание, когда
                                            // свободных клеток на поле всё меньше, и рандомный перебор и поиск свободной не приносит быстрого результата
            int current_attempt = 0;
            do
            {
                randomRow = random.Next(3);
                randomCol = random.Next(3);
                current_attempt++;
            } while (gameField[randomRow][randomCol] != EMPTY_CELL &&
current_attempt <= max_attempts);

            if (current_attempt > max_attempts)
            {
                // мы не смогли выбрать рандомную свободную клетку за 1000 попыток, поэтому выбираем вручную
                // ближайшую клетку простым перебором по всем клеткам игрового поля
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (gameField[row][col] == EMPTY_CELL)
                        {
                            // клетка свободна, сразу возвращаем её 
                            return Cell.From(row, col);
                        }
                    }
                }
            }

            return Cell.From(randomRow, randomCol);
        }
            /// <summary> 
            /// Возвращает true, если есть хотя бы одна незанятая клетка на игровом поле и false в противном случае
            /// </summary> 
            /// <returns>true при наличии хотя бы одной свободной клетки на поле, иначе false </ returns >
        public bool IsAnyFreeCell()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (gameField[row][col] == EMPTY_CELL)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Cell MakeComputerTurnAndGetCell()
        {
            // Стратегия 1 - компьютер пытается сначала атаковать, если ему до победы остался всего лишь один ход
            Cell attackedCell = ComputerTryAttackCell();
            if (!attackedCell.IsErrorCell())
            {
                return attackedCell;
            }

            // Стратегия 2 - если нет приемлемых клеток для атаки, компьютер попытается найти клетки, которые нужно защитить, 
            // чтобы предотвратить победу человека 
            Cell defendedCell = ComputerTryDefendCell();
            if (!defendedCell.IsErrorCell())
            {
                return defendedCell;
            }

            // Стратегия 3 - у комьютера нет приемлемых клеток для атаки и защиты, поэтому ему нужно выбрать произвольную свободную клетку
            // для его очередного хода 
            if (IsAnyFreeCell())
            {
                Cell randomFreeCell = ComputerTrySelectRandomFreeCell();
                return randomFreeCell;
            }

            return Cell.ErrorCell();
        }
        /// <summary> 
        /// Возвращает true и увеличивает счётчик ничьих, если произошла очередная ничья.         
        /// </summary> 
        /// <returns>true, если произошла ничья, в противном случае false </ returns >
        public bool IsDraw()
        {
            bool isNoFreeCellsLeft = !IsAnyFreeCell();
            if (isNoFreeCellsLeft)
            {
                numberOfDraws++;
            }
            return isNoFreeCellsLeft; }
            /// <summary> 
            /// Проверяет наличие победы какого-либо из игроков по горизонтальным клеткам игрового поля
        /// </summary> 
        /// <returns></returns> 
        private bool CheckWinOnHorizontalCellsAndUpdateWinner()
        {
            for (int row = 0; row < 3; row++)
            {
                int sumX = 0; int sumO = 0;
                for (int col = 0; col < 3; col++)
                {
                    sumX += gameField[row][col] == X_MARK ? 1 : 0;
                    sumO += gameField[row][col] == O_MARK ? 1 : 0;
                }
                if (sumX == 3)
                {
                    // X победили 
                    Winner = Mode == GameMode.PlayerVsPlayer ?
PLAYER_HUMAN_TITLE + " 1" : PLAYER_HUMAN_TITLE;
                    player1Score++;
                    return true;
                }
                else if (sumO == 3)
                {
                    // O победили 
                    Winner = Mode == GameMode.PlayerVsPlayer ?
PLAYER_HUMAN_TITLE + " 2" : PLAYER_CPU_TITLE;
                    player2Score++;
                    return true;
                }
            }
            return false;
        }

        /// <summary> 
        /// Проверяет наличие победы какого-либо из игроков по вертикальным клеткам игрового поля
        /// </summary> 
        /// <returns></returns> 
        private bool CheckWinOnVerticalCellsAndUpdateWinner()
        {
            for (int col = 0; col < 3; col++)
            {
                int sumX = 0; int sumO = 0;
                for (int row = 0; row < 3; row++)
                {
                    sumX += gameField[row][col] == X_MARK ? 1 : 0;
                    sumO += gameField[row][col] == O_MARK ? 1 : 0;
                }

                if (sumX == 3)
                {
                    // X победили 
                    Winner = Mode == GameMode.PlayerVsPlayer ?
PLAYER_HUMAN_TITLE + " 1" : PLAYER_HUMAN_TITLE;
                    player1Score++;
                    return true;
                }
                else if (sumO == 3)
                {
                    // O победили 
                    Winner = Mode == GameMode.PlayerVsPlayer ?
PLAYER_HUMAN_TITLE + " 2" : PLAYER_CPU_TITLE;
                    player2Score++;
                    return true;
                }
            }
            return false;
        }

        /// <summary> 
        /// Проверяет наличие победы какого-либо из игроков по диагональным клеткам игрового поля
        /// </summary> 
        /// <returns></returns> 
        private bool CheckWinOnDiagonalCellsAndUpdateWinner()
        {
            int diag1sumX = 0, diag2sumX = 0;
            int diag1sumO = 0, diag2sumO = 0;
            for (int row = 0; row < 3; row++)
            {
                if (gameField[row][row] == O_MARK)
                {
                    diag1sumO++;
                }
                if (gameField[row][row] == X_MARK)
                {
                    diag1sumX++;
                }
                if (gameField[row][2 - row] == O_MARK)
                {
                    diag2sumO++;
                }
                if (gameField[row][2 - row] == X_MARK)
                {
                    diag2sumX++;
                }
            }

            if (diag1sumX == 3 || diag2sumX == 3)
            {
                Winner = Mode == GameMode.PlayerVsPlayer ?
PLAYER_HUMAN_TITLE + " 1" : PLAYER_HUMAN_TITLE;
                player1Score++;
                return true;
            }
            else if (diag1sumO == 3 || diag2sumO == 3)
            {
                Winner = Mode == GameMode.PlayerVsPlayer ?
PLAYER_HUMAN_TITLE + " 2" : PLAYER_CPU_TITLE;
                player2Score++;
                return true;
            }

            return false;
        }
             /// <summary> 
             /// Возвращает true, если кто-то из игроков выиграл 
             /// </summary> 
             /// <returns>true, если какой-то из игроков выиграл, иначе false</returns> 
        public bool IsWin()
        {
            if (CheckWinOnHorizontalCellsAndUpdateWinner())
            {
                return true;
            }

            if (CheckWinOnVerticalCellsAndUpdateWinner())
            {
                return true;
            }

            if (CheckWinOnDiagonalCellsAndUpdateWinner())
            {
                return true;
            }

            return false;
        }
    }
}
    
    
   














