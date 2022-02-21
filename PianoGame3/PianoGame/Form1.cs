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
using System.Threading;

namespace PianoGame
{
    public partial class Form1 : Form
    {
        public string WhatSong;
        public string Difficulty;
        //Form2 SubForm;
        bool IsFormClosing = false;
        public Form1() // 생성자
        {
            
            InitializeComponent();
            //SubForm = new Form2();
            
        }
        // Start button
        private void F1Start_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            //무슨 노래인지
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                this.WhatSong = checkedListBox1.CheckedItems[0].ToString();
            }
            else
            {
                this.WhatSong = "메롱";
            }
            //어떤 난이도인지?
            if (listBox_difficulty.CheckedItems.Count != 0)
            {
                this.Difficulty = listBox_difficulty.CheckedItems[0].ToString();
            }
            else
            {
                this.Difficulty = "메롱";
            }


            Form2 Dlg = new Form2();
            Dlg.Owner = this;
            Dlg.Show();
            //Dlg.timer1.Interval = this.Difficulty;
            Dlg.timer1.Start();

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //체크 리스트 박스 한 아이템만 선택하도록 허용
            if (e.NewValue == CheckState.Checked)
            {
                CheckedListBox checkedListBox = sender as CheckedListBox; //캐스팅

                for (int count = 0; count < checkedListBox.Items.Count; ++count)
                {
                    if (e.Index != count) checkedListBox.SetItemChecked(count, false);
                }

            }
        }

        private void listBox_difficulty_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //체크 리스트 박스 한 아이템만 선택하도록 허용
            if (e.NewValue == CheckState.Checked)
            {
                CheckedListBox checkedListBox = sender as CheckedListBox; //캐스팅

                for (int count = 0; count < checkedListBox.Items.Count; ++count)
                {
                    if (e.Index != count) checkedListBox.SetItemChecked(count, false);
                }

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //while(true)
            //{
            //    Invalidate();
            //}
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Thread MainThread = Thread.CurrentThread;
            //MessageBox.Show("MainThread의 id는 {0}", MainThread.ManagedThreadId.ToString());
            Thread MyThread = new Thread(CheckScore);
            MyThread.IsBackground = true;
            //MessageBox.Show("MyThread의 id는 {0}",MyThread.ManagedThreadId.ToString());
            MyThread.Start();

        }

        public void CheckScore()
        {
            
            int initialScore = Convert.ToInt32(textBox1.Text);
            int afterScore = 0;
            while (true)
            {
                if (IsFormClosing == false)
                {
                    afterScore = Convert.ToInt32(textBox1.Text);
                    
                    if (afterScore != initialScore)
                    {
                        userControl11.score = afterScore;
                        userControl11.DoPaint();
                    }
                    initialScore = afterScore;
                }
                else
                {
                    this.Dispose();
                    break;
                }
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsFormClosing = true;
        }
    }
}
