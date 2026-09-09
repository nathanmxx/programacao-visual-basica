using System;
using System.Windows;

namespace Projeto_2bim_PVB
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calcular_Click(object sender, RoutedEventArgs e)
        {
            int quantidade = txtDados.LineCount;

            double soma = 0;
            double somaQuadrado = 0;

            double numero = double.Parse(txtDados.GetLineText(0));
            double menor = numero;
            double maior = numero;

            for (int i = 0; i < quantidade; i++)
            {
                numero = double.Parse(txtDados.GetLineText(i));

                soma += numero;
                somaQuadrado += numero * numero;

                if (numero < menor)
                {
                    menor = numero;
                }
                else
                {
                    if (numero > maior)
                    {
                        maior = numero;
                    }
                }
            }

            double media = soma / quantidade;
            double variancia = (somaQuadrado - (soma * soma) / quantidade) / (quantidade - 1);
            double desvio = Math.Sqrt(variancia);

            saida1.Content = "Quantidade: " + quantidade;
            saida2.Content = "Menor valor: " + menor.ToString("0.00");
            saida3.Content = "Maior valor: " + maior.ToString("0.00");
            saida4.Content = "Média: " + media.ToString("0.00");
            saida5.Content = "Variância: " + variancia.ToString("0.00");
            saida6.Content = "Desvio padrão: " + desvio.ToString("0.00");
        }
    }
}
