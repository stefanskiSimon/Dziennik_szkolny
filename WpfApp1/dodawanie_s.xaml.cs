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
    /// Logika interakcji dla klasy dodawanie_s.xaml
    /// </summary>
    public partial class dodawanie_s : Window
    {
        public dodawanie_s()
        {
            InitializeComponent();
        }

        private void Dodaj_szkole_click(object sender, RoutedEventArgs e)
        {
            Dane.szkoly_lista.Add(new Szkola(s_nazwa.Text, s_id.Text));

            
            this.Close();
        }
    }
}
