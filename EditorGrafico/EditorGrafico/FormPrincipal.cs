using EditorGrafico.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafico
{
    public partial class FormPrincipal : Form
    {
        double x1, x2, y1, y2;
        private Bitmap _imagem;

        public FormPrincipal()
        {
            InitializeComponent();
            int w = pictureBox.Height;
            int h = pictureBox.Width;
            _imagem = 
                new Bitmap(h, w, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(_imagem);
            pictureBox.Image = _imagem;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1= e.Y;    
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            bool escolhido = true;
            x2 = e.X;
            y2 = e.Y;

            if (escolhido && cbReta1.Checked)
            {
                Reta.EquacaoRealReta(x1, y1, x2, y2, _imagem);
                escolhido = false;
            }
            if (escolhido && cbReta2.Checked)
            {
                Reta.DigitalDifferentialAnalyzer(x1, y1, x2, y2, _imagem);
                escolhido = false;
            }
            if (escolhido && cbReta3.Checked)
            {
                Reta.PontoMedio(x1, y1, x2, y2, _imagem);
                escolhido= false;
            }


            pictureBox.Image = _imagem;
        }
    }
}
