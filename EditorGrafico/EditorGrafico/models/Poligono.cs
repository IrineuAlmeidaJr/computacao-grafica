using EditorGrafico.models.rasterizacao;
using EditorGrafico.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafico.models
{
    public class Poligono
    {
        public List<Ponto> PontosOriginais { get; set; }
        public List<Ponto> Pontos { get; set; }
        public double[,] MatrizAcumulada { get; set; }
        private bool _colorido;
        public string NomeCor { get; set; }


        public Poligono(List<Ponto> pontos)
        {
            _colorido = false;
            NomeCor = string.Empty;
            Pontos = new List<Ponto>(pontos);
            PontosOriginais = new List<Ponto>(pontos);
            this.MatrizAcumulada = new double[3,3];
            // Matriz Identidade
            for (int i = 0; i < 3; i++)
            {
                this.MatrizAcumulada[i, i] = 1;
            }
        }

        public void DesenharPoligono(Bitmap imagem, PictureBox pictureBoxPoligono)
        {
            if (this.Pontos.Count > 1)
            {
                int ate = this.Pontos.Count - 1;
                for (int i = 0; i < ate; i++)
                {
                    Ponto.PontoMedio(this.Pontos[i].X, this.Pontos[i].Y,
                    this.Pontos[i + 1].X, this.Pontos[i + 1].Y, imagem);
                }
                Ponto.PontoMedio(this.Pontos[ate].X, this.Pontos[ate].Y,
                    this.Pontos[0].X, this.Pontos[0].Y, imagem);

                if (_colorido)
                {
                    //FloodFill(imagem);
                    Rasterizacao(pictureBoxPoligono.Width, imagem);
                }
                            

                pictureBoxPoligono.Image = imagem;
            }

        }

        public void FloodFill(Bitmap imagem)
        {
            try
            {
                Color corPreenchimento;
                switch (NomeCor)
                {
                    case "Vermelho":
                        corPreenchimento = Color.Red; 
                        break;
                    case "Azul":
                        corPreenchimento = Color.Blue;
                        break;
                    case "Verde":
                        corPreenchimento = Color.Green;
                        break;
                    case "Amarelo":
                        corPreenchimento = Color.Yellow;
                        break;
                    case "Roxo":
                        corPreenchimento = Color.Purple;
                        break;
                    default:
                        corPreenchimento = Color.Red;
                        break;
                }


                double[] centroide = Centroide();

                Ponto ponto = null;
                Stack<Ponto> stack = new Stack<Ponto>();
                stack.Push(new Ponto((int)centroide[0], (int)centroide[1]));
                while (stack.Count > 0)
                {
                    ponto = stack.Pop();
                    Color color = imagem.GetPixel(ponto.X, ponto.Y);
                    string nameColor = color.Name;
                    bool temp = nameColor == "0";
                    if (temp)
                    {
                        imagem.SetPixel(ponto.X, ponto.Y, corPreenchimento);

                        //FloodFill(x + 1, y);
                        stack.Push(new Ponto(ponto.X + 1, ponto.Y));

                        //FloodFill(x, y + 1);
                        stack.Push(new Ponto(ponto.X, ponto.Y + 1));

                        //FloodFill(x - 1, y);
                        stack.Push(new Ponto(ponto.X - 1, ponto.Y));

                        //FloodFill(x, y - 1);
                        stack.Push(new Ponto(ponto.X, ponto.Y - 1));

                    }
                }

                _colorido = true;
            }
            catch
            {
                MessageBox.Show("Erro ao Pintar !!!");
                _colorido = false;
            }


        }

        public double[] Centroide()
        {
            double cX, cY;
            cX = cY = 0;
            foreach (var ponto in PontosOriginais)
            {
                cX += ponto.X;
                cY += ponto.Y;
            }
            cX /= PontosOriginais.Count;
            cY /= PontosOriginais.Count;

            return new double[2] { cX , cY };
        }

        public void MatrizAcumuladaPontos()
        {
            int x, y;
            Pontos.Clear();
            foreach (var ponto in PontosOriginais)
            {
                x = (int)(ponto.X * MatrizAcumulada[0, 0] + ponto.Y * MatrizAcumulada[0, 1] + MatrizAcumulada[0, 2]);
                y = (int)(ponto.X * MatrizAcumulada[1, 0] + ponto.Y * MatrizAcumulada[1, 1] + MatrizAcumulada[1, 2]);
                Pontos.Add(new Ponto(x, y));
            }
        }

        public void Rotacao(int graus)
        {
            double radiano = (Math.PI / 180) * graus;
            double[,] matrizRotacao;
            matrizRotacao = new double[3, 3];
            double[,] novaMatrizAcumulada;
            novaMatrizAcumulada = new double[3, 3];
            // Matriz Acumulada
            for (int i = 0; i < 3; i++)
            {
                matrizRotacao[i, i] = 1;
            }
            // Matriz Rotacao
            matrizRotacao[0, 0] = Math.Cos(radiano);
            matrizRotacao[0, 1] = -Math.Sin(radiano);
            matrizRotacao[1, 0] = Math.Sin(radiano);
            matrizRotacao[1, 1] = Math.Cos(radiano);

            // Nova_Matriz = R * MA
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        novaMatrizAcumulada[linha, coluna] += matrizRotacao[linha, i] * MatrizAcumulada[i, coluna];
                    }
                }
            }

            this.MatrizAcumulada = novaMatrizAcumulada;

            MatrizAcumuladaPontos();
        }

        
        public void RotacaoCentro(int graus, double eixoX=0, double eixoY=0)
        {
            double[] coordenadasXY;
            if (eixoX == 0 && eixoY == 0)
            {
                coordenadasXY = Centroide();
            }
            else
            {
                coordenadasXY = new double[] { eixoX, eixoY };
            }            
            double radiano = (Math.PI / 180) * graus;
            double[,] matrizRotacao = new double[3,3];
            double[,] matrizTranslacao_origem = new double[3, 3];
            double[,] matrizTranslacao_centroide= new double[3, 3];
            double[,] matrizResultante_1 = new double[3, 3];
            double[,] matrizResultante_2 = new double[3, 3];
            double[,] novaMatrizAcumulada = new double[3, 3];

            // Matriz Identidade
            for (int i=0; i < 3; i++)
            {
                matrizRotacao[i, i] = 1;
                matrizTranslacao_origem[i, i] = 1;
                matrizTranslacao_centroide[i, i] = 1;
            }

            matrizRotacao[0,0] = Math.Cos(radiano);
            matrizRotacao[0,1] = -Math.Sin(radiano);
            matrizRotacao[1,0] = Math.Sin(radiano);
            matrizRotacao[1,1] = Math.Cos(radiano);

            matrizTranslacao_origem[0,2] = -coordenadasXY[0];
            matrizTranslacao_origem[1,2] = -coordenadasXY[1];

            matrizTranslacao_centroide[0, 2] = coordenadasXY[0];
            matrizTranslacao_centroide[1, 2] = coordenadasXY[1];


            // MA_Nova = T(cent) * R * T(ori) * P(MA)
            // matrizResultante_1 = T(cent) * R 
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matrizResultante_1[linha, coluna] += matrizTranslacao_centroide[linha,i] * matrizRotacao[i, coluna];
                    }                        
                }
            }
            // matrizResultante_2 = matrizResultante_1 * T(ori)
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matrizResultante_2[linha, coluna] += matrizResultante_1[linha, i] * matrizTranslacao_origem[i, coluna];
                    }
                }
            }
            // Nova Matriz Acumulada
            // Nova_MatrizAcumulada = matrizResultante_2 * MatrizAcumulada
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        novaMatrizAcumulada[linha, coluna] += matrizResultante_2[linha, i] * this.MatrizAcumulada[i, coluna];
                    }
                }
            }
            
            this.MatrizAcumulada = novaMatrizAcumulada;

            MatrizAcumuladaPontos();


        }

        public void Translacao(int dX, int dY)
        {
            double[,] matrizTranslacao = new double[3, 3];
            double[,] novaMatrizAcumulada = new double[3, 3];
            // Matriz Identidade
            for (int i = 0; i < 3; i++)
            {
                matrizTranslacao[i, i] = 1;
            }
            // Matriz Translação
            matrizTranslacao[0, 2] = dX;
            matrizTranslacao[1, 2] = dY;
            //  NovaMA = T * MA
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        novaMatrizAcumulada[linha, coluna] += matrizTranslacao[linha, i] * this.MatrizAcumulada[i, coluna];
                    }
                }
            }

            this.MatrizAcumulada = novaMatrizAcumulada;

            MatrizAcumuladaPontos();

        }

        public void Escala(double sX, double sY)
        {
            double[,] matrizEscala = new double[3, 3];
            double[,] novaMatrizAcumulada = new double[3, 3];
            // Matriz Identidade
            for (int i = 0; i < 3; i++)
            {
                matrizEscala[i, i] = 1;
            }
            // Matriz Escala
            matrizEscala[0, 0] = sX;
            matrizEscala[1, 1] = sY;
            //  NovaMA = E * MA
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        novaMatrizAcumulada[linha, coluna] += matrizEscala[linha, i] * this.MatrizAcumulada[i, coluna];
                    }
                }
            }

            this.MatrizAcumulada = novaMatrizAcumulada;

            MatrizAcumuladaPontos();

        }

        public void EscalaCentro(double sX, double sY, int eixoX = 0, int eixoY = 0)
        {
            double[] cordenadasXY;
            if (eixoX == 0 && eixoY == 0)
            {
                cordenadasXY = Centroide();
            }
            else
            {
                cordenadasXY = new double[] { eixoX, eixoY };
            }

            double[,] matrizEscala = new double[3, 3];
            double[,] matrizTranslacao_origem = new double[3, 3];
            double[,] matrizTranslacao_centroide = new double[3, 3];
            double[,] matrizResultante_1 = new double[3, 3];
            double[,] matrizResultante_2 = new double[3, 3];
            double[,] novaMatrizAcumulada = new double[3, 3];

            double[,] matrizAcumulada = new double[3, 1];
            // Matriz Identidade
            for (int i = 0; i < 3; i++)
            {
                matrizEscala[i, i] = 1;
                matrizTranslacao_origem[i, i] = 1;
                matrizTranslacao_centroide[i, i] = 1;
            }

            matrizEscala[0, 0] = sX;
            matrizEscala[1, 1] = sY;

            matrizTranslacao_origem[0, 2] = -cordenadasXY[0]; // X
            matrizTranslacao_origem[1, 2] = -cordenadasXY[1]; // Y

            matrizTranslacao_centroide[0, 2] = cordenadasXY[0]; // X
            matrizTranslacao_centroide[1, 2] = cordenadasXY[1]; // Y


            // NovaMA = T(cent) * E * T(ori) * MA
            // matrizResultante_1 = T(cent) * E
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matrizResultante_1[linha, coluna] += matrizTranslacao_centroide[linha, i] * matrizEscala[i, coluna];
                    }
                }
            }
            // matrizResultante_2 = matrizResultante_1 *  T(ori)
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matrizResultante_2[linha, coluna] += matrizResultante_1[linha, i] * matrizTranslacao_origem[i, coluna];
                    }
                }
            }
            // NovaMA = matrizResultante_2 *  MA
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        novaMatrizAcumulada[linha, coluna] += matrizResultante_2[linha, i] * this.MatrizAcumulada[i, coluna];
                    }
                }
            }

            this.MatrizAcumulada = novaMatrizAcumulada;

            MatrizAcumuladaPontos();


        }


        public void Cisalhamento(double x, double y)
        {
            double[,] matrizCisalhamentoX = new double[3, 3];
            double[,] matrizCisalhamentoY = new double[3, 3];
            double[,] matrizResultante = new double[3, 3];
            double[,] novaMatrizAcumulada = new double[3, 3];
            // Matriz Identidade
            for (int i = 0; i < 3; i++)
            {
                matrizCisalhamentoX[i, i] = 1;
                matrizCisalhamentoY[i, i] = 1;
            }
            // Matriz Cisalahamento
            matrizCisalhamentoX[0, 1] = y;
            matrizCisalhamentoY[1, 0] = x;

            // matrizResultante_1 = matrizCisalhamentoY * matrizCisalhamentoX
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matrizResultante[linha, coluna] += matrizCisalhamentoY[linha, i] * matrizCisalhamentoX[i, coluna];
                    }
                }
            }
            // novaMatrizAcumulada = matrizCisalhamentoY * matrizCisalhamentoX
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        novaMatrizAcumulada[linha, coluna] += matrizResultante[linha, i] * MatrizAcumulada[i, coluna];
                    }
                }
            }

            MatrizAcumulada = matrizResultante;

            MatrizAcumuladaPontos();
        }

        public void CisalhamentoCentro(double x, double y, int eixoX = 0, int eixoY = 0)
        {
            double[] coordenadasXY;
            if (eixoX == 0 && eixoY == 0)
            {
                coordenadasXY = Centroide();
            }
            else
            {
                coordenadasXY = new double[] { eixoX, eixoY };
            }

            double[,] matrizCisalhamento = new double[3, 3];
            double[,] matrizTranslacao_origem = new double[3, 3];
            double[,] matrizTranslacao_centroide = new double[3, 3];
            double[,] matrizResultante_1 = new double[3, 3];
            double[,] matrizResultante_2 = new double[3, 3];
            double[,] novaMatrizAcumulada = new double[3, 3];

            double[,] matrizAcumulada = new double[3, 1];
            // Matriz Identidade
            for (int i = 0; i < 3; i++)
            {
                matrizCisalhamento[i, i] = 1;
                matrizTranslacao_origem[i, i] = 1;
                matrizTranslacao_centroide[i, i] = 1;
            }

            matrizCisalhamento[0, 1] = y;
            matrizCisalhamento[1, 0] = x; // Ver se de erro é pq tem fazer mat 2

            matrizTranslacao_origem[0, 2] = -coordenadasXY[0]; // X
            matrizTranslacao_origem[1, 2] = -coordenadasXY[1]; // Y

            matrizTranslacao_centroide[0, 2] = coordenadasXY[0]; // X
            matrizTranslacao_centroide[1, 2] = coordenadasXY[1]; // Y

            // NovaMA = T(cent) * Cisalhamento * T(ori) * MA
            // matrizResultante_1 = T(cent) * Cisalhamento
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matrizResultante_1[linha, coluna] += matrizTranslacao_centroide[linha, i] * matrizCisalhamento[i, coluna];
                    }
                }
            }
            // matrizResultante_2 = matrizResultante_1 *  T(ori)
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matrizResultante_2[linha, coluna] += matrizResultante_1[linha, i] * matrizTranslacao_origem[i, coluna];
                    }
                }
            }
            // NovaMA = matrizResultante_2 *  MA
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        novaMatrizAcumulada[linha, coluna] += matrizResultante_2[linha, i] * this.MatrizAcumulada[i, coluna];
                    }
                }
            }

            this.MatrizAcumulada = novaMatrizAcumulada;

            MatrizAcumuladaPontos();

        }

        public void Espelhamento(string escolhido)
        {
            double[] coordenadasXY = Centroide();

            double[,] matrizEspelhamento = new double[3, 3];
            double[,] matrizTranslacao_origem = new double[3, 3];
            double[,] matrizTranslacao_centroide = new double[3, 3];
            double[,] matrizResultante_1 = new double[3, 3];
            double[,] matrizResultante_2 = new double[3, 3];
            double[,] novaMatrizAcumulada = new double[3, 3];

            double[,] matrizAcumulada = new double[3, 1];
            // Matriz Identidade
            for (int i = 0; i < 3; i++)
            {
                matrizTranslacao_origem[i, i] = 1;
                matrizTranslacao_centroide[i, i] = 1;
            }


            matrizTranslacao_origem[0, 2] = -coordenadasXY[0]; // X
            matrizTranslacao_origem[1, 2] = -coordenadasXY[1]; // Y

            matrizTranslacao_centroide[0, 2] = coordenadasXY[0]; // X
            matrizTranslacao_centroide[1, 2] = coordenadasXY[1]; // Y


            switch(escolhido)
            {
                case "X":
                    matrizEspelhamento[0, 0] = 1;
                    matrizEspelhamento[1, 1] = -1;
                    matrizEspelhamento[2, 2] = 1;
                    break;
                case "Y":
                    matrizEspelhamento[0, 0] = -1;
                    matrizEspelhamento[1, 1] = 1;
                    matrizEspelhamento[2, 2] = 1;
                    break;
                case "XY":
                    matrizEspelhamento[0, 0] = -1;
                    matrizEspelhamento[1, 1] = -1;
                    matrizEspelhamento[2, 2] = 1;
                    break;
            }


            // NovaMA = T(cent) * Espalhamento * T(ori) * MA
            // matrizResultante_1 = T(cent) * Espalhamento
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matrizResultante_1[linha, coluna] += matrizTranslacao_centroide[linha, i] * matrizEspelhamento[i, coluna];
                    }
                }
            }
            // matrizResultante_2 = matrizResultante_1 *  T(ori)
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matrizResultante_2[linha, coluna] += matrizResultante_1[linha, i] * matrizTranslacao_origem[i, coluna];
                    }
                }
            }
            // NovaMA = matrizResultante_2 *  MA
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        novaMatrizAcumulada[linha, coluna] += matrizResultante_2[linha, i] * this.MatrizAcumulada[i, coluna];
                    }
                }
            }

            this.MatrizAcumulada = novaMatrizAcumulada;

            MatrizAcumuladaPontos();

        }

        public void Rasterizacao(int maxY, Bitmap imagem)
        {
            try
            {
                EdgeTable lista = new EdgeTable(maxY);
                lista.Inicializar(Pontos);

                Color corPreenchimento;
                switch (NomeCor)
                {
                    case "Vermelho":
                        corPreenchimento = Color.Red;
                        break;
                    case "Azul":
                        corPreenchimento = Color.Blue;
                        break;
                    case "Verde":
                        corPreenchimento = Color.Green;
                        break;
                    case "Amarelo":
                        corPreenchimento = Color.Yellow;
                        break;
                    case "Roxo":
                        corPreenchimento = Color.Purple;
                        break;
                    default:
                        corPreenchimento = Color.Red;
                        break;
                }

                lista.Preencher(imagem, corPreenchimento);

                _colorido = true;
            }
            catch
            {
                MessageBox.Show("Erro ao Pintar !!!");
                _colorido = false;
            }


           

        }



    }
}
