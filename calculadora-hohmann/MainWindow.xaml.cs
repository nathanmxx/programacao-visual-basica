using System;
using System.Windows;

namespace CalculadoraHohmann
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            double r1 = double.Parse(txtOrigem.Text);
            double r2 = double.Parse(txtDestino.Text);
            double massa = double.Parse(txtMassa.Text);
            double impulso = double.Parse(txtImpulso.Text);

            r1 = r1 * 1000000;
            r2 = r2 * 1000000;

            double mu = 1.327 * Math.Pow(10, 11);

            double a = (r1 + r2) / 2;

            double tempo = Math.PI * Math.Sqrt(Math.Pow(a, 3) / mu);

            double dias = tempo / 86400;

            double meses = dias / 30;

            double deltaV1 = Math.Sqrt(mu / r1) * (Math.Sqrt((2 * r2) / (r1 + r2)) - 1);

            double deltaV2 = Math.Sqrt(mu / r2) * (1 - Math.Sqrt((2 * r1) / (r1 + r2)));

            double deltaV = Math.Abs(deltaV1) + Math.Abs(deltaV2);

            double combustivel = massa * (Math.Exp((deltaV * 1000) / (impulso * 9.81)) - 1);

            double toneladas = combustivel / 1000;

            lblTempo.Content = Math.Round(dias) + " dias (~" + meses.ToString("N1") + " meses)";

            lblDeltaV.Content = deltaV.ToString("N3") + " km/s";

            lblCombustivel.Content = combustivel.ToString("N2") + " kg (" + toneladas.ToString("N2") + " t)";
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtOrigem.Text = "";
            txtDestino.Text = "";
            txtMassa.Text = "";
            txtImpulso.Text = "";

            lblTempo.Content = "-";
            lblDeltaV.Content = "-";
            lblCombustivel.Content = "-";
        }
    }
}
