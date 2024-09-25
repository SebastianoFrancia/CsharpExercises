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
    /// Interaction logic for WindowAggiungiAdozione.xaml
    /// </summary>
    public partial class WindowAggiungiAdozione : Window
    {
        private Gattile _gattile;
        private ScriviFile sf;
        public WindowAggiungiAdozione(Gattile gattile, ScriviFile scriviFile)
        {
            InitializeComponent();
            _gattile = gattile;
            sf = scriviFile;

            lbxGatti.ItemsSource = _gattile.Gatti;
            lbxAdottanti.ItemsSource = _gattile.Adottanti;
        }

        private void btnAggiungiAdottante_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Gatto gatto = _gattile.Gatti[lbxGatti.SelectedIndex];
                Adottante adottante = _gattile.Adottanti[lbxAdottanti.SelectedIndex];
                _gattile.AggiungiAdozione(new Adozione(gatto, adottante), sf);

                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnAggiornaListe_Click(object sender, RoutedEventArgs e)
        {
            lbxGatti.ItemsSource = _gattile.Gatti;
            lbxAdottanti.ItemsSource = _gattile.Adottanti;
        }

        
    }
}
