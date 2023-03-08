using ImageEditor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class MainForm : Form
    {
        private Bitmap _image;
        private Bitmap _imageBackup;
        private Bitmap _imageUndoModification;
        //private List<List<double[]>> _HSI;

        public MainForm()
        {
            InitializeComponent();
        }

        private void toolOpenImage_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files| *.jpg; *.jpeg; *.png; *.bmp; *.tiff;";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        this._image = new Bitmap(ofd.FileName);
                        this._imageBackup = (Bitmap)this._image.Clone();
                        this._imageUndoModification = (Bitmap)this._image.Clone();
                        //this._HSI = MyImageConverter.RGB2HSI(this._image);

                        pictureBoxMain.Image = this._image;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"ERROR: {error}");
            }

        }

        private void tollRestoreImage_Click(object sender, EventArgs e)
        {
            if (this._image != null)
            {
                this._image = (Bitmap)this._imageBackup.Clone();
                this._imageBackup = (Bitmap)this._image.Clone();
                //this._HSI = MyImageConverter.RGB2HSI(this._imageBackup);
                pictureBoxMain.Image = this._image;
            }
        }

        private void toolCloseProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (this._image != null)
            {
                int x = e.X;
                int y = e.Y;
                Color color = this._image.GetPixel(x, y);

                // RGB
                labelTextR.Text = $"{color.R}";
                labelTextG.Text = $"{color.G}";
                labelTextB.Text = $"{color.B}";

                // RG2CMY
                double[] cmy = MyImageConverter.PixelRGB2CMY(color);
                labelTextC.Text = cmy[0].ToString("N4");
                labelTextM.Text = cmy[1].ToString("N4");
                labelTextY.Text = cmy[2].ToString("N4");

                // RGB2HSI
                double[] hsi = MyImageConverter.PixelRGB2HSI(color);
                labelTextH.Text = hsi[0].ToString("N4");
                labelTextS.Text = hsi[1].ToString("N4");
                labelTextI.Text = hsi[2].ToString("N4");
            }
        }

        private void btnMoreB_Click(object sender, EventArgs e)
        {
            if (this._image != null)
            {
                this._imageUndoModification = (Bitmap)this._image.Clone();

                /*
                double intensity;
                double[] hsi;

                List<double[]> tempHSI;
                for (int x = 0; x < this._image.Width; x++)
                {
                    tempHSI = this._HSI[x];
                    for (int y = 0; y < this._image.Height; y++)
                    {
                        hsi = tempHSI[y];
                        intensity = hsi[2];
                        
                        intensity += intensity * 0.10;                        

                        hsi[2] = intensity;
                    }
                }
                */



                this._image = MyImageConverter.RGB2HSI_DMA_More_Brightness(this._image);
                pictureBoxMain.Image = this._image;
            }
        }

        private void btnLessB_Click(object sender, EventArgs e)
        {
            if (this._image != null)
            {
                this._imageUndoModification = (Bitmap)this._image.Clone();

                /*
                double intensity;
                double[] hsi;

                List<double[]> tempHSI;
                for (int x = 0; x < this._image.Width; x++)
                {
                    tempHSI = _HSI[x];
                    for (int y = 0; y < this._image.Height; y++)
                    {
                        hsi = tempHSI[y];
                        intensity = hsi[2];
                        if ((intensity - 10) >= 0)
                        {
                            intensity -= 10;
                        }
                        else
                        {
                            intensity -= 0;
                        }

                        hsi[2] = intensity;
                    }
                }
                */

                this._image = MyImageConverter.RGB2HSI_DMA_Less_Brightness(this._image);
                pictureBoxMain.Image = this._image;
            }
        }

        private void btnMoreH_Click(object sender, EventArgs e)
        {
            if (this._image != null)
            {
                this._imageUndoModification = (Bitmap)this._image.Clone();

                /*
                double hue;
                double[] hsi;

                List<double[]> tempHSI;
                for (int x = 0; x < this._image.Width; x++)
                {
                    tempHSI = _HSI[x];
                    for (int y = 0; y < this._image.Height; y++)
                    {
                        hsi = tempHSI[y];
                        hue = hsi[0];
                        if ((hue + 10) < 360)
                        {
                            hue += 10;
                        }
                        else
                        {
                            hue = 360;
                        }

                        hsi[0] = hue;
                    }
                }
                */

                this._image = MyImageConverter.RGB2HSI_DMA_More_Hue(this._image);
                //this._image = MyImageConverter.HSI2RGB(this._image, this._HSI);
                pictureBoxMain.Image = this._image;
            }
        }

        private void btnLessH_Click(object sender, EventArgs e)
        {
            if (this._image != null)
            {
                this._imageUndoModification = (Bitmap)this._image.Clone();

                /*
                double hue;
                double[] hsi;

                List<double[]> tempHSI;
                for (int x = 0; x < this._image.Width; x++)
                {
                    tempHSI = _HSI[x];
                    for (int y = 0; y < this._image.Height; y++)
                    {
                        hsi = tempHSI[y];
                        hue = hsi[0];
                        if ((hue - 10) >= 0)
                        {
                            hue -= 10;
                        }
                        else
                        {
                            hue -= 0;
                        }

                        hsi[0] = hue;
                    }
                }
                */

                this._image = MyImageConverter.RGB2HSI_DMA_More_Hue(this._image);
                //this._image = MyImageConverter.HSI2RGB(this._image, this._HSI);
                pictureBoxMain.Image = this._image;
            }
        }

        private void btnLuminance_Click(object sender, EventArgs e)
        {
            if (this._image != null)
            {
                this._imageUndoModification = (Bitmap)this._image.Clone();
                //this._image = MyImageConverter.RGB2GRAY(this._image);
                this._image = MyImageConverter.RGB2GRAY_DMA(this._image);
                pictureBoxMain.Image = this._image;

                var grayForm = new GrayForm((Bitmap)this._image.Clone());
                grayForm.ShowDialog();
            }

        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (this._imageUndoModification != null)
            {
                this._image = (Bitmap)this._imageUndoModification.Clone();
                pictureBoxMain.Image = this._image;
            } 
        }

    }
}
