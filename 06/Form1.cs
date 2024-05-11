using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("cisla.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            
            foreach (string radek in textBox1.Lines)
            {
                int cislo = int.Parse(radek);
                bw.Write(cislo);
            }

            bw.Close();
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("cisla.dat", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            BinaryWriter bw = new BinaryWriter(fs);

            int minPos = -1;
            int min = int.MaxValue;
            int maxPos = -1;
            int max = int.MinValue;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                int cislo = br.ReadInt32();

                if (cislo >= max)
                {
                    max = cislo;
                    maxPos = (int)br.BaseStream.Position - 4;
                }

                if (cislo <= min)
                {
                    min = cislo;
                    minPos = (int)br.BaseStream.Position - 4;
                }
            }

            fs.Seek(minPos, SeekOrigin.Begin);
            bw.Write(max);
            fs.Seek(maxPos, SeekOrigin.Begin);
            bw.Write(min);

            br.Close();
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("cisla.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            listBox1.Items.Clear();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                int cislo = br.ReadInt32();
                listBox1.Items.Add(cislo);
            }

            br.Close();
            fs.Close();
        }
    }
}
