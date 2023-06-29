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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            
        }
        private void Id_szkola_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Ilosc_klas_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Nazwa_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int cos;
            int liczba;
            Int32.TryParse(Ilosc_klas.Text, out cos);
            Int32.TryParse(Id_szkola.Text, out liczba);
            if(cos == 0 || Nazwa.Text =="" || liczba <= 0)
            {
                return;
            }
            else
            {
                info.Text = "Dodane szkołe " + Nazwa.Text;
            }
           Szkola szkolkanasza = new Szkola(Id_szkola.Text, cos, Nazwa.Text);
        }
    }
}
