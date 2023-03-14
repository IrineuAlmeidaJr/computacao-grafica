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
        public static void circEquacaoReal(double cx, double cy, double x2, double y2, Bitmap imagem)
        {
            double raio = Math.Sqrt(Math.Pow(x2 - cx, 2) + Math.Pow(y2 - cy, 2));
            double y;
            
            for(int x=0; x<raio/Math.Sqrt(2); x++ )
            {
                y = Math.Sqrt(Math.Pow(raio, 2) - Math.Pow(x, 2));
                simetria((int)cx, (int)cy, (int)x, (int)y, imagem);
            }

        }

        private static void simetria(int cx, int cy, int x, int y, Bitmap imagem)
        {
            // Um if para cada um para verificar os limites
            imagem.SetPixel(cx + x, cy + y, Color.Red);
            imagem.SetPixel(cx + y, cy + x, Color.Red);
            imagem.SetPixel(cx + x, cy - y, Color.Red);
            imagem.SetPixel(cx + y, cy - x, Color.Red);

            imagem.SetPixel(cx - x, cy - y, Color.Red);
            imagem.SetPixel(cx - y, cy - x, Color.Red);
            imagem.SetPixel(cx - x, cy + y, Color.Red);
            imagem.SetPixel(cx - y, cy + x, Color.Red);

        }


    }
}
