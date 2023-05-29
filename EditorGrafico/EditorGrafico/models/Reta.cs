using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace EditorGrafico.utils
{
    abstract class Reta
    {

        private unsafe static void PosicionaXY(byte* src, int width, int height, int padding, int atePosX, int atePosY)
        {
            for (int y = 0; y < atePosY; y++)
            {
                
                // Ao terminar a linha pula a parte que estaria o padding da imagem, por isso tem que
                // fazer dois for
                src += width *3 + padding;
            }

            for (int x = 0; x < atePosX; x++)
            {
                src += 3;
            }

            *(src++) = (byte)200;
            *(src++) = (byte)0;
            *(src++) = (byte)0;

        }

        public static void EquacaoRealReta(int x1, int y1, int x2, int y2, Bitmap imagem)
        {
            // --- Inicio DMA
            int width = imagem.Width;
            int height = imagem.Height;
            int pixelSize = 3;

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = imagem.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            // No bitmap ao abri no final sobra uma faixa de padding, então tem que tirar, pois, irá dar erro
            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            // ---------------

            int inc;
            double x, y;
            double deltaX, deltaY, m;

            deltaX = x2 - x1;
            deltaY = y2 - y1;
            m = deltaY / deltaX;

            if (Math.Abs(deltaX) < Math.Abs(deltaY))
            {
                unsafe
                {
                    byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();

                    inc = Math.Sign(deltaY);
                    for (y = y1; y != y2; y += inc)
                    {
                        x = x1 + (y - y1) / m;

                        PosicionaXY(src, width, height, padding, (int)x, (int)y);
                    }
                }
            }
            else
            {
                unsafe
                {
                    byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();

                    inc = Math.Sign(deltaX);
                    for (x = x1; x != x2; x += inc)
                    {
                        y = y1 + m * (x - x1);
                        PosicionaXY(src, width, height, padding, (int)x, (int)y);
                    }
                }
            }

            // Desbloqueia a área de memória do bitmap
            imagem.UnlockBits(bitmapDataSrc);
        }


        public static unsafe void EquacaoRealReta2(int x1, int y1, int x2, int y2, Bitmap imagem)
        {
            // Obtém o objeto BitmapData para a imagem
            Rectangle rect = new Rectangle(0, 0, imagem.Width, imagem.Height);
            BitmapData bitmapData = imagem.LockBits(rect, ImageLockMode.ReadWrite, imagem.PixelFormat);

            // Obtém o ponteiro para os dados do bitmap
            byte* ptr = (byte*)bitmapData.Scan0.ToPointer();

            // Obtém o tamanho real de cada pixel em bytes
            int pixelSize = Bitmap.GetPixelFormatSize(bitmapData.PixelFormat) / 8;
            int rowSize = bitmapData.Width * pixelSize;


            int inc;
            double x, y;
            double deltaX, deltaY, m;

            deltaX = x2 - x1;
            deltaY = y2 - y1;
            m = deltaY / deltaX;

            if (Math.Abs(deltaX) < Math.Abs(deltaY))
            {
                unsafe
                {
                    byte* currentLine;
                    byte* currentPixel;

                    inc = Math.Sign(deltaY);
                    for (y = y1; y != y2; y += inc)
                    {
                        x = x1 + (y - y1) / m;

                        currentLine = (byte*)ptr + ((int)y * bitmapData.Stride);
                        currentPixel = currentLine + ((int)x * pixelSize);

                        // Lê os componentes de cor do pixel
                        byte blue = *currentPixel;
                        byte green = *(currentPixel + 1);
                        byte red = *(currentPixel + 2);

                        *currentPixel = (byte)0; 
                        *(currentPixel + 1) = (byte)0; 
                        *(currentPixel + 2) = (byte)0; 
                    }

                }
            }
            else
            {
                unsafe
                {
                    byte* currentLine;
                    byte* currentPixel;

                    inc = Math.Sign(deltaX);
                    for (x = x1; x != x2; x += inc)
                    {
                        y = y1 + m * (x - x1);

                        currentLine = (byte*)(ptr + ((int)y * bitmapData.Stride));
                        currentPixel = (byte*)(currentLine + ((int)x * pixelSize));

                        // Lê os componentes de cor do pixel
                        byte blue = *currentPixel;
                        byte green = *(currentPixel + 1);
                        byte red = *(currentPixel + 2);

                        *currentPixel = (byte)100; 
                        *(currentPixel + 1) = (byte)100; 
                        *(currentPixel + 2) = (byte)0;
                    }
                }
            }

            // Desbloqueia a área de memória do bitmap
            imagem.UnlockBits(bitmapData);

        }

        //public static void EquacaoRealReta(int x1, int y1, int x2, int y2, Bitmap imagem)
        //{
        //    Graphics graphics = Graphics.FromImage(imagem);
        //    int inc;
        //    double x, y;
        //    double deltaX, deltaY, m;

        //    deltaX = x2 - x1;
        //    deltaY = y2 - y1;
        //    m = deltaY / deltaX;

        //    if (Math.Abs(deltaX) < Math.Abs(deltaY))
        //    {
        //        if (Math.Sign(deltaY) > 0)
        //        {
        //            for (y = y1; y < y2; y++)
        //            {
        //                x = x1 + (y - y1) / m;
        //                imagem.SetPixel((int)x, (int)y, Color.Black);
        //            }
        //        }
        //        else
        //        {
        //            for (y = y1; y > y2; y--)
        //            {
        //                x = x1 + (y - y1) / m;
        //                imagem.SetPixel((int)x, (int)y, Color.Black);
        //            }
        //        }

        //    }
        //    else
        //    {
        //        if (Math.Sign(deltaX) > 0)
        //        {
        //            for (x = x1; x < x2; x ++)
        //            {
        //                y = y1 + m * (x - x1);
        //                imagem.SetPixel((int)x, (int)y, Color.Black);
        //            }
        //        }
        //        else
        //        {
        //            for (x = x1; x > x2; x--)
        //            {
        //                y = y1 + m * (x - x1);
        //                imagem.SetPixel((int)x, (int)y, Color.Black);
        //            }
        //        }

        //    }

        //}

        public static void DigitalDifferentialAnalyzer(int x1, int y1, 
            int x2, int y2, Bitmap imagem)
        {
            Graphics graphics = Graphics.FromImage(imagem);
            int cont;
            int length;
            double x, y, incX, incY;
            double deltaX, deltaY;

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
                imagem.SetPixel((int)Math.Round(x), (int)Math.Round(y), Color.Black);
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

        public static unsafe void PontoMedio(int x1, int y1, int x2, int y2, Bitmap imagem)
        {
            // --- Inicio DMA
            int width = imagem.Width;
            int height = imagem.Height;
            int pixelSize = 3;

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = imagem.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            // No bitmap ao abri no final sobra uma faixa de padding, então tem que tirar, pois, irá dar erro
            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();

            // ---------------

            int declive;
            double deltaX, deltaY, incE, incNE, d, x, y;
            deltaX = x2 - x1;
            deltaY = y2 - y1;


            if (Math.Abs(deltaX) > Math.Abs(deltaY)) // 10 -- 5
            {
                if (x1 > x2)
                {
                    // Desbloqueia a área de memória do bitmap
                    imagem.UnlockBits(bitmapDataSrc);

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
                    PosicionaXY(src, width, height, padding, (int)x, (int)y);
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
                    // Desbloqueia a área de memória do bitmap
                    imagem.UnlockBits(bitmapDataSrc);

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
                    PosicionaXY(src, width, height, padding, (int)x, (int)y);
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
            // Desbloqueia a área de memória do bitmap
            imagem.UnlockBits(bitmapDataSrc);
        }
    }
}
