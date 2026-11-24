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

        string arquivo = "pessoas.json";

        public MainWindow()
        {
            InitializeComponent();
            Carregar();
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

        string PegarTexto(string registro, string campo)
        {
            int p = registro.IndexOf(campo);
            p = registro.IndexOf(":", p);
            int inicio = registro.IndexOf("\"", p) + 1;
            int fim = registro.IndexOf("\"", inicio);
            return registro.Substring(inicio, fim - inicio);
        }

        double PegarNumero(string registro, string campo)
        {
            int p = registro.IndexOf(campo);
            p = registro.IndexOf(":", p) + 1;
            int fim = registro.IndexOf(",", p);
            if (fim < 0) fim = registro.Length;
            string valor = registro.Substring(p, fim - p);
            valor = valor.Replace("}", "");
            valor = valor.Trim();
            valor = valor.Replace(".", ",");
            return double.Parse(valor);
        }

        string Numero(double n)
        {
            return n.ToString("0.##").Replace(",", ".");
        }

        string NumeroDuasCasas(double n)
        {
            return n.ToString("0.00").Replace(",", ".");
        }

        void Carregar()
        {
            total = 0;

            File.AppendAllText(arquivo, "");
            string texto = File.ReadAllText(arquivo);

            if (texto.Trim().Length == 0)
            {
                File.WriteAllText(arquivo, "[" + Environment.NewLine + "]");
                texto = File.ReadAllText(arquivo);
            }

            int pos = texto.IndexOf("{");
            while (pos >= 0 && total < 200)
            {
                int fim = texto.IndexOf("}", pos);
                if (fim < 0) break;

                string registro = texto.Substring(pos, fim - pos);

                ids[total] = (int)PegarNumero(registro, "\"Id\"");
                nomes[total] = PegarTexto(registro, "\"Nome\"");
                pesos[total] = PegarNumero(registro, "\"Peso (Kg)\"");
                alturas[total] = PegarNumero(registro, "\"Altura (m)\"");
                imcs[total] = pesos[total] / (alturas[total] * alturas[total]);
                classificacoes[total] = Classificar(imcs[total]);
                total = total + 1;

                pos = texto.IndexOf("{", fim);
            }
        }

        void Gravar()
        {
            string texto = "[" + Environment.NewLine;

            for (int i = 0; i < total; i++)
            {
                texto = texto + "  {\"Id\": " + ids[i];
                texto = texto + ", \"Nome\": \"" + nomes[i] + "\"";
                texto = texto + ", \"Peso (Kg)\": " + Numero(pesos[i]);
                texto = texto + ", \"Altura (m)\": " + Numero(alturas[i]);
                texto = texto + ", \"IMC\": " + NumeroDuasCasas(imcs[i]);
                texto = texto + ", \"Classificação\": \"" + classificacoes[i] + "\"}";
                if (i < total - 1) texto = texto + ",";
                texto = texto + Environment.NewLine;
            }

            texto = texto + "]";
            File.WriteAllText(arquivo, texto);
        }

        int Procurar(int id)
        {
            for (int i = 0; i < total; i++)
            {
                if (ids[i] == id) return i;
            }
            return -1;
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

        int LerId()
        {
            int id;
            if (!int.TryParse(txtId.Text.Trim(), out id))
            {
                MessageBox.Show("Digite um Id numerico.");
                return -1;
            }
            return id;
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

            Gravar();
            Listar();

            txtId.Text = ids[total - 1].ToString();
            lblResultado.Content = "Cadastrado com o Id " + ids[total - 1] + ". IMC: "
                + imcs[total - 1].ToString("0.00") + " - " + classificacoes[total - 1];
        }

        private void Consultar_Click(object sender, RoutedEventArgs e)
        {
            int id = LerId();
            if (id < 0) return;

            int i = Procurar(id);
            if (i < 0)
            {
                MessageBox.Show("Nao existe cadastro com o Id " + id + ".");
                return;
            }

            txtNome.Text = nomes[i];
            txtPeso.Text = pesos[i].ToString("0.##");
            txtAltura.Text = alturas[i].ToString("0.##");
            lblResultado.Content = "Id " + ids[i] + " - IMC: " + imcs[i].ToString("0.00") + " - " + classificacoes[i];
        }

        private void Alterar_Click(object sender, RoutedEventArgs e)
        {
            int id = LerId();
            if (id < 0) return;

            int i = Procurar(id);
            if (i < 0)
            {
                MessageBox.Show("Nao existe cadastro com o Id " + id + ".");
                return;
            }

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

            nomes[i] = nome;
            pesos[i] = peso;
            alturas[i] = altura;
            imcs[i] = peso / (altura * altura);
            classificacoes[i] = Classificar(imcs[i]);

            Gravar();
            Listar();
            lblResultado.Content = "Alterado. Id " + ids[i] + " - IMC: " + imcs[i].ToString("0.00") + " - " + classificacoes[i];
        }

        private void Excluir_Click(object sender, RoutedEventArgs e)
        {
            int id = LerId();
            if (id < 0) return;

            int i = Procurar(id);
            if (i < 0)
            {
                MessageBox.Show("Nao existe cadastro com o Id " + id + ".");
                return;
            }

            for (int j = i; j < total - 1; j++)
            {
                ids[j] = ids[j + 1];
                nomes[j] = nomes[j + 1];
                pesos[j] = pesos[j + 1];
                alturas[j] = alturas[j + 1];
                imcs[j] = imcs[j + 1];
                classificacoes[j] = classificacoes[j + 1];
            }
            total = total - 1;

            Gravar();
            Listar();
            Limpar();
            lblResultado.Content = "Cadastro do Id " + id + " excluido.";
        }

        private void Limpar_Click(object sender, RoutedEventArgs e)
        {
            Limpar();
        }
    }
}
