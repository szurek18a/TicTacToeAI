using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

using System.Windows.Forms;
using static KolkoKrzyzykAI.MultiDimensionalArrayExtensions;

namespace KolkoKrzyzykAI
{

    public partial class Form2 : Form
    {
        int X1, Y1;
        int count = 0;
        int zapelnionaPlansza = 0;
        string nazwaGracza;
        string player;
        string opponent;
        Button b = new Button();
        Button[,] arrayBtn;
        bool wygranaGracza;
        bool wygranaPrzeciwnika;
        bool remis;
        bool ruchAI;
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        public Form2(int _X, int _Y, string _nick)
        {
            InitializeComponent();
            X1 = _X;
            Y1 = _Y;
            nazwaGracza = _nick;
            arrayBtn = new Button[X1, Y1];
            wygranaGracza = false;
            wygranaPrzeciwnika = false;
            remis = false;
            ruchAI = false;
            losujZnak();
            RysujPlansze();
            czyjRuch();
            InitTimer();
        }
        private void InitTimer()
        {
            timer1.Interval = 500;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ruchAI == true)
                bestMove();            
        }

        private void RysujPlansze()
        {
            for (int row = 0; row < X1; row++)
            {
                for (int col = 0; col < Y1; col++)
                {
                    b = new Button();
                    b.Click += new EventHandler(button_Click);
                    b.Size = new Size(50, 50);
                    b.Location = new Point(55 * (col + 1), 55 * row);
                    b.Font = new Font(Button.DefaultFont.FontFamily, 20);
                    Controls.Add(b);
                    arrayBtn[row, col] = b;
                }
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Licznik" + count);
            b = sender as Button;
            if (b.Text == "")
            {
                if (count % 2 == 0)
                {
                    b.Text = player;
                }
                count++;
                czyWygrana();
                czyjRuch();
                ruchAI = true;
                timer1.Start();
            }
        }

        private void losujZnak()
        {
            var random = new Random();
            var liczba = random.Next(0, 2);
            if (liczba == 0)
            {
                player = "X";
                opponent = "O";
            }
            else
            {
                player = "O";
                opponent = "X";
            }
            var liczba2 = random.Next(0, 2);
            count = liczba2;
            if (count == 1)
                ruchAI = true;
        }

        private void czyjRuch()
        {
            if (count % 2 == 0)
                labelKtoryGracz.Text = "Ruch gracza " + nazwaGracza + "     " + player;
            else
                labelKtoryGracz.Text = "Ruch przeciwnika " + "      " + opponent;
        }

        private int czyWygrana()
        {
            Func<Button, bool> playerWin = c => c.Text == player;
            Func<Button, bool> opponentWin = d => d.Text == opponent;

            wygranaGracza = false;
            wygranaPrzeciwnika = false;
            remis = false;
            zapelnionaPlansza = 0;

            for (int i = 0; i < X1; i++)
            {
                if (arrayBtn.Row(i).All(playerWin) == true)
                    wygranaGracza = true;

                if (arrayBtn.Column(i).All(playerWin) == true)
                    wygranaGracza = true;

                if (arrayBtn.Row(i).All(opponentWin) == true)
                    wygranaPrzeciwnika = true;

                if (arrayBtn.Column(i).All(opponentWin) == true)
                    wygranaPrzeciwnika = true;
            }

            if (arrayBtn.Diagonal(DiagonalDirection.DownRight).All(playerWin) == true)
                wygranaGracza = true;

            if (arrayBtn.Diagonal(DiagonalDirection.DownRight).All(opponentWin) == true)
                wygranaPrzeciwnika = true;

            if (arrayBtn.Diagonal(DiagonalDirection.DownLeft).All(playerWin) == true)
                wygranaGracza = true;

            if (arrayBtn.Diagonal(DiagonalDirection.DownLeft).All(opponentWin) == true)
                wygranaPrzeciwnika = true;

            for (int i = 0; i < X1; i++)
            {
                for (int j = 0; j < Y1; j++)
                {
                    if (arrayBtn[i, j].Text != "")
                    {
                        zapelnionaPlansza++;
                    }
                }
            }

            if (zapelnionaPlansza == X1 * Y1 && wygranaGracza == false && wygranaPrzeciwnika == false)
                remis = true;

            if (wygranaGracza == true || wygranaPrzeciwnika == true)
                if (ruchAI == false)
                    wygranaGra();

            if (wygranaGracza == true)
                return 1;


            if (wygranaPrzeciwnika == true)
                return -1;

            if (remis == true)
                if (ruchAI == false)
                    remisGra();
                else
                    return 0;

            return 2;
        }

        private void wygranaGra()
        {
            DialogResult result;
            if (count % 2 != 0)
                result = MessageBox.Show("Wygrana gracza " + nazwaGracza, "Koniec gry!");

            else
                result = MessageBox.Show("Wygrana przeciwnika", "Koniec gry!");

            if (result == DialogResult.OK)
                nowaGra();
        }

        private void remisGra()
        {
            DialogResult result;
            result = MessageBox.Show("Remis", "Koniec gry!");
            if (result == DialogResult.OK)
                nowaGra();
        }
        private void nowaGra()
        {
            timer1.Stop();
            wygranaGracza = false;
            wygranaPrzeciwnika = false;
            remis = false;
            count = 0;
            ruchAI = false;
            for (int i = X1 * Y1; i > 0; i--)
            {
                Controls.RemoveAt(i);
            }                   
            losujZnak();
            timer1.Start();
            RysujPlansze();
        }

        public void bestMove()
        {
            int bestScore = -1000;
            int moveI = 0;
            int moveJ = 0;

            for (int i = 0; i < X1; i++)
            {
                for (int j = 0; j < Y1; j++)
                {
                    if (arrayBtn[i, j].Text == "")
                    {
                        arrayBtn[i, j].Text = opponent;
                        int score = miniMax(arrayBtn, 0, false, i, j);
                        Console.WriteLine("Score" + score);
                        arrayBtn[i, j].Text = "";
                        if (score > bestScore)
                        {
                            moveI = i;
                            moveJ = j;
                            bestScore = score;
                        }

                    }
                }
            }
            ruchAI = false;
            count++;
            arrayBtn[moveI, moveJ].Text = opponent;
            timer1.Stop();
            czyWygrana();
            czyjRuch();
        }

        private int miniMax(Button[,] arrayBtn, int depth, bool isMaximizing, int row, int col)
        {
            int scoreMove = 0;

            if(X1 == 4 && depth > (count/2))
            {
                scoreMove += ocenRuch(col, row);
                return scoreMove;
            }

            if (X1 == 5 && depth > Math.Sqrt(count/2))
            {
                scoreMove += ocenRuch(col, row);
                return scoreMove;
            }
            
            if (X1 <= 3)
            {
                if (depth > count * 2)             
                    return 0;
            }


            int wynik = czyWygrana();
            if (wynik != 2)
            {
                if (wynik == 1)
                    return -10 + scoreMove; //Wygrana Gracza

                if (wynik == -1)
                    return 10 + scoreMove;  //Wygrana AI

                if (wynik == 0)
                    return 0 + scoreMove; //Nierozstrzygnięte
            }

            if (X1 != 3)
            {
                scoreMove += ocenRuch(row, col);
            }

            if (isMaximizing)
            {
                int bestScore = int.MinValue;
                for (int i = 0; i < X1; i++)
                {
                    for (int j = 0; j < Y1; j++)
                    {
                        if (arrayBtn[i, j].Text == "")
                        {
                            arrayBtn[i, j].Text = opponent;
                            bestScore = Math.Max(bestScore, miniMax(arrayBtn, depth + 1, !isMaximizing, i, j));
                            arrayBtn[i, j].Text = "";
                        }
                    }
                }

                return bestScore + scoreMove;
            }
            else
            {
                int bestScore = int.MaxValue;
                for (int i = 0; i < X1; i++)
                {
                    for (int j = 0; j < Y1; j++)
                    {
                        if (arrayBtn[i, j].Text == "")
                        {
                            arrayBtn[i, j].Text = player;
                            bestScore = Math.Min(bestScore, miniMax(arrayBtn, depth + 1, !isMaximizing, i, j));
                            arrayBtn[i, j].Text = "";
                        }
                    }
                }
                return bestScore + scoreMove;
            }
        }

        private int ocenRuch(int row, int col)
        {
            int points = 0;

            for (int i = 0; i < X1; i++) //Wiersze i kolumny
            {
                if (i != col)
                {
                    if (arrayBtn[row, i].Text == opponent)
                        points++;

                    if (arrayBtn[row, i].Text == player)
                        points--;
                }

                if (i != row)
                {
                    if (arrayBtn[i, col].Text == opponent)
                        points++;

                    if (arrayBtn[i, col].Text == player)
                        points--;
                }
            }

            for (int i = 0; i < X1; i++) //Pierwsza przekątna
            {
                for (int j = 0; j < Y1; j++)
                {
                    if (arrayBtn[i, j].Text == player)
                        points--;

                    if (arrayBtn[i, j].Text == opponent)
                        points++;
                }
            }

            for (int i = 0; i < X1; i++) //Druga przekątna
            {
                for (int j = Y1-1; j > 0; j--)
                {
                    if (arrayBtn[i, j].Text == player)
                        points--;

                    if (arrayBtn[i, j].Text == opponent)
                        points++;
                }
            }
            return points;
        }

    }


