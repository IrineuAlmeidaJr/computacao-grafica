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
    public partial class FormPoligonal : Form
    {
        private List<Poligono> pontosPoligono;
        private List<List<Poligono>> poligonos;
        private Bitmap _imagem;

        public FormPoligonal()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.pontosPoligono = new List<Poligono>();
            this.poligonos = new List<List<Poligono>>();

            LimparTela();
        }

        private void LimparTela()
        {
            int w = pictureBoxPoligono.Height;
            int h = pictureBoxPoligono.Width;
            _imagem =
                new Bitmap(h, w, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(_imagem);
            pictureBoxPoligono.Image = _imagem;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            if (e.Button == MouseButtons.Right)
            {
                if (pontosPoligono.Count > 2)
                {
                    x = pontosPoligono[0].X;
                    y = pontosPoligono[0].Y;
                    pontosPoligono.Add(new Poligono(x, y));

                    Poligono.Desenhar(pontosPoligono, _imagem, pictureBoxPoligono);

                    poligonos.Add(pontosPoligono);

                    listBox.Items.Add($"Poligono_{poligonos.Count}");

                    this.pontosPoligono = new List<Poligono>();
                }               
            } 
            else
            {
                pontosPoligono.Add(new Poligono(x, y));
                Poligono.Desenhar(pontosPoligono, _imagem, pictureBoxPoligono);
            }
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            List<int> posExcluir = new List<int>();
            for (int  i= 0; i < listBox.Items.Count; i++)
            {
                if (listBox.GetItemChecked(i))
                {
                    posExcluir.Add(i);
                }
            }


            foreach (var item in posExcluir)
            {
                poligonos.RemoveAt(item);
                listBox.Items.RemoveAt(item);
            }

            LimparTela();

            foreach(var item in poligonos)
            {
                Poligono.Desenhar(item, _imagem, pictureBoxPoligono);
            }
        }
    }
}
