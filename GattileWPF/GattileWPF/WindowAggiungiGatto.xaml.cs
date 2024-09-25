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
    /// Interaction logic for WindowAggiungiGatto.xaml
    /// </summary>
    public partial class WindowAggiungiGatto : Window
    {
        private Gattile _gattile;
        private ScriviFile _sf;
        public WindowAggiungiGatto(Gattile gattile, ScriviFile sf)
        {
            InitializeComponent();
            _sf = sf;
            _gattile = gattile;
            cmbxRazza.Items.Add(Razza.Soriano);
            cmbxRazza.Items.Add(Razza.Siamese);
            cmbxRazza.Items.Add(Razza.ColorpointShorthair);
            cmbxRazza.Items.Add(Razza.Persiano);
            cmbxRazza.Items.Add(Razza.Sconosciuta);

            cmbxSesso.Items.Add(Sesso.Femmina);
            cmbxSesso.Items.Add(Sesso.Maschio);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lblError.Content = "";
            try
            {
                string nome = txbNome.Text;
                Razza razza;
                if (cmbxRazza.SelectedItem.ToString() == Razza.Sconosciuta.ToString())
                {
                    razza = Razza.Sconosciuta;
                }
                else if (cmbxRazza.SelectedItem.ToString() == Razza.Siamese.ToString())
                {
                    razza = Razza.Siamese;
                }
                else if (cmbxRazza.SelectedItem.ToString() == Razza.Soriano.ToString())
                {
                    razza = Razza.Soriano;
                }
                else if (cmbxRazza.SelectedItem.ToString() == Razza.ColorpointShorthair.ToString())
                {
                    razza = Razza.ColorpointShorthair;
                }
                else if (cmbxRazza.SelectedItem.ToString() == Razza.Persiano.ToString())
                {
                    razza = Razza.Persiano;
                }
                else throw new Exception(message: "razza non selezionata");

                Sesso sesso;
                if (cmbxSesso.SelectedItem.ToString() == Sesso.Maschio.ToString())
                {
                    sesso = Sesso.Maschio;
                }
                else if (cmbxSesso.SelectedItem.ToString() == Sesso.Femmina.ToString())
                {
                    sesso = Sesso.Femmina;
                }
                else throw new Exception(message: "sesso non selezionato");

                DateOnly dataArrivo;
                DateTime? SelectedDataArrivo = datepArrivo.SelectedDate;
                if (SelectedDataArrivo.HasValue)
                {
                    dataArrivo = DateOnly.FromDateTime(SelectedDataArrivo.Value);
                }
                else throw new Exception(message:"inserire data di arrivo");


                DateOnly? dataUscita;
                if (ckbxUscitaSconosciuta.IsChecked == true)
                {
                    dataUscita = null;  
                }
                else
                {
                    dataUscita = DateOnly.FromDateTime(datepUscita.SelectedDate.Value);
                }
                
                DateOnly? dataNascita;
                if (ckbxNascitaSconosciuta.IsChecked == true)
                {
                    dataNascita = null;
                }else
                {
                    dataNascita = DateOnly.FromDateTime(datepNacita.SelectedDate.Value);
                }
                string descrizione = txbDescrizione.Text;

                _gattile.AggiungiGatto(new Gatto(nome, razza, sesso, dataArrivo, dataUscita, dataNascita, descrizione), _sf);

                this.Close();
            }
            catch (Exception ex)
            {
                lblError.Content = ex.Message;
            }
        }

        private void ckbxUscitaSconosciuta_Click(object sender, RoutedEventArgs e)
        {
            if (ckbxUscitaSconosciuta.IsChecked == true)
            {
                datepUscita.Visibility = Visibility.Collapsed;
            }
            else
            {
                datepUscita.Visibility = Visibility.Visible;
            }
        }

        private void ckbxNascitaSconosciuta_Click(object sender, RoutedEventArgs e)
        {
            if (ckbxNascitaSconosciuta.IsChecked == true)
            {
                datepNacita.Visibility = Visibility.Collapsed;
            }
            else
            {
                datepNacita.Visibility = Visibility.Visible;
            }
        }
    }
}
