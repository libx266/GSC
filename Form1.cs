using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string kurwa = "";
            for (int i = 0; i < 60; i++)
            {
                kurwa += "k";
            }
            richTextBox1.TextChanged += new EventHandler(Encode);
            pictureBox1.MouseClick += new MouseEventHandler(Save);
        }

        char[,] Buffer = new char[Encrypter.SizeX, Encrypter.SizeY];

        int length;
        
        void Encode(object sender, EventArgs e)
        {
            int i = 0, l = richTextBox1.Text.Length;

            for (int j = 0; j < length - l; j++)
            {
                int[] index = pictureBox1.Remove();
                Buffer[index[0], index[1]] = '~';
            }
            
            length = l;
            
            for (int y = 0; y < Encrypter.SizeY; y++)
            {
                for (int x = 0; x < Encrypter.SizeX; x++)
                {
                    if (i >= l) return;
                    
                    char c = richTextBox1.Text[i];
                    if (c == '\n') { y++; x = -1; }
                    else if (c != Buffer[x, y])
                    {
                        Buffer[x, y] = c;
                        pictureBox1[x, y] = c;
                    }
                    i++;
                }
            }
        }

        void Save(object sender, MouseEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Image Files(*.tiff)|*.tiff";
            
            if (dialog.ShowDialog() == DialogResult.OK)
                pictureBox1.Save(dialog.FileName);
        }
            

        
    }
}
