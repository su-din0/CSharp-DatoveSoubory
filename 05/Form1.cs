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

namespace _05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("sport.txt");
            FileStream fs = new FileStream("sport.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                char[] chars = { ';' };
                string[] data = line.Split(chars, StringSplitOptions.RemoveEmptyEntries);


                int osc = int.Parse(data[0]);
                string name = data[1];
                string surname = data[2];
                char gender = char.Parse(data[3]);
                int vyska = int.Parse(data[4]);
                int hmotnost = int.Parse(data[5]);

                bw.Write(osc);
                bw.Write(name);
                bw.Write(surname);
                bw.Write(gender);
                bw.Write(vyska);
                bw.Write(hmotnost);

            }

            bw.Close();
            fs.Close();
            sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("sport.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                int osc = br.ReadInt32();
                string name = br.ReadString();
                string surname = br.ReadString();
                char gender = br.ReadChar();
                int vyska = br.ReadInt32();
                int hmotnost = br.ReadInt32();

                string line = $"{osc};{name};{surname};{gender};{vyska};{hmotnost}";
                textBox1.Text += line + Environment.NewLine;
            }

            br.Close();
            fs.Close();
        }
    }
}
