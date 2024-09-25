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
    /// Interaction logic for WindowAdotanti.xaml
    /// </summary>
    public partial class WindowAdottanti : Window
    {
        private List<Adottante> _adottanti;
        public WindowAdottanti(List<Adottante> adottanti)
        {
            InitializeComponent();

            _adottanti = adottanti;
            lbxAdottanti.ItemsSource = _adottanti;
        }

        private void btnAggitnalbx_Click(object sender, RoutedEventArgs e)
        {
            lbxAdottanti.ItemsSource = _adottanti;
        }

        private void lbxGatti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblNome.Content = $"Nome: {_adottanti[lbxAdottanti.SelectedIndex].Nome}";
            lblCognome.Content = $"Cognome: {_adottanti[lbxAdottanti.SelectedIndex].Cognome}";
            lblIndirizzo.Content = $"Indirizzo: {_adottanti[lbxAdottanti.SelectedIndex].Indirizzo}";
            lblTellefono.Content = $"Telefono: {_adottanti[lbxAdottanti.SelectedIndex].Telefono}";
        }
    }
}
