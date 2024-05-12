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

namespace _09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("znaky.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            foreach (string radek in textBox1.Lines)
            {
                char znak = radek[0];
                bw.Write(znak);
            }

            bw.Close();
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("znaky.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                char znak = br.ReadChar();
                textBox2.Text += znak + Environment.NewLine;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("znaky.dat", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            BinaryWriter bw = new BinaryWriter(fs);

            int count = 0;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                char znak = br.ReadChar();
                if (count % 10 == 0 && count != 0)
                {
                    br.BaseStream.Position -= sizeof(char);
                    bw.Write('*');
                }
                ++count;
            }

            br.Close();
            bw.Close();
            fs.Close();
        }
    }
}
