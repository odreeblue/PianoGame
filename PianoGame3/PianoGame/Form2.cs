using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;//추가
using System.Data.SqlClient;
namespace PianoGame
{
    public partial class Form2 : Form
    {
        
        int song_case;
        //int difficulty;
        int nCount;
        
        List<Button> buttons = new List<Button>();

        int[][] airplane;
        int[] airplane_not999 = new int[33];

        int[][] butterfly;
        int[] butterfly_not999 = new int[73];

        int[][] schoolbell;
        int[] schoolbell_not999 = new int[31];
        
        
        public Form2()
        {
            this.KeyPreview = true;
            InitializeComponent();
            nCount = 0;
            #region AddButton
            buttons.Add(b0);
            buttons.Add(b1);
            buttons.Add(b2);
            buttons.Add(b3);
            buttons.Add(b4);
            buttons.Add(b5);
            buttons.Add(b6);
            buttons.Add(b7);
            buttons.Add(b8);
            buttons.Add(b9);
            buttons.Add(b10);
            buttons.Add(b11);
            buttons.Add(b12);
            buttons.Add(b13);
            buttons.Add(b14);
            buttons.Add(b15);
            buttons.Add(b16);
            buttons.Add(b17);
            buttons.Add(b18);
            buttons.Add(b19);
            buttons.Add(b20);
            buttons.Add(b21);
            buttons.Add(b22);
            buttons.Add(b23);
            buttons.Add(b24);
            buttons.Add(b25);
            buttons.Add(b26);
            buttons.Add(b27);
            buttons.Add(b28);
            buttons.Add(b29);
            buttons.Add(b30);
            buttons.Add(b31);
            buttons.Add(b32);
            buttons.Add(b33);
            buttons.Add(b34);
            buttons.Add(b35);
            buttons.Add(b36);
            buttons.Add(b37);
            buttons.Add(b38);
            buttons.Add(b39);
            #endregion

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Form1에서 어떤 노래 선택되었는지 가져오기
            Form1 MainForm = (Form1)Owner;

            //노래
            if (MainForm.WhatSong == "비행기")
            {
                this.song_case = 1;
            }
            else if(MainForm.WhatSong == "나비야")
            {
                this.song_case = 2;
            }
            else if(MainForm.WhatSong == "학교종")
            {
                this.song_case = 3;
            }
            else
            {
                MessageBox.Show("동요를 선택해주세요");
                Close();
            }
            //난이도
            if (MainForm.Difficulty == "상")
            {
                this.timer1.Interval = 500;
            }
            else if (MainForm.Difficulty == "중")
            {
                this.timer1.Interval = 750;
            }
            else if (MainForm.Difficulty == "하")
            {
                this.timer1.Interval = 1000;
            }
            else
            {
                MessageBox.Show("난이도를 선택해주세요");
                Close();
            }
            //this.timer1.Interval = this.difficulty;
            //선택된 동요를 SQL 데이터에서 가져오기
            SqlDataLoad(this.song_case);


        }
        private void SqlDataLoad(int song_case)
        {
            int AirCount = 0;//비행기 행 숫자
            int ButCount = 0;//나비야 행 숫자
            int SchCount = 0;//옹달샘 행 숫자
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=LAPTOP-XINNOS\\SQLEXPRESS;" +
                                        "uid=sa; pwd=1234;database=song; ";
            SqlDataAdapter adapter;
            DataSet ds;
            switch (song_case)
            {
                case 1:
                    airplane = new int[33][];
                    adapter = new SqlDataAdapter("SELECT * FROM dbo.airplane", conn);
                    ds = new DataSet();
                    adapter.Fill(ds, "airplane");
                    break;
                case 2:
                    butterfly = new int[73][];
                    adapter = new SqlDataAdapter("SELECT * FROM dbo.butterfly", conn);
                    ds = new DataSet();
                    adapter.Fill(ds, "butterfly");
                    break;
                case 3:
                    schoolbell = new int[31][];
                    adapter = new SqlDataAdapter("SELECT * FROM dbo.schoolbell", conn);
                    ds = new DataSet();
                    adapter.Fill(ds, "schoolbell");
                    break;
                default:
                    adapter = new SqlDataAdapter("SELECT * FROM dbo.airplane", conn);
                    ds = new DataSet();
                    adapter.Fill(ds, "airplane");
                    break;
            }
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string[] GetString = new string[5];
                int[] GetInt = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    GetString[i] = row[i].ToString();
                    GetInt[i] = Convert.ToInt32(GetString[i]);
                }

