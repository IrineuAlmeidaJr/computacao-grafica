using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace EditorGrafico.utils
{
    public class Ponto
    {
        public int X {  get; set; }
        public int Y { get; set; }

        public Ponto(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static void DesenharReta(List<Ponto> pontos, Bitmap imagem, PictureBox pictureBoxPoligono)
        {
            if (pontos.Count > 1)
            {
                int ate = pontos.Count - 1;
                for (int i = 0; i < ate; i++)
                {
                    Ponto.PontoMedio(pontos[i].X, pontos[i].Y,
                    pontos[i + 1].X, pontos[i + 1].Y, imagem);
                }

                pictureBoxPoligono.Image = imagem;
            }
        }

        public static void PontoMedio(double x1, double y1, double x2, double y2, Bitmap imagem)
        {
            int declive;
            double deltaX, deltaY, incE, incNE, d, x, y;
            deltaX = x2 - x1;
            deltaY = y2 - y1;

            int w = imagem.Width;
            int h = imagem.Height;

            if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                if (x1 > x2)
                {
                    PontoMedio(x2, y2, x1, y1, imagem);
                    return;
                }

                declive = Math.Sign(deltaY);
                if (y1 > y2)
                {
                    deltaY = -deltaY;
                }


                incE = 2 * deltaY;
                incNE = 2 * (deltaY - deltaX);
                d = 2 * deltaY - deltaX;
                y = y1;
                for (x = x1; x <= x2; x++)
                {
                    if ((int)x > 0 && (int)x < w && (int)y > 0 && (int)y < h)
                    {
                        imagem.SetPixel((int)x, (int)y, Color.Red);
                    }
                    if (d <= 0)
                    {
                        d += incE;
                    }
                    else
                    {
                        d += incNE;
                        y += declive;
                    }
                }
            }
            else
            {
                if (y1 > y2)
                {
                    PontoMedio(x2, y2, x1, y1, imagem);
                    return;
                }

                declive = Math.Sign(deltaX);
                if (x1 > x2)
                {
                    deltaX = -deltaX;
                }


                incE = 2 * deltaX;
                incNE = 2 * (deltaX - deltaY);
                d = 2 * deltaX - deltaY;
                x = x1;
                for (y = y1; y <= y2; y++)
                {
                    if ((int)x > 0 && (int)x < w && (int)y > 0 && (int)y < h)
                    {
                        imagem.SetPixel((int)x, (int)y, Color.Red);
                    }
                    if (d <= 0)
                    {
                        d += incE;
                    }
                    else
                    {
                        d += incNE;
                        x += declive;
                    }
                }
            }
        }

    }
}
