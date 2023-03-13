using ImageEditor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    /*
               *** DÚVIDA ***
        --  Equalização de Histogram 
        -- Binarização com Otsu (extra)     
     */


    public partial class GrayForm : Form
    {
        private Bitmap _image;
        private int[] _shadesGray;
        public GrayForm(Bitmap image)
        {
            InitializeComponent();
            if (image != null)
            {
                this._image = image;
                pictureBoxGray.Image = this._image;
                this._shadesGray = new int[256];

                MakeBarGraph();
            }

        }

        private void MakeBarGraph()
        {
            int width = this._image.Width;
            int height = this._image.Height;
            int pixelSize = 3;

            //lock dados bitmap 
            BitmapData bitmapDataSrc = this._image.LockBits(new Rectangle(0, 0, width, height),
               ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            // No bitmap ao abri no final sobra uma faixa de padding, então tem que tirar, pois, irá dar erro
            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Dessa forma armazena em BGR: vai dando ++ para deslocar para o pixel da frente, 
                        // aqui precisamos deslocar todos os pixel, testar se doslocar mais 3 Bytes
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);
                        this._shadesGray[r]++;
                    }
                    // Ao terminar a linha pula a parte que estaria o padding da imagem, por isso tem que
                    // fazer dois for
                    src += padding;
                }

            }
            //unlock imagem origem
            this._image.UnlockBits(bitmapDataSrc);


            for (int i = 0; i < this._shadesGray.Length; i++)
            {
                chartLuminance.Series["Escala de Cinza"].Points.AddXY(i, this._shadesGray[i]);
            }
            
        }

        private void btnBinarization_Click(object sender, EventArgs e)
        {
            
            // Achar maior ocorrência de Pixel Cinza
            int biggerGray = this._shadesGray[0];
            int posBiggerGray = 0;
            int pos = 1;
            while(pos < this._shadesGray.Length)
            {
                if (this._shadesGray[pos] > biggerGray)
                {
                    biggerGray = this._shadesGray[pos];
                    posBiggerGray = pos;
                }
                pos++;
            }
            // -----------
            

            this._image = MyImageConverter.Binarization_DMA(this._image, posBiggerGray);
            pictureBoxGray.Image = this._image;

        }

        private void btnBinarizar_Click(object sender, EventArgs e)
        {
            int cutGray;
            if (int.TryParse(textBinarizar.Text, out cutGray))
            {
                this._image = MyImageConverter.Binarization_DMA(this._image, cutGray);
                pictureBoxGray.Image = this._image;
            }

        }
    }
}
