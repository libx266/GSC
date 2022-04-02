using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSC
{
    public class Encrypter : PictureBox
    {
        public const int SizeX = 59;
        public const int SizeY = 84;
        protected int Offset(int v) => v * 64 + 128;
        
        protected char[,] EncryptedText = new char[SizeX, SizeY];

        protected readonly Bitmap Source = Properties.Resources.BLANK_UHD;
        
        protected Point Brush;

        protected int[] RowLength = new int[SizeY];


        protected static Bitmap Print(char c)
        {
            switch (c)
            {
                case 'а': return Properties.Resources.а; 
                case 'А': return Properties.Resources.а; 
                case 'б': return Properties.Resources.б; 
                case 'Б': return Properties.Resources.б; 
                case 'в': return Properties.Resources.в; 
                case 'В': return Properties.Resources.в; 
                case 'г': return Properties.Resources.г; 
                case 'Г': return Properties.Resources.г; 
                case 'д': return Properties.Resources.д; 
                case 'Д': return Properties.Resources.д; 
                case 'Е': return Properties.Resources.е; 
                case 'е': return Properties.Resources.е; 
                case 'ё': return Properties.Resources.ё; 
                case 'Ё': return Properties.Resources.ё; 
                case 'ж': return Properties.Resources.ж; 
                case 'Ж': return Properties.Resources.ж; 
                case 'з': return Properties.Resources.з; 
                case 'З': return Properties.Resources.з; 
                case 'и': return Properties.Resources.и; 
                case 'И': return Properties.Resources.и; 
                case 'й': return Properties.Resources.й; 
                case 'Й': return Properties.Resources.й; 
                case 'к': return Properties.Resources.к; 
                case 'К': return Properties.Resources.к; 
                case 'л': return Properties.Resources.л; 
                case 'Л': return Properties.Resources.л; 
                case 'м': return Properties.Resources.м; 
                case 'М': return Properties.Resources.м; 
                case 'н': return Properties.Resources.н; 
                case 'Н': return Properties.Resources.н; 
                case 'о': return Properties.Resources.о; 
                case 'О': return Properties.Resources.о; 
                case 'п': return Properties.Resources.п; 
                case 'П': return Properties.Resources.п; 
                case 'р': return Properties.Resources.р; 
                case 'Р': return Properties.Resources.р; 
                case 'с': return Properties.Resources.с; 
                case 'С': return Properties.Resources.с; 
                case 'т': return Properties.Resources.т; 
                case 'Т': return Properties.Resources.т; 
                case 'у': return Properties.Resources.у; 
                case 'У': return Properties.Resources.у; 
                case 'ф': return Properties.Resources.ф; 
                case 'Ф': return Properties.Resources.ф; 
                case 'х': return Properties.Resources.х; 
                case 'Х': return Properties.Resources.х; 
                case 'ц': return Properties.Resources.ц; 
                case 'Ц': return Properties.Resources.ц; 
                case 'ч': return Properties.Resources.ч; 
                case 'Ч': return Properties.Resources.ч; 
                case 'ш': return Properties.Resources.ш; 
                case 'Ш': return Properties.Resources.ш; 
                case 'щ': return Properties.Resources.щ; 
                case 'Щ': return Properties.Resources.щ; 
                case 'ъ': return Properties.Resources.ъ; 
                case 'Ъ': return Properties.Resources.ъ; 
                case 'ы': return Properties.Resources.ы; 
                case 'Ы': return Properties.Resources.ы; 
                case 'ь': return Properties.Resources.ь; 
                case 'Ь': return Properties.Resources.ь; 
                case 'э': return Properties.Resources.э; 
                case 'Э': return Properties.Resources.э; 
                case 'ю': return Properties.Resources.ю; 
                case 'Ю': return Properties.Resources.ю; 
                case 'я': return Properties.Resources.я; 
                case 'Я': return Properties.Resources.я; 
                case '0': return Properties.Resources._0; 
                case '1': return Properties.Resources._1; 
                case '2': return Properties.Resources._2; 
                case '3': return Properties.Resources._3; 
                case '4': return Properties.Resources._4; 
                case '5': return Properties.Resources._5; 
                case '6': return Properties.Resources._6; 
                case '7': return Properties.Resources._7; 
                case '8': return Properties.Resources._8; 
                case '9': return Properties.Resources._9; 
                case '+': return Properties.Resources.сложение; 
                case '-': return Properties.Resources.вычитание; 
                case '*': return Properties.Resources.умножение; 
                case '/': return Properties.Resources.деление; 
                case '=': return Properties.Resources.вопрос; 
                case '.': return Properties.Resources.точка; 
                case ',': return Properties.Resources.запятая; 
                case ':': return Properties.Resources.двоеточие; 
                case ';': return Properties.Resources.точка_с_запятой; 
                case ' ': return Properties.Resources.пробел; 
                case 'a': return Properties.Resources._a; 
                case 'A': return Properties.Resources._a; 
                case 'b': return Properties.Resources._b; 
                case 'B': return Properties.Resources._b; 
                case 'c': return Properties.Resources._c; 
                case 'C': return Properties.Resources._c; 
                case 'd': return Properties.Resources._d; 
                case 'D': return Properties.Resources._d; 
                case 'e': return Properties.Resources._e; 
                case 'E': return Properties.Resources._e; 
                case 'f': return Properties.Resources._f; 
                case 'F': return Properties.Resources._f; 
                case 'g': return Properties.Resources._g; 
                case 'G': return Properties.Resources._g; 
                case 'h': return Properties.Resources._h; 
                case 'H': return Properties.Resources._h; 
                case 'i': return Properties.Resources._i; 
                case 'I': return Properties.Resources._i; 
                case 'j': return Properties.Resources._j; 
                case 'J': return Properties.Resources._j; 
                case 'k': return Properties.Resources._k; 
                case 'K': return Properties.Resources._k; 
                case 'l': return Properties.Resources._l; 
                case 'L': return Properties.Resources._l; 
                case 'm': return Properties.Resources._m; 
                case 'M': return Properties.Resources._m; 
                case 'n': return Properties.Resources._n; 
                case 'N': return Properties.Resources._n; 
                case 'o': return Properties.Resources._o; 
                case 'O': return Properties.Resources._o; 
                case 'p': return Properties.Resources._p; 
                case 'P': return Properties.Resources._p; 
                case 'q': return Properties.Resources._q; 
                case 'Q': return Properties.Resources._q; 
                case 'r': return Properties.Resources._r; 
                case 'R': return Properties.Resources._r; 
                case 's': return Properties.Resources._s; 
                case 'S': return Properties.Resources._s; 
                case 't': return Properties.Resources._t; 
                case 'T': return Properties.Resources._t; 
                case 'u': return Properties.Resources._u; 
                case 'U': return Properties.Resources._u; 
                case 'v': return Properties.Resources._v; 
                case 'V': return Properties.Resources._v; 
                case 'w': return Properties.Resources._w; 
                case 'W': return Properties.Resources._w; 
                case 'x': return Properties.Resources._x; 
                case 'X': return Properties.Resources._x; 
                case 'y': return Properties.Resources._y; 
                case 'Y': return Properties.Resources._y; 
                case 'z': return Properties.Resources._z; 
                case 'Z': return Properties.Resources._z; 
                case '?': return Properties.Resources.равно; 
                case '!': return Properties.Resources.восклицательный_знак; 
                case '&': return Properties.Resources.логическое_и; 
                case '|': return Properties.Resources.логическое_или; 
                case '>': return Properties.Resources._больше; 
                case '<': return Properties.Resources._меньше; 
                case '(': return Properties.Resources.скобка_левая; 
                case '[': return Properties.Resources.скобка_левая; 
                case '{': return Properties.Resources.скобка_левая; 
                case ')': return Properties.Resources.скобка_правая; 
                case ']': return Properties.Resources.скобка_правая; 
                case '}': return Properties.Resources.скобка_правая;
                case '~': return Properties.Resources._enter;
                default: return Properties.Resources._default; 
            }
        }

        public char this[int X, int Y]
        {
            get => EncryptedText[X, Y];
            set
            {
                if (X < 0) X = 0;
                if (Y < 0) Y = 0;
                
                Bitmap symbol = Print(value);
                
                for (int y = Offset(Y) + 1, i = 0; y <= Offset(Y + 1) - 1; y++, i++)
                {
                    for (int x = Offset(X) + 1, j = 0; x <= Offset(X + 1) - 1; x++, j++)
                    {
                        Source.SetPixel(x, y, symbol.GetPixel(j, i));
                    }
                }
                
                Image = Source;
                EncryptedText[X, Y] = value;
                Brush = new Point(X, Y);
                RowLength[Y]++;
                GC.Collect(); GC.WaitForPendingFinalizers(); GC.Collect();
            }
        }

        public int[] Remove()
        {
            int x = Brush.X, y = Brush.Y;
            this[x, y] = '~';
            bool b = x > 0;
            

            Brush = new Point(b ? x - 1 : RowLength[b || y == 0 ? y : y - 1] - 1, b ? y : y - 1);
            RowLength[b || y == 0 ? y : y - 1]-=2;
            return new int[] { x < 0 ? 0 : x, y };
        }

        public void Save(string path)
        {
            var Params = new EncoderParameters(2);
            Params.Param[0] = new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
            Params.Param[1] = new EncoderParameter(Encoder.ColorDepth, 8L);

            Source.Save(path, ImageCodecInfo.GetImageEncoders().First(ICI => ICI.MimeType == "image/tiff"), Params);
        }
    }
}
