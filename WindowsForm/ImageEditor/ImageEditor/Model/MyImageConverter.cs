using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor.Model
{
    abstract class MyImageConverter
    {
        public static double[] PixelRGB2HSI(Color color)
        {
            double[] hsi = new double[3];
            double R = color.R;
            double G = color.G;
            double B = color.B;
            double r, g, b;
            double h, s, i;

            if (R == 0 && G == 0 && B == 0)
            {
                h = 0;
                s = 0;
                i = 0;
            }
            else
            {
                //  Normalizing RGB values
                r = R / (R + G + B);
                g = G / (R + G + B);
                b = B / (R + G + B);

                h = Math.Acos(
                        0.5 * ((r - g) + (r - b))
                        /
                        (Math.Pow((Math.Pow((r - g), 2) + (r - b) * (g - b)), 0.5))
                );

                if (b > g)
                {
                    h = 2 * Math.PI - h;
                    if (h > 2 * Math.PI)
                    {
                        h = 2 * Math.PI;
                    }
                }
                else
                {
                    if (h > Math.PI)
                    {
                        h = Math.PI;
                    }
                }


                h = h * 180 / Math.PI;
                s = 1 - 3 * Math.Min(Math.Min(r, g), b);
                s = s * 100;
                i = (color.R + color.G + color.B) / 3;
            }

            if (double.IsNaN(h))
                h = 0;

            hsi[0] = h;
            hsi[1] = s;
            hsi[2] = i;

            return hsi;
        }

        public static List<List<double[]>> RGB2HSI(Bitmap bitmap)
        {
            double[] hsi;
            List<List<double[]>> HSI = new List<List<double[]>>();
            List<double[]> tempHSI = new List<double[]>();
            Color color;
            for (int x = 0; x < bitmap.Width; x++)
            {
                tempHSI = new List<double[]>();
                for (int y = 0; y < bitmap.Height; y++)
                {
                    color = bitmap.GetPixel(x, y);
                    hsi = PixelRGB2HSI(color);
                    tempHSI.Add(hsi);
                }
                HSI.Add(tempHSI);
            }


            return HSI;
        }

        public static Bitmap RGB2GRAY(Bitmap bitmap)
        {
            var newImageGray = new Bitmap(bitmap.Width, bitmap.Height);

            int red, green, blue, sum;
            Color color;
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    color = bitmap.GetPixel(x, y);
                    red = (int)(color.R * 0.299);
                    green = (int)(color.G * 0.587);
                    blue = (int)(color.B * 0.114);
                    sum = red + green + blue;
                    newImageGray.SetPixel(x, y, Color.FromArgb(sum, sum, sum));
                }
            }

            return newImageGray;
        }

        public static int[] PixelHSI2RGB(double[] hsi)
        {
            int[] rgb = new int[3];
            double x, y, z;
            double r, g, b;
            double h, s, i;

            h = hsi[0] * Math.PI / 180;
            s = hsi[1] / 100;
            i = hsi[2] / 255;


            if (h < (2 * Math.PI / 3))
            {
                x = i * (1 - s);
                y = i * (1 + (s * Math.Cos(h) / Math.Cos(Math.PI / 3 - h)));
                z = 3 * i - (x + y);

                r = y;
                g = z;
                b = x;
            }
            else
            {
                if (h >= (2 * Math.PI / 3) && h < (4 * Math.PI / 3))
                {
                    h = h - 2 * Math.PI / 3;

                    x = i * (1 - s);
                    y = i * (1 + (s * Math.Cos(h) / Math.Cos(Math.PI / 3 - h)));
                    z = 3 * i - (x + y);

                    r = x;
                    g = y;
                    b = z;
                }
                else
                {
                    h = h - 4 * Math.PI / 3;

                    x = i * (1 - s);
                    y = i * (1 + (s * Math.Cos(h) / Math.Cos(Math.PI / 3 - h)));
                    z = 3 * i - (x + y);

                    r = z;
                    g = x;
                    b = y;

                }
            }

            rgb[0] = (int)(255 * r);
            rgb[1] = (int)(255 * g);
            rgb[2] = (int)(255 * b);

            return rgb;
        }

        public static Bitmap HSI2RGB(Bitmap bitmap, List<List<double[]>> HSI)
        {
            int[] rgb;
            List<double[]> tempHSI = new List<double[]>();
            var newImage = new Bitmap(bitmap.Width, bitmap.Height);

            for (int x = 0; x < bitmap.Width; x++)
            {
                tempHSI = HSI[x];
                for (int y = 0; y < bitmap.Height; y++)
                {
                    rgb = PixelHSI2RGB(tempHSI[y]);
                    if (rgb[0] > 255)
                    {
                        rgb[0] = 255;
                    }
                    if (rgb[1] > 255)
                    {
                        rgb[1] = 255;
                    }
                    if (rgb[2] > 255)
                    {
                        rgb[2] = 255;
                    }

                    // *** OBS: tive colocar aqui para não estourar, por mais que eu não
                    // permitese adicionar mais de 255 em intenside ele dava erro aqui ou no hue                 
                    newImage.SetPixel(x, y, Color.FromArgb(rgb[0], rgb[1], rgb[2]));
                }
            }

            return newImage;
        }


        public static double[] PixelRGB2CMY(Color color)
        {
            double[] cmy = new double[3];
            double R = color.R;
            double G = color.G;
            double B = color.B;
            double r, g, b;

            r = R / 255;
            g = G / 255;
            b = B / 255;

            cmy[0] = 1 - r;
            cmy[1] = 1 - g;
            cmy[2] = 1 - b;

            return cmy;
        }


        // ----------------------------------------------------------------
        // Métodos DMA
        public static Bitmap RGB2GRAY_DMA(Bitmap bitmap)
        {
            var newImageGray = (Bitmap)bitmap.Clone();

            int width = bitmap.Width;
            int height = bitmap.Height;
            int pixelSize = 3;
            Int32 gs;

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = bitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = newImageGray.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            // No bitmap ao abri no final sobra uma faixa de padding, então tem que tirar, pois, irá dar erro
            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Dessa forma armazena em BGR: vai dando ++ para deslocar para o pixel da frente
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);
                        gs = (Int32)(r * 0.2990 + g * 0.5870 + b * 0.1140);
                        *(dst++) = (byte)gs;
                        *(dst++) = (byte)gs;
                        *(dst++) = (byte)gs;
                    }
                    // Ao terminar a linha pula a parte que estaria o padding da imagem, por isso tem que
                    // fazer dois for
                    src += padding;
                    dst += padding;
                }

            }
            //unlock imagem origem
            bitmap.UnlockBits(bitmapDataSrc);
            //unlock imagem destino
            newImageGray.UnlockBits(bitmapDataDst);


            return newImageGray;
        }

        public static Bitmap Binarization_DMA(Bitmap bitmap, int cutGray)
        {
            var newImageBinary = (Bitmap)bitmap.Clone();

            int width = bitmap.Width;
            int height = bitmap.Height;
            int pixelSize = 3;
            Int32 gs;

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = bitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = newImageBinary.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);
                        if (r > cutGray)
                        {
                            gs = 255;
                        }
                        else
                        {
                            gs = 0;
                        }
                        *(dst++) = (byte)gs;
                        *(dst++) = (byte)gs;
                        *(dst++) = (byte)gs;
                    }

                    src += padding;
                    dst += padding;
                }

            }
            //unlock imagem origem
            bitmap.UnlockBits(bitmapDataSrc);
            //unlock imagem destino
            newImageBinary.UnlockBits(bitmapDataDst);


            return newImageBinary;
        }

        public static Bitmap RGB2HSI_DMA_More_Brightness(Bitmap bitmap)
        {
            var newImage = (Bitmap)bitmap.Clone();

            double[] hsi = new double[3];
            Int32[] rgb = new Int32[3];
            double intensity;

            int width = bitmap.Width;
            int height = bitmap.Height;
            int pixelSize = 3;

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = bitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = newImage.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);
                        hsi = PixelRGB2HSI(Color.FromArgb(r, g, b));
                        // *** DUVIDA -> não tem jeito de limitar a 255 já aqui na converção?
                        // ai tiraria esses 3 ifs
                        intensity = hsi[2] + hsi[2] * 0.10;
                        // ---> Precisa fazer essa verificação ?
                        if (intensity < 245)
                        {
                            hsi[2] = intensity;
                        }
                        else
                        {
                            hsi[2] = 255;
                        }

                        rgb = PixelHSI2RGB(hsi);

                        // Ver se valor passou de 255
                        if (rgb[0] > 255)
                        {
                            rgb[0] = 255;
                        }
                        if (rgb[1] > 255)
                        {
                            rgb[1] = 255;
                        }
                        if (rgb[2] > 255)
                        {
                            rgb[2] = 255;
                        }
                        // ---------

                        *(dst++) = (byte)rgb[2];
                        *(dst++) = (byte)rgb[1];
                        *(dst++) = (byte)rgb[0];
                    }
                    src += padding;
                    dst += padding;
                }

            }
            //unlock imagem origem
            bitmap.UnlockBits(bitmapDataSrc);
            //unlock imagem destino
            newImage.UnlockBits(bitmapDataDst);


            return newImage;
        }

        public static Bitmap RGB2HSI_DMA_Less_Brightness(Bitmap bitmap)
        {
            var newImage = (Bitmap)bitmap.Clone();

            double[] hsi = new double[3];
            Int32[] rgb = new Int32[3];
            double intensity;

            int width = bitmap.Width;
            int height = bitmap.Height;
            int pixelSize = 3;

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = bitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = newImage.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);
                        hsi = PixelRGB2HSI(Color.FromArgb(r, g, b));
                        intensity = hsi[2] - hsi[2] * 0.10;
                        if (intensity > 0)
                        {
                            hsi[2] = intensity;
                        }
                        else
                        {
                            hsi[2] = 0;
                        }

                        rgb = PixelHSI2RGB(hsi);

                        *(dst++) = (byte)rgb[2];
                        *(dst++) = (byte)rgb[1];
                        *(dst++) = (byte)rgb[0];
                    }
                    src += padding;
                    dst += padding;
                }

            }
            //unlock imagem origem
            bitmap.UnlockBits(bitmapDataSrc);
            //unlock imagem destino
            newImage.UnlockBits(bitmapDataDst);


            return newImage;
        }

        public static Bitmap RGB2HSI_DMA_More_Hue(Bitmap bitmap)
        {
            var newImage = (Bitmap)bitmap.Clone();

            double[] hsi = new double[3];
            Int32[] rgb = new Int32[3];
            double hue;

            int width = bitmap.Width;
            int height = bitmap.Height;
            int pixelSize = 3;

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = bitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = newImage.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);
                        hsi = PixelRGB2HSI(Color.FromArgb(r, g, b));
                        hue = hsi[0] + 5;
                        // ---> Precisa fazer essa verificação ?
                        // *** Estava dando erro
                        if (hue < 350)
                        {
                            hsi[0] = hue;
                        }
                        else
                        {
                            hsi[0] = 360;
                        }

                        rgb = PixelHSI2RGB(hsi);

                        if (rgb[0] > 255)
                        {
                            rgb[0] = 255;
                        }
                        if (rgb[1] > 255)
                        {
                            rgb[1] = 255;
                        }
                        if (rgb[2] > 255)
                        {
                            rgb[2] = 255;
                        }

                        *(dst++) = (byte)rgb[2];
                        *(dst++) = (byte)rgb[1];
                        *(dst++) = (byte)rgb[0];
                    }
                    src += padding;
                    dst += padding;
                }

            }
            //unlock imagem origem
            bitmap.UnlockBits(bitmapDataSrc);
            //unlock imagem destino
            newImage.UnlockBits(bitmapDataDst);


            return newImage;
        }

        public static Bitmap RGB2HSI_DMA_Less_Hue(Bitmap bitmap)
        {
            var newImage = (Bitmap)bitmap.Clone();

            double[] hsi = new double[3];
            Int32[] rgb = new Int32[3];
            double intensity;

            int width = bitmap.Width;
            int height = bitmap.Height;
            int pixelSize = 3;

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = bitmap.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = newImage.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);
                        hsi = PixelRGB2HSI(Color.FromArgb(r, g, b));
                        intensity = hsi[0] - 10;
                        if (intensity > 0)
                        {
                            hsi[2] = intensity;
                        }
                        else
                        {
                            hsi[2] = 0;
                        }

                        rgb = PixelHSI2RGB(hsi);

                        *(dst++) = (byte)rgb[2];
                        *(dst++) = (byte)rgb[1];
                        *(dst++) = (byte)rgb[0];
                    }
                    src += padding;
                    dst += padding;
                }

            }
            //unlock imagem origem
            bitmap.UnlockBits(bitmapDataSrc);
            //unlock imagem destino
            newImage.UnlockBits(bitmapDataDst);


            return newImage;
        }

        public static Bitmap OtsuThreshold(Bitmap bitmap, int[] histogram)
        {
            int[] TresholdValue = new int[255];
            int temp = 0, temp2 = 0, temp3 = 0, temp4 = 0, temp5 = 0, temp6 = 0;
            int size = (bitmap.Height * bitmap.Width);

            int BWeight = 0, BMean = 0, BVariance = 0;
            int FWeight = 0, FMean = 0, FVariance = 0;

            int[] T = new int[256];
            int ClassVariance = 0;

            for (int i = 0; i < 256; i++)
            {
                temp = temp + histogram[i];
                BWeight = temp / size;

                temp2 = temp2 + (i * histogram[i]);
                if (temp == 0) { temp = 1; }

                BMean = temp2 / temp;

                temp3 = temp3 + ((int)Math.Sqrt(i - BMean) * histogram[i]);
                BVariance = temp3 / temp;


                for (int j = i + 1; j < 256; j++)
                {
                    temp4 = temp4 + histogram[j];
                    FWeight = temp4 / size;

                    temp5 = temp5 + (j * histogram[j]);
                    if (temp4 == 0) temp4 = 1;
                    FMean = temp5 / temp4;

                    temp6 = temp6 + ((int)Math.Sqrt(j - FMean) * histogram[j]);
                    FVariance = temp6 / temp4;
                }

                ClassVariance = (BWeight * BVariance + FWeight * FVariance);

                T[i] = ClassVariance;
            }

            int MinNumber = T[44], a = 0;

            for (int b = 1; b < 255; b++)
            {
                if (T[b] < MinNumber)
                {
                    MinNumber = T[b];
                    a = b;
                }
            }

            Bitmap bitmap2 = new Bitmap(bitmap.Height, bitmap.Width);
            int Threshold = 0;

            for (int i = 0; i < bitmap2.Height; i++)
            {
                for (int j = 0; j < bitmap2.Width; j++)
                {
                    Color c1 = bitmap.GetPixel(i, j);
                    if (c1.B > a) { Threshold = 255; }
                    else { Threshold = 0; }
                    bitmap2.SetPixel(i, j, Color.FromArgb(Threshold, Threshold, Threshold));
                }
            }
            return bitmap2;
        }


        private static int maiorValor(int[] hist)
        {
            for (int i = (hist.Length - 1); i >= 0; i--)
            {
                if (hist[i] != 0)
                    return i;
            }
            return 0;
        }

        private static void calcularHistograma(Bitmap img, int[] histograma)
        {
            Color pixel;
            int posTom;
            histograma = new int[256];
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    pixel = img.GetPixel(x, y);
                    posTom = pixel.R;
                    histograma[posTom]++;
                }
            }
        }


        public static Bitmap equalizarImagem(Bitmap imagem, int[] histograma)
        {
            Color pixel;
            int posTom, novoTom;
            float[] histogramaAcumulado = new float[256];

            calcularHistograma(imagem, histograma);

            //Calcula histograma acumulado
            float aux = histogramaAcumulado[0];
            for (int i = 1; i < histograma.Length; i++)
            {
                if (histograma[i] != 0)
                {
                    histogramaAcumulado[i] = (aux + ((float)histograma[i] / (imagem.Width * imagem.Height)));
                    aux = histogramaAcumulado[i];
                }
            }

            //Calcula mapa de cores
            int[] mapaCores = new int[256];
            int maior = maiorValor(histograma);
            for (int i = 0; i < histograma.Length; i++)
                mapaCores[i] = (int)(Math.Round(histogramaAcumulado[i] * maior));



            //Equalizando imagem
            Bitmap tempImg = new Bitmap(imagem.Width, imagem.Height);
            for (int m = 0; m < imagem.Width; m++)
            {
                for (int n = 0; n < imagem.Height; n++)
                {
                    pixel = imagem.GetPixel(m, n);
                    posTom = pixel.R;
                    novoTom = mapaCores[posTom];
                    tempImg.SetPixel(m, n, Color.FromArgb(novoTom, novoTom, novoTom));
                }
            }
            return tempImg;
        }     
            
         
    }
}
