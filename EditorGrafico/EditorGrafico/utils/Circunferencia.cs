using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorGrafico.utils
{
    abstract class Circunferencia
    {
        public static void EquacaoReal(double cx, double cy, double x2, double y2, Bitmap imagem)
        {
            double raio = Math.Sqrt(Math.Pow(x2 - cx, 2) + Math.Pow(y2 - cy, 2));
            double y;
            
            for(int x=0; x<raio/Math.Sqrt(2); x++ )
            {
                y = Math.Sqrt(Math.Pow(raio, 2) - Math.Pow(x, 2));
                Simetria((int)cx, (int)cy, (int)x, (int)y, imagem);
            }
        }

        public static void EquacaoTrig(double cx, double cy, double x2, double y2, Bitmap imagem)
        {
            double raio = Math.Sqrt(Math.Pow(x2 - cx, 2) + Math.Pow(y2 - cy, 2));
            double y;

            double trigX, trigY, alpha;
            double inc = 360 / (2 * Math.PI * raio);
            for (double x = 45; x <= 90; x += inc)
            {
                //y = Math.Sqrt(Math.Pow(raio, 2) - Math.Pow(x, 2));

                alpha = (Math.PI / 180) * x; // transforma grau para radiano

                trigX = raio * Math.Cos(alpha);
                trigY = raio * Math.Sin(alpha);

                // 

                //simetria((int)cx, (int)cy, (int)x, (int)y, imagem);
                Simetria((int)cx, (int)cy, (int)trigX, (int)trigY, imagem);
            }
        }


        private static void Simetria(int cx, int cy, int x, int y, Bitmap imagem)
        {
            int w = imagem.Width;
            int h = imagem.Height;
            // Um if para cada um para verificar os limites
            int tempX, tempY;

            tempX = cx + x;
            tempY = cy + y;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Red);
            }

            tempX = cx + y;
            tempY = cy + x;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Red);
            }

            tempX = cx + x;
            tempY = cy - y;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Red);
            }

            tempX = cx + y;
            tempY = cy - x;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Red);
            }




            tempX = cx - x;
            tempY = cy - y;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Red);
            }

            tempX = cx - y;
            tempY = cy - x;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Red);
            }

            tempX = cx - x;
            tempY = cy + y;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Red);
            }

            tempX = cx - y;
            tempY = cy + x;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Red);
            }

        }

        

    }
}
