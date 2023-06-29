using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    public static class Dane
    {
        public static List<Uczen> uczniowie_lista = new List<Uczen>();
        public static List<Klasa> klasy_lista = new List<Klasa>();
        public static List<Szkola> szkoly_lista = new List<Szkola>();
    }

    public partial class MainWindow : Window
    {
       

        string[] mimiona = { "Belzebub", "Ignacy", "Bozydar", "Korniszon", "Waclaw", "Jerzy", "Misiek", "Bronislaw" };
        string[] kimiona = { "Konstancja", "Izyda", "Genowefa", "Kunegunda", "Oksana", "Jagoda", "Kamila", "Julita" };
        string[] nazwiska = { "Wieczorek", "Kielbasa", "Ryszard", "Nowak", "Podloga", "Ozorek", "Sosna", "Bagienko", "Przystan", "Michalek", "Olej", "Kowal" };
        

        public MainWindow()
        {
            InitializeComponent();
          
            Random rnd = new Random();

            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(kimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.kobieta, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(kimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.kobieta, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(kimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.kobieta, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(kimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.kobieta, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(kimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.kobieta, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(kimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.kobieta, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(kimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.kobieta, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(kimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.kobieta, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(mimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.mezczyzna, rnd.Next(0, 99), rnd.Next(0, 99)));
            Dane.uczniowie_lista.Add(new Uczen(kimiona[rnd.Next(0, 7)], nazwiska[rnd.Next(0, 11)], Plec.kobieta, rnd.Next(0, 99), rnd.Next(0, 99)));

            Dane.klasy_lista.Add(new Klasa("1a"));
            Dane.klasy_lista.Add(new Klasa("1b"));
            Dane.klasy_lista.Add(new Klasa("2a"));
            Dane.klasy_lista.Add(new Klasa("3a"));

            Szkola s1 = new Szkola("Zespol Szkol Lacznosci", "zsl");
            Dane.szkoly_lista.Add(s1);


            for (int i=0; i<6; i++)
            {
                Dane.klasy_lista[0].AddUczen(Dane.uczniowie_lista[i]);
            }
            for (int i = 6; i < 12; i++)
            {
                Dane.klasy_lista[1].AddUczen(Dane.uczniowie_lista[i]);
            }
            for (int i = 12; i < 18; i++)
            {
                Dane.klasy_lista[2].AddUczen(Dane.uczniowie_lista[i]);
            }
            for (int i = 18; i < 24; i++)
            {
                Dane.klasy_lista[3].AddUczen(Dane.uczniowie_lista[i]);
            }

            for (int i = 0; i < Dane.klasy_lista.Count; i++)
            {
                s1.AddKlasa(Dane.klasy_lista[i]);
            }

            //wyswietlanie szkol w listbox
            szkoly.Items.Clear();
            for (int i = 0; i < Dane.szkoly_lista.Count; i++)
            {
                szkoly.Items.Add(Dane.szkoly_lista.ElementAt(i).nazwa);
            }
            
        }
        
       
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (szkoly.SelectedIndex >= 0) { 
                klasy.Items.Clear();
                uczniowie.Items.Clear();    
            for (int i = 0; i < Dane.klasy_lista.Count; i++)
            {
                if (Dane.klasy_lista[i].szkola == Dane.szkoly_lista[szkoly.SelectedIndex].id)
                {
                    klasy.Items.Add(Dane.klasy_lista[i].id);
                }
                
                

            }
            output.Text = Dane.szkoly_lista[szkoly.SelectedIndex].Wyswietlanie();
            }
        }

        private void klasy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (szkoly.SelectedIndex >= 0 && klasy.SelectedIndex >= 0)
            {
            uczniowie.Items.Clear();
            string wybrana_klasa = klasy.SelectedItem as string;
            
            output.Text = Dane.szkoly_lista[szkoly.SelectedIndex].Wyswietlanie() + Dane.klasy_lista[klasy.SelectedIndex].Wyswietlanie();
            
            for (int i = 0; i < Dane.uczniowie_lista.Count; i++)
            {
                if (Dane.uczniowie_lista[i].klasa==wybrana_klasa && Dane.uczniowie_lista[i].szkola==Dane.szkoly_lista[szkoly.SelectedIndex].id)
                {
                    uczniowie.Items.Add(Dane.uczniowie_lista.ElementAt(i).imie+" "+ Dane.uczniowie_lista.ElementAt(i).nazwisko);
                }
                
            }
            }

        }

        private void uczniowie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            output.Text = "";
            output.Text += Dane.szkoly_lista[0].Wyswietlanie();
            if(klasy.SelectedIndex>=0)
            output.Text += Dane.klasy_lista[klasy.SelectedIndex].Wyswietlanie();

            int licznik = 0;
            //Obliczanie indeksu wybranego ucznia liscie wszystkich uczniow
            for (int i = 0; i < klasy.SelectedIndex; i++)
            {
                licznik += Dane.klasy_lista[i].klasa.Count;
            }
            licznik += uczniowie.SelectedIndex;

            if(uczniowie.SelectedIndex <= Dane.uczniowie_lista.Count && uczniowie.SelectedIndex >= 0)
            {
                output.Text += Dane.uczniowie_lista[licznik].Wyswietlanie();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dodawanie nowe_okno = new dodawanie();
            nowe_okno.Show();
        }
        private void Button_Click_klasa(object sender, RoutedEventArgs e)
        {
            dodawanie_k nowe_okno = new dodawanie_k();
            nowe_okno.Show();
        }
        private void Button_Click_szkola(object sender, RoutedEventArgs e)
        {
            dodawanie_s nowe_okno = new dodawanie_s();
            nowe_okno.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //wyswietlanie szkol w listbox
            szkoly.Items.Clear();
            for (int i = 0; i < Dane.szkoly_lista.Count; i++)
            {
                szkoly.Items.Add(Dane.szkoly_lista.ElementAt(i).nazwa);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //wyswietlanie szkol w listbox
            szkoly.Items.Clear();
            klasy.Items.Clear();
            uczniowie.Items.Clear();
            output.Text = "Kliknij aby wybrac szkole";
            for (int i = 0; i < Dane.szkoly_lista.Count; i++)
            {
                szkoly.Items.Add(Dane.szkoly_lista.ElementAt(i).nazwa);
            }
        }
    }
}
