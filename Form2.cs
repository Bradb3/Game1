using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;


namespace Game1v2
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "plays.txt";
            if (!File.Exists(filepath))
            {
                File.CreateText(filepath);
                listBox1.Items.Add("No History");
            }
            else if (File.Exists(filepath))
            {
                List<string> lines = File.ReadAllLines(filepath).ToList();
                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');
                    listBox1.Items.Add("Game: " + entries[0] + " Player Name: " + entries[1] + " Start DateTime: " + entries[2] + " Timer Seconds Taken: " + entries[3] +" Total Time: " + entries[4] + " Result: "+ entries[5]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
