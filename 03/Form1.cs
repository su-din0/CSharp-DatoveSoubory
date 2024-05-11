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

namespace _03
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

            string text = textBox1.Text;
            foreach (char znak in text)
            {
                bw.Write(znak);
            }

            bw.Close();
            fs.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("znaky.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            int pozice = 0;
            char predchozi = ' ';
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                char znak = br.ReadChar();
                if(znak == '!')
                {
                    MessageBox.Show($"Znak ! je na pozici: {pozice+1} a predchozi znak byl: {predchozi}");
                }
                
                predchozi = znak;
                pozice++;
            }

            br.Close();
            fs.Close();
        }
    }
}
