﻿using System;
using System.Windows.Forms;

namespace Gomeku
{
    public partial class Form1 : Form
    {

        private Game game = new Game();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = game.CreatePiece(e.X, e.Y);
            if (piece != null)
            {
                this.Controls.Add(piece);
               
                // 检查是否有玩家获胜
                if (game.Winner == PieceType.BLACK)
                {
                    MessageBox.Show("黑色获胜");
                    RePlay();
                }
                else if (game.Winner == PieceType.WHITE)
                {
                    MessageBox.Show("白色获胜");
                    RePlay();
                }
            }
        }

        private void RePlay()
        {
            this.RemovePieces();
            game.InitGame();
        }


        // 移除所有的棋子
        private void RemovePieces()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Piece piece = game.board.PieceData[i, j];
                    if (piece != null)
                    {
                        this.Controls.Remove(piece);
                    }
                }
            }   
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
