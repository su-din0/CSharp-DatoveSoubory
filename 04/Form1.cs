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

namespace _04
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
            
            int k = int.Parse(textBox2.Text);
            int l = int.Parse(textBox3.Text);

            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                int cislo = br.ReadInt32();

                if (cislo != k) continue;

                br.BaseStream.Position -= sizeof(int); //Velikost intu je 4
                bw.Write(l);
            }

            bw.Close();
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

        }
    }
}
