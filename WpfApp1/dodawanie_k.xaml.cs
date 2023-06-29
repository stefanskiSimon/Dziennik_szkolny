using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Logika interakcji dla klasy dodawanie_k.xaml
    /// </summary>
    public partial class dodawanie_k : Window
    {
        public dodawanie_k()
        {
            InitializeComponent();
        }

        private void Dodaj_klase_click(object sender, RoutedEventArgs e)
        {
            
            Dane.klasy_lista.Add(new Klasa(k_id.Text));
            for(int i=0; i < Dane.szkoly_lista.Count; i++)
            {
                if (k_szkola.Text==Dane.szkoly_lista[i].id)
                {
                    Dane.szkoly_lista[i].AddKlasa(Dane.klasy_lista.Last());
                }
            }
            
            this.Close();
        }
    }
}