                if (song_case == 1)
                {
                    airplane[AirCount] = new int[] { GetInt[0], GetInt[1], GetInt[2], GetInt[3], GetInt[4] };
                    AirCount++;
                }
                else if (song_case == 2)
                {
                    butterfly[ButCount] = new int[] { GetInt[0], GetInt[1], GetInt[2], GetInt[3], GetInt[4] };
                    ButCount++;
                }
                else if (song_case == 3)
                {
                    schoolbell[SchCount] = new int[] { GetInt[0], GetInt[1], GetInt[2], GetInt[3], GetInt[4] };
                    SchCount++;
                }

            }
            switch (song_case)
            {
                case 1:
                    for (int i = 0; i < 33; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (airplane[i][j] == 999)
                            {
                                //만약에 i번째 time에서 j번째가 999라면
                                //j까지가 airplane_not999의 길이
                                airplane_not999[i] = j;
                                break;
                            }
                            if (j == 4 && airplane[i][j] != 999)
                            {
                                airplane_not999[i] = 5;
                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < 73; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (butterfly[i][j] == 999)
                            {
                                //만약에 i번째 time에서 j번째가 999라면
                                //j까지가 airplane_not999의 길이
                                butterfly_not999[i] = j;
                                break;
                            }
                            if (j == 4 && butterfly[i][j] != 999)
                            {
                                butterfly_not999[i] = 5;
                            }
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < 31; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (schoolbell[i][j] == 999)
                            {
                                //만약에 i번째 time에서 j번째가 999라면
                                //j까지가 airplane_not999의 길이
                                schoolbell_not999[i] = j;
                                break;
                            }
                            if (j == 4 && schoolbell[i][j] != 999)
                            {
                                schoolbell_not999[i] = 5;
                            }
                        }
                    }
                    break;

            }

        }
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    btn_Do_Click(sender, e);
                    break;
                case Keys.S:
                    btn_Re_Click(sender, e);
                    break;
                case Keys.D:
                    btn_Mi_Click(sender, e);
                    break;
                case Keys.F:
                    btn_Pa_Click(sender, e);
                    break;
                case Keys.G:
                    btn_Sol_Click(sender, e);
                    break;
                case Keys.H:
                    btn_Ra_Click(sender, e);
                    break;
                case Keys.J:
                    btn_Si_Click(sender, e);
                    break;
                case Keys.K:
                    btn_DoUp_Click(sender, e);
                    break;
            }
        }

        private void btn_Do_Click(object sender, EventArgs e)
        {
            int score;
            Form1 MainForm = (Form1)Owner;
            score = Convert.ToInt32(MainForm.textBox1.Text);
            

            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources._25);
            simpleSound.Play();
            simpleSound.Dispose();
            if (b3.BackColor == Color.Black)
            {
                btn_Do.BackColor = Color.Yellow;
                score = score + 1;
                MainForm.getScore = score;
            }
            else if (b4.BackColor == Color.Black)
            {
                btn_Do.BackColor = Color.Blue;
                score = score + 2;
                MainForm.getScore = score;
            }
            else
            {
                btn_Do.BackColor = Color.Red;
                score = score - 1;
                MainForm.getScore = score;
            }
        }

        private void btn_Re_Click(object sender, EventArgs e)
        {
            int score;
            Form1 MainForm = (Form1)Owner;
            score = Convert.ToInt32(MainForm.textBox1.Text);
            //btn_Re.BackColor = Color.Red;

            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources._26);
            simpleSound.Play();
            simpleSound.Dispose();
            if (b8.BackColor == Color.Black)
            {
                btn_Re.BackColor = Color.Yellow;
                score = score + 1;
                MainForm.getScore = score;
            }
            else if (b9.BackColor == Color.Black)
            {
                btn_Re.BackColor = Color.Blue;
                score = score + 2;
                MainForm.getScore = score;
            }
            else
            {
                btn_Re.BackColor = Color.Red;
                score = score - 1;
                MainForm.getScore = score;
            }
        }

        private void btn_Mi_Click(object sender, EventArgs e)
        {
            int score;
            Form1 MainForm = (Form1)Owner;
            score = Convert.ToInt32(MainForm.textBox1.Text);
            //btn_Mi.BackColor = Color.Red;

            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources._27);
            simpleSound.Play();
            simpleSound.Dispose();
            if (b13.BackColor == Color.Black)
            {
                btn_Mi.BackColor = Color.Yellow;
                score = score + 1;
                MainForm.getScore = score;
            }
            else if (b14.BackColor == Color.Black)
            {
                btn_Mi.BackColor = Color.Blue;
                score = score + 2;
                MainForm.getScore = score;
            }
            else
            {
                btn_Mi.BackColor = Color.Red;
                score = score - 1;
                MainForm.getScore = score;
            }
        }

        private void btn_Pa_Click(object sender, EventArgs e)
        {
            int score;
            Form1 MainForm = (Form1)Owner;
            score = Convert.ToInt32(MainForm.textBox1.Text);
            //btn_Pa.BackColor = Color.Red;

            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources._28);
            simpleSound.Play();
            simpleSound.Dispose();
            if (b18.BackColor == Color.Black)
            {
                btn_Pa.BackColor = Color.Yellow;
                score = score + 1;
                MainForm.getScore = score;
            }
            else if (b19.BackColor == Color.Black)
            {
                btn_Pa.BackColor = Color.Blue;
                score = score + 2;
                MainForm.getScore = score;
            }
            else
            {
                btn_Pa.BackColor = Color.Red;
                score = score - 1;
                MainForm.getScore = score;
            }
        }

        private void btn_Sol_Click(object sender, EventArgs e)
        {
            int score;
            Form1 MainForm = (Form1)Owner;
            score = Convert.ToInt32(MainForm.textBox1.Text);
            //btn_Sol.BackColor = Color.Red;

            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources._29);
            simpleSound.Play();
            simpleSound.Dispose();
            if (b23.BackColor == Color.Black)
            {
                btn_Sol.BackColor = Color.Yellow;
                score = score + 1;
                MainForm.getScore = score;
            }
            else if (b24.BackColor == Color.Black)
            {
                btn_Sol.BackColor = Color.Blue;
                score = score + 2;
                MainForm.getScore = score;
            }
            else
            {
                btn_Sol.BackColor = Color.Red;
                score = score - 1;
                MainForm.getScore = score;
            }
        }

        private void btn_Ra_Click(object sender, EventArgs e)
        {
            int score;
            Form1 MainForm = (Form1)Owner;
            score = Convert.ToInt32(MainForm.textBox1.Text);
            //btn_Ra.BackColor = Color.Red;

            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources._30);
            simpleSound.Play();
            simpleSound.Dispose();
            if (b28.BackColor == Color.Black)
            {
                btn_Ra.BackColor = Color.Yellow;
                score = score + 1;
                MainForm.getScore = score;
            }
            else if (b29.BackColor == Color.Black)
            {
                btn_Ra.BackColor = Color.Blue;
                score = score + 2;
                MainForm.getScore = score;
            }
            else
            {
                btn_Ra.BackColor = Color.Red;
                score = score - 1;
                MainForm.getScore = score;
            }
        }

        private void btn_Si_Click(object sender, EventArgs e)
        {
            int score;
            Form1 MainForm = (Form1)Owner;
            score = Convert.ToInt32(MainForm.textBox1.Text);
            //btn_Si.BackColor = Color.Red;

            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources._31);
            simpleSound.Play();
            simpleSound.Dispose();
            if (b33.BackColor == Color.Black)
            {
                btn_Si.BackColor = Color.Yellow;
                score = score + 1;
                MainForm.getScore = score;
            }
            else if (b34.BackColor == Color.Black)
            {
                btn_Si.BackColor = Color.Blue;
                score = score + 2;
                MainForm.getScore = score;
            }
            else
            {
                btn_Si.BackColor = Color.Red;
                score = score - 1;
                MainForm.getScore = score;
            }
        }

        private void btn_DoUp_Click(object sender, EventArgs e)
        {
            int score;
            Form1 MainForm = (Form1)Owner;
            score = Convert.ToInt32(MainForm.textBox1.Text);
            //btn_DoUp.BackColor = Color.Red;

            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources._32);
            simpleSound.Play();
            simpleSound.Dispose();
            if (b38.BackColor == Color.Black)
            {
                btn_DoUp.BackColor = Color.Yellow;
                score = score + 1;
                MainForm.getScore = score;
            }
            else if (b39.BackColor == Color.Black)
            {
                btn_DoUp.BackColor = Color.Blue;
                score = score + 2;
                MainForm.getScore = score;
            }
            else
            {
                btn_DoUp.BackColor = Color.Red;
                score = score - 1;
                MainForm.getScore = score;
            }
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    btn_Do.BackColor = Color.White;
                    break;
                case Keys.S:
                    btn_Re.BackColor = Color.White;
                    break;
                case Keys.D:
                    btn_Mi.BackColor = Color.White;
                    break;
                case Keys.F:
                    btn_Pa.BackColor = Color.White;
                    break;
                case Keys.G:
                    btn_Sol.BackColor = Color.White;
                    break;
                case Keys.H:
                    btn_Ra.BackColor = Color.White;
                    break;
                case Keys.J:
                    btn_Si.BackColor = Color.White;
                    break;
                case Keys.K:
                    btn_DoUp.BackColor = Color.White;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch(song_case)
            {
                case 1:
                    if (nCount == 0)
                    {
                        int[] num = new int[airplane_not999[nCount]];
                        for (int i = 0; i < airplane_not999[nCount]; i++)
                        {
                            num[i] = airplane[nCount][i];
                        }
                        for (int i = 0; i < num.Length; i++)
                        {
                            buttons[num[i]].BackColor = Color.Black;
                        }
                        nCount++;
                    }
                    else
                    {
                        int[] num2 = new int[airplane_not999[nCount - 1]];
                        for (int i = 0; i < airplane_not999[nCount - 1]; i++)
                        {
                            num2[i] = airplane[nCount - 1][i];
                        }
                        for (int i = 0; i < num2.Length; i++)
                        {
                            buttons[num2[i]].BackColor = Color.White;
                        }
                        int[] num3 = new int[airplane_not999[nCount]];
                        for (int i = 0; i < airplane_not999[nCount]; i++)
                        {
                            num3[i] = airplane[nCount][i];
                        }
                        for (int i = 0; i < num3.Length; i++)
                        {
                            buttons[num3[i]].BackColor = Color.Black;
                        }
                        nCount++;
                    }

                    if (nCount > 32)
                    {
                        timer1.Stop();
                        nCount = 0;
                    }
                    break;
                case 2:
                    if (nCount == 0)
                    {
                        int[] num = new int[butterfly_not999[nCount]];
                        for (int i = 0; i < butterfly_not999[nCount]; i++)
                        {
                            num[i] = butterfly[nCount][i];
                        }
                        for (int i = 0; i < num.Length; i++)
                        {
                            buttons[num[i]].BackColor = Color.Black;
                        }
                        nCount++;
                    }
                    else
                    {
                        int[] num2 = new int[butterfly_not999[nCount - 1]];
                        for (int i = 0; i < butterfly_not999[nCount - 1]; i++)
                        {
                            num2[i] = butterfly[nCount - 1][i];
                        }
                        for (int i = 0; i < num2.Length; i++)
                        {
                            buttons[num2[i]].BackColor = Color.White;
                        }
                        int[] num3 = new int[butterfly_not999[nCount]];
                        for (int i = 0; i < butterfly_not999[nCount]; i++)
                        {
                            num3[i] = butterfly[nCount][i];
                        }
                        for (int i = 0; i < num3.Length; i++)
                        {
                            buttons[num3[i]].BackColor = Color.Black;
                        }
                        nCount++;
                    }

                    if (nCount > 72)
                    {
                        timer1.Stop();
                        nCount = 0;
                    }
                    break;
                case 3:
                    if (nCount == 0)
                    {
                        int[] num = new int[schoolbell_not999[nCount]];
                        for (int i = 0; i < schoolbell_not999[nCount]; i++)
                        {
                            num[i] = schoolbell[nCount][i];
                        }
                        for (int i = 0; i < num.Length; i++)
                        {
                            buttons[num[i]].BackColor = Color.Black;
                        }
                        nCount++;
                    }
                    else
                    {
                        int[] num2 = new int[schoolbell_not999[nCount - 1]];
                        for (int i = 0; i < schoolbell_not999[nCount - 1]; i++)
                        {
                            num2[i] = schoolbell[nCount - 1][i];
                        }
                        for (int i = 0; i < num2.Length; i++)
                        {
                            buttons[num2[i]].BackColor = Color.White;
                        }
                        int[] num3 = new int[schoolbell_not999[nCount]];
                        for (int i = 0; i < schoolbell_not999[nCount]; i++)
                        {
                            num3[i] = schoolbell[nCount][i];
                        }
                        for (int i = 0; i < num3.Length; i++)
                        {
                            buttons[num3[i]].BackColor = Color.Black;
                        }
                        nCount++;
                    }

                    if (nCount > 30)
                    {
                        timer1.Stop();
                        nCount = 0;
                    }
                    break;
            }
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

    }
}
