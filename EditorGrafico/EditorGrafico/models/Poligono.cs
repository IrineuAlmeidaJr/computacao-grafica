using EditorGrafico.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafico.models
{
    public class Poligono
    {
        public List<Ponto> Pontos { get; set; }

        public Poligono(List<Ponto> pontos)
        {
            Pontos = pontos;
        }

        public void DesenharPoligono(Bitmap imagem, PictureBox pictureBoxPoligono)
        {
            if (this.Pontos.Count > 1)
            {
                int ate = this.Pontos.Count - 1;
                for (int i = 0; i < ate; i++)
                {
                    Ponto.PontoMedio(this.Pontos[i].X, this.Pontos[i].Y,
                    this.Pontos[i + 1].X, this.Pontos[i + 1].Y, imagem);
                }

                pictureBoxPoligono.Image = imagem;
            }

        }

        public void Translacao(int dX, int dY)
        {
            foreach (var ponto in Pontos)
            {
                ponto.X += dX;
                ponto.Y += dY;
            }
        }

        public void Escala(double eX, double eY)
        {
            foreach (var ponto in Pontos)
            {
                double xl = ponto.X * eX;
                double yl = ponto.Y * eY;

                ponto.X = (int)xl;
                ponto.Y = (int)yl;
            }
        }
       

    }
}
