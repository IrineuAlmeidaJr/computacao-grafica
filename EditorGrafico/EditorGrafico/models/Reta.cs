using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EditorGrafico.utils
{
    abstract class Reta
    {
        public static void EquacaoRealReta(int x1, int y1, int x2, int y2, Bitmap imagem)
        {
            Graphics graphics = Graphics.FromImage(imagem);
            int inc;
            double x, y;
            double deltaX, deltaY, m;

            deltaX = x2 - x1;
            deltaY = y2 - y1;
            m = deltaY / deltaX;

            if (Math.Abs(deltaX) < Math.Abs(deltaY))
            {
                inc = Math.Sign(deltaY);
                for (y = y1; y != y2; y += inc)
                {
                    x = x1 + (y - y1) / m;
                    imagem.SetPixel((int)x, (int)y, Color.Red);
                }
            }
            else
            {
                inc = Math.Sign(deltaX);
                for (x = x1; x != x2; x += inc)
                {
                    y = y1 + m * (x - x1);
                    imagem.SetPixel((int)x, (int)y, Color.Red);
                }
            }

        } 

        public static void DigitalDifferentialAnalyzer(int x1, int y1, 
            int x2, int y2, Bitmap imagem)
        {
            Graphics graphics = Graphics.FromImage(imagem);
            int cont;
            int length;
            double x, y, incX, incY;
            double deltaX, deltaY, m;

            deltaX = x2 - x1;
            deltaY = y2 - y1;

            if (Math.Abs(deltaY) > Math.Abs(deltaX))
            {
                length = (int)Math.Abs(deltaY);
            }
            else
            {
                length = (int)Math.Abs(deltaX);
            }

            incX = deltaX / length;
            incY = deltaY / length;

            x = x1; y = y1;
            
            // Usa assim porque eu só preciso saber quantos calculos serão feito, pois, o length
            // já irá dizer quanto eu tenho de que desenhar, e se irá para cima ou baixo, frente
            // ou traz o próprio incX ou incY irá me dizer
            cont = 0;
            while (cont <= length)
            {
                imagem.SetPixel((int)Math.Round(x), (int)Math.Round(y), Color.Red);
                x += incX;
                y += incY;

                cont++;
            }
           

            //  --> Eu tinha feito dessa forma abaixo

            //if (deltaY > deltaX)
            //{
            //    length = Math.Abs(deltaY);
            //}
            //else
            //{
            //    length = Math.Abs(deltaX);
            //}

            //incX = deltaX / length;
            //incY = deltaY / length;            

            //x = x1; y = y1; 
            //if (x < x2)
            //{
            //    while (x < x2)
            //    {
            //        graphics.FillRectangle(Brushes.Red, (int)Math.Round(x), (int)Math.Round(y), 6, 6);
            //        x += incX;
            //        y += incY;
            //    }
            //}
            //else
            //{
            //    // Ele já vai ter o valor de DeltaX e Delta Y ai quando manda incrementar, ele irá subtraindo
            //    // porque o valor de incrementa será negativo. 
            //    while (x > x2)
            //    {
            //        graphics.FillRectangle(Brushes.Red, (int)Math.Round(x), (int)Math.Round(y), 6, 6);
            //        x += incX;
            //        y += incY;
            //    }
            //}

        }

        public static void PontoMedio(int x1, int y1, int x2, int y2, Bitmap imagem)
        {
            int declive;
            double deltaX, deltaY, incE, incNE, d, x, y;
            deltaX = x2 - x1;
            deltaY = y2 - y1;


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
                    imagem.SetPixel((int)x, (int)y, Color.Red);
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
                    imagem.SetPixel((int)x, (int)y, Color.Red);
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
