using System;
using System.IO;
using System.Windows;

namespace ConsultorioIMC
{
    public partial class MainWindow : Window
    {
        int[] ids = new int[200];
        string[] nomes = new string[200];
        double[] pesos = new double[200];
        double[] alturas = new double[200];
        double[] imcs = new double[200];
        string[] classificacoes = new string[200];
        int total = 0;

        string[] faixas = { "Magreza", "Saudável", "Sobrepeso", "Obesidade Grau I", "Obesidade Grau II", "Obesidade Grau III" };

        public MainWindow()
        {
            InitializeComponent();
            Listar();
        }

        int Faixa(double imc)
        {
            if (imc < 18.5) return 0;
            if (imc < 25) return 1;
            if (imc < 30) return 2;
            if (imc < 35) return 3;
            if (imc < 40) return 4;
            return 5;
        }

        string Classificar(double imc)
        {
            return faixas[Faixa(imc)];
        }

        string Numero(double n)
        {
            return n.ToString("0.##").Replace(",", ".");
        }

        void Listar()
        {
            lstPesos.Items.Clear();
            for (int i = 0; i < total; i++)
            {
                string linha = "Id " + ids[i] + " - " + nomes[i] + " - Peso: " + Numero(pesos[i]) + " Kg";
                lstPesos.Items.Add(linha);
            }
        }

        double LerNumero(string texto, string campo)
        {
            double n;
            string valor = texto.Trim().Replace(".", ",");
            if (!double.TryParse(valor, out n) || n <= 0)
            {
                MessageBox.Show("Digite um valor valido para " + campo + ". Exemplo: 70,5");
                return -1;
            }
            return n;
        }

        void Limpar()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtPeso.Text = "";
            txtAltura.Text = "";
            lblResultado.Content = "Informe os dados e clique em Cadastrar.";
        }

        private void Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            string nome = txtNome.Text.Trim();
            if (nome.Length == 0)
            {
                MessageBox.Show("Digite o nome da pessoa.");
                return;
            }

            double peso = LerNumero(txtPeso.Text, "Peso");
            if (peso < 0) return;

            double altura = LerNumero(txtAltura.Text, "Altura");
            if (altura < 0) return;

            if (total >= 200)
            {
                MessageBox.Show("A base ja tem 200 pessoas cadastradas.");
                return;
            }

            int maior = 0;
            for (int i = 0; i < total; i++)
            {
                if (ids[i] > maior) maior = ids[i];
            }

            ids[total] = maior + 1;
            nomes[total] = nome;
            pesos[total] = peso;
            alturas[total] = altura;
            imcs[total] = peso / (altura * altura);
            classificacoes[total] = Classificar(imcs[total]);
            total = total + 1;

            Listar();

            txtId.Text = ids[total - 1].ToString();
            lblResultado.Content = "Cadastrado com o Id " + ids[total - 1] + ". IMC: "
                + imcs[total - 1].ToString("0.00") + " - " + classificacoes[total - 1];
        }

        private void Limpar_Click(object sender, RoutedEventArgs e)
        {
            Limpar();
        }
    }
}
