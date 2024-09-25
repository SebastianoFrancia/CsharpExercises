using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GattileLIB;

namespace GattileWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Gattile _gattile;
        private ScriviFile sf = new ScriviFile(@"..\..\..\DatiGatti.txt", @"..\..\..\DatiAdottanti.txt", @"..\..\..\DatiAdozioni.txt");
        public MainWindow()
        {
            InitializeComponent();

            LeggiFile lf = new LeggiFile(@"..\..\..\DatiGatti.txt", @"..\..\..\DatiAdottanti.txt", @"..\..\..\DatiAdozioni.txt");

            List<Gatto> gatti = lf.LeggiDatiGatti();
            List<Adottante> adottanti = lf.LeggiDatiAdottanti();
            List<Adozione> adozioni = lf.LeggiDatiAdozioni(gatti);

            _gattile = new Gattile(gatti, adottanti, adozioni);
            UpdateNumGati();
        }

        private void UpdateNumGati()
        {
            lblNumGattiPresenti.Content = $"numero gatti: {_gattile.NumGattiPresenti()}";
        }

        private void btnGattiWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowGatti windowGatti = new WindowGatti(_gattile.Gatti);
            windowGatti.Show();
        }

        private void btnWindowAggiungiGatto_Click(object sender, RoutedEventArgs e)
        {

            WindowAggiungiGatto windowAggiungiGatto = new WindowAggiungiGatto(_gattile, sf);
            windowAggiungiGatto.Show();
        }

        private void btnWindowAdottanti_Click(object sender, RoutedEventArgs e)
        {
            WindowAdottanti windowAdottanti = new WindowAdottanti(_gattile.Adottanti);
            windowAdottanti.Show();
        }

        private void btnWindowAggiungiAdottante_Click(object sender, RoutedEventArgs e)
        {
            WindowAggiungiAdottante windowAggiungiAdottante = new WindowAggiungiAdottante(_gattile, sf);
            windowAggiungiAdottante.Show();
        }

        private void btnWindowAdozioni_Click(object sender, RoutedEventArgs e)
        {
            WindowAdozioni windowAdozioni = new WindowAdozioni(_gattile.Adozioni);
            windowAdozioni.Show();  
        }

        private void btnWindowAggiungiAdozioni_Click(object sender, RoutedEventArgs e)
        {
            WindowAggiungiAdozione windowAggiungiAdozione = new WindowAggiungiAdozione(_gattile, sf);
            windowAggiungiAdozione.Show();
        }

        private void btnAdozioneFallita_Click(object sender, RoutedEventArgs e)
        {
            WindowAdozioneFallita windowAdozioneFallita = new WindowAdozioneFallita(_gattile, sf);
            windowAdozioneFallita.Show();
        }

        private void btnAggiornaNumGatti_Click(object sender, RoutedEventArgs e)
        {
            UpdateNumGati();
        }
    }
}