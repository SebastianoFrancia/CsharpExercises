using System;
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

namespace Hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Match _match;
        public MainWindow()
        {
            InitializeComponent();
            _match = new Match(ReadToFile());
            lblWordGuess.Content = _match.WordGuess;
            lblError.Visibility = Visibility.Collapsed;
        }


        public string[] ReadToFile()
        {
            List<string> words = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(new Uri(Path.Source + "/words.txt", UriKind.Relative).ToString()))
                {
                    string word;
                    while ((word = sr.ReadLine()) != null)
                    {
                        words.Add(word);
                    }
                }
                return words.ToArray();
            }
            catch (Exception ex)
            {
                lblError.Content = $"The file of Words could not be read:{ex.Message}";
                throw ex;
            }
        }

        private void ButtonChar_Click(object sender, RoutedEventArgs e)
        {
            lblError.Visibility = Visibility.Collapsed;
            try
            {
                char ch = char.Parse(txbChar.Text.ToLower());
                MatchStatus status = _match.TurnGuessChar(ch);
                txbChar.Text = "";
                StatusActions(status, ch.ToString());
            }
            catch (Exception ex)
            {
                lblError.Visibility = Visibility.Visible;
                if (txbChar.Text == "")
                {
                    lblError.Content = $"insert a character";
                }
                else
                {
                    lblError.Content = $"{ex}";
                }
            }
        }

        private void OnKeyDownHandler_char(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ButtonChar_Click(sender, e);
            }
        }

        private void ButtonWord_Click(object sender, RoutedEventArgs e)
        {
            string word = txbWord.Text;
            try
            {
                MatchStatus status = _match.TurnGuessWord(word.ToLower());
                StatusActions(status, word);
            }
            catch (Exception ex)
            {
                lblError.Content = $"{ex}";
            }
        }
        private void OnKeyDownHandler_word(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ButtonWord_Click(sender, e);
            }
        }

        private void StatusActions(MatchStatus status, string s)
        {
            if (status == MatchStatus.charGuessed)
            {
                lblError.Visibility = Visibility.Collapsed;
                lblWordGuess.Content = _match.WordGuess;
            }
            else if (status == MatchStatus.charNotGuessed)
            {
                AddHangmanPart();
                lblError.Visibility = Visibility.Visible;
                lblError.Content = "you didn't guess";
            }
            else if (status == MatchStatus.alreadyUsed)
            {
                lblError.Visibility = Visibility.Visible;
                lblError.Content = $"you already used {s}";
            }else if(status == MatchStatus.wordNotGuessed)
            {
                EndGame("you didn't guess");
            }
            else if (status == MatchStatus.livesEnded)
            {
                EndGame("you're dead!");
            }
            else if (status == MatchStatus.Win)
            {
                EndGame("you Win!");
            }
        }

        public void AddHangmanPart()
        {
            if (_match.livesPlayer == 10) imgHangman1.Visibility = Visibility.Visible;
            if (_match.livesPlayer == 9) imgHangman2.Visibility = Visibility.Visible;
            if (_match.livesPlayer == 8) imgHangman3.Visibility = Visibility.Visible;
            if (_match.livesPlayer == 7) imgHangman4.Visibility = Visibility.Visible;
            if (_match.livesPlayer == 6) imgHangman5.Visibility = Visibility.Visible;
            if (_match.livesPlayer == 5) imgHangman6.Visibility = Visibility.Visible;
            if (_match.livesPlayer == 4) imgHangman7.Visibility = Visibility.Visible;
            if (_match.livesPlayer == 3) imgHangman8.Visibility = Visibility.Visible;
            if (_match.livesPlayer == 2) imgHangman9.Visibility = Visibility.Visible;
            if (_match.livesPlayer == 1) imgHangman10.Visibility = Visibility.Visible;
            if (_match.livesPlayer == 0) imgHangman11.Visibility = Visibility.Visible;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblError.Visibility = Visibility.Collapsed;
            try
            {
                Convert.ToChar(txbChar.Text);
            }
            catch (Exception ex)
            {
                lblError.Visibility= Visibility.Visible;
                if (txbChar.Text != "" && lblEndMesage.Visibility == Visibility.Collapsed)
                {
                    lblError.Content = $"insert a character";
                }
                txbChar.Text = "";
            }
        }

        private void RadioButtonWord_Checked(object sender, RoutedEventArgs e)
        {
            lblEnterCharacter.Visibility = Visibility.Collapsed;
            txbChar.Visibility = Visibility.Collapsed;
            btnGuessChar.Visibility = Visibility.Collapsed;
            lblEnterWord.Visibility = Visibility.Visible;
            txbWord.Visibility = Visibility.Visible;
            btnGuessWord.Visibility = Visibility.Visible;
        }

        private void RadioButtonChar_Checked(object sender, RoutedEventArgs e)
        {
            lblEnterCharacter.Visibility = Visibility.Visible;
            txbChar.Visibility = Visibility.Visible;
            btnGuessChar.Visibility = Visibility.Visible;
            lblEnterWord.Visibility = Visibility.Collapsed;
            txbWord.Visibility = Visibility.Collapsed;
            btnGuessWord.Visibility = Visibility.Collapsed;
        }
        public void EndGame(string s)
        {
            lblWord.Content = $"Word: {_match.Word} ";
            lblWord.Visibility = Visibility.Visible;
            rbtnChar.Visibility = Visibility.Collapsed;
            rbtnWord.Visibility = Visibility.Collapsed;
            lblEndMesage.Visibility = Visibility.Visible;
            lblEndMesage.Content = s;
            btnPlayAgain.Visibility = Visibility.Visible;
            btnExit.Visibility = Visibility.Visible;
        }
        private void btnPlayAgain_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            App.Current.Shutdown();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}