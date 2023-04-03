using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorGrafico.utils
{
    public abstract class Circunferencia
    {
        public static void EquacaoReal(int cx, int cy, int x2, int y2, Bitmap imagem)
        {
            double raio = Math.Sqrt(Math.Pow(x2 - cx, 2) + Math.Pow(y2 - cy, 2));
            double y;
            
            for(int x=0; x<raio/Math.Sqrt(2); x++ )
            {
                y = Math.Sqrt(Math.Pow(raio, 2) - Math.Pow(x, 2));
                Simetria((int)cx, (int)cy, (int)x, (int)y, imagem);
            }
        }

        public static void EquacaoTrig(int cx, int cy, int x2, int y2, Bitmap imagem)
        {
            double raio = Math.Sqrt(Math.Pow(x2 - cx, 2) + Math.Pow(y2 - cy, 2));

            double trigX, trigY, alpha;
            double inc = 360 / (2 * Math.PI * raio);
            for (double x = 45; x <= 90; x += inc)
            {
                //y = Math.Sqrt(Math.Pow(raio, 2) - Math.Pow(x, 2));

                alpha = (Math.PI / 180) * x; // transforma grau para radiano

                trigX = raio * Math.Cos(alpha);
                trigY = raio * Math.Sin(alpha);

                //simetria((int)cx, (int)cy, (int)x, (int)y, imagem);
                Simetria((int)cx, (int)cy, (int)trigX, (int)trigY, imagem);
            }
        }

        public static void PontoMedio(int cx, int cy, int x2, int y2, Bitmap imagem)
        {
            //int x, y;
            //double raio = Math.Sqrt(Math.Pow(x2 - cx, 2) + Math.Pow(y2 - cy, 2));

            //x = 0;
            //y = Convert.ToInt32(raio);
            //double d = 1 - raio;
            //Simetria((int)cx, (int)cy, x, y, imagem);
            //while (y > x)
            //{
            //    if (d < 0) // Dentro circunferência -> E
            //    {
            //        d += 2 * x + 3;
            //    }
            //    else // Fora circunferência -> SE
            //    {
            //        d += 2 * (x - y) + 5;
            //        y--;
            //    }
            //    x++;
            //    Simetria((int)cx, (int)cy, x, y, imagem);
            //}

            int x, y;
            int raio = (int)Math.Sqrt(Math.Pow(x2 - cx, 2) + Math.Pow(y2 - cy, 2));

            x = 0;
            y = raio;
            int deltaE = 3;
            int deltaSE = -2 * raio + 5;
            int d = 1 - raio;
            Simetria(cx, cy, x, y, imagem);
            while (y > x)
            {
                if (d < 0) // Dentro circunferência -> E
                {
                    d += deltaE;
                    deltaE += 2;
                    deltaSE += 2;
                }
                else // Fora circunferência -> SE
                {
                    d += deltaSE;
                    deltaE += 2;
                    deltaSE += 4;
                    y--;
                }
                x++;
                Simetria(cx, cy, x, y, imagem);
            }

        }

        private static void Simetria(int cx, int cy, int x, int y, Bitmap imagem)
        {
            int w = imagem.Width;
            int h = imagem.Height;
            int tempX, tempY;

            tempX = cx + x;
            tempY = cy + y;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Black);
            }

            tempX = cx + y;
            tempY = cy + x;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Black);
            }

            tempX = cx + x;
            tempY = cy - y;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Black);
            }

            tempX = cx + y;
            tempY = cy - x;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Black);
            }



            tempX = cx - x;
            tempY = cy - y;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Black);
            }

            tempX = cx - y;
            tempY = cy - x;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Black);
            }

            tempX = cx - x;
            tempY = cy + y;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Black);
            }

            tempX = cx - y;
            tempY = cy + x;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Black);
            }   

        }

        

    }
}
