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

        public int Area()
        {
            int somatorio = 0;
            for(int i=0; i<this.Pontos.Count -1 ; i++)
            {
                somatorio += Pontos[i].X * Pontos[i + 1].Y - Pontos[i + 1].X * Pontos[i].Y;
            }

            return somatorio / 2;
        }


        public int[] Centroide()
        {
            int cX, cY;


            //for (int i = 0; i < Pontos.Count; i++)
            //{
            //    cX += Pontos[i].X;
            //}
            //cX /= Pontos.Count;

            //for (int i = 0; i < Pontos.Count - 1; i++)
            //{
            //    cY += Pontos[i].Y;
            //}
            //cY /= Pontos.Count;


            int somatorio = 0;
            int area = Area();
            for (int i = 0; i < Pontos.Count - 1; i++)
            {
                somatorio += (Pontos[i].X + Pontos[i + 1].X) * (Pontos[i].X * Pontos[i + 1].Y - Pontos[i + 1].X * Pontos[i].Y);
            }
            cX = somatorio / (6 * area);

            somatorio = 0;
            for (int i = 0; i < Pontos.Count - 1; i++)
            {
                somatorio += (Pontos[i].Y + Pontos[i + 1].Y) * (Pontos[i].X * Pontos[i + 1].Y - Pontos[i + 1].X * Pontos[i].Y);
            }
            cY = somatorio / (6 * area);

            return new int[2] { cX , cY };
        }

        public void Translacao(int dX, int dY)
        {
            foreach (var ponto in Pontos)
            {
                ponto.X += dX;
                ponto.Y += dY;
            }
        }
       

    }
}
