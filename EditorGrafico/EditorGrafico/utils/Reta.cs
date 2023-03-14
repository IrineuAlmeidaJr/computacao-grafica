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
        public static void EquacaoRealReta(double x1, double y1, double x2, double y2, Bitmap imagem)
        {
            Graphics graphics = Graphics.FromImage(imagem);
            int inc;
            double x, y;
            double deltaX, deltaY, m;

            deltaX = x2 - x1;
            deltaY = y2 - y1;
            m = deltaY / deltaX;
            inc = Math.Sign(deltaX);

            if (y1 > y2) // 7° e 8° octante
            {
                if (deltaX < deltaY) // 7° octante
                {
                    for (y = y1; y != y2; y += inc)
                    {
                        x = x1 + (y - y1) / m;
                        graphics.FillRectangle(Brushes.Red, (int)x, (int)y, 6, 6);
                    }
                }
                else // deltaX > deltaY -> 8° octante 
                {
                    for (x = x1; x != x2; x += inc)
                    {
                        y = y1 + m * (x - x1);
                        graphics.FillRectangle(Brushes.Red, (int)x, (int)y, 6, 6);
                    }
                }
            }
            else // y2 > y1 -> 1° e 2° octante
            {
                if (deltaX < deltaY) // 2° octante
                {
                    for (y = y1; y != y2; y += inc)
                    {
                        x = x1 + (y - y1) / m;
                        graphics.FillRectangle(Brushes.Red, (int)x, (int)y, 6, 6);
                    }
                }
                else // deltaX > deltaY -> 1° octante 
                {
                    // Acjo que aqui x++ se positivo se ngativo delta x--
                    for (x = x1; x != x2; x += inc)
                    {
                        y = y1 + m * (x - x1);
                        graphics.FillRectangle(Brushes.Red, (int)x, (int)y, 6, 6);
                    }
                }
            }
        }

        public static void DigitalDifferentialAnalyzer(double x1, double y1, 
            double x2, double y2, Bitmap imagem)
        {
            Graphics graphics = Graphics.FromImage(imagem);
            int i;
            double length;
            double x, y, incX, incY;
            double deltaX, deltaY, m;

            deltaX = x2 - x1;
            deltaY = y2 - y1;            

            if (deltaY > deltaX)
            {
                length = Math.Abs(deltaY);
            }
            else
            {
                length = Math.Abs(deltaX);
            }

            incX = deltaX / length;
            incY = deltaY / length;

            x = x1; y = y1; 
            if (x < x2)
            {
                while (x < x2)
                {
                    graphics.FillRectangle(Brushes.Red, (int)Math.Round(x), (int)Math.Round(y), 6, 6);
                    x += incX;
                    y += incY;
                }
            }
            else
            {
                // Ele já vai ter o valor de DeltaX e Delta Y ai quando manda incrementar, ele irá subtraindo
                // porque o valor de incrementa será negativo. 
                while (x > x2)
                {
                    graphics.FillRectangle(Brushes.Red, (int)Math.Round(x), (int)Math.Round(y), 6, 6);
                    x += incX;
                    y += incY;
                }
            }
            
        }

        public static void PontoMedio(double x1, double y1, double x2, double y2, Bitmap imagem)
        {
            double tempX, tempY;
            if (x2 < x1)
            {
                tempX = x1;
                tempY = y1;
                x1 = x2;
                y1 = y2;
                x2 = tempX;
                y2 = tempY;
            }

            if (y2 < y1)
            {
                y1 = -y1;
                y2 = -y2;
            }

           

            Graphics graphics = Graphics.FromImage(imagem);
            int declive;
            double deltaX, deltaY, incE, incNE, d, x, y;
            deltaX = x2 - x1;
            deltaY = y2 - y1;


            if (Math.Abs(deltaY) > Math.Abs(deltaX))
            {
                tempX = x1;
                x1 = y1;
                y1 = tempX;

                tempX = x2;
                x2 = y2;
                y2 = tempX;
            }


            declive = Math.Sign(deltaY);

            incE = 2 * deltaY;
            incNE = 2 * (deltaY - deltaX);
            d = 2 * deltaY - deltaX;
            y = y1;
            for (x = x1; x <= x2; x++)
            {
                graphics.FillRectangle(Brushes.Red, (int)x, (int)y, 6, 6);
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
    }
}
