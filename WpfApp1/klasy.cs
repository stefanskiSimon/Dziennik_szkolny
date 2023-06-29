using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{

    internal class klasy
    {

    }
    public enum Plec
    {
        kobieta,
        mezczyzna
    }
   
    public class Uczen
    {

        public string imie;
        public string nazwisko;
        public Plec plec;
        public int inteligencja;
        public int sila;
        public string id;
        public string szkola;
        public string klasa;


        public Uczen(string imie, string nazwisko, Plec plec, int inteligencja, int sila)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.plec = plec;
            this.inteligencja = inteligencja;
            this.sila = sila;
            Random rnd = new Random();
            id = rnd.Next(1, 100).ToString();
        }
        public string Wyswietlanie()
        {
            string a = "------------ Uczen " + this.imie + " " + this.nazwisko + "[id: " + this.id + "] i jego supermoce: ------------\n" + " ----- Inteligencja: " + this.inteligencja + "\n ----- Sila: " + this.sila + "\n ----- Plec: " + this.plec+"\n";
            return a;

        }
        public void Wyswietl()
        {
            Console.WriteLine("------------ Uczen " + this.imie + " " + this.nazwisko + " [id: " + this.id + "] i jego supermoce: ------------");
            Console.WriteLine(" ----- Inteligencja: " + this.inteligencja);
            Console.WriteLine(" ----- Sila: " + this.sila);
            Console.WriteLine(" ----- Plec: " + this.plec);
        }
    }

    public class Klasa
    {
        // private Uczen[] klasa;
        public List<Uczen> klasa = new List<Uczen>();
        public Uczen[] tablica = new Uczen[30];
        public double srednia_inteligencja;
        public double srednia_sila;
        public double procent_m;
        public double procent_k;
        public int liczba_uczniow;
        public int liczba_k;
        public int liczba_m;
        public string id;
        private int l;
        public string szkola;
        
        public void AddUczen(Uczen uczen)
        {
            l++;
            klasa.Add(uczen);
            //Dodawanie oznaczenia klasy do id znajdujacych sie w niej uczniow
            uczen.id = this.id + l;
            uczen.klasa = this.id;

            Procent_k();
            Procent_m();
            SredniaInteligencja();
            SredniaSila();
            this.liczba_uczniow = klasa.Count;

        }

        public Klasa(string id)
        {
            this.id = id;
            this.l = 0;
            this.liczba_k = 0;
            this.liczba_m = 0;
        }

        public string Wyswietlanie()
        {
            string a = "-- Klasa  " + this.id + " -- \n liczba uczniow: " + this.liczba_uczniow + " || mezczyzni:  " + this.procent_m + " %  || kobiety:  " + this.procent_k + " %  || srednia inteligencja: " + this.srednia_inteligencja + " || srednia sila: " + this.srednia_sila + " " + "\n================================\n";
            return a;

        }
        public void Wyswietl()
        {
            Console.WriteLine("===================================================== Klasa  " + this.id + " ============================================================= ");
            Console.WriteLine("liczba uczniow: " + this.liczba_uczniow + "  ||  mezczyzni:  " + this.procent_m + "%  ||  kobiety:  " + this.procent_k + "%  ||  srednia inteligencja:  " + this.srednia_inteligencja + "  ||  srednia sila:  " + this.srednia_sila + " ");
            Console.WriteLine("============================================================================================================================= ");
            foreach (var uczen in klasa)
            {
                uczen.Wyswietl();
            }
            Console.WriteLine("");

        }

        public double Procent_m()
        {
            double n = 0;
            foreach (var uczen in klasa)
            {
                if (uczen.plec == Plec.mezczyzna)
                {
                    n++;
                    liczba_m++;
                }
            }
            n = Math.Round((n / klasa.Count) * 100, 2);
            this.procent_m = n;
            return n;
        }
        public double Procent_k()
        {
            double n = 0;
            foreach (var uczen in klasa)
            {
                if (uczen.plec == Plec.kobieta)
                {
                    liczba_k++;
                    n++;
                }
            }
            n = Math.Round((n / klasa.Count) * 100, 2);
            this.procent_k = n;
            return n;
        }
        public double SredniaInteligencja()
        {
            double srednia = 0;
            foreach (var uczen in klasa)
            {
                srednia += uczen.inteligencja;
            }
            srednia /= klasa.Count;
            srednia = Math.Round(srednia, 2);
            this.srednia_inteligencja = srednia;
            return srednia;
        }
        public double SredniaSila()
        {
            double srednia = 0;
            foreach (var uczen in klasa)
            {
                srednia += uczen.sila;
            }
            srednia /= klasa.Count;
            srednia = Math.Round(srednia, 2);
            this.srednia_sila = srednia;
            return srednia;
        }
    }

    public class Szkola
    {
        public List<Klasa> szkola = new List<Klasa>();
        public int ilosc_klas;
        public int liczba_uczniow;
        public string nazwa;
        public string id;
        public double srednia_inteligencja;
        public double srednia_sila;
        public double procent_m;
        public double procent_k;

        public void AddKlasa(Klasa dodawana)
        {
            //Dodawanie oznaczenia szkoly do id znajdujacych sie w niej uczniow
            foreach (var uczen in dodawana.klasa)
            {
                uczen.id = this.id + uczen.id;
                uczen.szkola = this.id;
            }
            dodawana.szkola = this.id;
            szkola.Add(dodawana);
            Procent_k();
            Procent_m();
            SredniaInteligencja();
            SredniaSila();
            LiczbaUczniow();

            this.ilosc_klas = szkola.Count;

        }
        public Szkola(string nazwa, string id)
        {
            this.id = id;
            this.nazwa = nazwa;
        }
        public string Wyswietlanie()
        {
            string a = "========" + this.nazwa + "=========\n" + "ilosc klas: " + this.ilosc_klas + "  ||  liczba uczniow: " + this.liczba_uczniow + "  ||  mezczyzni:  " + this.procent_m + "%  ||  kobiety:  " + this.procent_k + "%  ||  srednia inteligencja:  " + this.srednia_inteligencja + "  ||  srednia sila:  " + this.srednia_sila + "\n================================\n";
            return a;
           
        }
        public void Wyswietl()
        {
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("============================" + this.nazwa + "       ========================================================");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("ilosc klas: " + this.ilosc_klas + "  ||  liczba uczniow: " + this.liczba_uczniow + "  ||  mezczyzni:  " + this.procent_m + "%  ||  kobiety:  " + this.procent_k + "%  ||  srednia inteligencja:  " + this.srednia_inteligencja + "  ||  srednia sila:  " + this.srednia_sila);
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("");
            foreach (var klasa in szkola)
            {
                klasa.Wyswietl();
            }

            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

        }
        public double Procent_m()
        {
            double n = 0;
            foreach (var klasa in szkola)
            {
                n += klasa.procent_m;
            }
            n /= szkola.Count;
            n = Math.Round(n, 2);
            this.procent_m = n;
            return n;
        }
        public double Procent_k()
        {
            double n = 0;
            foreach (var klasa in szkola)
            {
                n += klasa.procent_k;
            }
            n /= szkola.Count;
            n = Math.Round(n, 2);
            this.procent_k = n;
            return n;
        }
        public double SredniaInteligencja()
        {
            double srednia = 0;
            foreach (var klasa in szkola)
            {
                srednia += klasa.srednia_inteligencja;
            }
            srednia /= szkola.Count;
            srednia = Math.Round(srednia, 2);
            this.srednia_inteligencja = srednia;
            return srednia;
        }
        public double SredniaSila()
        {
            double srednia = 0;
            foreach (var klasa in szkola)
            {
                srednia += klasa.srednia_sila;
            }
            srednia /= szkola.Count;
            srednia = Math.Round(srednia, 2);
            this.srednia_sila = srednia;
            return srednia;
        }
        public int LiczbaUczniow()
        {
            int n = 0;
            foreach (var klasa in szkola)
            {
                n += klasa.liczba_uczniow;
            }
            this.liczba_uczniow = n;
            return n;
        }
    }
}
