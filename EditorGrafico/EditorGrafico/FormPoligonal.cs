using EditorGrafico.models;
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
    public partial class FormPoligonal : Form
    {
        private int numPoligono;

        private List<Ponto> pontosPoligono;
        private List<Poligono> listaPoligonos;

        private Bitmap _imagem;

        public FormPoligonal()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.numPoligono = 1;
            this.pontosPoligono = new List<Ponto>();
            this.listaPoligonos = new List<Poligono>();

            CarregarTela();
        }

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
            double x = e.X;
            double y = e.Y;

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
                Poligono pAtual = listaPoligonos[pos];
                try
                {
                    int rotacao = Convert.ToInt32(tbRotacao.Text);
                    int eixoX, eixoY;                    
                    
                    if (rbCentro.Checked)
                    {
                        // Calcular o Centro 
                        eixoX = 0;
                        eixoY = 0;
                        double[] centroide = pAtual.Centroide();

                        


                    }
                    else if (rbOrigem.Checked)
                    {
                        eixoX = 0;
                        eixoY = 0;

                    }
                    else if (rbCoordenada.Checked)
                    {
                        eixoX = Convert.ToInt32(txCordX.Text);
                        eixoY = Convert.ToInt32(txCordY.Text);
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
                Poligono poligono = listaPoligonos[pos];
                try
                {
                    double rotacao = Convert.ToDouble(tbRotacao.Text);
                    double eixoX, eixoY;

                    if (rbCentro.Checked)
                    {
                        eixoX = 0;
                        eixoY = 0;



                    }
                    else if (rbOrigem.Checked)
                    {
                        // Calcular o Centro 
                        eixoX = Convert.ToDouble(tbTranslacaoX);
                        eixoY = Convert.ToDouble(tbTranslacaoY);

                       




                    }
                    else if (rbCoordenada.Checked)
                    {
                        eixoX = Convert.ToInt32(txCordX.Text);
                        eixoY = Convert.ToInt32(txCordY.Text);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("O valor informado deve ser um número real");
                }
            }
        }
    }
}
