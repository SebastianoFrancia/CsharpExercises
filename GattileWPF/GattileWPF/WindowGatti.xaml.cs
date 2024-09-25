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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WindowGatti : Window
    {
        private List<Gatto> _gatti;
        public WindowGatti(List<Gatto> gatti)
        {
            InitializeComponent();
            _gatti = gatti; 
            lbxGatti.ItemsSource = _gatti;
        }

        private void lbxGatti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblID.Content = $"Id: {_gatti[lbxGatti.SelectedIndex].Id}";
            lblNome.Content = $"Nome: {_gatti[lbxGatti.SelectedIndex].Nome}";
            lblRazza.Content = $"Razza: {_gatti[lbxGatti.SelectedIndex].Razza}";
            lblSesso.Content = $"Sesso: {_gatti[lbxGatti.SelectedIndex].Sesso}";
            lblDataArrivo.Content = $"Data Arrivo: {_gatti[lbxGatti.SelectedIndex].Arrivo}";
            lblDataUscita.Content = $"Data Uscita: {_gatti[lbxGatti.SelectedIndex].Uscita}";
            lblDataNascita.Content = $"Data Nascita: {_gatti[lbxGatti.SelectedIndex].Nascita}";
            lblDescrizione.Content = $"Descrizione: \n{_gatti[lbxGatti.SelectedIndex].Descrizione}";
        }

        private void btnAggitnalbx_Click(object sender, RoutedEventArgs e)
        {
            lbxGatti.ItemsSource = _gatti;
        }
    }
}
