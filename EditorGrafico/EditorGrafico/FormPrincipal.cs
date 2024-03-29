﻿using EditorGrafico.models;
using EditorGrafico.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafico
{
    public partial class FormPrincipal : Form
    {
        int x1, x2, y1, y2;
        private Bitmap _imagem;               

        public FormPrincipal()
        {
            InitializeComponent();
            int w = pictureBox.Height;
            int h = pictureBox.Width;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            _imagem =
              new Bitmap(h, w, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            CarregarTela();
        }

        private void CarregarTela()
        {
            int w = pictureBox.Height;
            int h = pictureBox.Width;
            _imagem =
               new Bitmap(h, w, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(_imagem);
            pictureBox.Image = _imagem;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            CarregarTela();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1= e.Y;    
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            x2 = e.X;
            y2 = e.Y;

            if (x2 >= 0 && x2 <= _imagem.Width && y2 >=0 && y2 <= _imagem.Height)
            {
                // ---> RETA
                if (rbReta1.Checked)
                {
                    Reta.EquacaoRealReta(x1, y1, x2, y2, _imagem);
                }
                else if (rbReta2.Checked)
                {
                    Reta.DigitalDifferentialAnalyzer(x1, y1, x2, y2, _imagem);
                }
                else if (rbReta3.Checked)
                {
                    Reta.PontoMedio(x1, y1, x2, y2, _imagem);
                }

                // ---> CIRCUNFERÊNCIA
                if (rbCircunferencia1.Checked)
                {                    
                    Circunferencia.EquacaoReal(x1, y1, x2, y2, _imagem);
                }
                else if (rbCircunferencia2.Checked)
                {
                    Circunferencia.EquacaoTrig(x1, y1, x2, y2, _imagem);
                }
                else if (rbCircunferencia3.Checked)
                {
                    Circunferencia.PontoMedio(x1, y1, x2, y2, _imagem);
                }

                // ---> CIRCUNFERÊNCIA
                if (rbElipse.Checked)
                {
                    Elipse.PontoMedio(x1, y1, x2, y2, _imagem);
                    //Circunferencia.EquacaoReal(x1, y1, x2, y2, _imagem);
                }






                pictureBox.Image = _imagem;
            }      
            
        }

        private void btnPoligonal_Click(object sender, EventArgs e)
        {
            var formPolinomial = new FormPoligonal();
            formPolinomial.ShowDialog();
        }
    }
}
