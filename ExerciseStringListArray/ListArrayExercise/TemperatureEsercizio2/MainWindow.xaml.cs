using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TemperatureEsercizio2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ISTAT istat;
        public MainWindow()
        {
            InitializeComponent();
            istat = new ISTAT();
            istat.ImpostaDatiDaFile("Tavole-Dati-Meteoclimatici-Anno-2021-temperature.csv");

            // indico la sorgente del oggeto list box
            lstComuni.ItemsSource = istat.Comuni;
        }


        private void btnTemperaturaMassima_Click(object sender, RoutedEventArgs e)
        {
            Comune? c = lstComuni.SelectedItem as Comune;
            if (c != null)
            {
                Comune comune = c;
                MessageBox.Show($"Temperatura massima{comune.TemperaturaMax()}°C");
            }
            else
            {
                MessageBox.Show("nessun comune selezionato");
            }
        }

        private void btnTempMaxAnnoX_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtMaxTemAnnoX.Text, out int anno) && anno > 0)
                {
                    List<string> comune_i = istat.Comune_iTemperaturaMassimaAnno(anno);
                    string comune_iOutput = "";
                    for (int i = 0; i < comune_i.Count; i++)
                    {
                        comune_iOutput += comune_i[i];
                    }
                    double? temperatura = istat.TemperatureaMaggioreAnno(anno);
                    if (temperatura != null)
                    {
                        MessageBox.Show($"{temperatura}°C - Comune:{comune_iOutput}");
                    }
                    else
                    {
                        MessageBox.Show("nessun dato trovato");
                    }
                }
                else
                {
                    MessageBox.Show("nessun anno valido selezionato");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
        }

        private void btnTempMinAnnoX_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtMinTemAnnoX.Text, out int anno) && anno > 0)
                {
                    List<string> comune_i = istat.Comune_iTemperaturaMinimaAnno(anno);
                    string comune_iOutput = "";
                    for (int i = 0; i < comune_i.Count; i++)
                    {
                        comune_iOutput += comune_i[i];
                    }
                    double? temperatura = istat.TemperatureaMinoreAnno(anno);
                    if (temperatura != null)
                    {
                        MessageBox.Show($"{temperatura}°C - Comune:{comune_iOutput}");
                    }
                    else
                    {
                        MessageBox.Show("nessun dato trovato");
                    }
                }
                else
                {
                    MessageBox.Show("nessun anno valido selezionato");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTempMediaAnnoX_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> output = new List<string>();
                if (int.TryParse(txtTemMediaAnnoX.Text, out int anno) && anno > 0)
                {
                    output .Add($"nel {anno} rispetto alla Media:\n");
                    double temperaturaMedia = istat.TemperaturaMediaAnno(anno);
                    int comuniTempInferiore = 0;
                    int comuniTempSuperiore = 0;
                    foreach (Comune comune in istat.Comuni)
                    {
                        if(comune.TemperaturaInAnnoX(anno) > temperaturaMedia)
                        {
                            comuniTempInferiore++;
                            output.Add( $"{comune.Nome} - {comune.TemperaturaInAnnoX(anno)}°C Inferiore\n");
                        }else if(comune.TemperaturaInAnnoX(anno) > temperaturaMedia)
                        {
                            comuniTempSuperiore++;
                            output.Add( $"{comune.Nome} - {comune.TemperaturaInAnnoX(anno)}°C Superiore\n");
                        }else
                        {
                            output.Add( $"{comune.Nome} - {comune.TemperaturaInAnnoX(anno)}°C Uguale\n");
                        }
                    }
                    output.Add($"comuni con temperatura inferiore alla media: {comuniTempInferiore}\n");
                    output.Add($"comuni con temperatura superiore alla media: {comuniTempSuperiore}\n");
                    double? temperaturaMaggiore = istat.TemperatureaMinoreAnno(anno);
                    double? temperaturaMinore = istat.TemperatureaMinoreAnno(anno);
                    if (temperaturaMaggiore == null && temperaturaMinore == null) throw new Exception("i dati sono nulli");
                    double scostamentoMassimo = ((double)temperaturaMaggiore - (double)temperaturaMinore)/2;
                    output.Add($"lo scostamento massimo della temperatura: {scostamentoMassimo}");

                    listTemperatureMedie.ItemsSource = output;
                }
                else
                {
                    MessageBox.Show("anno non valido");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
    }
}
