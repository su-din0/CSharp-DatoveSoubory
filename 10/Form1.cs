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

namespace _10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            FileStream fs = new FileStream("cisla.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            listBox1.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                int cislo = rnd.Next(-10, 11);
                listBox1.Items.Add(cislo);
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

            br.BaseStream.Seek(-4, SeekOrigin.End);
            int last = br.ReadInt32();

            br.BaseStream.Position = 0;
            if (last % 2 == 0)
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    int cislo = br.ReadInt32();
                    if (cislo % 2 == 0) continue;

                    cislo *= 2;
                    br.BaseStream.Position -= sizeof(int);
                    bw.Write(cislo);
                }
            }
            else
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    int cislo = br.ReadInt32();
                    if (cislo % 2 != 0) continue;

                    cislo += 1;
                    br.BaseStream.Position -= sizeof(int);
                    bw.Write(cislo);
                }
            }

            bw.Close();
            br.Close();
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("cisla.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            listBox2.Items.Clear();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                int cislo = br.ReadInt32();
                listBox2.Items.Add(cislo);
            }

            br.Close();
            fs.Close();
        }
    }
}
