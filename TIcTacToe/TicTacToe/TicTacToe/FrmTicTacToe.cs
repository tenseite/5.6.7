﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class FrmTicTacToe : Form
    {
        // подключаем наш игровой движок:
        private GameEngine engine = new GameEngine();
        // ... ранее написанный код формы ... 

        private void ButtonMouseEnter(Panel buttonPanel)
        {
            buttonPanel.BackColor = Color.Purple;
            Cursor = Cursors.Hand;
        }
        private void CellMouseOver(object sender)
        {
            if (sender is Panel)
            {
                Panel panelCell = (Panel)sender;
                panelCell.BackColor = Color.Purple;
                Cursor = Cursors.Hand;
            }
        }

        private void CellMouseOut(object sender)
        {
            if (sender is Panel)
            {
                Panel panelCell = (Panel)sender;
                panelCell.BackColor = Color.Indigo;
                Cursor = Cursors.Default;
            }
        }
        private void FillCell(Panel panel, int row, int column)
        {
            if (!engine.IsGameStarted())
            {
                // если игра не началась, не рисовать ничего на игровом поле и просто вернуться
                return;
            }

            Label markLabel = new Label();
            markLabel.Font = new Font(FontFamily.GenericMonospace, 72,
FontStyle.Bold);
            markLabel.AutoSize = true;
            markLabel.Text = engine.GetCurrentMarkLabelText();
            markLabel.ForeColor = engine.GetCurrentMarkLabelColor();

            labelWhooseTurn.Text = engine.GetWhooseNextTurnTitle();

            engine.MakeTurnAndFillGameFieldCell(row, column);

            panel.Controls.Add(markLabel);

            if (engine.IsWin())
            {
                // Движок вернул результат, что произошла победа одного из игроков
                MessageBox.Show("Победа! Выиграл " + engine.GetWinner(),
"Крестики-Нолики", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labelPlayer1Score.Text = engine.GetPlayer1Score().ToString();
                labelPlayer2Score.Text = engine.GetPlayer2Score().ToString();
                ClearGameField();
            }
            else if (engine.IsDraw())
            {
                // Движок вернул результат, что произошла ничья 
                MessageBox.Show("Ничья!", "Крестики-Нолики",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearGameField();
            }
            else
            {
                // Ещё остались свободные клетки на поле. Если ход компьютера - вызываем движок для определения клетки, которую
                // выберет комьютер для хода 
                if (engine.GetCurrentTurn() == GameEngine.WhooseTurn.Player2CPU)
                {
                    Cell cellChosenByCpu = engine.MakeComputerTurnAndGetCell();
                    if (!cellChosenByCpu.IsErrorCell())
                    {
                        Panel panelCell = GetPanelCellControlByCell(cellChosenByCpu);
                        if (panelCell != null)
                        {
                            FillCell(panelCell, cellChosenByCpu.Row,
cellChosenByCpu.Column);
                        }
                        else
                        {
                            // что-то пошло не так, мы не смогли найти верный элемент Panel по клетке, выбранной компьютером
                            // покажем ошибку 
                            MessageBox.Show(
                                "Произошла ошибка: выбранная компьютером клетка не должна быть равна null!", 
                                "Крестики-Нолики",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                    else
                    {
                        // что-то пошло не так, движок вернул спецклетку, хотя такого быть не должно. 
                        // покажем ошибку 
                        MessageBox.Show(
                            "Произошла ошибка: компьютер не смог выбрать клетку для хода!",  
                            "Крестики-Нолики",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }
        


        public FrmTicTacToe()
        {
            InitializeComponent();
        }
        private
void
RegularButtonMouseOver(Panel
panelButton,
Label
labelButtonText)
        {
            panelButton.BackColor = Color.Purple;
            labelButtonText.ForeColor = Color.Yellow;
            Cursor = Cursors.Hand;
        }
        private
        void
        RegularButtonMouseOut(Panel
        panelButton,
        Label
        labelButtonText)
        {
            panelButton.BackColor = Color.SlateBlue;
            labelButtonText.ForeColor = Color.Cyan;
            Cursor = Cursors.Default;
        }
        private void SetPlayersLabelsAndScoreVisible(bool visible)
        {
            labelPlayer1Name.Visible = visible;
            labelPlayer1Score.Visible = visible;
            labelPlayer2Name.Visible = visible;
            labelPlayer2Score.Visible = visible;
            labelNowTurnIs.Visible = visible;
            labelWhooseTurn.Visible = visible;

            panelNewGame.Visible = visible;
            panelReset.Visible = visible;
        }
        private Panel GetPanelCellControlByCell(Cell cell)
        {
            if (cell == null || !cell.IsValidGameFieldCell())
            {
                return null;
            }
            string panelCtrlName = "panelCell" + cell.Row + "_" + cell.Column;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name.Equals(panelCtrlName) && ctrl is Panel)
                {
                    return (Panel)ctrl;
                }
            }

            return null;
        }

        private void ClearGameField()
        {
            engine.ClearGameField();

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Panel panelCell = GetPanelCellControlByCell(Cell.From(row, col));
                    if (panelCell != null)
                    {
                        panelCell.Controls.Clear();
                    }
                }
            }

            engine.SetPlayer1HumanTurn();
            labelWhooseTurn.Text = engine.GetWhooseTurnTitle();
        }
        private void ResetGame()
        {
            ClearGameField();
            engine.StartGame(engine.GetCurrentMode());
            labelPlayer1Score.Text = engine.GetPlayer1Score().ToString();
            labelPlayer2Score.Text = engine.GetPlayer2Score().ToString();
            UpdateControls();

        }

        private void StartNewGame()
        {
            ClearGameField();
            engine.PrepareForNewGame();

            labelPlayer1Score.Text = engine.GetPlayer1Score().ToString();
            labelPlayer2Score.Text = engine.GetPlayer2Score().ToString();

            ShowMainMenu(true);
            SetPlayersLabelsAndScoreVisible(false);
        }
        private void StartNewGameInSelectedMode(GameEngine.GameMode
selectedMode)
        {
            engine.StartGame(selectedMode);
            UpdateControls();
        }





        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            StartNewGameInSelectedMode(GameEngine.GameMode.PlayerVsPlayer);
        }

        private void panelCloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelCloseButton_MouseEnter(object sender, EventArgs e)
        {
            ButtonMouseEnter(panelCloseButton);
        }

        private void panelCloseButton_MouseLeave(object sender, EventArgs e)
        {
            panelCloseButton.BackColor = Color.Indigo;
            Cursor = Cursors.Default;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            ButtonMouseEnter(panelCloseButton);
        }

        private void panelCell0_2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCell0_0_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCell0_1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCell1_0_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCell1_1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCell1_2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCell2_0_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCell2_1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCell2_2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelReset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void labelNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void panelNewGame_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelReset_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelNewGameTitle_Click(object sender, EventArgs e)
        {

        }

        private void labelPlayerVsCpu_Click(object sender, EventArgs e)
        {
            StartNewGameInSelectedMode(GameEngine.GameMode.PlayerVsCPU);
        }

        private void panelPlayerVsCpu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelPlayerVsPlayer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelPlayer1Name_Click(object sender, EventArgs e)
        {

        }

        private void labelPlayer2Score_Click(object sender, EventArgs e)
        {

        }

        private void labelNowTurnIs_Click(object sender, EventArgs e)
        {

        }

        private void labelWhooseTurn_Click(object sender, EventArgs e)
        {

        }

        private void panelCell0_0_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 0, 0);
        }

        private void panelCell0_0_MouseEnter(object sender, EventArgs e)
        {
            CellMouseOver(sender);
        }

        private void panelCell0_0_MouseLeave(object sender, EventArgs e)
        {
            CellMouseOut(sender);
        }

        private void panelCell0_1_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 0, 1);
        }

        private void panelCell0_1_MouseEnter(object sender, EventArgs e)
        {
            CellMouseOver(sender);
        }

        private void panelCell0_1_MouseLeave(object sender, EventArgs e)
        {
            CellMouseOut(sender);
        }

        private void panelCell0_2_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 0, 2);
        }

        private void panelCell0_2_MouseEnter(object sender, EventArgs e)
        {
            CellMouseOver(sender);
        }

        private void panelCell0_2_MouseLeave(object sender, EventArgs e)
        {
            CellMouseOut(sender);
        }

        private void panelCell1_0_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 1, 0);
        }

        private void panelCell1_0_MouseEnter(object sender, EventArgs e)
        {
            CellMouseOver(sender);
        }

        private void panelCell1_0_MouseLeave(object sender, EventArgs e)
        {
            CellMouseOut(sender);
        }

        private void panelCell1_1_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 1, 1);
        }

        private void panelCell1_1_MouseEnter(object sender, EventArgs e)
        {
            CellMouseOver(sender);
        }

        private void panelCell1_1_MouseLeave(object sender, EventArgs e)
        {
            CellMouseOut(sender);
        }

        private void panelCell1_2_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 1, 2);
        }

        private void panelCell1_2_MouseEnter(object sender, EventArgs e)
        {
            CellMouseOver(sender);
        }

        private void panelCell1_2_MouseLeave(object sender, EventArgs e)
        {
            CellMouseOut(sender);
        }

        private void panelCell2_0_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 2, 0);
        }

        private void panelCell2_0_MouseEnter(object sender, EventArgs e)
        {
            CellMouseOver(sender);
        }

        private void panelCell2_0_MouseLeave(object sender, EventArgs e)
        {
            CellMouseOut(sender);
        }

        private void panelCell2_1_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 2, 1);
        }

        private void panelCell2_1_MouseEnter(object sender, EventArgs e)
        {
            CellMouseOver(sender);
        }

        private void panelCell2_1_MouseLeave(object sender, EventArgs e)
        {
            CellMouseOut(sender);
        }

        private void panelCell2_2_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 2, 2);
        }

        private void panelCell2_2_MouseEnter(object sender, EventArgs e)
        {
            CellMouseOver(sender);
        }

        private void panelCell2_2_MouseLeave(object sender, EventArgs e)
        {
            CellMouseOut(sender);
        }

        private void panelPlayerVsCpu_Click(object sender, EventArgs e)
        {
            StartNewGameInSelectedMode(GameEngine.GameMode.PlayerVsCPU);
        }

        private void panelPlayerVsCpu_MouseEnter(object sender, EventArgs e)
        {
            RegularButtonMouseOver(panelPlayerVsCpu, labelPlayerVsCpu);
        }

        private void panelPlayerVsCpu_MouseLeave(object sender, EventArgs e)
        {
            RegularButtonMouseOut(panelPlayerVsCpu, labelPlayerVsCpu);
        }

        private void labelPlayerVsCpu_MouseEnter(object sender, EventArgs e)
        {
            RegularButtonMouseOver(panelPlayerVsCpu, labelPlayerVsCpu);
        }

        private void panelPlayerVsPlayer_Click(object sender, EventArgs e)
        {
            StartNewGameInSelectedMode(GameEngine.GameMode.PlayerVsPlayer);
        }

        private void panelPlayerVsPlayer_MouseEnter(object sender, EventArgs e)
        {
            RegularButtonMouseOver(panelPlayerVsPlayer, labelPlayerVsPlayer);
        }

        private void panelPlayerVsPlayer_MouseLeave(object sender, EventArgs e)
        {
            RegularButtonMouseOut(panelPlayerVsPlayer, labelPlayerVsPlayer);
        }

        private void labelPlayerVsPlayer_MouseEnter(object sender, EventArgs e)
        {
            RegularButtonMouseOver(panelPlayerVsPlayer, labelPlayerVsPlayer);
        }

        private void panelReset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void panelReset_MouseEnter(object sender, EventArgs e)
        {
            RegularButtonMouseOver(panelReset, labelReset);
        }

        private void panelReset_MouseLeave(object sender, EventArgs e)
        {
            RegularButtonMouseOut(panelReset, labelReset);
        }

        private void labelReset_MouseEnter(object sender, EventArgs e)
        {
            RegularButtonMouseOver(panelReset, labelReset);
        }

        private void panelNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void panelNewGame_MouseEnter(object sender, EventArgs e)
        {
            RegularButtonMouseOver(panelNewGame, labelNewGame);
        }

        private void panelNewGame_MouseLeave(object sender, EventArgs e)
        {
            RegularButtonMouseOut(panelNewGame, labelNewGame);
        }

        private void labelNewGame_MouseEnter(object sender, EventArgs e)
        {
            RegularButtonMouseOver(panelNewGame, labelNewGame);
        }

        private void FrmTicTacToe_Load(object sender, EventArgs e)
        {
            labelPlayer1Name.Text = "?";
            labelPlayer2Name.Text = "?";
            SetPlayersLabelsAndScoreVisible(false);

        }
        private void ShowMainMenu(bool show)
        {
            labelNewGameTitle.Visible = show;
            panelPlayerVsCpu.Visible = show;
            panelPlayerVsPlayer.Visible = show;
        }
        private void UpdateControls()
        {


            ShowMainMenu(false);

            labelPlayer1Name.Text = "Игрок 1"; // engine.GetCurrentPlayer1Title(); 
            labelPlayer2Name.Text = "Игрок 2"; // engine.GetCurrentPlayer2Title(); 
            labelWhooseTurn.Text = "Ход игрока N"; // engine.GetWhooseTurnTitle(); 

            labelPlayer1Name.Top = labelNewGameTitle.Top;
            labelPlayer1Score.Top = labelPlayer1Name.Top;
            labelPlayer2Name.Top = labelPlayer1Name.Top + 37;
            labelPlayer2Score.Top = labelPlayer2Name.Top;
            labelNowTurnIs.Top = labelPlayer2Name.Top + 37;
            labelWhooseTurn.Top = labelNowTurnIs.Top;

            panelNewGame.Left = labelNowTurnIs.Left + 30;
            panelNewGame.Top = labelNowTurnIs.Bottom + 15;

            panelReset.Left = panelNewGame.Right + 15;
            panelReset.Top = panelNewGame.Top;

            SetPlayersLabelsAndScoreVisible(true);

        }
    }
}
