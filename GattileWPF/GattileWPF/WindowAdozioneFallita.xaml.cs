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
    /// Interaction logic for WindowAdozioneFallita.xaml
    /// </summary>
    public partial class WindowAdozioneFallita : Window
    {
        private Gattile _gattile;
        private ScriviFile sf;
        public WindowAdozioneFallita(Gattile gattile, ScriviFile scriviFile)
        {
            InitializeComponent();
            _gattile = gattile;
            sf = scriviFile;
            lbxAdozioni.ItemsSource = _gattile.Adozioni;
        }

        private void btnConferma_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateOnly termine = DateOnly.FromDateTime(datepTermine.SelectedDate.Value);
                _gattile.AdozioneFallita(_gattile.Adozioni[lbxAdozioni.SelectedIndex], termine, sf);

                this.Close();   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAggitnalbx_Click(object sender, RoutedEventArgs e)
        {
            lbxAdozioni.ItemsSource = _gattile.Adozioni;
        }
    }
}
