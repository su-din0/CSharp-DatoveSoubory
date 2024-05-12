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

namespace _07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private bool JePrvocislo(int cislo)
        {
            if (cislo == 1 || (cislo % 2 == 0 && cislo != 2)) return false;
            for (int i = 3; i <= Math.Sqrt(cislo); i+=2)
            {
                if (cislo % i == 0) return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            FileStream fs = new FileStream("cisla.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            listBox1.Items.Clear();
            for (int i = 0; i < 25; i++)
            {
                int cislo = rnd.Next(5000);
                listBox1.Items.Add(cislo);
                bw.Write(cislo);
            }

            bw.Close();
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("cisla.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            StreamWriter sw = new StreamWriter("prvocisla.txt");

            listBox2.Items.Clear();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                int cislo = br.ReadInt32();
                if (this.JePrvocislo(cislo))
                {
                    sw.WriteLine(cislo);
                    listBox2.Items.Add(cislo);
                }
            }

            sw.Close();
            br.Close();
            fs.Close();
        }
    }
}
