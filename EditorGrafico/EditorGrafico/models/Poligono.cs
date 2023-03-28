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
        public List<Ponto> Pontos { get; set; }

        public Poligono(List<Ponto> pontos)
        {
            Pontos = pontos;
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

                pictureBoxPoligono.Image = imagem;
            }

        }

        public double Area()
        {
            double somatorio = 0;
            for(int i=0; i<this.Pontos.Count -1 ; i++)
            {
                somatorio += Pontos[i].X * Pontos[i + 1].Y - Pontos[i + 1].X * Pontos[i].Y;
            }

            return somatorio / 2;
        }


        public int[] Centroide()
        {
            int cX, cY;

            int somatorio = 0;
            double area = Area();

            for (int i = 0; i < Pontos.Count - 1; i++)
            {
                somatorio += (Pontos[i].X + Pontos[i + 1].X) * (Pontos[i].X * Pontos[i + 1].Y - Pontos[i + 1].X * Pontos[i].Y);
            }
            cX = (int)(somatorio / (6 * area));

            somatorio = 0;
            for (int i = 0; i < Pontos.Count - 1; i++)
            {
                somatorio += (Pontos[i].Y + Pontos[i + 1].Y) * (Pontos[i].X * Pontos[i + 1].Y - Pontos[i + 1].X * Pontos[i].Y);
            }
            cY = (int)(somatorio / (6 * area));

            return new int[2] { cX , cY };
        }

        public void Rotacao(int graus)
        {
            double radiano = (Math.PI / 180) * graus;
            foreach (var ponto in Pontos)
            {
                ponto.X = (int)(ponto.X * Math.Cos(radiano) - ponto.Y * Math.Sin(radiano));
                ponto.Y = (int)(ponto.X * Math.Sin(radiano) + ponto.Y * Math.Cos(radiano));
            }
        }

        public void RotacaoCentro(int graus, int eixoX=0, int eixoY=0)
        {
            int[] cordenadasXY;
            if (eixoX == 0 && eixoY == 0)
            {
                cordenadasXY = Centroide();
            }
            else
            {
                cordenadasXY = new int[] { eixoX, eixoY };
            }            
            double radiano = (Math.PI / 180) * graus;
            double[,] matrizRotacao = new double[3,3];
            double[,] matrizTranslacao_origem = new double[3, 3];
            double[,] matrizTranslacao_centroide= new double[3, 3];
            double[,] matrizResultante_1 = new double[3, 3];
            double[,] matrizResultante_2 = new double[3, 3];

            double[,] matrizAcumulada = new double[3, 1];
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

            matrizTranslacao_origem[0,2] = -cordenadasXY[0];
            matrizTranslacao_origem[1,2] = -cordenadasXY[1];

            matrizTranslacao_centroide[0, 2] = cordenadasXY[0];
            matrizTranslacao_centroide[1, 2] = cordenadasXY[1];


            // P' = T(cent) * R * T(ori) * P
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


            foreach (var ponto in Pontos)
            {               
                for (int linha = 0; linha < 3; linha++)
                {                
                    matrizAcumulada[linha, 0] += matrizResultante_2[linha, 0] * ponto.X;
                    matrizAcumulada[linha, 0] += matrizResultante_2[linha, 1] * ponto.Y;
                    matrizAcumulada[linha, 0] += matrizResultante_2[linha, 2] * 1;
                                      
                }
                ponto.X = (int)(matrizAcumulada[0, 0]);
                ponto.Y = (int)(matrizAcumulada[1, 0]);

                matrizAcumulada[0,0] = 0;
                matrizAcumulada[1,0] = 0;
                matrizAcumulada[2,0] = 0;
            }

        }

        public void Translacao(int dX, int dY)
        {
            foreach (var ponto in Pontos)
            {
                ponto.X += dX;
                ponto.Y += dY;
            }
        }

        public void Escala(double sX, double sY)
        {
            // Seria multiplicação de matriz, mas, nesse caso não precisa
            foreach (var ponto in Pontos)
            {
                ponto.X = (int)(ponto.X * sX);
                ponto.Y = (int)(ponto.Y * sY);
            }
        }

        public void EscalaCentro(double sX, double sY, int eixoX = 0, int eixoY = 0)
        {
            int[] cordenadasXY;
            if (eixoX == 0 && eixoY == 0)
            {
                cordenadasXY = Centroide();
            }
            else
            {
                cordenadasXY = new int[] { eixoX, eixoY };
            }

            double[,] matrizEscala = new double[3, 3];
            double[,] matrizTranslacao_origem = new double[3, 3];
            double[,] matrizTranslacao_centroide = new double[3, 3];
            double[,] matrizResultante_1 = new double[3, 3];
            double[,] matrizResultante_2 = new double[3, 3];

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


            // P' = T(cent) * E * T(ori) * P
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


            foreach (var ponto in Pontos)
            {
                for (int linha = 0; linha < 3; linha++)
                {
                    matrizAcumulada[linha, 0] += matrizResultante_2[linha, 0] * ponto.X;
                    matrizAcumulada[linha, 0] += matrizResultante_2[linha, 1] * ponto.Y;
                    matrizAcumulada[linha, 0] += matrizResultante_2[linha, 2] * 1;

                }
                ponto.X = (int)(matrizAcumulada[0, 0]);
                ponto.Y = (int)(matrizAcumulada[1, 0]);

                matrizAcumulada[0, 0] = 0;
                matrizAcumulada[1, 0] = 0;
                matrizAcumulada[2, 0] = 0;
            }


        }



    }
}
