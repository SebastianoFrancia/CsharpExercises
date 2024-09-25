using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GattileLIB;

namespace GattileWPF
{
    /// <summary>
    /// Interaction logic for WindowAdozioni.xaml
    /// </summary>
    public partial class WindowAdozioni : Window
    {
        private List<Adozione> _adozioni;
        public WindowAdozioni(List<Adozione> adozioni)
        {
            InitializeComponent();
            _adozioni = adozioni;
            lbxAdozioni.ItemsSource = _adozioni; 
        }

        private void btnAggitnalbx_Click(object sender, RoutedEventArgs e)
        {
            lbxAdozioni.ItemsSource = _adozioni;
        }

        private void lbxGatti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblNomeGatto.Content = $"Nome: {_adozioni[lbxAdozioni.SelectedIndex].Gatto.Nome}";
            lblRazza.Content = $"Razza: {_adozioni[lbxAdozioni.SelectedIndex].Gatto.Razza}";
            lblSesso.Content = $"Sesso: {_adozioni[lbxAdozioni.SelectedIndex].Gatto.Sesso}";
            lblDataArrivo.Content = $"Data Arrivo: {_adozioni[lbxAdozioni.SelectedIndex].Gatto.Arrivo}";
            lblDataUscita.Content = $"Data Uscita: {_adozioni[lbxAdozioni.SelectedIndex].Gatto.Uscita}";
            lblDataNascita.Content = $"Data Nascita: {_adozioni[lbxAdozioni.SelectedIndex].Gatto.Nascita}";
            lblDescrizione.Content = $"Descrizione: {_adozioni[lbxAdozioni.SelectedIndex].Gatto.Descrizione}";

            lblNomeAdottante.Content = $"Nome: {_adozioni[lbxAdozioni.SelectedIndex].Adottante.Nome}";
            lblCognome.Content = $"Cognome: {_adozioni[lbxAdozioni.SelectedIndex].Adottante.Cognome}";
            lblIndirizzo.Content = $"Indirizzo: {_adozioni[lbxAdozioni.SelectedIndex].Adottante.Indirizzo}";
            lblTellefono.Content = $"Telefono: {_adozioni[lbxAdozioni.SelectedIndex].Adottante.Telefono}";

            lblDataAdozione.Content = $"Data Adozione: {_adozioni[lbxAdozioni.SelectedIndex].DataAdozione}";
        }
    }
}
