using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _05_TicTacToeGame.Properties;

namespace _05_TicTacToeGame
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.White;
            Pen Pen = new Pen(White);

            Pen.Width = 20;
            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(Pen, 600, 120, 600, 700);
            e.Graphics.DrawLine(Pen, 800, 120, 800, 700);
            e.Graphics.DrawLine(Pen, 400, 300, 1000, 300);
            e.Graphics.DrawLine(Pen, 400, 500, 1000, 500);

        }

        enum enPlayers { ePlayer1 = 1, ePlayer2 = 2 };
        enPlayers PlayerTurn = enPlayers.ePlayer1;
        private void EndGame()
        {
            lblState.Text = "Game Ober";
            lblState.ForeColor = Color.Red;
            pb1.Enabled = false;
            pb2.Enabled = false;
            pb3.Enabled = false;
            pb4.Enabled = false;
            pb5.Enabled = false;
            pb6.Enabled = false;
            pb7.Enabled = false;
            pb8.Enabled = false;
            pb9.Enabled = false;
            MessageBox.Show("Game Over. To Raplay Click Restart Game Btn", "End", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private bool CheckPBValues(PictureBox Pb1, PictureBox Pb2, PictureBox Pb3)
        {
            if(Pb1.Tag.ToString() != "?" && Pb1.Tag.ToString() == Pb2.Tag.ToString()&& Pb1.Tag.ToString() == Pb3.Tag.ToString())
            {
                Pb1.BackColor = Color.Lime;
                Pb2.BackColor = Color.Lime;
                Pb3.BackColor = Color.Lime;
                if(Pb1.Tag.ToString() == "X")
                {
                    lblWinner.Text = "Player1";

                }else
                {
                    lblWinner.Text = "Player2";   
                }
                EndGame();
                return true;
            }else
            {
                lblState.Text = "In Progress...";
                return false;
            }
        }
        private  void CheckWinner()
        {
            if (CheckPBValues(pb1,pb2,pb3)) return;
            if (CheckPBValues(pb4,pb5,pb6)) return;
            if (CheckPBValues(pb7,pb8,pb9)) return;

            if (CheckPBValues(pb1, pb4, pb7)) return;
            if (CheckPBValues(pb2, pb5, pb8)) return;
            if (CheckPBValues(pb3, pb6, pb9)) return;

            if (CheckPBValues(pb1, pb5, pb9)) return;
            if (CheckPBValues(pb3, pb5, pb7)) return;
        }

        public void ChangeImage(PictureBox Pb)
        {
            if(Pb.Tag.ToString() =="?")
            {
                lblState.Text = "In Progress";
                switch(PlayerTurn)
                {
                    case enPlayers.ePlayer1:
                        lblPlayer.Text = "Player[2]";
                        Pb.Image = Resources.X_Image;
                        Pb.Tag = "X";
                        PlayerTurn = enPlayers.ePlayer2;
                        CheckWinner();

                        break;
                    case enPlayers.ePlayer2:
                        lblPlayer.Text = "Player[1]";
                        Pb.Image = Resources.O_Image;
                        Pb.Tag = "O";
                        PlayerTurn = enPlayers.ePlayer1;
                        CheckWinner();

                        break;
                }

            }else
            {
                MessageBox.Show("The Button Is Already Checked !", "Wrong!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ResetGameImages(PictureBox pb)
        {
            pb.Image = Resources.Qst_Image;
            pb.BackColor = Color.Black;
            pb.Tag = "?";
        }
        private void RestartGame()
        {
            pb1.Enabled = true;
            pb2.Enabled = true;
            pb3.Enabled = true;
            pb4.Enabled = true;
            pb5.Enabled = true;
            pb6.Enabled = true;
            pb7.Enabled = true;
            pb8.Enabled = true;
            pb9.Enabled = true;
            ResetGameImages(pb1);
            ResetGameImages(pb2);
            ResetGameImages(pb3);
            ResetGameImages(pb4);
            ResetGameImages(pb5);
            ResetGameImages(pb6);
            ResetGameImages(pb7);
            ResetGameImages(pb8);
            ResetGameImages(pb9);
            lblPlayer.Text = "Player1";
            lblState.Text = "In Start";
            lblState.ForeColor = Color.AntiqueWhite;
            lblWinner.Text = "...";
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            ChangeImage((PictureBox)sender);
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
