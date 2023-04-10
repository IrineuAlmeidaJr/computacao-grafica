using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorGrafico.models
{
    public abstract class Elipse
    {
        public static void PontoMedio(int cx, int cy, int x2, int y2, Bitmap imagem)
        {
            // Olha porque tem uma posição que da divisao por 0

            // Calcula o raio para o eixo de X e Y
            //int rx = (int)Math.Sqrt(Math.Pow(x2 - cx, 2) + Math.Pow(y2 - cy, 2)); 
            //int ry = (int)(rx - rx * 0.3);
            int rx = Math.Abs(x2 - cx);
            int ry = Math.Abs(y2 - cy);
            int rx_pot = rx * rx;
            int ry_pot = ry * ry;

            int x = 0;
            int y = ry;

            // Região 1
            double d1 = ry * ry - rx * rx * ry + rx * rx / 4.0;
            Simetria4_reg1(cx, cy, x, y, imagem);
            while (rx_pot * (y - 0.5) > ry_pot * (x + 1))
            {                
                if (d1 < 0)
                { 
                    d1 = d1 + ry_pot * (2 * x + 3);
                    x++;
                }
                else
                {
                    d1 = d1 + ry_pot * (2 * x + 3) + rx_pot * (-2 * y + 2);
                    x++;
                    y--;
                }
                Simetria4_reg1(cx, cy, x, y, imagem);
            }

            // Região 2 
            double d2 = ry_pot * (x + 0.5) * (x + 0.5) +
                rx_pot * (y - 1) * (y - 1) - rx_pot * ry_pot;
            Simetria4_reg1(cx, cy, x, y, imagem);
            while (y > 0)
            {
                if (d2 < 0)
                {
                    d2 = d2 + ry_pot * (2 * x + 2) + rx_pot * (-2 * y + 3);
                    x++;
                    y--;
                }
                else
                {
                    d2 = d2 + rx_pot * (-2 * y + 3);
                    y--;
                }
                Simetria4_reg2(cx, cy, x, y, imagem);
            }
        }

        private static void Simetria4_reg1(int cx, int cy, int x, int y, Bitmap imagem)
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

            tempX = cx - x;
            tempY = cy + y;
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

            tempX = cx - x;
            tempY = cy - y;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Black);
            }
        }

        private static void Simetria4_reg2(int cx, int cy, int x, int y, Bitmap imagem)
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

            tempX = cx - x;
            tempY = cy + y;
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

            tempX = cx - x;
            tempY = cy - y;
            if (tempX > 0 && tempX < w && tempY > 0 && tempY < h)
            {
                imagem.SetPixel(tempX, tempY, Color.Black);
            }
        }

    }
}
