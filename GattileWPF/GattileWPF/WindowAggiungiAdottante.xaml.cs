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
    /// Interaction logic for WindowAggiungiAdottante.xaml
    /// </summary>
    public partial class WindowAggiungiAdottante : Window
    {
        private Gattile _gattile;
        private ScriviFile sf;
        public WindowAggiungiAdottante(Gattile gattile, ScriviFile scriviFile)
        {
            InitializeComponent();
            _gattile = gattile;
            sf = scriviFile;
        }

        private void btnAggiungiAdottante_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nome = txbNome.Text;
                string cognome = txbCognome.Text;
                string indirizzo = txbIndirizzo.Text;
                int telefono = int.Parse(txbTelefono.Text);
                _gattile.AggiungiAdottante(new Adottante(nome, cognome, indirizzo, telefono), sf);

                this.Close();   

            }
            catch (Exception ex)
            {
                lblError.Content = ex.Message;
            }
        }
    }
}
