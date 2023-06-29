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
    /// Logika interakcji dla klasy dodawanie.xaml
    /// </summary>
    public partial class dodawanie : Window
    {
        public dodawanie()
        {
            InitializeComponent();
        }

        private void Dodaj_ucznia_click(object sender, RoutedEventArgs e)
        {
            int s = 0;
            int i = 0;
            Plec a = Plec.mezczyzna;
            if (u_kobieta.IsSelected) a = Plec.kobieta;
            Int32.TryParse(u_inteligencja.Text, out i);
            Int32.TryParse(u_sila.Text, out s);
            

            int indeks_klasy = 0;
            int indeks_ucznia = 0;

            // wyszukiwanie indeksu klasy do kotrej zostanie dodany nowy uczen
            foreach (Klasa x in Dane.klasy_lista)
            {
                if (x.id == u_klasa.Text && x.szkola==u_szkola.Text)
                {
                    indeks_klasy = Dane.klasy_lista.IndexOf(x);  
                }
            }
            // obliczanie indeksu nowego ucznia w liscie uczniow
            for(int j = 0; j <= indeks_klasy; j++)
            {
                indeks_ucznia += Dane.klasy_lista[j].klasa.Count;
            }
            // dodawanie ucznia do listy w odpowiednim miejscu
            Dane.uczniowie_lista.Insert(indeks_ucznia, new Uczen(u_imie.Text, u_nazwisko.Text, a, i, s));
            Dane.uczniowie_lista[indeks_ucznia].szkola = u_szkola.Text;
            Dane.uczniowie_lista[indeks_ucznia].klasa = u_klasa.Text;
            Dane.klasy_lista[indeks_klasy].AddUczen(Dane.uczniowie_lista[indeks_ucznia]);
            
            Dane.uczniowie_lista[indeks_ucznia].id = "xxx" + u_klasa.Text + Dane.uczniowie_lista.Last().id;

            this.Close();
        }
    }
}
