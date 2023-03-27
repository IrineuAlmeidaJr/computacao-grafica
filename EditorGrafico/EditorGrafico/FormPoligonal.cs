﻿using System;
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
    public partial class FormPoligonal : Form
    {
        public FormPoligonal()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
<<<<<<< Updated upstream
=======

        private void CarregarTela()
        {
            int w = pictureBoxPoligono.Height;
            int h = pictureBoxPoligono.Width;
            _imagem =
                new Bitmap(h, w, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(_imagem);
            pictureBoxPoligono.Image = _imagem;

            foreach (var poligono in listaPoligonos)
            {
                poligono.DesenharPoligono(_imagem, pictureBoxPoligono);
            }
        }

        private int PoligonoSelecionado()
        {
            int pos = 0;
            while (pos < listBox.Items.Count && !listBox.GetItemChecked(pos))
            {
                pos++;
            }

            if (pos < listBox.Items.Count)
            {
                return pos;
            }

            return -1;
        }

        private void listBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (listBox.CheckedItems.Count >= 1 && e.CurrentValue != CheckState.Checked)
            {
                e.NewValue = e.CurrentValue;

                MessageBox.Show("Você pode apenas selecionar um item");
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            if (e.Button == MouseButtons.Right)
            {
                if (pontosPoligono.Count > 2)
                {
                    x = pontosPoligono[0].X;
                    y = pontosPoligono[0].Y;
                    pontosPoligono.Add(new Ponto(x, y));                    

                    listaPoligonos.Add(new Poligono(pontosPoligono));

                    Poligono poligoAdicionado = listaPoligonos[listaPoligonos.Count - 1];
                    poligoAdicionado.DesenharPoligono(_imagem, pictureBoxPoligono);

                    listBox.Items.Add($"Poligono {numPoligono++}");

                    this.pontosPoligono = new List<Ponto>();
                }
            }
            else
            {
                pontosPoligono.Add(new Ponto(x, y));
                Ponto.DesenharReta(pontosPoligono, _imagem, pictureBoxPoligono);
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int posExcluir = PoligonoSelecionado();
            if (posExcluir != -1)
            {
                listaPoligonos.RemoveAt(posExcluir);
                listBox.Items.RemoveAt(posExcluir);

                CarregarTela();                
            }
        }

        private void btnRotacao_Click(object sender, EventArgs e)
        {
            int pos = PoligonoSelecionado();
            if (pos != -1)
            {
                try
                {
                    int rotacao = Convert.ToInt32(tbRotacao.Text);

                    if (rbCentro.Checked)
                    {

                    }
                    else if (rbOrigem.Checked)
                    {

                    }
                    else if (rbCoordenada.Checked)
                    {
                        int coordenadaX = Convert.ToInt32(txCordX.Text);
                        int coordenadaY = Convert.ToInt32(txCordY.Text);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("O valor informado deve ser um número");
                }
            }            
        }

        private void btnTranslacao_Click(object sender, EventArgs e)
        {
            int pos = PoligonoSelecionado();
            if (pos != -1)
            {
                try
                {                   
                    int dX = Convert.ToInt32(tbTranslacaoX.Text);
                    int dY = Convert.ToInt32(tbTranslacaoY.Text);

                    Poligono poligono = this.listaPoligonos[pos];
                    poligono.Translacao(dX, dY);

                    CarregarTela();
                }
                catch (FormatException)
                {
                    MessageBox.Show("O valor informado deve ser um número");
                }
            }            
        }

        private void btnEscala_Click(object sender, EventArgs e)
        {
            int pos = PoligonoSelecionado();
            if (pos != -1)
            {
                Poligono poligono = this.listaPoligonos[pos];
                try
                {
                    double escalaPontoX = Convert.ToDouble(tbEscalaX.Text);
                    double escalaPontoY = Convert.ToDouble(tbEscalaY.Text);

                    if (rbCentro.Checked)
                    {

                    }
                    else if (rbOrigem.Checked)
                    {
                        int x = 0;
                        int y = 0;
                    }
                    else if (rbCoordenada.Checked)
                    {
                        //int x = Convert.ToInt32(txCordX.Text);
                        //int y = Convert.ToInt32(txCordY.Text);

                        poligono.Escala(escalaPontoX, escalaPontoY);

                        CarregarTela();
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("O valor informado deve ser um número");
                }
            }
        }
>>>>>>> Stashed changes
    }
}
