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

namespace _08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("texty.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            string[] strings = {
                "Slunce zapadá za kopce.",
                "Ptáci zpívají ve větvích.",
                "Děti si hrají na louce.",
                "Hvězdy svítí na obloze.",
                "Květiny rozkvétají na zahradě.",
                "Řeka klidně plyne k moři.",
                "Stromy šumí ve větru.",
                "Měsíc vykukuje za mraky",
                "Tráva ševelí pod nohama.",
                "Vlny šumí na pobřeží."
            };

            listBox1.Items.Clear();
            foreach (string s in strings)
            {
                bw.Write(s);
                listBox1.Items.Add(s);
            }

            bw.Close();
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("texty.dat", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            BinaryWriter bw = new BinaryWriter(fs);

            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                char znak = br.ReadChar();
                if (znak == '.')
                {
                    br.BaseStream.Seek(-1, SeekOrigin.Current);
                    bw.Write('!');
                }   
            }

            bw.Close();
            br.Close();
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("texty.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            listBox2.Items.Clear();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                string s = br.ReadString();
                listBox2.Items.Add(s);
            }

            br.Close();
            fs.Close();
        }
    }
}