    public static class MultiDimensionalArrayExtensions
    {
        public static IEnumerable<T> Row<T>(this T[,] array, int row)
        {
            var columnLower = array.GetLowerBound(1);
            var columnUpper = array.GetUpperBound(1);

            for (int i = columnLower; i <= columnUpper; i++)
            {
                yield return array[row, i];
            }
        }

        public static IEnumerable<T> Column<T>(this T[,] array, int column)
        {
            var rowLower = array.GetLowerBound(0);
            var rowUpper = array.GetUpperBound(0);

            for (int i = rowLower; i <= rowUpper; i++)
            {
                yield return array[i, column];
            }
        }

        public static IEnumerable<T> Diagonal<T>(this T[,] array,
                                                 DiagonalDirection direction)
        {
            var rowLower = array.GetLowerBound(0);
            var rowUpper = array.GetUpperBound(0);
            var columnLower = array.GetLowerBound(1);
            var columnUpper = array.GetUpperBound(1);

            for (int row = rowLower, column = columnLower;
                 row <= rowUpper && column <= columnUpper;
                 row++, column++)
            {
                int realColumn = column;
                if (direction == DiagonalDirection.DownLeft)
                    realColumn = columnUpper - columnLower - column;

                yield return array[row, realColumn];
            }
        }

        public enum DiagonalDirection
        {
            DownRight,
            DownLeft
        }
    }
}
